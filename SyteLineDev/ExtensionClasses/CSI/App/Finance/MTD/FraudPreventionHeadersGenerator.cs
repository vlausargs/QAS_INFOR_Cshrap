using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using CSI.Data;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public class FraudPreventionHeadersGenerator : IFraudPreventionHeadersGenerator
    {
        private readonly ICSIRequester _csiRequester;
        private readonly IMsgApp _iMsgApp;

        #region constant for this class

        private static readonly string WEB_CONNECTION_METHOD = @"WEB_APP_VIA_SERVER";
        private static readonly string DESKTOP_CONNECTION_METHOD = @"DESKTOP_APP_VIA_SERVER";

        #endregion

        public FraudPreventionHeadersGenerator(ICSIRequester csiRequester, IMsgApp msgApp)
        {
            _csiRequester = csiRequester;
            _iMsgApp = msgApp;
        }

        public void GenerateFraudPreventionHeaders(
            ICSIHttpWebRequest webRequest,
            bool isWeb,
            string accessToken,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string userIds,
            string windowSize,
            string licenseIds,
            string productName,
            string vendorVersion,
            string doNotTrack,
            string userAgent,
            string plugins,
            string macAddresses)
        {
            // If it is Sandbox mode, Give a fixed Scenario header to ensure the api results won't be 404 Not Found.
            if (webRequest.RequestUri.ToString().Contains("test"))
            {
                if (webRequest.RequestUri.ToString().Contains("liabilities"))
                {
                    webRequest.Headers.Add($@"Gov-Test-Scenario: SINGLE_LIABILITY");
                }
                else if (webRequest.RequestUri.ToString().Contains("payments"))
                {
                    webRequest.Headers.Add($@"Gov-Test-Scenario: SINGLE_PAYMENT");
                }
            }

            // Check All Platform Application required Params up
            // If those params are null or empty, throw an SecurityException
            if (string.IsNullOrWhiteSpace(CheckStringValue(publicIp)) || string.IsNullOrWhiteSpace(CheckStringValue(publicPort)) ||
                string.IsNullOrWhiteSpace(CheckStringValue(localIps)) || string.IsNullOrWhiteSpace(CheckStringValue(licenseIds)) ||
                string.IsNullOrWhiteSpace(CheckStringValue(windowSize)) ||
                string.IsNullOrWhiteSpace(CheckStringValue(screens)) || string.IsNullOrWhiteSpace(CheckStringValue(deviceId)))
            {
                var (_, infobar) = _iMsgApp.MsgAppSp(string.Empty, "E=RequestHMRCServiceError");
                throw new System.Security.SecurityException(infobar);
            }

            // 1024 - 65535
            var rgxForPublicPort = new Regex(@"^(?:102[4-9]|10[3-9]\d|1[1-9]\d{2}|[2-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$");
            if (!rgxForPublicPort.IsMatch(publicPort))
            {
                var (_, infobar) = _iMsgApp.MsgAppSp(string.Empty, "E=RequestHMRCServiceError");
                throw new System.Security.SecurityException(infobar);
            }

            if (!isWeb)
            {
                // Check Desktop application required Params up
                // If those params are null or empty, throw an SecurityException
                if (string.IsNullOrWhiteSpace(userAgent) || string.IsNullOrWhiteSpace(macAddresses))
                {
                    var (_, infobar) = _iMsgApp.MsgAppSp(string.Empty, "E=RequestHMRCServiceError");
                    throw new System.Security.SecurityException(infobar);
                }

                webRequest.Headers.Add($@"Gov-Client-Connection-Method: {DESKTOP_CONNECTION_METHOD}");
                webRequest.Headers.Add($@"Gov-Client-MAC-Addresses: {macAddresses}");
                webRequest.Headers.Add($@"Gov-Client-User-Agent: {userAgent}");
            }
            else
            {
                webRequest.Headers.Add($@"Gov-Client-Connection-Method: {WEB_CONNECTION_METHOD}");
                webRequest.Headers.Add($@"Gov-Client-Browser-Do-Not-Track: {doNotTrack}");
                webRequest.Headers.Add($@"Gov-Client-Browser-JS-User-Agent: {userAgent}");
                webRequest.Headers.Add($@"Gov-Client-Browser-Plugins: {plugins}");
            }

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                // OAuth 2.0 Get Authorization Code and Refresh Token don't need AccessToken 
                webRequest.Headers.Add($@"Authorization: Bearer {accessToken}");
            }

            var vendorPublicIp = GetVendorPublicIp();

            // Decode to check for ip format.
            vendorPublicIp = Uri.UnescapeDataString(vendorPublicIp);
            publicIp = Uri.UnescapeDataString(publicIp);

            // Use IPAddress.TryParse to Check Ip Format. IPv4 & IPv6 both are okay!
            if (!IPAddress.TryParse(vendorPublicIp, out _) ||
                !IPAddress.TryParse(publicIp, out _))
            {
                var (_, infobar) = _iMsgApp.MsgAppSp(string.Empty, "E=RequestHMRCServiceError");
                throw new System.Security.SecurityException(infobar);
            }

            // Encode to make a request
            vendorPublicIp = Uri.EscapeDataString(vendorPublicIp);
            publicIp = Uri.EscapeDataString(publicIp);

            webRequest.Headers.Add($@"Gov-Client-Device-ID: {deviceId}");
            webRequest.Headers.Add($@"Gov-Client-Local-IPs: {localIps}");
            webRequest.Headers.Add($@"Gov-Client-Local-IPs-Timestamp: {localIpsTimestamp}");
            webRequest.Headers.Add($@"Gov-Client-Multi-Factor: {string.Empty}");
            webRequest.Headers.Add($@"Gov-Client-Public-IP: {publicIp}");
            webRequest.Headers.Add($@"Gov-Client-Public-IP-Timestamp: {publicIpTimestamp}");
            webRequest.Headers.Add($@"Gov-Client-Public-Port: {publicPort}");
            webRequest.Headers.Add($@"Gov-Client-Screens: {screens}");
            webRequest.Headers.Add($@"Gov-Client-Timezone: {timeZone}");
            webRequest.Headers.Add($@"Gov-Client-User-IDs: {userIds}");
            webRequest.Headers.Add($@"Gov-Client-Window-Size: {windowSize}");
            // The by field must be the public IP address that the server received the request on
            // The for field must be the public IP address of the request sender. For the first hop, this is the public IP address of the client. For subsequent hops, it is the public IP address of the intermediate server.
            webRequest.Headers.Add($@"Gov-Vendor-Forwarded: by={vendorPublicIp}&for={publicIp}");
            webRequest.Headers.Add($@"Gov-Vendor-License-IDs: {licenseIds}");
            webRequest.Headers.Add($@"Gov-Vendor-Product-Name: {productName}");
            webRequest.Headers.Add($@"Gov-Vendor-Public-IP: {vendorPublicIp}");
            webRequest.Headers.Add($@"Gov-Vendor-Version: {vendorVersion}");
        }

        /// <summary>
        /// Get server public ip
        /// </summary>
        /// <returns></returns>
        private string GetVendorPublicIp()
        {
            var vendorPublicIp = string.Empty;

            try
            {
                var requestToIfconfigMe = _csiRequester.Create("https://ifconfig.me/ip", "GET", "", "");
                requestToIfconfigMe.UserAgent = "curl";

                using (var response = _csiRequester.Call(requestToIfconfigMe, string.Empty))
                {
                    using (var reader = new StreamReader(response.GetResponseStream() ??
                                                         throw new InvalidOperationException(
                                                             "Failed to curl ifconfig.me/ip!")))
                    {
                        vendorPublicIp = reader.ReadToEnd().Trim();
                        if (string.IsNullOrWhiteSpace(vendorPublicIp))
                        {
                            throw new Exception("Failed to curl ifconfig.me/ip!");
                        }
                    }
                }
            }
            catch
            {
                // If ifconfig.me/ip failed, try to request to ifconfig.io.
                // Don't throw any exception caught, return string.Empty.
                // Nested try-catch in catch block, not pretty, but there is no alternatives.
                if (string.IsNullOrWhiteSpace(vendorPublicIp))
                {
                    try
                    {
                        var requestToIfconfigIo = _csiRequester.Create("https://ifconfig.io/ip", "GET", "", "");
                        requestToIfconfigIo.UserAgent = "curl";

                        using (var response = _csiRequester.Call(requestToIfconfigIo, string.Empty))
                        {
                            using (var reader = new StreamReader(response.GetResponseStream() ??
                                                                 throw new InvalidOperationException(
                                                                     "Failed to curl ifconfig.io/ip!")))
                            {
                                vendorPublicIp = reader.ReadToEnd().Trim();
                            }
                        }
                    }
                    catch
                    {
                        vendorPublicIp = string.Empty;
                    }
                }
            }

            return vendorPublicIp;
        }

        private string CheckStringValue(string value)
        {
            return value == "undefined" || value == null || value == "null" ? string.Empty : value;
        }
    }
}