﻿using ProtoBuf;
using Pulsar.Common.Enums;
using Pulsar.Common.Messages.Other;

namespace Pulsar.Common.Messages.Monitoring.HVNC
{
    [ProtoContract]
    public class GetHVNCDesktop : IMessage
    {
        [ProtoMember(1)]
        public bool CreateNew { get; set; }

        [ProtoMember(2)]
        public int Quality { get; set; }

        [ProtoMember(3)]
        public int DisplayIndex { get; set; }

        [ProtoMember(4)]
        public RemoteDesktopStatus Status { get; set; }

        [ProtoMember(5)]
        public bool UseGPU { get; set; }

        [ProtoMember(6)]
        public int FramesRequested { get; set; } = 1;

        [ProtoMember(7)]
        public bool IsBufferedMode { get; set; } = true;
    }
}
