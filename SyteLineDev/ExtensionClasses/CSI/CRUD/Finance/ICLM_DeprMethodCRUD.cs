//PROJECT NAME: Finance
//CLASS NAME: ICLM_DeprMethodCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_DeprMethodCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectDeprmethod();
		ICollectionLoadResponse SelectMethodSL();
		ICollectionLoadResponse SelectMethodSYD();
		ICollectionLoadResponse SelectMethodUSAGE();
		ICollectionLoadResponse SelectMethod125DB();
		ICollectionLoadResponse SelectMethod150DB();
		ICollectionLoadResponse SelectMethod175DB();
		ICollectionLoadResponse SelectMethod200DB();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_DeprMethodSp(string AltExtGenSp);
	}
}

