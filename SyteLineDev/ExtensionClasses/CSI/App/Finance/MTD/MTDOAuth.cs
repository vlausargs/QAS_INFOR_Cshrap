using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public class MTDOAuth : IMTDOAuth
    {
        private readonly ICSIRequester _csiRequester;
        private readonly IFraudPreventionHeadersGenerator _fraudPreventionHeadersGenerator;
        private readonly IMTDAPIFailedMessage _mtdAPIFailedMessage;

        #region constant for this class

        private readonly string CONTENT_TYPE = @"application/x-www-form-urlencoded";
        private readonly string POST = @"POST";
        private readonly string ACCEPT = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        private readonly string AUTHORIZATION_CODE = @"authorization_code";
        private readonly string REFRESH_TOKEN = @"refresh_token";

        #endregion

        public MTDOAuth(ICSIRequester csiRequester, IFraudPreventionHeadersGenerator fraudPreventionHeadersGenerator, IMTDAPIFailedMessage mtdAPIFailedMessage)
        {
            _csiRequester = csiRequester;
            _fraudPreventionHeadersGenerator = fraudPreventionHeadersGenerator;
            _mtdAPIFailedMessage = mtdAPIFailedMessage;
        }

        public ICSIWebResponse RefreshToken(
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
            string refreshToken)
        {
            try
            {
                var refreshTokenRequestUri =
                    $@"{apiUrl}/oauth/token";

                //grant_type
                var refreshTokenRequestBody =
                    $"client_secret={clientSecret}&client_id={clientId}&refresh_token={refreshToken}&grant_type={REFRESH_TOKEN}";
                // sends the request
                var refreshTokenRequest = _csiRequester.Create(refreshTokenRequestUri, POST, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(refreshTokenRequest, isWeb, string.Empty, deviceId,
                    localIps, localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(refreshTokenRequest, refreshTokenRequestBody);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }

        public ICSIWebResponse ExchangeAuthorizationCodeForAccessToken(
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
            string redirectUri)
        {
            try
            {
                var exchangeCodeRequestUri =
                    $@"{apiUrl}/oauth/token";

                //grant_type
                var exchangeCodeRequestBody =
                    $"client_secret={clientSecret}&client_id={clientId}&code={code}&scope={scope}&redirect_uri={redirectUri}&grant_type={AUTHORIZATION_CODE}";
                // sends the request
                var exchangeCodeRequest = _csiRequester.Create(exchangeCodeRequestUri, POST, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(exchangeCodeRequest, isWeb, string.Empty, deviceId,
                    localIps, localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(exchangeCodeRequest, exchangeCodeRequestBody);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }
    }
}