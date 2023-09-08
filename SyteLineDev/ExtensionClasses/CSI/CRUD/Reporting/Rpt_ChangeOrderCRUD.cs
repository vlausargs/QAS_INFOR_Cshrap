//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChangeOrderCRUD.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;


namespace CSI.Reporting
{
	public class Rpt_ChangeOrderCRUD : IRpt_ChangeOrderCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IReportNotesExist iReportNotesExist;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		
		public Rpt_ChangeOrderCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IReportNotesExist iReportNotesExist,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.iReportNotesExist = iReportNotesExist;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ChangeOrderSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ChangeOrderSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_ChangeOrderSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};
			
			return optional_module1LoadResponse;
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (string TaxCodeLabel, string TaxAmtLabel, int? TaxSystem1_ActiveForPurch, int? rowCount) Tax_SystemLoad(int? TaxSystem1_ActiveForPurch, string TaxCodeLabel, string TaxAmtLabel)
		{
			TaxCodeLabelType _TaxCodeLabel = DBNull.Value;
			TaxCodeLabelType _TaxAmtLabel = DBNull.Value;
			ListYesNoType _TaxSystem1_ActiveForPurch = DBNull.Value;
			
			var tax_systemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TaxCodeLabel,"tax_system.tax_code_label"},
					{_TaxAmtLabel,"tax_system.tax_amt_label"},
					{_TaxSystem1_ActiveForPurch,"tax_system.active_for_purch"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"tax_system",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("tax_system = 1"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tax_systemLoadResponse = this.appDB.Load(tax_systemLoadRequest);
			if(tax_systemLoadResponse.Items.Count > 0)
			{
				TaxCodeLabel = _TaxCodeLabel;
				TaxAmtLabel = _TaxAmtLabel;
				TaxSystem1_ActiveForPurch = _TaxSystem1_ActiveForPurch;
			}
			
			int rowCount = tax_systemLoadResponse.Items.Count;
			return (TaxCodeLabel, TaxAmtLabel, TaxSystem1_ActiveForPurch, rowCount);
		}
		
		public (string TaxCode2Label, string TaxAmt2Label, int? TaxSystem2_ActiveForPurch, int? rowCount) Tax_System1Load(int? TaxSystem2_ActiveForPurch, string TaxCode2Label, string TaxAmt2Label)
		{
			TaxCodeLabelType _TaxCode2Label = DBNull.Value;
			TaxCodeLabelType _TaxAmt2Label = DBNull.Value;
			ListYesNoType _TaxSystem2_ActiveForPurch = DBNull.Value;
			
			var tax_system1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TaxCode2Label,"tax_system.tax_code_label"},
					{_TaxAmt2Label,"tax_system.tax_amt_label"},
					{_TaxSystem2_ActiveForPurch,"tax_system.active_for_purch"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"tax_system",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("tax_system = 2"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tax_system1LoadResponse = this.appDB.Load(tax_system1LoadRequest);
			if(tax_system1LoadResponse.Items.Count > 0)
			{
				TaxCode2Label = _TaxCode2Label;
				TaxAmt2Label = _TaxAmt2Label;
				TaxSystem2_ActiveForPurch = _TaxSystem2_ActiveForPurch;
			}
			
			int rowCount = tax_system1LoadResponse.Items.Count;
			return (TaxCode2Label, TaxAmt2Label, TaxSystem2_ActiveForPurch, rowCount);
		}
		
		public (string ParmsSite, int? PrintCompanyName, string ParmsURL, int? rowCount) ParmsLoad(string ParmsSite, int? PrintCompanyName, string ParmsURL)
		{
			SiteType _ParmsSite = DBNull.Value;
			ListYesNoType _PrintCompanyName = DBNull.Value;
			URLType _ParmsURL = DBNull.Value;
			
			var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ParmsSite,"parms.site"},
					{_PrintCompanyName,"print_name"},
					{_ParmsURL,"url"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
			if(parmsLoadResponse.Items.Count > 0)
			{
				ParmsSite = _ParmsSite;
				PrintCompanyName = _PrintCompanyName;
				ParmsURL = _ParmsURL;
			}
			
			int rowCount = parmsLoadResponse.Items.Count;
			return (ParmsSite, PrintCompanyName, ParmsURL, rowCount);
		}
		
		public (int? ECurrencyPlaces, string ECurrencySymbol, int? rowCount) Currencyase_CurrencyLoad(string TEuroCurr, int? ECurrencyPlaces, string ECurrencySymbol)
		{
			DecimalPlacesType _ECurrencyPlaces = DBNull.Value;
			CurrSymbolType _ECurrencySymbol = DBNull.Value;
			
			var currencyASe_currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ECurrencyPlaces,"e_currency.places"},
					{_ECurrencySymbol,"e_currency.symbol"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"currency AS e_currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("e_currency.curr_code = {0}",TEuroCurr),
				orderByClause: collectionLoadRequestFactory.Clause(" e_currency.curr_code ASC"));
			
			var currencyASe_currencyLoadResponse = this.appDB.Load(currencyASe_currencyLoadRequest);
			if(currencyASe_currencyLoadResponse.Items.Count > 0)
			{
				ECurrencyPlaces = _ECurrencyPlaces;
				ECurrencySymbol = _ECurrencySymbol;
			}
			
			int rowCount = currencyASe_currencyLoadResponse.Items.Count;
			return (ECurrencyPlaces, ECurrencySymbol, rowCount);
		}
		
		public (string CurrparmsCurrCode, int? rowCount) CurrparmsLoad(string CurrparmsCurrCode)
		{
			CurrCodeType _CurrparmsCurrCode = DBNull.Value;
			
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CurrparmsCurrCode,"currparms.curr_code"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if(currparmsLoadResponse.Items.Count > 0)
			{
				CurrparmsCurrCode = _CurrparmsCurrCode;
			}
			
			int rowCount = currparmsLoadResponse.Items.Count;
			return (CurrparmsCurrCode, rowCount);
		}
		
		public (int? PoparmsVendorRequired, string PoparmsPoText1, string PoparmsPoText2, string PoparmsPoText3, int? rowCount) PoparmsLoad(int? PoparmsVendorRequired, string PoparmsPoText1, string PoparmsPoText2, string PoparmsPoText3)
		{
			ListYesNoType _PoparmsVendorRequired = DBNull.Value;
			ReportTxtType _PoparmsPoText1 = DBNull.Value;
			ReportTxtType _PoparmsPoText2 = DBNull.Value;
			ReportTxtType _PoparmsPoText3 = DBNull.Value;
			
			var poparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoparmsVendorRequired,"poparms.vendor_required"},
					{_PoparmsPoText1,"poparms.po_text_1"},
					{_PoparmsPoText2,"poparms.po_text_2"},
					{_PoparmsPoText3,"poparms.po_text_3"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"poparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poparmsLoadResponse = this.appDB.Load(poparmsLoadRequest);
			if(poparmsLoadResponse.Items.Count > 0)
			{
				PoparmsVendorRequired = _PoparmsVendorRequired;
				PoparmsPoText1 = _PoparmsPoText1;
				PoparmsPoText2 = _PoparmsPoText2;
				PoparmsPoText3 = _PoparmsPoText3;
			}
			
			int rowCount = poparmsLoadResponse.Items.Count;
			return (PoparmsVendorRequired, PoparmsPoText1, PoparmsPoText2, PoparmsPoText3, rowCount);
		}
		
		public (string OfficeEmailAddrFooter, int? rowCount) ArparmsLoad(string OfficeEmailAddrFooter)
		{
			EmailType _OfficeEmailAddrFooter = DBNull.Value;
			
			var arparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_OfficeEmailAddrFooter,"email_addr"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"arparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("arparms_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var arparmsLoadResponse = this.appDB.Load(arparmsLoadRequest);
			if(arparmsLoadResponse.Items.Count > 0)
			{
				OfficeEmailAddrFooter = _OfficeEmailAddrFooter;
			}
			
			int rowCount = arparmsLoadResponse.Items.Count;
			return (OfficeEmailAddrFooter, rowCount);
		}
		
		public ICollectionLoadResponse PoSelect(string pPoType, string pPoStat, string pStartPoNum, string pEndPoNum, string pStartvendor, string pEndVendor, string TStartVendor, string TEndVendor, int? pStartPoRElease, int? pEndPoRelease, int? pStartPoLine, string pPoitemStat, int? pEndPoLine, int? pTransDomCurr, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, string CurrparmsCurrCode)
		{
			var po_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"rowpointer","po.rowpointer"},
					{"noteexistsflag","po.noteexistsflag"},
					{"vend_num","po.vend_num"},
					{"stat","po.stat"},
					{"po_num","po.po_num"},
					{"type","po.type"},
					{"ship_addr","po.ship_addr"},
					{"drop_ship_no","po.drop_ship_no"},
					{"drop_seq","po.drop_seq"},
					{"exch_rate","po.exch_rate"},
					{"print_price","po.print_price"},
					{"buyer","po.buyer"},
					{"vend_lcr_num","po.vend_lcr_num"},
					{"fob","po.fob"},
					{"include_tax_in_cost","po.include_tax_in_cost"},
					{"col0","CAST (NULL AS NVARCHAR)"},
					{"curr_code","po.curr_code"},
					{"lang_code","vendor.lang_code"},
					{"vend_remit","vendor.vend_remit"},
					{"description","terms.description"},
					{"description_","shipcode.description"},
					{"places","currency.places"},
					{"col1","CAST (NULL AS NVARCHAR)"},
					{"description__","currency.description"},
					{"rowpointer_","po_lang.rowpointer"},
					{"po_text##1","po_lang.po_text##1"},
					{"po_text##2","po_lang.po_text##2"},
					{"po_text##3","po_lang.po_text##3"},
					{"fax_num","vendaddr.fax_num"},
					{"col2","CAST (NULL AS INT)"},
					{"col3","CAST (NULL AS NVARCHAR)"},
					{"col4","CAST (NULL AS NVARCHAR)"},
					{"userdesc","usernames.userdesc"},
					{"vend_order","po.vend_order"},
					{"curr_code_","currency.curr_code"},
					{"name","bank_hdr.name"},
					{"bank_transit_num","bank_hdr.bank_transit_num"},
					{"account","vendor.account"},
					{"u0",$"(SELECT   TOP 1 a_poitem.rowpointer FROM     poitem AS a_poitem WHERE    po.po_num = a_poitem.po_num          AND a_poitem.po_line BETWEEN {pStartPoLine} AND {pEndPoLine}          AND a_poitem.po_release BETWEEN (CASE WHEN po.type = 'R' THEN a_poitem.po_release ELSE {pStartPoRElease} END) AND (CASE WHEN po.type = 'R' THEN a_poitem.po_release ELSE {pEndPoRelease} END)          AND CHARINDEX(a_poitem.stat, {variableUtil.GetQuotedValue<string>(pPoitemStat)}) > 0 ORDER BY a_poitem.po_num ASC, a_poitem.rowpointer ASC)"},
					{"u1","currency.symbol"},
					{"u2","ship_lang.rowpointer"},
					{"u3","ship_lang.description"},
					{"u4","term_lang.rowpointer"},
					{"u5","term_lang.description"},
					{"ven_bank_transit_num","vendor.bank_transit_num"},
					{"override_bank_transit_num","vendor.override_bank_transit_num"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"po",
				fromClause: collectionLoadRequestFactory.Clause(@" left outer join vendor on po.vend_num = vendor.vend_num left outer join terms on po.terms_code = terms.terms_code left outer join shipcode on po.ship_code = shipcode.ship_code left outer join currency on currency.curr_code = case when {1} = 1 then {0} else po.curr_code end left outer join po_lang on po_lang.lang_code = vendor.lang_code left outer join ship_lang on ship_lang.ship_code = shipcode.ship_code
					and ship_lang.lang_code = vendor.lang_code left outer join term_lang on term_lang.terms_code = terms.terms_code
					and term_lang.lang_code = vendor.lang_code left outer join vendaddr on vendor.vend_num = vendaddr.vend_num left outer join usernames on usernames.username = po.buyer left outer join bank_hdr on vendor.vend_bank = bank_hdr.bank_code",CurrparmsCurrCode,pTransDomCurr),
				whereClause: collectionLoadRequestFactory.Clause("po.po_num BETWEEN {2} AND {5} AND ((po.vend_num BETWEEN {0} AND {3}) OR ({1} IS NULL AND {4} IS NULL)) AND CHARINDEX(po.type, {6}) > 0 AND CHARINDEX(po.stat, {7}) > 0",pStartvendor,TStartVendor,pStartPoNum,pEndVendor,TEndVendor,pEndPoNum,pPoType,pPoStat),
				orderByClause: collectionLoadRequestFactory.Clause(" po.po_num"));
			
			var po_crsLoadResponseForCursor = this.appDB.Load(po_crsLoadRequestForCursor);
			foreach(var poItem in po_crsLoadResponseForCursor.Items){
				poItem.SetValue<Guid?>("rowpointer", poItem.GetValue<Guid?>("rowpointer"));
				poItem.SetValue<int?>("noteexistsflag", poItem.GetValue<int?>("noteexistsflag"));
				poItem.SetValue<string>("vend_num", poItem.GetValue<string>("vend_num"));
				poItem.SetValue<string>("stat", poItem.GetValue<string>("stat"));
				poItem.SetValue<string>("po_num", poItem.GetValue<string>("po_num"));
				poItem.SetValue<string>("type", poItem.GetValue<string>("type"));
				poItem.SetValue<string>("ship_addr", poItem.GetValue<string>("ship_addr"));
				poItem.SetValue<string>("drop_ship_no", poItem.GetValue<string>("drop_ship_no"));
				poItem.SetValue<int?>("drop_seq", poItem.GetValue<int?>("drop_seq"));
				poItem.SetValue<decimal?>("exch_rate", poItem.GetValue<decimal?>("exch_rate"));
				poItem.SetValue<int?>("print_price", poItem.GetValue<int?>("print_price"));
				poItem.SetValue<string>("buyer", poItem.GetValue<string>("buyer"));
				poItem.SetValue<string>("vend_lcr_num", poItem.GetValue<string>("vend_lcr_num"));
				poItem.SetValue<string>("fob", poItem.GetValue<string>("fob"));
				poItem.SetValue<int?>("include_tax_in_cost", poItem.GetValue<int?>("include_tax_in_cost"));
				poItem.SetValue<Guid?>("col0", poItem.GetValue<Guid?>("u0"));
				poItem.SetValue<string>("curr_code", poItem.GetValue<string>("curr_code"));
				poItem.SetValue<string>("lang_code", poItem.GetValue<string>("lang_code"));
				poItem.SetValue<string>("vend_remit", poItem.GetValue<string>("vend_remit"));
				poItem.SetValue<string>("description", poItem.GetValue<string>("description"));
				poItem.SetValue<string>("description_", poItem.GetValue<string>("description_"));
				poItem.SetValue<int?>("places", poItem.GetValue<int?>("places"));
				poItem.SetValue<string>("col1", stringUtil.IsNull(
					poItem.GetValue<string>("u1"),
					""));
				poItem.SetValue<string>("description__", poItem.GetValue<string>("description__"));
				poItem.SetValue<Guid?>("rowpointer_", poItem.GetValue<Guid?>("rowpointer_"));
				poItem.SetValue<string>("po_text##1", poItem.GetValue<string>("po_text##1"));
				poItem.SetValue<string>("po_text##2", poItem.GetValue<string>("po_text##2"));
				poItem.SetValue<string>("po_text##3", poItem.GetValue<string>("po_text##3"));
				poItem.SetValue<string>("fax_num", poItem.GetValue<string>("fax_num"));
				poItem.SetValue<int?>("col2", (sQLUtil.SQLEqual(pPrintPOTable, 1) == true ? this.iReportNotesExist.ReportNotesExistFn(
					"po",
					poItem.GetValue<Guid?>("rowpointer"),
					pShowInternal1,
					pShowExternal1,
					poItem.GetValue<int?>("noteexistsflag")) : 0));
				poItem.SetValue<string>("col3", (poItem.GetValue<Guid?>("u2")!= null ? poItem.GetValue<string>("u3") : poItem.GetValue<string>("description_")));
				poItem.SetValue<string>("col4", (poItem.GetValue<Guid?>("u4")!= null ? poItem.GetValue<string>("u5") : poItem.GetValue<string>("description")));
				poItem.SetValue<string>("userdesc", poItem.GetValue<string>("userdesc"));
				poItem.SetValue<string>("vend_order", poItem.GetValue<string>("vend_order"));
				poItem.SetValue<string>("curr_code_", poItem.GetValue<string>("curr_code_"));
				poItem.SetValue<string>("name", poItem.GetValue<string>("name"));
				poItem.SetValue<string>("bank_transit_num", poItem.GetValue<string>("bank_transit_num"));
				poItem.SetValue<string>("account", poItem.GetValue<string>("account"));
				poItem.SetValue<string>("ven_bank_transit_num", poItem.GetValue<string>("ven_bank_transit_num"));
				poItem.SetValue<string>("override_bank_transit_num", poItem.GetValue<string>("override_bank_transit_num"));
			};
			
			return po_crsLoadResponseForCursor;
		}
		public (string MessageLanguage, int? rowCount) LanguageidsLoad(string VendorLangCode, string MessageLanguage)
		{
			MessageLanguageType _MessageLanguage = DBNull.Value;
			
			var LanguageIDsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_MessageLanguage,"LocaleID"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"LanguageIDs",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("LanguageCode = {0}",VendorLangCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var LanguageIDsLoadResponse = this.appDB.Load(LanguageIDsLoadRequest);
			if(LanguageIDsLoadResponse.Items.Count > 0)
			{
				MessageLanguage = _MessageLanguage;
			}
			
			int rowCount = LanguageIDsLoadResponse.Items.Count;
			return (MessageLanguage, rowCount);
		}
		
		public (int? UseAlternateAddressReportFormat, int? rowCount) CountryLoad(int? UseAlternateAddressReportFormat)
		{
			ListYesNoType _UseAlternateAddressReportFormat = DBNull.Value;
			
			var countryLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_UseAlternateAddressReportFormat,"use_alt_addr_report_formatting"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"country",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("country = (SELECT country FROM parms WITH (READUNCOMMITTED) WHERE parm_key = 0)"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var countryLoadResponse = this.appDB.Load(countryLoadRequest);
			if(countryLoadResponse.Items.Count > 0)
			{
				UseAlternateAddressReportFormat = _UseAlternateAddressReportFormat;
			}
			
			int rowCount = countryLoadResponse.Items.Count;
			return (UseAlternateAddressReportFormat, rowCount);
		}
		
		public (int? UseAlternateAddressReportFormat, int? rowCount) Parms1Load(int? UseAlternateAddressReportFormat)
		{
			ListYesNoType _UseAlternateAddressReportFormat = DBNull.Value;
			
			var parms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_UseAlternateAddressReportFormat,"use_alt_addr_report_formatting"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("parm_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var parms1LoadResponse = this.appDB.Load(parms1LoadRequest);
			if(parms1LoadResponse.Items.Count > 0)
			{
				UseAlternateAddressReportFormat = _UseAlternateAddressReportFormat;
			}
			
			int rowCount = parms1LoadResponse.Items.Count;
			return (UseAlternateAddressReportFormat, rowCount);
		}
		
		public (Guid? PochangeRowpointer,
			string PochangeStat,
			int? PochangeNoteexistsflag,
			int? PochangeChgNum,
			DateTime? PochangeChgDate, int? rowCount)
		PochangeLoad(string PoPoNum,
			Guid? PochangeRowpointer,
			string PochangeStat,
			int? PochangeNoteexistsflag,
			int? PochangeChgNum,
			DateTime? PochangeChgDate)
		{
			RowPointerType _PochangeRowpointer = DBNull.Value;
			PoChangeStatusType _PochangeStat = DBNull.Value;
			ListYesNoType _PochangeNoteexistsflag = DBNull.Value;
			ChgNumType _PochangeChgNum = DBNull.Value;
			DateType _PochangeChgDate = DBNull.Value;
			
			var pochangeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PochangeRowpointer,"pochange.rowpointer"},
					{_PochangeStat,"pochange.stat"},
					{_PochangeNoteexistsflag,"pochange.noteexistsflag"},
					{_PochangeChgNum,"pochange.chg_num"},
					{_PochangeChgDate,"pochange.chg_date"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"pochange",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("pochange.po_num = {0}",PoPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(" pochange.po_num, pochange.chg_num DESC"));
			
			var pochangeLoadResponse = this.appDB.Load(pochangeLoadRequest);
			if(pochangeLoadResponse.Items.Count > 0)
			{
				PochangeRowpointer = _PochangeRowpointer;
				PochangeStat = _PochangeStat;
				PochangeNoteexistsflag = _PochangeNoteexistsflag;
				PochangeChgNum = _PochangeChgNum;
				PochangeChgDate = _PochangeChgDate;
			}
			
			int rowCount = pochangeLoadResponse.Items.Count;
			return (PochangeRowpointer, PochangeStat, PochangeNoteexistsflag, PochangeChgNum, PochangeChgDate, rowCount);
		}
		
		public (Guid? XVendorRowpointer, string XVendorVendNum, int? rowCount) Vendorasx_VendorLoad(string TVendRemit, Guid? XVendorRowpointer, string XVendorVendNum)
		{
			RowPointerType _XVendorRowpointer = DBNull.Value;
			VendNumType _XVendorVendNum = DBNull.Value;
			
			var vendorASx_vendorLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XVendorRowpointer,"x_vendor.rowpointer"},
					{_XVendorVendNum,"x_vendor.vend_num"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"vendor AS x_vendor",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("x_vendor.vend_num = {0}",TVendRemit),
				orderByClause: collectionLoadRequestFactory.Clause(" x_vendor.vend_num ASC"));
			
			var vendorASx_vendorLoadResponse = this.appDB.Load(vendorASx_vendorLoadRequest);
			if(vendorASx_vendorLoadResponse.Items.Count > 0)
			{
				XVendorRowpointer = _XVendorRowpointer;
				XVendorVendNum = _XVendorVendNum;
			}
			
			int rowCount = vendorASx_vendorLoadResponse.Items.Count;
			return (XVendorRowpointer, XVendorVendNum, rowCount);
		}
		
		public (string XVendaddrVendNum, int? rowCount) Vendaddrasx_VendaddrLoad(string XVendorVendNum, string XVendaddrVendNum)
		{
			VendNumType _XVendaddrVendNum = DBNull.Value;
			
			var vendaddrASx_vendaddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XVendaddrVendNum,"x_vendaddr.vend_num"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"vendaddr AS x_vendaddr",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("{0} = x_vendaddr.vend_num",XVendorVendNum),
				orderByClause: collectionLoadRequestFactory.Clause(" x_vendaddr.vend_num ASC"));
			
			var vendaddrASx_vendaddrLoadResponse = this.appDB.Load(vendaddrASx_vendaddrLoadRequest);
			if(vendaddrASx_vendaddrLoadResponse.Items.Count > 0)
			{
				XVendaddrVendNum = _XVendaddrVendNum;
			}
			
			int rowCount = vendaddrASx_vendaddrLoadResponse.Items.Count;
			return (XVendaddrVendNum, rowCount);
		}
		
		public ICollectionLoadResponse PoitemSelect(string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, string PoPoNum, string PoType, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable)
		{
			var d_poitem_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"d_poitem.po_line","d_poitem.po_line"},
					{"d_poitem.po_release","d_poitem.po_release"},
					{"d_poitem.unit_mat_cost_conv","d_poitem.unit_mat_cost_conv"},
					{"d_poitem.qty_ordered_conv","d_poitem.qty_ordered_conv"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(" AS d_poitem"),
				whereClause: collectionLoadRequestFactory.Clause("{5} = d_poitem.po_num AND d_poitem.po_line BETWEEN {2} AND {4} AND d_poitem.po_release BETWEEN (CASE WHEN {6} = 'R' THEN d_poitem.po_release ELSE {0} END) AND (CASE WHEN {6} = 'R' THEN d_poitem.po_release ELSE {1} END) AND CHARINDEX(d_poitem.stat, {3}) > 0",pStartPoRElease,pEndPoRelease,pStartPoLine,pPoitemStat,pEndPoLine,PoPoNum,PoType),
				orderByClause: collectionLoadRequestFactory.Clause(" d_poitem.po_num, d_poitem.po_line, d_poitem.po_release"));
			
			var d_poitem_crsLoadResponseForCursor = this.appDB.Load(d_poitem_crsLoadRequestForCursor);
			return d_poitem_crsLoadResponseForCursor;
		}
		public (Guid? PoitmchgRowpointer, int? rowCount) PoitmchgLoad(int? PochangeChgNum, string PoPoNum, int? DPoitemPoLine, int? DPoitemPoRelease, Guid? PoitmchgRowpointer)
		{
			RowPointerType _PoitmchgRowpointer = DBNull.Value;
			
			var poitmchgLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoitmchgRowpointer,"poitmchg.rowpointer"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"poitmchg",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poitmchg.chg_num = {1} AND poitmchg.po_num = {3} AND poitmchg.po_line = {2} AND poitmchg.po_release = {0}",DPoitemPoRelease,PochangeChgNum,DPoitemPoLine,PoPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(" poitmchg.po_num DESC, poitmchg.po_line DESC, poitmchg.po_release DESC"));
			
			var poitmchgLoadResponse = this.appDB.Load(poitmchgLoadRequest);
			if(poitmchgLoadResponse.Items.Count > 0)
			{
				PoitmchgRowpointer = _PoitmchgRowpointer;
			}
			
			int rowCount = poitmchgLoadResponse.Items.Count;
			return (PoitmchgRowpointer, rowCount);
		}
		
		public ICollectionLoadResponse Poitem1Select(string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, string PoPoNum, string PoType, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem)
		{
			var poitem_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"rowpointer","poitem.rowpointer"},
					{"noteexistsflag","poitem.noteexistsflag"},
					{"stat","poitem.stat"},
					{"item","poitem.item"},
					{"po_num","poitem.po_num"},
					{"po_line","poitem.po_line"},
					{"vend_item","poitem.vend_item"},
					{"po_release","poitem.po_release"},
					{"unit_mat_cost_conv","poitem.unit_mat_cost_conv"},
					{"qty_ordered_conv","poitem.qty_ordered_conv"},
					{"u_m","poitem.u_m"},
					{"qty_received","poitem.qty_received"},
					{"drawing_nbr","poitem.drawing_nbr"},
					{"revision","poitem.revision"},
					{"due_date","poitem.due_date"},
					{"tax_code1","poitem.tax_code1"},
					{"tax_code2","poitem.tax_code2"},
					{"tax_code1_","po.tax_code1"},
					{"tax_code2_","po.tax_code2"},
					{"print_vat_on_po","vendor.print_vat_on_po"},
					{"expedited","poitem.expedited"},
					{"drop_ship_no","poitem.drop_ship_no"},
					{"drop_seq","poitem.drop_seq"},
					{"ship_addr","poitem.ship_addr"},
					{"col0","CAST (NULL AS NVARCHAR)"},
					{"manufacturer_id","poitem.manufacturer_id"},
					{"manufacturer_item","poitem.manufacturer_item"},
					{"col1","CAST (NULL AS INT)"},
					{"col2","CAST (NULL AS NVARCHAR)"},
					{"delterm","poitem.delterm"},
					{"description","del.description"},
					{"ec_code","poitem.ec_code"},
					{"origin","poitem.origin"},
					{"comm_code","poitem.comm_code"},
					{"u0","poitem.description"},
					{"u1","item.description"},
					{"u2","item_lang.description"},
					{"u3","item_lang.overview"},
					{"u4","item.overview"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(@" AS poitem INNER JOIN po ON poitem.po_num = po.po_num LEFT OUTER JOIN vendor ON po.vend_num = vendor.vend_num LEFT OUTER JOIN item_lang ON item_lang.item = poitem.item
					AND item_lang.lang_code = vendor.lang_code LEFT OUTER JOIN item ON item.item = poitem.item LEFT OUTER JOIN del_term AS del ON poitem.delterm = del.delterm"),
				whereClause: collectionLoadRequestFactory.Clause("{5} = poitem.po_num AND poitem.po_line BETWEEN {2} AND {4} AND poitem.po_release BETWEEN (CASE WHEN {6} = 'R' THEN poitem.po_release ELSE {0} END) AND (CASE WHEN {6} = 'R' THEN poitem.po_release ELSE {1} END) AND CHARINDEX(poitem.stat, {3}) > 0",pStartPoRElease,pEndPoRelease,pStartPoLine,pPoitemStat,pEndPoLine,PoPoNum,PoType),
				orderByClause: collectionLoadRequestFactory.Clause(" poitem.po_num, poitem.po_line, poitem.po_release"));
			
			var poitem_crsLoadResponseForCursor = this.appDB.Load(poitem_crsLoadRequestForCursor);
			foreach(var poitem1Item in poitem_crsLoadResponseForCursor.Items){
				poitem1Item.SetValue<Guid?>("rowpointer", poitem1Item.GetValue<Guid?>("rowpointer"));
				poitem1Item.SetValue<int?>("noteexistsflag", poitem1Item.GetValue<int?>("noteexistsflag"));
				poitem1Item.SetValue<string>("stat", poitem1Item.GetValue<string>("stat"));
				poitem1Item.SetValue<string>("item", poitem1Item.GetValue<string>("item"));
				poitem1Item.SetValue<string>("po_num", poitem1Item.GetValue<string>("po_num"));
				poitem1Item.SetValue<int?>("po_line", poitem1Item.GetValue<int?>("po_line"));
				poitem1Item.SetValue<string>("vend_item", poitem1Item.GetValue<string>("vend_item"));
				poitem1Item.SetValue<int?>("po_release", poitem1Item.GetValue<int?>("po_release"));
				poitem1Item.SetValue<decimal?>("unit_mat_cost_conv", poitem1Item.GetValue<decimal?>("unit_mat_cost_conv"));
				poitem1Item.SetValue<decimal?>("qty_ordered_conv", poitem1Item.GetValue<decimal?>("qty_ordered_conv"));
				poitem1Item.SetValue<string>("u_m", poitem1Item.GetValue<string>("u_m"));
				poitem1Item.SetValue<decimal?>("qty_received", poitem1Item.GetValue<decimal?>("qty_received"));
				poitem1Item.SetValue<string>("drawing_nbr", poitem1Item.GetValue<string>("drawing_nbr"));
				poitem1Item.SetValue<string>("revision", poitem1Item.GetValue<string>("revision"));
				poitem1Item.SetValue<DateTime?>("due_date", poitem1Item.GetValue<DateTime?>("due_date"));
				poitem1Item.SetValue<string>("tax_code1", poitem1Item.GetValue<string>("tax_code1"));
				poitem1Item.SetValue<string>("tax_code2", poitem1Item.GetValue<string>("tax_code2"));
				poitem1Item.SetValue<string>("tax_code1_", poitem1Item.GetValue<string>("tax_code1_"));
				poitem1Item.SetValue<string>("tax_code2_", poitem1Item.GetValue<string>("tax_code2_"));
				poitem1Item.SetValue<int?>("print_vat_on_po", poitem1Item.GetValue<int?>("print_vat_on_po"));
				poitem1Item.SetValue<int?>("expedited", poitem1Item.GetValue<int?>("expedited"));
				poitem1Item.SetValue<string>("drop_ship_no", poitem1Item.GetValue<string>("drop_ship_no"));
				poitem1Item.SetValue<int?>("drop_seq", poitem1Item.GetValue<int?>("drop_seq"));
				poitem1Item.SetValue<string>("ship_addr", poitem1Item.GetValue<string>("ship_addr"));
				poitem1Item.SetValue<string>("col0", (sQLUtil.SQLNotEqual(stringUtil.IsNull(
					poitem1Item.GetValue<string>("u0"),
					""), stringUtil.IsNull(
					poitem1Item.GetValue<string>("u1"),
					"")) == true ? poitem1Item.GetValue<string>("u0") : stringUtil.IsNull(
					poitem1Item.GetValue<string>("u2"),
					poitem1Item.GetValue<string>("u1"))));
				poitem1Item.SetValue<string>("manufacturer_id", poitem1Item.GetValue<string>("manufacturer_id"));
				poitem1Item.SetValue<string>("manufacturer_item", poitem1Item.GetValue<string>("manufacturer_item"));
				poitem1Item.SetValue<int?>("col1", (sQLUtil.SQLEqual(pPrintpoitem, 1) == true ? this.iReportNotesExist.ReportNotesExistFn(
					"poitem",
					poitem1Item.GetValue<Guid?>("rowpointer"),
					pShowInternal1,
					pShowExternal1,
					poitem1Item.GetValue<int?>("noteexistsflag")) : 0));
				poitem1Item.SetValue<string>("col2", stringUtil.IsNull(
					poitem1Item.GetValue<string>("u3"),
					poitem1Item.GetValue<string>("u4")));
				poitem1Item.SetValue<string>("delterm", poitem1Item.GetValue<string>("delterm"));
				poitem1Item.SetValue<string>("description", poitem1Item.GetValue<string>("description"));
				poitem1Item.SetValue<string>("ec_code", poitem1Item.GetValue<string>("ec_code"));
				poitem1Item.SetValue<string>("origin", poitem1Item.GetValue<string>("origin"));
				poitem1Item.SetValue<string>("comm_code", poitem1Item.GetValue<string>("comm_code"));
			};
			
			return poitem_crsLoadResponseForCursor;
		}
		public ICollectionLoadResponse Poitem2Select(Guid? PoitemRowpointer, string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem)
		{
			var poitem2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","poitem.stat"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poitem.rowpointer = {0}",PoitemRowpointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(poitem2LoadRequest);
		}
		
		public void Poitem2Update(ICollectionLoadResponse poitem2LoadResponse)
		{
			foreach(var poitem2Item in poitem2LoadResponse.Items){
				poitem2Item.SetValue<string>("stat", "O");
			};
			
			var poitem2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "poitem",
				items: poitem2LoadResponse.Items);
			
			this.appDB.Update(poitem2RequestUpdate);
		}
		
		public (Guid? PoBlnRowpointer,
			string PoBlnVendItem,
			string PoBlnStat,
			string PoBlnDrawingNbr,
			string PoBlnRevision,
			DateTime? PoBlnEffDate,
			DateTime? PoBlnExpDate,
			int? PoBlnNoteexistsflag,
			string poblndescription,
			string PoBlnManufacturerId,
			string PoBlnManufacturerItem, int? rowCount)
		Po_BlnLoad(string PoitemPoNum,
			int? PoitemPoLine,
			Guid? PoBlnRowpointer,
			string PoBlnVendItem,
			string PoBlnStat,
			string PoBlnDrawingNbr,
			string PoBlnRevision,
			DateTime? PoBlnEffDate,
			DateTime? PoBlnExpDate,
			int? PoBlnNoteexistsflag,
			string PoBlnManufacturerId,
			string PoBlnManufacturerItem,
			string poblndescription)
		{
			RowPointerType _PoBlnRowpointer = DBNull.Value;
			VendItemType _PoBlnVendItem = DBNull.Value;
			PoStatType _PoBlnStat = DBNull.Value;
			DrawingNbrType _PoBlnDrawingNbr = DBNull.Value;
			RevisionType _PoBlnRevision = DBNull.Value;
			DateType _PoBlnEffDate = DBNull.Value;
			DateType _PoBlnExpDate = DBNull.Value;
			ListYesNoType _PoBlnNoteexistsflag = DBNull.Value;
			DescriptionType _poblndescription = DBNull.Value;
			ManufacturerIdType _PoBlnManufacturerId = DBNull.Value;
			ManufacturerItemType _PoBlnManufacturerItem = DBNull.Value;
			
			var po_blnLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoBlnRowpointer,"po_bln.rowpointer"},
					{_PoBlnVendItem,"po_bln.vend_item"},
					{_PoBlnStat,"po_bln.stat"},
					{_PoBlnDrawingNbr,"po_bln.drawing_nbr"},
					{_PoBlnRevision,"po_bln.revision"},
					{_PoBlnEffDate,"po_bln.eff_date"},
					{_PoBlnExpDate,"po_bln.exp_date"},
					{_PoBlnNoteexistsflag,"po_bln.noteexistsflag"},
					{_poblndescription,"po_bln.description"},
					{_PoBlnManufacturerId,"po_bln.manufacturer_id"},
					{_PoBlnManufacturerItem,"po_bln.manufacturer_item"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"po_bln",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("po_bln.po_num = {1} AND po_bln.po_line = {0}",PoitemPoLine,PoitemPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(" po_bln.po_num ASC, po_bln.po_line ASC"));
			
			var po_blnLoadResponse = this.appDB.Load(po_blnLoadRequest);
			if(po_blnLoadResponse.Items.Count > 0)
			{
				PoBlnRowpointer = _PoBlnRowpointer;
				PoBlnVendItem = _PoBlnVendItem;
				PoBlnStat = _PoBlnStat;
				PoBlnDrawingNbr = _PoBlnDrawingNbr;
				PoBlnRevision = _PoBlnRevision;
				PoBlnEffDate = _PoBlnEffDate;
				PoBlnExpDate = _PoBlnExpDate;
				PoBlnNoteexistsflag = _PoBlnNoteexistsflag;
				poblndescription = _poblndescription;
				PoBlnManufacturerId = _PoBlnManufacturerId;
				PoBlnManufacturerItem = _PoBlnManufacturerItem;
			}
			
			int rowCount = po_blnLoadResponse.Items.Count;
			return (PoBlnRowpointer, PoBlnVendItem, PoBlnStat, PoBlnDrawingNbr, PoBlnRevision, PoBlnEffDate, PoBlnExpDate, PoBlnNoteexistsflag, poblndescription, PoBlnManufacturerId, PoBlnManufacturerItem, rowCount);
		}
		
		public (Guid? XPoBlnRowpointer, int? rowCount) Po_Blnasx_Po_BlnLoad(Guid? PoBlnRowpointer, Guid? XPoBlnRowpointer)
		{
			RowPointerType _XPoBlnRowpointer = DBNull.Value;
			
			var po_blnASx_po_blnLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XPoBlnRowpointer,"x_po_bln.rowpointer"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"po_bln AS x_po_bln",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("x_po_bln.RowPointer = {0}",PoBlnRowpointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var po_blnASx_po_blnLoadResponse = this.appDB.Load(po_blnASx_po_blnLoadRequest);
			if(po_blnASx_po_blnLoadResponse.Items.Count > 0)
			{
				XPoBlnRowpointer = _XPoBlnRowpointer;
			}
			
			int rowCount = po_blnASx_po_blnLoadResponse.Items.Count;
			return (XPoBlnRowpointer, rowCount);
		}
		
		public ICollectionLoadResponse Po_Bln1Select(Guid? XPoBlnRowpointer, string pPoitemStat, int? pStartPoLine, int? pEndPoLine, int? pStartPoRElease, int? pEndPoRelease, int? pShowExternal1, int? pShowInternal1, int? pPrintPOTable, int? pPrintpoitem)
		{
			var po_bln1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","po_bln.stat"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"po_bln",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}",XPoBlnRowpointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(po_bln1LoadRequest);
		}
		
		public void Po_Bln1Update(ICollectionLoadResponse po_bln1LoadResponse)
		{
			foreach(var po_bln1Item in po_bln1LoadResponse.Items){
				po_bln1Item.SetValue<string>("stat", "O");
			};
			
			var po_bln1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "po_bln",
				items: po_bln1LoadResponse.Items);
			
			this.appDB.Update(po_bln1RequestUpdate);
		}
		
		public (Guid? PoblnchgRowpointer, int? rowCount) PoblnchgLoad(int? PochangeChgNum, string PoPoNum, int? PoitemPoLine, Guid? PoblnchgRowpointer)
		{
			RowPointerType _PoblnchgRowpointer = DBNull.Value;
			
			var poblnchgLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoblnchgRowpointer,"poblnchg.rowpointer"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"poblnchg",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poblnchg.chg_num = {0} AND poblnchg.po_num = {2} AND poblnchg.po_line = {1}",PochangeChgNum,PoitemPoLine,PoPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(" poblnchg.chg_num DESC, poblnchg.po_num DESC, poblnchg.po_line DESC"));
			
			var poblnchgLoadResponse = this.appDB.Load(poblnchgLoadRequest);
			if(poblnchgLoadResponse.Items.Count > 0)
			{
				PoblnchgRowpointer = _PoblnchgRowpointer;
			}
			
			int rowCount = poblnchgLoadResponse.Items.Count;
			return (PoblnchgRowpointer, rowCount);
		}
		
		public (Guid? PoitmchgRowpointer, int? rowCount) Poitmchg1Load(int? PochangeChgNum, string PoPoNum, int? PoitemPoLine, int? PoitemPoRelease, Guid? PoitmchgRowpointer)
		{
			RowPointerType _PoitmchgRowpointer = DBNull.Value;
			
			var poitmchg1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoitmchgRowpointer,"poitmchg.rowpointer"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"poitmchg",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poitmchg.chg_num = {1} AND poitmchg.po_num = {3} AND poitmchg.po_line = {2} AND poitmchg.po_release = {0}",PoitemPoRelease,PochangeChgNum,PoitemPoLine,PoPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(" poitmchg.chg_num DESC, poitmchg.po_num DESC, poitmchg.po_release DESC"));
			
			var poitmchg1LoadResponse = this.appDB.Load(poitmchg1LoadRequest);
			if(poitmchg1LoadResponse.Items.Count > 0)
			{
				PoitmchgRowpointer = _PoitmchgRowpointer;
			}
			
			int rowCount = poitmchg1LoadResponse.Items.Count;
			return (PoitmchgRowpointer, rowCount);
		}
		
		public (Guid? PoBlnRowpointer,
			string PoBlnVendItem,
			string PoBlnStat,
			string PoBlnDrawingNbr,
			string PoBlnRevision,
			DateTime? PoBlnEffDate,
			DateTime? PoBlnExpDate,
			int? PoBlnNoteexistsflag,
			string poblndescription,
			string PoBlnManufacturerId,
			string PoBlnManufacturerItem, int? rowCount)
		Po_Bln2Load(string PoitemPoNum,
			int? PoitemPoLine,
			Guid? PoBlnRowpointer,
			string PoBlnVendItem,
			string PoBlnStat,
			string PoBlnDrawingNbr,
			string PoBlnRevision,
			DateTime? PoBlnEffDate,
			DateTime? PoBlnExpDate,
			int? PoBlnNoteexistsflag,
			string PoBlnManufacturerId,
			string PoBlnManufacturerItem,
			string poblndescription)
		{
			RowPointerType _PoBlnRowpointer = DBNull.Value;
			VendItemType _PoBlnVendItem = DBNull.Value;
			PoStatType _PoBlnStat = DBNull.Value;
			DrawingNbrType _PoBlnDrawingNbr = DBNull.Value;
			RevisionType _PoBlnRevision = DBNull.Value;
			DateType _PoBlnEffDate = DBNull.Value;
			DateType _PoBlnExpDate = DBNull.Value;
			ListYesNoType _PoBlnNoteexistsflag = DBNull.Value;
			DescriptionType _poblndescription = DBNull.Value;
			ManufacturerIdType _PoBlnManufacturerId = DBNull.Value;
			ManufacturerItemType _PoBlnManufacturerItem = DBNull.Value;
			
			var po_bln2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoBlnRowpointer,"po_bln.rowpointer"},
					{_PoBlnVendItem,"po_bln.vend_item"},
					{_PoBlnStat,"po_bln.stat"},
					{_PoBlnDrawingNbr,"po_bln.drawing_nbr"},
					{_PoBlnRevision,"po_bln.revision"},
					{_PoBlnEffDate,"po_bln.eff_date"},
					{_PoBlnExpDate,"po_bln.exp_date"},
					{_PoBlnNoteexistsflag,"po_bln.noteexistsflag"},
					{_poblndescription,"po_bln.description"},
					{_PoBlnManufacturerId,"po_bln.manufacturer_id"},
					{_PoBlnManufacturerItem,"po_bln.manufacturer_item"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"PO_BLN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("{1} = po_bln.po_num AND {0} = po_bln.po_line",PoitemPoLine,PoitemPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(" po_bln.po_num ASC, po_bln.po_line ASC"));
			
			var po_bln2LoadResponse = this.appDB.Load(po_bln2LoadRequest);
			if(po_bln2LoadResponse.Items.Count > 0)
			{
				PoBlnRowpointer = _PoBlnRowpointer;
				PoBlnVendItem = _PoBlnVendItem;
				PoBlnStat = _PoBlnStat;
				PoBlnDrawingNbr = _PoBlnDrawingNbr;
				PoBlnRevision = _PoBlnRevision;
				PoBlnEffDate = _PoBlnEffDate;
				PoBlnExpDate = _PoBlnExpDate;
				PoBlnNoteexistsflag = _PoBlnNoteexistsflag;
				poblndescription = _poblndescription;
				PoBlnManufacturerId = _PoBlnManufacturerId;
				PoBlnManufacturerItem = _PoBlnManufacturerItem;
			}
			
			int rowCount = po_bln2LoadResponse.Items.Count;
			return (PoBlnRowpointer, PoBlnVendItem, PoBlnStat, PoBlnDrawingNbr, PoBlnRevision, PoBlnEffDate, PoBlnExpDate, PoBlnNoteexistsflag, poblndescription, PoBlnManufacturerId, PoBlnManufacturerItem, rowCount);
		}
		
		public ICollectionLoadResponse Nontable1Select(int? TRptNum, string PoPoNum, int? PochangeChgNum, DateTime? PochangeChgDate, string PoType, int? PoPrintPrice, int? PoitemPoLine, int? PoitemPoRelease, string PoVendNum, string TAddr0, string TAddr1, string TAddr2, string TAddr4, string UserNamesUserDesc, string PoBuyer, string PoVendLcrNum, string PoFob, string TShipcodeDesc, string TTermsDesc, string PoDropShipNo, int? PoDropSeq, string VendaddrFaxNum, string TSymbol, decimal? TTot, string CurrencyDescription, string PoitemItem, string TVendItem, decimal? TcCprUnitMatCostConv, decimal? PoitemQtyOrderedConv, decimal? TQty, string TRevision, string TDrawingNbr, DateTime? TEffDate, DateTime? TExpDate, decimal? TcAmtPrice, DateTime? PoitemDueDate, int? PoitemExpedited, string PoitemDescription, string PoitemUM, int? TPOBlnNoteExits, int? TPOLineNoteExits, int? TPOChgNoteExits, Guid? PoBlnRowpointer, Guid? PoitemRowpointer, Guid? PochangeRowpointer, string poblndescription, decimal? VatAmt, decimal? VatAmt2, string PoitemTaxCode1, string PoitemTaxCode2, int? VendorPrintVATonPO, string TaxCodeLabel, string TaxCode2Label, string TaxAmtLabel, string TaxAmt2Label, decimal? CostWithoutTax, int? PoIncludeTaxInCost, decimal? TaxAmount, int? PrintVATSummary, string TManufacturerId, string TManufacturerItem, string ItemOverview, string PoVendOrder, string PoItemDeliveryIncoTerm, string DeltermDescription, string PoItemECCode, string PoItemOriginCode, string PoItemCommodityCode, string ParmsURL, string CurrCode, string OfficeAddrFooter, string OfficeEmailAddrFooter, string BankName, string BankTransitNum, string Account)
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "rpt_seq", TRptNum},
					{ "po_num", PoPoNum},
					{ "chg_num", PochangeChgNum},
					{ "chg_date", PochangeChgDate},
					{ "po_type", PoType},
					{ "print_price", PoPrintPrice},
					{ "po_line", PoitemPoLine},
					{ "po_release", PoitemPoRelease},
					{ "vend_num", PoVendNum},
					{ "addr_0", TAddr0},
					{ "addr_1", TAddr1},
					{ "addr_2", TAddr2},
					{ "addr_4", TAddr4},
					{ "buyer", (UserNamesUserDesc!= null ? UserNamesUserDesc : stringUtil.IsNull<string>(
						PoBuyer,
						""))},
					{ "vend_lcr_num", PoVendLcrNum},
					{ "fob", PoFob},
					{ "shipcode_desc", TShipcodeDesc},
					{ "terms_desc", TTermsDesc},
					{ "dropship_num", PoDropShipNo},
					{ "dropship_seq", PoDropSeq},
					{ "fax_num", VendaddrFaxNum},
					{ "std_symbol", TSymbol},
					{ "po_amount", TTot},
					{ "curr_desc", CurrencyDescription},
					{ "item", PoitemItem},
					{ "vend_item", TVendItem},
					{ "unit_mat_cost", TcCprUnitMatCostConv},
					{ "qty_ordered", PoitemQtyOrderedConv},
					{ "qty_due", TQty},
					{ "revision", TRevision},
					{ "drawing_nbr", TDrawingNbr},
					{ "eff_date", TEffDate},
					{ "exp_date", TExpDate},
					{ "amt_ext_price", TcAmtPrice},
					{ "due_date", PoitemDueDate},
					{ "expedited", PoitemExpedited},
					{ "item_Desc", PoitemDescription},
					{ "item_u_m", PoitemUM},
					{ "POBlnNotes", TPOBlnNoteExits},
					{ "POLineNotes", TPOLineNoteExits},
					{ "POChgNotes", TPOChgNoteExits},
					{ "poblnrow", PoBlnRowpointer},
					{ "poitemrow", PoitemRowpointer},
					{ "pochgrow", PochangeRowpointer},
					{ "poblndescription", poblndescription},
					{ "VatAmt", VatAmt},
					{ "VatAmt2", VatAmt2},
					{ "tax_code1", PoitemTaxCode1},
					{ "tax_code2", PoitemTaxCode2},
					{ "print_vat_on_po", VendorPrintVATonPO},
					{ "tax_code_label", TaxCodeLabel},
					{ "tax_code2_label", TaxCode2Label},
					{ "tax_amt_label", TaxAmtLabel},
					{ "tax_amt2_label", TaxAmt2Label},
					{ "Cost_without_tax", CostWithoutTax},
					{ "Include_tax_in_cost", PoIncludeTaxInCost},
					{ "Tax_amt", TaxAmount},
					{ "PrintVATSummary", PrintVATSummary},
					{ "manufacturer_id", TManufacturerId},
					{ "manufacturer_item", TManufacturerItem},
					{ "item_overview", ItemOverview},
					{ "vend_order", PoVendOrder},
					{ "delterm", PoItemDeliveryIncoTerm},
					{ "description", DeltermDescription},
					{ "ec_code", PoItemECCode},
					{ "origin", PoItemOriginCode},
					{ "comm_code", PoItemCommodityCode},
					{ "url", ParmsURL},
					{ "curr_code", CurrCode},
					{ "AddressforReportFooter", OfficeAddrFooter},
					{ "email_addr", OfficeEmailAddrFooter},
					{ "bank_name", BankName},
					{ "bank_transit_num", BankTransitNum},
					{ "account", Account},
			});
			
			return this.appDB.Load(nonTable1LoadRequest);
		}
		public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
		{
			var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ReportSet",
				items: nonTable1LoadResponse.Items);
			
			this.appDB.Insert(nonTable1InsertRequest);
		}
		
		public ICollectionLoadResponse Nontable2Select(string PoPoNum, int? PochangeChgNum, string PoType, int? PoPrintPrice, string TAddr3, string TPoText1, string TPoText2, string TPoText3, string TSymbol, decimal? TTot, string TESymbol, decimal? TEuroTotal, string CurrencyDescription, int? TPONoteExits, Guid? PoRowpointer, int? VendorPrintVATonPO, string TaxCodeLabel, string TaxCode2Label, string TaxAmtLabel, string TaxAmt2Label, int? PrintVATSummary, string PoVendNum, string TAddr0, string TAddr1, string TAddr2, string TAddr4, string UserNamesUserDesc, string PoBuyer, string PoVendLcrNum, string PoFob, string TShipcodeDesc, string TTermsDesc, string PoDropShipNo, int? PoDropSeq, string VendaddrFaxNum, DateTime? PochangeChgDate, string PoVendOrder, string PoItemDeliveryIncoTerm, string DeltermDescription, string PoItemECCode, string PoItemOriginCode, string PoItemCommodityCode, string ParmsURL, string CurrCode, string OfficeAddrFooter, string OfficeEmailAddrFooter, string BankName, string BankTransitNum, string Account)
		{
			var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "rpt_seq", 9999},
					{ "po_num", PoPoNum},
					{ "chg_num", PochangeChgNum},
					{ "po_type", PoType},
					{ "print_price", PoPrintPrice},
					{ "po_line", 9999},
					{ "po_release", 9999},
					{ "addr_3", TAddr3},
					{ "po_text_1", TPoText1},
					{ "po_text_2", TPoText2},
					{ "po_text_3", TPoText3},
					{ "std_symbol", TSymbol},
					{ "po_amount", TTot},
					{ "eur_symbol", TESymbol},
					{ "euro_amount", TEuroTotal},
					{ "curr_desc", CurrencyDescription},
					{ "PONotes", TPONoteExits},
					{ "porow", PoRowpointer},
					{ "print_vat_on_po", VendorPrintVATonPO},
					{ "tax_code_label", TaxCodeLabel},
					{ "tax_code2_label", TaxCode2Label},
					{ "tax_amt_label", TaxAmtLabel},
					{ "tax_amt2_label", TaxAmt2Label},
					{ "PrintVATSummary", PrintVATSummary},
					{ "vend_num", PoVendNum},
					{ "addr_0", TAddr0},
					{ "addr_1", TAddr1},
					{ "addr_2", TAddr2},
					{ "addr_4", TAddr4},
					{ "buyer", (UserNamesUserDesc!= null ? UserNamesUserDesc : stringUtil.IsNull<string>(
						PoBuyer,
						""))},
					{ "vend_lcr_num", PoVendLcrNum},
					{ "fob", PoFob},
					{ "shipcode_desc", TShipcodeDesc},
					{ "terms_desc", TTermsDesc},
					{ "dropship_num", PoDropShipNo},
					{ "dropship_seq", PoDropSeq},
					{ "fax_num", VendaddrFaxNum},
					{ "chg_date", PochangeChgDate},
					{ "vend_order", PoVendOrder},
					{ "delterm", PoItemDeliveryIncoTerm},
					{ "description", DeltermDescription},
					{ "ec_code", PoItemECCode},
					{ "origin", PoItemOriginCode},
					{ "comm_code", PoItemCommodityCode},
					{ "url", ParmsURL},
					{ "curr_code", CurrCode},
					{ "AddressforReportFooter", OfficeAddrFooter},
					{ "email_addr", OfficeEmailAddrFooter},
					{ "bank_name", BankName},
					{ "bank_transit_num", BankTransitNum},
					{ "account", Account},
			});
			
			return this.appDB.Load(nonTable2LoadRequest);
		}
		public void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse)
		{
			var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ReportSet",
				items: nonTable2LoadResponse.Items);
			
			this.appDB.Insert(nonTable2InsertRequest);
		}
		
		public (Guid? XPochangeRowpointer, int? rowCount) Pochangeasx_PochangeLoad(Guid? PochangeRowpointer, Guid? XPochangeRowpointer)
		{
			RowPointerType _XPochangeRowpointer = DBNull.Value;
			
			var pochangeASx_pochangeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XPochangeRowpointer,"x_pochange.rowpointer"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"pochange AS x_pochange",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("x_pochange.RowPointer = {0}",PochangeRowpointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var pochangeASx_pochangeLoadResponse = this.appDB.Load(pochangeASx_pochangeLoadRequest);
			if(pochangeASx_pochangeLoadResponse.Items.Count > 0)
			{
				XPochangeRowpointer = _XPochangeRowpointer;
			}
			
			int rowCount = pochangeASx_pochangeLoadResponse.Items.Count;
			return (XPochangeRowpointer, rowCount);
		}
		
		public ICollectionLoadResponse Pochange1Select(Guid? XPochangeRowpointer)
		{
			var pochange1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","pochange.stat"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"pochange",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}",XPochangeRowpointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(pochange1LoadRequest);
		}
		
		public void Pochange1Update(ICollectionLoadResponse pochange1LoadResponse)
		{
			foreach(var pochange1Item in pochange1LoadResponse.Items){
				pochange1Item.SetValue<string>("stat", "P");
			};
			
			var pochange1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "pochange",
				items: pochange1LoadResponse.Items);
			
			this.appDB.Update(pochange1RequestUpdate);
		}
		
		public ICollectionLoadResponse Nontable3Select(string PoitemPoNum, int? PochangeChgNum, string PrevPoType, int? PrevPoPrintPrice, string TAddr3, string TPoText1, string TPoText2, string TPoText3, string TSymbol, decimal? TTot, string TESymbol, decimal? TEuroTotal, string CurrencyDescription, int? TPONoteExits, Guid? PoRowpointer, int? VendorPrintVATonPO, string TaxCodeLabel, string TaxCode2Label, string TaxAmtLabel, string TaxAmt2Label, int? PrintVATSummary, string PoVendNum, string TAddr0, string TAddr1, string TAddr2, string TAddr4, string UserNamesUserDesc, string PoBuyer, string PoVendLcrNum, string PoFob, string TShipcodeDesc, string TTermsDesc, string PoDropShipNo, int? PoDropSeq, string VendaddrFaxNum, DateTime? PochangeChgDate, string PoVendOrder, string PoItemDeliveryIncoTerm, string DeltermDescription, string PoItemECCode, string PoItemOriginCode, string PoItemCommodityCode, string ParmsURL, string CurrCode, string OfficeAddrFooter, string OfficeEmailAddrFooter, string BankName, string BankTransitNum, string Account)
		{
			var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "rpt_seq", 9999},
					{ "po_num", PoitemPoNum},
					{ "chg_num", PochangeChgNum},
					{ "po_type", PrevPoType},
					{ "print_price", PrevPoPrintPrice},
					{ "po_line", 9999},
					{ "po_release", 9999},
					{ "addr_3", TAddr3},
					{ "po_text_1", TPoText1},
					{ "po_text_2", TPoText2},
					{ "po_text_3", TPoText3},
					{ "std_symbol", TSymbol},
					{ "po_amount", TTot},
					{ "eur_symbol", TESymbol},
					{ "euro_amount", TEuroTotal},
					{ "curr_desc", CurrencyDescription},
					{ "PONotes", TPONoteExits},
					{ "porow", PoRowpointer},
					{ "print_vat_on_po", VendorPrintVATonPO},
					{ "tax_code_label", TaxCodeLabel},
					{ "tax_code2_label", TaxCode2Label},
					{ "tax_amt_label", TaxAmtLabel},
					{ "tax_amt2_label", TaxAmt2Label},
					{ "PrintVATSummary", PrintVATSummary},
					{ "vend_num", PoVendNum},
					{ "addr_0", TAddr0},
					{ "addr_1", TAddr1},
					{ "addr_2", TAddr2},
					{ "addr_4", TAddr4},
					{ "buyer", (UserNamesUserDesc!= null ? UserNamesUserDesc : stringUtil.IsNull<string>(
						PoBuyer,
						""))},
					{ "vend_lcr_num", PoVendLcrNum},
					{ "fob", PoFob},
					{ "shipcode_desc", TShipcodeDesc},
					{ "terms_desc", TTermsDesc},
					{ "dropship_num", PoDropShipNo},
					{ "dropship_seq", PoDropSeq},
					{ "fax_num", VendaddrFaxNum},
					{ "chg_date", PochangeChgDate},
					{ "vend_order", PoVendOrder},
					{ "delterm", PoItemDeliveryIncoTerm},
					{ "description", DeltermDescription},
					{ "ec_code", PoItemECCode},
					{ "origin", PoItemOriginCode},
					{ "comm_code", PoItemCommodityCode},
					{ "url", ParmsURL},
					{ "curr_code", CurrCode},
					{ "AddressforReportFooter", OfficeAddrFooter},
					{ "email_addr", OfficeEmailAddrFooter},
					{ "bank_name", BankName},
					{ "bank_transit_num", BankTransitNum},
					{ "account", Account},
			});
			
			return this.appDB.Load(nonTable3LoadRequest);
		}
		public void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse)
		{
			var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ReportSet",
				items: nonTable3LoadResponse.Items);
			
			this.appDB.Insert(nonTable3InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_ReportsetSelect()
		{
			var tv_ReportSetLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"PrintVATSummary","#tv_ReportSet.PrintVATSummary"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"#tv_ReportSet",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ReportSetLoadRequest);
		}
		
		public void Tv_ReportsetUpdate(int? PrintVATSummary, ICollectionLoadResponse tv_ReportSetLoadResponse)
		{
			foreach(var tv_ReportSetItem in tv_ReportSetLoadResponse.Items){
				tv_ReportSetItem.SetValue<int?>("PrintVATSummary", PrintVATSummary);
			};
			
			var tv_ReportSetRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ReportSet",
				items: tv_ReportSetLoadResponse.Items);
			
			this.appDB.Update(tv_ReportSetRequestUpdate);
		}
		
		public ICollectionLoadResponse Tv_Reportset1Select(int? Severity, int? UseAlternateAddressReportFormat)
		{
			var tv_ReportSet1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"col0seq","seq"},
					{"col1rpt_seq","rpt_seq"},
					{"col2po_num","po_num"},
					{"col3chg_num","chg_num"},
					{"col4chg_date","chg_date"},
					{"col5chg_label_1","chg_label_1"},
					{"col6chg_label_2","chg_label_2"},
					{"col7po_type","po_type"},
					{"col8print_price","print_price"},
					{"col9po_date","po_date"},
					{"col10po_line","po_line"},
					{"col11Po_release","Po_release"},
					{"col12vend_num","vend_num"},
					{"col13addr_0","addr_0"},
					{"col14addr_1","addr_1"},
					{"col15addr_2","addr_2"},
					{"col16addr_3","addr_3"},
					{"col17addr_4","addr_4"},
					{"col18buyer","buyer"},
					{"col19vend_lcr_num","vend_lcr_num"},
					{"col20fob","fob"},
					{"col21shipcode_desc","shipcode_desc"},
					{"col22terms_desc","terms_desc"},
					{"col23dropship_num","dropship_num"},
					{"col24dropship_seq","dropship_seq"},
					{"col25fax_num","fax_num"},
					{"col26item","item"},
					{"col27vend_item","vend_item"},
					{"col28unit_mat_cost","unit_mat_cost"},
					{"col29qty_ordered","qty_ordered"},
					{"col30qty_due","qty_due"},
					{"col31revision","revision"},
					{"col32drawing_nbr","drawing_nbr"},
					{"col33eff_date","eff_date"},
					{"col34exp_date","exp_date"},
					{"col35amt_ext_price","amt_ext_price"},
					{"col36due_date","due_date"},
					{"col37expedited","expedited"},
					{"col38item_Desc","item_Desc"},
					{"col39item_u_m","item_u_m"},
					{"col40po_text_1","po_text_1"},
					{"col41po_text_2","po_text_2"},
					{"col42po_text_3","po_text_3"},
					{"col43std_symbol","std_symbol"},
					{"col44po_amount","po_amount"},
					{"col45eur_symbol","eur_symbol"},
					{"col46euro_amount","euro_amount"},
					{"col47curr_desc","curr_desc"},
					{"col48LcrNumLabel","LcrNumLabel"},
					{"col49FaxLabel","FaxLabel"},
					{"col50DrawingLabel","DrawingLabel"},
					{"col51RevisionLabel","RevisionLabel"},
					{"col52EffectiveDatelabel","EffectiveDatelabel"},
					{"col53Expirationdatelabel","Expirationdatelabel"},
					{"col54RelText","RelText"},
					{"col55DropShipToLabel","DropShipToLabel"},
					{"col56CurrencyLabel","CurrencyLabel"},
					{"col57PONotes","PONotes"},
					{"col58POBlnNotes","POBlnNotes"},
					{"col59POLineNotes","POLineNotes"},
					{"col60POChgNotes","POChgNotes"},
					{"col61porow","porow"},
					{"col62poblnrow","poblnrow"},
					{"col63poitemrow","poitemrow"},
					{"col64pochgrow","pochgrow"},
					{"col65poblndescription","poblndescription"},
					{"col66VatAmt","VatAmt"},
					{"col67VatAmt2","VatAmt2"},
					{"col68tax_code1","tax_code1"},
					{"col69tax_code2","tax_code2"},
					{"col70print_vat_on_po","print_vat_on_po"},
					{"col71tax_code_label","tax_code_label"},
					{"col72tax_code2_label","tax_code2_label"},
					{"col73tax_amt_label","tax_amt_label"},
					{"col74tax_amt2_label","tax_amt2_label"},
					{"col75Cost_without_tax","Cost_without_tax"},
					{"col76Include_tax_in_cost","Include_tax_in_cost"},
					{"col77Tax_amt","Tax_amt"},
					{"col78PrintVATSummary","PrintVATSummary"},
					{"col79manufacturer_id","manufacturer_id"},
					{"col80manufacturer_item","manufacturer_item"},
					{"col81item_overview","item_overview"},
					{"col82vend_order","vend_order"},
					{"col83delterm","delterm"},
					{"col84description","description"},
					{"col85ec_code","ec_code"},
					{"col86origin","origin"},
					{"col87comm_code","comm_code"},
					{"col88url","url"},
					{"col89curr_code","curr_code"},
					{"col90AddressforReportFooter","AddressforReportFooter"},
					{"col91email_addr","email_addr"},
					{"col92bank_name","bank_name"},
					{"col93bank_transit_num","bank_transit_num"},
					{"col94account","account"},
					{"UseAlternateAddressReportFormat",$"{variableUtil.GetQuotedValue<int?>(UseAlternateAddressReportFormat)}"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#tv_ReportSet",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("{0} = 0",Severity),
				orderByClause: collectionLoadRequestFactory.Clause(" po_num, seq, po_line, po_release"));
			return this.appDB.Load(tv_ReportSet1LoadRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_ChangeOrderSp(
			string AltExtGenSp,
			string pPoType = null,
			string pPoStat = null,
			string pPoitemStat = null,
			int? pRoundPlaces = null,
			string pPrintItemIV = null,
			int? pPrPoTxt = null,
			int? pPrPoBlnTxt = null,
			int? pPrPoLineTxt = null,
			string pPRPoChg = null,
			string pChgStat = null,
			int? pTransDomCurr = null,
			int? pPrintEuro = null,
			string pStartPoNum = null,
			string pEndPoNum = null,
			int? pStartPoLine = null,
			int? pEndPoLine = null,
			int? pStartPoRElease = null,
			int? pEndPoRelease = null,
			string pStartvendor = null,
			string pEndVendor = null,
			int? pShowExternal1 = null,
			int? pShowInternal1 = null,
			int? pPrintPOTable = null,
			int? pPrintpoitem = null,
			int? pPrintpo_bln = null,
			int? pPrintpochange = null,
			int? TaskId = null,
			int? pPrintManufacturerItem = 0,
			string ReviewPrint = null,
			string pSite = null,
			int? pPrintItemOverview = null,
			int? PrintDrawingNumber = 0,
			int? PrintDeliveryIncoTerms = 0,
			int? PrintEUCode = 0,
			int? PrintOriginCode = 0,
			int? PrintCommodityCode = 0,
			int? PrintHeaderOnAllPages = 0,
			int? PrintAuthorizationSignatures = 0)
		{
			Infobar _pPoType = pPoType;
			Infobar _pPoStat = pPoStat;
			Infobar _pPoitemStat = pPoitemStat;
			GenericIntType _pRoundPlaces = pRoundPlaces;
			Infobar _pPrintItemIV = pPrintItemIV;
			ListYesNoType _pPrPoTxt = pPrPoTxt;
			ListYesNoType _pPrPoBlnTxt = pPrPoBlnTxt;
			ListYesNoType _pPrPoLineTxt = pPrPoLineTxt;
			Infobar _pPRPoChg = pPRPoChg;
			Infobar _pChgStat = pChgStat;
			ListYesNoType _pTransDomCurr = pTransDomCurr;
			ListYesNoType _pPrintEuro = pPrintEuro;
			PoNumType _pStartPoNum = pStartPoNum;
			PoNumType _pEndPoNum = pEndPoNum;
			PoLineType _pStartPoLine = pStartPoLine;
			PoLineType _pEndPoLine = pEndPoLine;
			PoReleaseType _pStartPoRElease = pStartPoRElease;
			PoReleaseType _pEndPoRelease = pEndPoRelease;
			VendNumType _pStartvendor = pStartvendor;
			VendNumType _pEndVendor = pEndVendor;
			ListYesNoType _pShowExternal1 = pShowExternal1;
			ListYesNoType _pShowInternal1 = pShowInternal1;
			ListYesNoType _pPrintPOTable = pPrintPOTable;
			ListYesNoType _pPrintpoitem = pPrintpoitem;
			ListYesNoType _pPrintpo_bln = pPrintpo_bln;
			ListYesNoType _pPrintpochange = pPrintpochange;
			TaskNumType _TaskId = TaskId;
			ListYesNoType _pPrintManufacturerItem = pPrintManufacturerItem;
			StringType _ReviewPrint = ReviewPrint;
			SiteType _pSite = pSite;
			ListYesNoType _pPrintItemOverview = pPrintItemOverview;
			ListYesNoType _PrintDrawingNumber = PrintDrawingNumber;
			ListYesNoType _PrintDeliveryIncoTerms = PrintDeliveryIncoTerms;
			ListYesNoType _PrintEUCode = PrintEUCode;
			ListYesNoType _PrintOriginCode = PrintOriginCode;
			ListYesNoType _PrintCommodityCode = PrintCommodityCode;
			ListYesNoType _PrintHeaderOnAllPages = PrintHeaderOnAllPages;
			ListYesNoType _PrintAuthorizationSignatures = PrintAuthorizationSignatures;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRoundPlaces", _pRoundPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintItemIV", _pPrintItemIV, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoTxt", _pPrPoTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoBlnTxt", _pPrPoBlnTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoLineTxt", _pPrPoLineTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPRPoChg", _pPRPoChg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChgStat", _pChgStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDomCurr", _pTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintEuro", _pPrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoRElease", _pStartPoRElease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoRelease", _pEndPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartvendor", _pStartvendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowExternal1", _pShowExternal1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowInternal1", _pShowInternal1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintPOTable", _pPrintPOTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintpoitem", _pPrintpoitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintpo_bln", _pPrintpo_bln, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintpochange", _pPrintpochange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintManufacturerItem", _pPrintManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReviewPrint", _ReviewPrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintItemOverview", _pPrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDrawingNumber", _PrintDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDeliveryIncoTerms", _PrintDeliveryIncoTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEUCode", _PrintEUCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOriginCode", _PrintOriginCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCommodityCode", _PrintCommodityCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintHeaderOnAllPages", _PrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintAuthorizationSignatures", _PrintAuthorizationSignatures, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;
				
				return (resultSet, returnCode);
			}
		}
		
	}
}
