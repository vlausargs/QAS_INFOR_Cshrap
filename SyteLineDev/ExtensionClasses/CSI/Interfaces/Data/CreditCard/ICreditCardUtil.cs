using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CreditCard
{
    public interface ICreditCardUtil
    {
        int CCIWebSession(string GatewayVendId, string GatewayEncryptionKey
                                        , ref string SessionData, ref string SessionDataPost
                                        , ref string sInfobar, ref byte iSuccess);

        int WebPaySiteVerify(string GatewayEncryptionKey, string GatewayAPIKey,string Email, decimal? TotalAmt, string AuthType, string CustNum, out string VerifyingPost, out string Infobar);
        bool EncryptValue(string Password, out string EncryptedPassword, out string Infobar);
    }
}
