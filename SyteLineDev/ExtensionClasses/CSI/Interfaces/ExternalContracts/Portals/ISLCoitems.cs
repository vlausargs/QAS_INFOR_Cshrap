using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLCoitems
    {
        int ValidateInternationalOrderSp(string CoNum, string PaymentMethod, string ShipMethod, ref string Infobar); 

        int PortalQuoteTaxEstimationSp(string CustNum, string CoNum, string CoLineList, string CustSeqList, decimal? Freight, ref decimal? CoSalesTax, ref decimal? CoSalesTax2, ref string Infobar);

        int UpdateCoitemSp(short? CoLine, decimal? QtyOrderedConv, decimal? PriceConv, int? CustSeq, ref string Infobar, ref byte? CoAlreadyPlaced, ref byte? EstAlreadyConverted, ref Guid? CoRowPointer, string CoNum, string CustNum, string CoType, DateTime? CoitemProjectedDate, DateTime? CoitemDueDate, DateTime? CoitemPromiseDate, string CoitemUM);
    }
}
