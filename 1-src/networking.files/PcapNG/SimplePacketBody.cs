using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Simple Packet Body
    /// <see href="https://pcapng.github.io/pcapng/#section_spb"/>
    /// </summary>
    public partial class SimplePacketBody : BlockBody, IPacket
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SimplePacketBody() : base(isPacket: true)
        {

        }

        /// <summary>
        /// 原始长度
        /// </summary>
        public UInt32 OriginalLength
        {
            get { return GetUInt32(Layout.OriginalLengthBegin); }
        }

        /// <summary>
        /// <see cref="IPacket.Type"/>
        /// </summary>
        public DataLinkType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// <see cref="IPacket.TimestampNanosecond"/>
        /// </summary>
        public UInt64 TimestampNanosecond
        {
            get { return 0; }
        }

        /// <summary>
        /// <see cref="IPacket.Payload"/>
        /// </summary>
        public Memory<Byte> Payload
        {
            get { return GetBytes(Layout.HeaderLength); }
        }
    }
}
