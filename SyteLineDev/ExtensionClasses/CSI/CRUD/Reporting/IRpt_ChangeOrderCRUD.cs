//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ChangeOrderCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ChangeOrderCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string TaxCodeLabel, string TaxAmtLabel, int? TaxSystem1_ActiveForPurch, int? rowCount) Tax_SystemLoad(int? TaxSystem1_ActiveForPurch, string TaxCodeLabel, string TaxAmtLabel);
		(string TaxCode2Label, string TaxAmt2Label, int? TaxSystem2_ActiveForPurch, int? rowCount) Tax_System1Load(int? TaxSystem2_ActiveForPurch, string TaxCode2Label, string TaxAmt2Label);
		(string ParmsSite, int? PrintCompanyName, string ParmsURL, int? rowCount) ParmsLoad(string ParmsSite, int? PrintCompanyName, string ParmsURL);
		(int? ECurrencyPlaces, string ECurrencySymbol, int? rowCount) Currencyase_CurrencyLoad(string TEuroCurr, int? ECurrencyPlaces, string ECurrencySymbol);
		(string CurrparmsCurrCode, int? rowCount) CurrparmsLoad(string CurrparmsCurrCode);
		(int? PoparmsVendorRequired, string PoparmsPoText1, string PoparmsPoText2, string PoparmsPoText3, int? rowCount) PoparmsLoad(int? PoparmsVendorRequired, string PoparmsPoText1, string PoparmsPoText2, string PoparmsPoText3);
		(string OfficeEmailAddrFooter, int? rowCount) ArparmsLoad(string OfficeEmailAddrFooter);
		ICollectionLoadResponse PoSelect(string pPoType, string pPoStat, string pStartPoNum, string pEndPoNum, string pStartvendor, string pEndVendor, string TStartVendor, string TEndVendor, int? pStartPoRElease, int? pEndPoRelease, int? pStartPoLine, string pPoitemStat, int? pEndPoLine, int? pTransDomCurr, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, string CurrparmsCurrCode);
		(string MessageLanguage, int? rowCount) LanguageidsLoad(string VendorLangCode, string MessageLanguage);
		(int? UseAlternateAddressReportFormat, int? rowCount) CountryLoad(int? UseAlternateAddressReportFormat);
		(int? UseAlternateAddressReportFormat, int? rowCount) Parms1Load(int? UseAlternateAddressReportFormat);
		(Guid? PochangeRowpointer,
			 string PochangeStat,
			 int? PochangeNoteexistsflag,
			 int? PochangeChgNum,
			 DateTime? PochangeChgDate, int? rowCount) PochangeLoad(string PoPoNum, Guid? PochangeRowpointer, string PochangeStat, int? PochangeNoteexistsflag, int? PochangeChgNum, DateTime? PochangeChgDate);
		(Guid? XVendorRowpointer, string XVendorVendNum, int? rowCount) Vendorasx_VendorLoad(string TVendRemit, Guid? XVendorRowpointer, string XVendorVendNum);
		(string XVendaddrVendNum, int? rowCount) Vendaddrasx_VendaddrLoad(string XVendorVendNum, string XVendaddrVendNum);
		ICollectionLoadResponse PoitemSelect(string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, string PoPoNum, string PoType, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable);
		(Guid? PoitmchgRowpointer, int? rowCount) PoitmchgLoad(int? PochangeChgNum, string PoPoNum, int? DPoitemPoLine, int? DPoitemPoRelease, Guid? PoitmchgRowpointer);
		ICollectionLoadResponse Poitem1Select(string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, string PoPoNum, string PoType, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem);
		ICollectionLoadResponse Poitem2Select(Guid? PoitemRowpointer, string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem);
		void Poitem2Update(ICollectionLoadResponse poitem2LoadResponse);
		(Guid? PoBlnRowpointer,
			 string PoBlnVendItem,
			 string PoBlnStat,
			 string PoBlnDrawingNbr,
			 string PoBlnRevision,
			 DateTime? PoBlnEffDate,
			 DateTime? PoBlnExpDate,
			 int? PoBlnNoteexistsflag,
			 string poblndescription,
			 string PoBlnManufacturerId,
			 string PoBlnManufacturerItem, int? rowCount) Po_BlnLoad(string PoitemPoNum, int? PoitemPoLine, Guid? PoBlnRowpointer, string PoBlnVendItem, string PoBlnStat, string PoBlnDrawingNbr, string PoBlnRevision, DateTime? PoBlnEffDate, DateTime? PoBlnExpDate, int? PoBlnNoteexistsflag, string PoBlnManufacturerId, string PoBlnManufacturerItem, string poblndescription);
		(Guid? XPoBlnRowpointer, int? rowCount) Po_Blnasx_Po_BlnLoad(Guid? PoBlnRowpointer, Guid? XPoBlnRowpointer);
		ICollectionLoadResponse Po_Bln1Select(Guid? XPoBlnRowpointer, string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem);
		void Po_Bln1Update(ICollectionLoadResponse po_bln1LoadResponse);
		(Guid? PoblnchgRowpointer, int? rowCount) PoblnchgLoad(int? PochangeChgNum, string PoPoNum, int? PoitemPoLine, Guid? PoblnchgRowpointer);
		(Guid? PoitmchgRowpointer, int? rowCount) Poitmchg1Load(int? PochangeChgNum, string PoPoNum, int? PoitemPoLine, int? PoitemPoRelease, Guid? PoitmchgRowpointer);
		(Guid? PoBlnRowpointer,
			 string PoBlnVendItem,
			 string PoBlnStat,
			 string PoBlnDrawingNbr,
			 string PoBlnRevision,
			 DateTime? PoBlnEffDate,
			 DateTime? PoBlnExpDate,
			 int? PoBlnNoteexistsflag,
			 string poblndescription,
			 string PoBlnManufacturerId,
			 string PoBlnManufacturerItem, int? rowCount) Po_Bln2Load(string PoitemPoNum, int? PoitemPoLine, Guid? PoBlnRowpointer, string PoBlnVendItem, string PoBlnStat, string PoBlnDrawingNbr, string PoBlnRevision, DateTime? PoBlnEffDate, DateTime? PoBlnExpDate, int? PoBlnNoteexistsflag, string PoBlnManufacturerId, string PoBlnManufacturerItem, string poblndescription);
		ICollectionLoadResponse Nontable1Select(int? TRptNum, string PoPoNum, int? PochangeChgNum, DateTime? PochangeChgDate, string PoType, int? PoPrintPrice, int? PoitemPoLine, int? PoitemPoRelease, string PoVendNum, string TAddr0, string TAddr1, string TAddr2, string TAddr4, string UserNamesUserDesc, string PoBuyer, string PoVendLcrNum, string PoFob, string TShipcodeDesc, string TTermsDesc, string PoDropShipNo, int? PoDropSeq, string VendaddrFaxNum, string TSymbol, decimal? TTot, string CurrencyDescription, string PoitemItem, string TVendItem, decimal? TcCprUnitMatCostConv, decimal? PoitemQtyOrderedConv, decimal? TQty, string TRevision, string TDrawingNbr, DateTime? TEffDate, DateTime? TExpDate, decimal? TcAmtPrice, DateTime? PoitemDueDate, int? PoitemExpedited, string PoitemDescription, string PoitemUM, int? TPOBlnNoteExits, int? TPOLineNoteExits, int? TPOChgNoteExits, Guid? PoBlnRowpointer, Guid? PoitemRowpointer, Guid? PochangeRowpointer, string poblndescription, decimal? VatAmt, decimal? VatAmt2, string PoitemTaxCode1, string PoitemTaxCode2, int? VendorPrintVATonPO, string TaxCodeLabel, string TaxCode2Label, string TaxAmtLabel, string TaxAmt2Label, decimal? CostWithoutTax, int? PoIncludeTaxInCost, decimal? TaxAmount, int? PrintVATSummary, string TManufacturerId, string TManufacturerItem, string ItemOverview, string PoVendOrder, string PoItemDeliveryIncoTerm, string DeltermDescription, string PoItemECCode, string PoItemOriginCode, string PoItemCommodityCode, string ParmsURL, string CurrCode, string OfficeAddrFooter, string OfficeEmailAddrFooter, string BankName, string BankTransitNum, string Account);
		void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
		ICollectionLoadResponse Nontable2Select(string PoPoNum, int? PochangeChgNum, string PoType, int? PoPrintPrice, string TAddr3, string TPoText1, string TPoText2, string TPoText3, string TSymbol, decimal? TTot, string TESymbol, decimal? TEuroTotal, string CurrencyDescription, int? TPONoteExits, Guid? PoRowpointer, int? VendorPrintVATonPO, string TaxCodeLabel, string TaxCode2Label, string TaxAmtLabel, string TaxAmt2Label, int? PrintVATSummary, string PoVendNum, string TAddr0, string TAddr1, string TAddr2, string TAddr4, string UserNamesUserDesc, string PoBuyer, string PoVendLcrNum, string PoFob, string TShipcodeDesc, string TTermsDesc, string PoDropShipNo, int? PoDropSeq, string VendaddrFaxNum, DateTime? PochangeChgDate, string PoVendOrder, string PoItemDeliveryIncoTerm, string DeltermDescription, string PoItemECCode, string PoItemOriginCode, string PoItemCommodityCode, string ParmsURL, string CurrCode, string OfficeAddrFooter, string OfficeEmailAddrFooter, string BankName, string BankTransitNum, string Account);
		void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse);
		(Guid? XPochangeRowpointer, int? rowCount) Pochangeasx_PochangeLoad(Guid? PochangeRowpointer, Guid? XPochangeRowpointer);
		ICollectionLoadResponse Pochange1Select(Guid? XPochangeRowpointer);
		void Pochange1Update(ICollectionLoadResponse pochange1LoadResponse);
		ICollectionLoadResponse Nontable3Select(string PoitemPoNum, int? PochangeChgNum, string PrevPoType, int? PrevPoPrintPrice, string TAddr3, string TPoText1, string TPoText2, string TPoText3, string TSymbol, decimal? TTot, string TESymbol, decimal? TEuroTotal, string CurrencyDescription, int? TPONoteExits, Guid? PoRowpointer, int? VendorPrintVATonPO, string TaxCodeLabel, string TaxCode2Label, string TaxAmtLabel, string TaxAmt2Label, int? PrintVATSummary, string PoVendNum, string TAddr0, string TAddr1, string TAddr2, string TAddr4, string UserNamesUserDesc, string PoBuyer, string PoVendLcrNum, string PoFob, string TShipcodeDesc, string TTermsDesc, string PoDropShipNo, int? PoDropSeq, string VendaddrFaxNum, DateTime? PochangeChgDate, string PoVendOrder, string PoItemDeliveryIncoTerm, string DeltermDescription, string PoItemECCode, string PoItemOriginCode, string PoItemCommodityCode, string ParmsURL, string CurrCode, string OfficeAddrFooter, string OfficeEmailAddrFooter, string BankName, string BankTransitNum, string Account);
		void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse);
		ICollectionLoadResponse Tv_ReportsetSelect();
		void Tv_ReportsetUpdate(int? PrintVATSummary, ICollectionLoadResponse tv_ReportSetLoadResponse);
		ICollectionLoadResponse Tv_Reportset1Select(int? Severity, int? UseAlternateAddressReportFormat);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ChangeOrderSp(string AltExtGenSp, string pPoType, string pPoStat, string pPoitemStat, int? pRoundPlaces, string pPrintItemIV, int? pPrPoTxt, int? pPrPoBlnTxt, int? pPrPoLineTxt, string pPRPoChg, string pChgStat, int? pTransDomCurr, int? pPrintEuro, string pStartPoNum, string pEndPoNum, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, string pStartvendor, string pEndVendor, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem, int? pPrintpo_bln, int? pPrintpochange, int? TaskId, int? pPrintManufacturerItem, string ReviewPrint, string pSite, int? pPrintItemOverview, int? PrintDrawingNumber, int? PrintDeliveryIncoTerms, int? PrintEUCode, int? PrintOriginCode, int? PrintCommodityCode, int? PrintHeaderOnAllPages, int? PrintAuthorizationSignatures);
	}
}

