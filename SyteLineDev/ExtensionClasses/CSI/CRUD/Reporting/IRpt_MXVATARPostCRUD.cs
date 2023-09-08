//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXVATARPostCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXVATARPostCRUD
	{
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectMX_Tt_Vat_Post();
		void DeleteMX_Tt_Vat_Post(ICollectionLoadResponse MX_tt_vat_post1LoadResponse);
		ICollectionLoadResponse SelectMX_Tt_Vat_Post_RowPointer();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_MXVATARPostSp(string AltExtGenSp);
	}
}

