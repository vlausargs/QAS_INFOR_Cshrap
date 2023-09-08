using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.Portals
{
    public interface ICCITrans
    {
        int CCIWebSessionCenPOSSp(string GatewayVendId, string GatewayEncryptionKey
                                          , ref string SessionData, ref string SessionDataPost
                                          , ref string sInfobar, ref byte iSuccess);

        int Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp(string CustNum, string RefType, string RefNum, ref string CardSystemId);

        int Portal_CCICalcBal_1_ForOrderCurrSp(string CustNum, string CardSystemId, string RefType, string RefNum, decimal? OrderAmt, decimal? OrderExchRate, ref decimal? Balance, ref decimal? PayExchRate, ref decimal? BankAmt, ref decimal? BankExchRate, ref string Infobar);

        int Portal_CCILogCardSp(string CardNum, string CardSystem, string CustNum, int? CustSeq, string expDate, string NameOnCard, decimal? GatewayTransNum, string CardType, string Username, string CardSystemId);

        int Portal_SSSCCIARPayFromTransSp(Guid? CCIRowPointer, ref string Infobar);

        int Portal_SSSCCICoBalSp(string CoNum, ref decimal? Balance, ref decimal? TaxAmt, ref decimal? ExchRate, ref decimal? ForAmt, ref int? CustSeq, ref string Infobar, string AuthType, string ShipMethod);

        int SSSCCIArInvBalSp(string InvNum, string CustNum, ref string TransType, ref decimal? Balance, ref decimal? TaxAmt, ref decimal? ExchRate, ref decimal? ForAmt, ref int? CustSeq, ref string Infobar);

        int SSSCCICoBalSp(string CoNum, ref decimal? Balance, ref decimal? TaxAmt, ref decimal? ExchRate, ref decimal? ForAmt, ref int? CustSeq, ref string Infobar, string AuthType, string ShipMethod);

        int SSSCCIPayOpenNextSp(ref int? NextOpenNum);

        int Portal_SSSCCIProcessCardWrapSp(string TransType, string cardNum, string expDate, string NameOnCard, string StreetAddress,
            string City, string State, string Zip, string CVNum, string CustNum, int? CustSeq, string RefType, string OrdInvNum,
            decimal? ForAmt, decimal? ExchRate, decimal? TotalAmt, decimal? TaxAmt, ref string cardType, ref string authCode,
            ref decimal? GatewayTransNum, ref string Infobar, ref byte? iSuccess, byte? AutoPostOpenPayment,
            byte? StoreCard, string CustRef, string Username, string CardSystemId, decimal? DomAmt, decimal? PayExchRate,
            byte[] Signature);

    }
}
