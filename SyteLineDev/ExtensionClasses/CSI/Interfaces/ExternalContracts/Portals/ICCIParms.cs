using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ICCIParms
    {
        int Portal_SSSCCIParmsInfoSp(string CardSystemId,
                                            ref string UserName,
                                            ref string Password,
                                            ref string PaymentSvr,
                                            ref byte? AutoPostOpenPayment,
                                            ref string CardSystem,
                                            ref byte? PurchaseAuth,
                                            ref string GatewayVendID,
                                            ref string DBName,
                                            ref string ServerName,
                                            ref string CurrCode,
                                            ref string GatewayEncryptionKey);
    }
}
