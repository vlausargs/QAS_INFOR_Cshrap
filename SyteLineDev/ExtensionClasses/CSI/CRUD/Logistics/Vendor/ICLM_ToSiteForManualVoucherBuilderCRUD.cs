//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ToSiteForManualVoucherBuilderCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_ToSiteForManualVoucherBuilderCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string CurrparmsCurrCode, int? rowCount) LoadCurrparms(string CurrparmsCurrCode);
		(string ParmsSite, int? rowCount) LoadParms(string ParmsSite);
		ICollectionLoadResponse SelectParmsSite(string ParmsSite);
		ICollectionLoadResponse SelectTmp_Mvb(string PVendNum, string CurrparmsCurrCode, string ParmsSite);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ToSiteForManualVoucherBuilderSp(string AltExtGenSp, string PVendNum);
	}
}

