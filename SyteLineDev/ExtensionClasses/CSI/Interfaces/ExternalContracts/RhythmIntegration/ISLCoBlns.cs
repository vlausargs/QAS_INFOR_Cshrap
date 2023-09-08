
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.RhythmIntegration
{
    public interface ISLCoBlns
    {
        
        int GetCoitemLinePriceNoCONumSp(string PCustomerNum,
                                        string CoitemItem,
                                        string PAtlItemUM,
                                        string PShipSite,
                                        DateTime? POrderDate,
                                        ref decimal? CoitemDisc,
                                        decimal? CoitemQtyOrdered,
                                        string CustCurCode,
                                        string ItemPriceCode,
                                        ref decimal? CoitemLinePrice,
                                        ref string Infobar,
                                        ref decimal? LineTaxAmount,
                                        ref decimal? CoitemPrice,
                                        ref int? CurrencyPlaces,
                                        Guid? CoitemRowPointer,
                                        ref string TaxAmountLabel,
                                        ref string SiteLanguageID);
    }
}
