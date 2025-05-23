﻿using ProtoBuf;
using Pulsar.Common.Messages.Other;

namespace Pulsar.Common.Messages.Administration.RegistryEditor
{
    [ProtoContract]
    public class DoDeleteRegistryKey : IMessage
    {
        [ProtoMember(1)]
        public string ParentPath { get; set; }

        [ProtoMember(2)]
        public string KeyName { get; set; }
    }
}
