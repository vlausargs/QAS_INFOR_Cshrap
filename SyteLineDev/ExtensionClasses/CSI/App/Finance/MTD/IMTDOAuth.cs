using System.Net;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public interface IMTDOAuth
    {
        ICSIWebResponse RefreshToken(
            string apiUrl,
            bool isWeb,
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
            string macAddresses,
            string clientId,
            string clientSecret,
            string refreshToken);

        ICSIWebResponse ExchangeAuthorizationCodeForAccessToken(
            string apiUrl,
            bool isWeb,
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
            string macAddresses,
            string code,
            string clientId,
            string clientSecret,
            string scope,
            string redirectUri);
    }
}