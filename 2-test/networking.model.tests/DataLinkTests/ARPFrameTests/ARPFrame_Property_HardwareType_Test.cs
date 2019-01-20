using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_HardwareType_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00 }, HardwareType.Unknown },
            new Object[] { new Byte[]{ 0x00, 0x01 }, HardwareType.Ethernet },
            new Object[] { new Byte[]{ 0x00, 0x06 }, HardwareType.IEEE802 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, HardwareType expected)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame[0, 2] = input;


            arpFrame.HardwareType.Should().Be(expected);
        }

        [Theory]
        [InlineData(HardwareType.Unknown)]
        [InlineData(HardwareType.Ethernet)]
        [InlineData(HardwareType.IEEE802)]
        public void Set(HardwareType input)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.HardwareType = input;


            arpFrame.HardwareType.Should().Be(input);
        }
    }
}
