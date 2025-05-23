﻿using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Pulsar.Client.Helper
{
    public class WebcamHelper
    {
        private readonly object _lock = new object();
        private Bitmap _currentFrame;
        private bool _isRunning = false;
        private VideoCaptureDevice _videoDevice;
        private int _width;
        private int _height;

        public void StartWebcam(int webcamIndex)
        {
            try
            {
                if (_isRunning) return;

                FilterInfoCollection captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (captureDevices.Count == 0)
                {
                    Debug.WriteLine("No webcam detected.");
                    return;
                }

                if (webcamIndex < 0 || webcamIndex >= captureDevices.Count)
                {
                    Debug.WriteLine("Invalid selection.");
                    return;
                }

                _videoDevice = new VideoCaptureDevice(captureDevices[webcamIndex].MonikerString);
                _videoDevice.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                _videoDevice.VideoSourceError += VideoDevice_VideoSourceError;
                _videoDevice.Start();
                _isRunning = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting webcam: {ex.Message}");
            }
        }

        public string[] GetWebcams()
        {
            try
            {
                FilterInfoCollection captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                string[] webcams = new string[captureDevices.Count];
                for (int i = 0; i < captureDevices.Count; i++)
                {
                    webcams[i] = captureDevices[i].Name;
                }
                return webcams;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting webcams: {ex.Message}");
                return new string[0];
            }
        }

        public void StopWebcam()
        {
            if (!_isRunning) return;

            try
            {
                _videoDevice.SignalToStop();
                _videoDevice.WaitForStop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping webcam: {ex.Message}");
            }
            finally
            {
                if (_videoDevice != null)
                {
                    _videoDevice.NewFrame -= FinalFrame_NewFrame;
                    _videoDevice.VideoSourceError -= VideoDevice_VideoSourceError;
                    _videoDevice = null;
                }
                _isRunning = false;
            }
        }

        public Bitmap GetLatestFrame()
        {
            lock (_lock)
            {
                try
                {
                    Thread.Sleep(22);
                    return _currentFrame?.Clone() as Bitmap;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting latest frame: {ex.Message}");
                    return null;
                }
            }
        }

        public Bounds GetBounds()
        {
            lock (_lock)
            {
                try
                {
                    return new Bounds { Width = _width, Height = _height };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting bounds: {ex.Message}");
                    return new Bounds { Width = 0, Height = 0 };
                }
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            lock (_lock)
            {
                try
                {
                    _currentFrame?.Dispose();
                    _currentFrame = (Bitmap)eventArgs.Frame.Clone();
                    _width = _currentFrame.Width;
                    _height = _currentFrame.Height;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing new frame: {ex.Message}");
                }
            }
        }

        private void VideoDevice_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            var desc = eventArgs.Description ?? string.Empty;
            if (desc.IndexOf("0x80004002", StringComparison.OrdinalIgnoreCase) >= 0 ||
                desc.IndexOf("Interface not supported", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Debug.WriteLine("Webcam does not support required video control interface; ignoring.");
            }
            else
            {
                Debug.WriteLine($"Video source error: {desc}");
            }
        }
    }

    public struct Bounds
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
