using System.Net;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public interface IFraudPreventionHeadersGenerator
    {
        void GenerateFraudPreventionHeaders(
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
            string macAddresses);
    }
}