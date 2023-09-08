//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ToBeShippedValueCRUD.cs

using System;
using System.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_ToBeShippedValueCRUD
    {
        bool Optional_ModuleForExists();
        void DeclareALTGEN();
        void InsertOptional_Module();
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
        void DeleteTv_ALTGEN(string ALTGEN_SpName);
        void SetIsolationLevel();
        (int? UnitQtyPlaces, string UnitQtyFormat, int? rowCount) LoadUnitQtyFromInvparms(int? UnitQtyPlaces, string UnitQtyFormat);
        (int? CostItemAtWhse, string DefaultWhse, int? rowCount) LoadWhseFromInvparms(int? CostItemAtWhse, string DefaultWhse);
        (string ParmsSite, int? rowCount) LoadParms(string ParmsSite);
        (string CurrparmsCurrCode, string CurrparmsCurrDescription, int? rowCount) LoadCurrparms(string CurrparmsCurrCode, string CurrparmsCurrDescription);
        (int? CoParmsUseAltPriceCalc, int? rowCount) LoadCoparms(int? CoParmsUseAltPriceCalc);
        IRecordStream SelectCo(int pageSize, LoadType loadType, int? pSortByCurrency, int? pTransDomCurr, string pCoType, string pCoStat, string pCoitemStat, string pStartCoNum, string pEndCoNum, string pStartCustNum, string pEndCustNum, DateTime? pStartOrderDate, DateTime? pEndOrderDate, string pStartCustPo, string pEndCustPo, string pStartItem, string pEndItem, string pStartCustItem, string pEndCustItem, DateTime? pStartDueDate, DateTime? pEndDueDate, DateTime? pStartShipDate, DateTime? pEndShipDate, string pStartCurrCode, string pEndCurrCode, string ParmsSite, int? IncludeNull, int? CostItemAtWhse);
        bool ItemForExists(int? Severity, decimal? CoitemCost, decimal? ConvFactor, decimal? TcCprItemCost, string Infobar, string CoitemItem);
        (Guid? TemplcrRowPointer, decimal? TemplcrShipValue, int? rowCount) LoadTv_Templcr(string CoCustNum, string CoLcrNum, Guid? TemplcrRowPointer, decimal? TemplcrShipValue);
        void InsertLcrNontable(string CustLcrCustNum, string CustLcrLcrNum, decimal? TToBeShipped);
        ICollectionLoadResponse SelectReportSetNontable(int? pSortByCurrency, int? seq, int level, int? rptSeq, string CoitemCoNum, DateTime? CoOrderDate, int? CoitemCoLine, int? CoitemCoRelease, string CoitemItem, decimal? CoDisc, decimal? CoitemQtyOrderedConv, decimal? TcQtuQtyInv, decimal? TcCprItemPrice, decimal? CoitemDisc, decimal? TcAmtNetPrice, DateTime? CoitemDueDate, string CoitemStat, string TDesc, decimal? TcQtuQtyShp, decimal? TcQtuQtyRmn, decimal? TcCprItemCost, string CoitemUM, decimal? TcAmtNetCost, string CurrencyCurrCode, string CurrencyDescription, string TErrMsg, int? UnitQtyPlaces, string UnitQtyFormat, string GroupBy);
        void DeclareTempLcr();
        void InsertBookmark(IRecordReadOnly coItem);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ToBeShippedValueSp(string AltExtGenSp, string pCoType, string pCoStat, string pCoitemStat, int? pTransDomCurr, int? pSortByCurrency, string pCreditHold, int? pDispSubTots, string pStartCoNum, string pEndCoNum, string pStartCustNum, string pEndCustNum, DateTime? pStartOrderDate, DateTime? pEndOrderDate, string pStartCustPo, string pEndCustPo, string pStartItem, string pEndItem, string pStartCustItem, string pEndCustItem, DateTime? pStartDueDate, DateTime? pEndDueDate, DateTime? pStartShipDate, DateTime? pEndShipDate, string pStartCurrCode, string pEndCurrCode, int? PrintCost, int? PrintPrice, int? DisplayHeader, string BGSessionId, int? TaskId, string pSite, string BGUser);
    }
}

