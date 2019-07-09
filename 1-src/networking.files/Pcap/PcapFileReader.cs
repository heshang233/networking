using System;
using System.Collections.Generic;
using System.IO;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// *.pcap文件
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// <see href="https://wiki.wireshark.org/SampleCaptures"/>
    /// </summary>
    public class PcapFileReader : PacketReader
    {
        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader Header { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFileReader(String filePath) : base(filePath)
        {
            ReadFileHeader();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFileReader(Stream stream) : base(stream)
        {
            ReadFileHeader();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFileReader(Byte[] bytes) : base(bytes)
        {
            ReadFileHeader();
        }

        /// <summary>
        /// 读取所有数据包
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<IPacket> ReadPackets()
        {
            var packet = ReadPacket();
            while (packet != null)
            {
                yield return packet;
                packet = ReadPacket();
            }
        }

        private void ReadFileHeader()
        {
            var headerBytes = base.ReadBytes(PcapFileHeader.Layout.HeaderLength);
            Header = new PcapFileHeader(headerBytes);
        }

        private PcapPacket ReadPacket()
        {
            var packetHeader = ReadPacketHeader();
            if (packetHeader == null)
            {
                return null;
            }

            var packetPayloadBytes = ReadPacketPayload(packetHeader);
            if (packetPayloadBytes.Length == 0)
            {
                return null;
            }

            return new PcapPacket(packetHeader, packetPayloadBytes);
        }

        private PcapPacketHeader ReadPacketHeader()
        {
            var packetHeaderBytes = base.ReadBytes(PcapPacketHeader.Layout.HeaderLength);
            if (packetHeaderBytes.Length == 0)
            {
                return null;
            }

            return new PcapPacketHeader
            {
                Header = Header,
                Bytes = packetHeaderBytes
            };
        }

        private Byte[] ReadPacketPayload(PcapPacketHeader packetHeader)
        {
            var packetPayloadLength = (Int32)packetHeader.CapturedLength;
            return base.ReadBytes(packetPayloadLength);
        }
    }
}