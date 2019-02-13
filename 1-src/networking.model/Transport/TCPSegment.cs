using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 传输控制协议
    /// <see href="https://en.wikipedia.org/wiki/transmission_control_protocol"/>
    /// </summary>
    public partial class TCPSegment : TransportPDU
    {
        /// <summary>
        /// 源端口
        /// </summary>
        public UInt16 SourcePort
        {
            get
            {
                return ReadUInt16(Layout.SourcePortBegin);
            }
            set
            {
                WriteUInt16(Layout.SourcePortBegin, value);
            }
        }

        /// <summary>
        /// 目标端口
        /// </summary>
        public UInt16 DestinationPort
        {
            get
            {
                return ReadUInt16(Layout.DestinationPortBegin);
            }
            set
            {
                WriteUInt16(Layout.DestinationPortBegin, value);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt32 SYNNumber
        {
            get
            {
                return ReadUInt32(Layout.SYNNumberBegin);
            }
            set
            {
                WriteUInt32(Layout.SYNNumberBegin, value);
            }
        }

        /// <summary>
        /// 确认号
        /// </summary>
        public UInt32 ACKNumber
        {
            get
            {
                return ReadUInt32(Layout.ACKNumberBegin);
            }
            set
            {
                WriteUInt32(Layout.ACKNumberBegin, value);
            }
        }

        /// <summary>
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return (Byte)(base[Layout.HeaderLengthBegin] >> 4); }
            set
            {
                var old = base[Layout.HeaderLengthBegin];
                base[Layout.HeaderLengthBegin] = (Byte)(((Byte)value) << 4 | old & 0x0F);
            }
        }

        /// <summary>
        /// ECN-nonce
        /// </summary>
        public Boolean NS
        {
            get { return (base[Layout.HeaderLengthBegin] & 0b_0000_0001) == 0b_0000_0001; }
        }

        /// <summary>
        /// Congestion Window Reduced
        /// </summary>
        public Boolean CWR
        {
            get { return (base[Layout.FlagsBegin] & 0b_1000_0000) == 0b_1000_0000; }
        }

        /// <summary>
        /// ECE-Echo
        /// </summary>
        public Boolean ECE
        {
            get { return (base[Layout.FlagsBegin] & 0b_0100_0000) == 0b_0100_0000; }
        }

        /// <summary>
        /// Urgent pointer
        /// </summary>
        public Boolean URG
        {
            get { return (base[Layout.FlagsBegin] & 0b_0010_0000) == 0b_0010_0000; }
        }

        /// <summary>
        /// Acknowledgment
        /// </summary>
        public Boolean ACK
        {
            get { return (base[Layout.FlagsBegin] & 0b_0001_0000) == 0b_0001_0000; }
        }

        /// <summary>
        /// Push function
        /// </summary>
        public Boolean PSH
        {
            get { return (base[Layout.FlagsBegin] & 0b_0000_1000) == 0b_0000_1000; }
        }

        /// <summary>
        /// Reset the connection
        /// </summary>
        public Boolean RST
        {
            get { return (base[Layout.FlagsBegin] & 0b_0000_0100) == 0b_0000_0100; }
        }

        /// <summary>
        /// Synchronize sequence number
        /// </summary>
        public Boolean SYN
        {
            get { return (base[Layout.FlagsBegin] & 0b_0000_0010) == 0b_0000_0010; }
        }

        /// <summary>
        /// Last packet from sender
        /// </summary>
        public Boolean FIN
        {
            get { return (base[Layout.FlagsBegin] & 0b_0000_0001) == 0b_0000_0001; }
        }

        /// <summary>
        /// 窗口大小
        /// </summary>
        public UInt16 WindowsSize
        {
            get
            {
                return ReadUInt16(Layout.WindowsSizeBegin);
            }
            set
            {
                WriteUInt16(Layout.WindowsSizeBegin, value);
            }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get
            {
                return ReadUInt16(Layout.ChecksumBegin);
            }
            set
            {
                WriteUInt16(Layout.ChecksumBegin, value);
            }
        }

        /// <summary>
        /// 紧急指针
        /// </summary>
        public UInt16 UrgentPointer
        {
            get
            {
                return ReadUInt16(Layout.UrgentPointerBegin);
            }
            set
            {
                WriteUInt16(Layout.UrgentPointerBegin, value);
            }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                return new Octets
                {
                    Bytes = Slice(HeaderLength * 4)
                };

            }
        }
    }
}
