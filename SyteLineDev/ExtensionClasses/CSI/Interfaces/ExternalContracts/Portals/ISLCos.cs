using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLCos
    {
        int CalcUpdCOFreightChargeSp(string CoNum, string COShipMethod, ref decimal? COFreightChargeAmt, string CalledByCO, ref string Infobar);

        int CreateCoColSp(string CoCustNum, int? CoCustSeq, DateTime? CoOrderDate, string CoWhse, byte? CoConsignment, string ColItem, string ColUM, decimal? ColQtyOrdered, string CoType, string CoShipFromSite, decimal? ItemPriceConv, decimal? ItemPrice, string PortalUsername, DateTime? ColProjectedDate, DateTime? ColDueDate, DateTime? ColPromiseDate, ref Guid? CoRowPointer, ref string Infobar);

        int PortalOrderTotalsCalculationSp(Guid? CoRowPointer, byte? ResellerPortalFlag, string ResellerCustNum, ref decimal? SubTotal, ref decimal? SalesTax, ref decimal? ShippingCost, ref int? ItemCnt, ref decimal? CommissionAmountTotal, ref string CoNum, ref string Infobar);

        int SubmitOrderConfirmationSp(string CoNum, string Username);

        int UpdateCoShipToSp(Guid? RowPointer, int? CustSeq, ref string Infobar);

        int CpSoSp(string CopyFromCoType, string CopyToCoType, string CopyFromCoNum, string CopyToCoNum, short? pCpOrdStart, short? pCpOrdEnd, string pCopyChoice, byte? HasCfg, string CurWhse, byte? pRecalcDueDate, ref string Infobar, byte? CalledFromEcomm);
    }
}
