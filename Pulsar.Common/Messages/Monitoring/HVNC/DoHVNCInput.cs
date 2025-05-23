﻿using System;
using ProtoBuf;
using Pulsar.Common.Messages.Other;

namespace Pulsar.Common.Messages.Monitoring.HVNC
{
    [ProtoContract]
    public class DoHVNCInput : IMessage
    {
        [ProtoMember(1)]
        public uint msg { get; set; }

        [ProtoMember(2)]
        public int wParam { get; set; }

        [ProtoMember(3)]
        public int lParam { get; set; }
    }
}