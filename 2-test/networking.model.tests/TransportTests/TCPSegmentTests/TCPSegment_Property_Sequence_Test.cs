using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_Sequence_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment[4, 4] = new Byte[] { 0x01, 0x23, 0x45, 0x67 };

            tcpSegment.Sequence.Should().Be(19088743);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.Sequence = 19088743;

            tcpSegment.Sequence.Should().Be(19088743);
            tcpSegment[4, 4].ToArray().Should().Equal(0x01, 0x23, 0x45, 0x67);
        }
    }
}