// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.Azure.Devices.Edge.Hub.Amqp.Test
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Devices.Edge.Hub.Amqp.Settings;
    using Microsoft.Azure.Devices.Edge.Util.Test.Common;
    using Xunit;

    public class DefaultTransportSettingsTest
    {
        [Fact]
        [Unit]
        public void TestInvalidConstructorInputs()
        {
            const string Scheme = "amqps";
            const string HostName = "restaurantatendofuniverse.azure-devices.net";
            const int Port = 5671;
            X509Certificate2 tlsCertificate = CertificateHelper.GenerateSelfSignedCert("TestCert");
            const bool clientCertsAllowed = true;

            Assert.Throws<ArgumentException>(() => new DefaultTransportSettings(null, HostName, Port, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentException>(() => new DefaultTransportSettings("", HostName, Port, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentException>(() => new DefaultTransportSettings("    ", HostName, Port, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentException>(() => new DefaultTransportSettings(Scheme, null, Port, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentException>(() => new DefaultTransportSettings(Scheme, "", Port, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentException>(() => new DefaultTransportSettings(Scheme, "   ", Port, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DefaultTransportSettings(Scheme, HostName, -1, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DefaultTransportSettings(Scheme, HostName, 70000, tlsCertificate, clientCertsAllowed));
            Assert.Throws<ArgumentNullException>(() => new DefaultTransportSettings(Scheme, HostName, Port, null, clientCertsAllowed));
            Assert.NotNull(new DefaultTransportSettings(Scheme, HostName, Port, tlsCertificate, clientCertsAllowed));
            Assert.NotNull(new DefaultTransportSettings(Scheme, HostName, Port, tlsCertificate, !clientCertsAllowed));
        }
    }
}
