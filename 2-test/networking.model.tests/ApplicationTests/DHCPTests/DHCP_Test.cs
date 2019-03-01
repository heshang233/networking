using System;
using FluentAssertions;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Test
    {
        [Fact]
        public void discover()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[]
                {
                    0x01,
                    0x01,
                    0x06,
                    0x00,
                    0x00, 0x00, 0x3d, 0x1d,
                    0x12, 0x34,
                    0x56, 0x78,
                    0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00,
                    0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,

                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,

                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,

                    0x63, 0x82, 0x53, 0x63, 0x35, 0x01, 0x01, 0x3d, 0x07, 0x01, 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42,
                    0x32, 0x04, 0x00, 0x00, 0x00, 0x00, 0x37, 0x04, 0x01, 0x03, 0x06, 0x2a, 0xff, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00
                }
            };


            dhcp.OperationCode.Should().Be(1);
            dhcp.HardwareType.Should().Be(1);
            dhcp.HardwareLength.Should().Be(6);
            dhcp.TransactionId.Should().Be(0x00003d1d);
            dhcp.Seconds.Should().Be(0x1234);
            dhcp.Flags.Should().Be(0x5678);
            dhcp.ClientIPAddress.ToString().Should().Be("0.0.0.0");
            dhcp.YourClientIPAddress.ToString().Should().Be("0.0.0.0");
            dhcp.ServerIPAddress.ToString().Should().Be("0.0.0.0");
            dhcp.GatewayIPAddress.ToString().Should().Be("0.0.0.0");
            dhcp.ClientHardwareAddress.ToString().Should().Be("00:0B:82:01:FC:42");
        }
    }
}
