//PROJECT NAME: Logistics
//CLASS NAME: ITableSharedSitesCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITableSharedSitesCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectParms();
		ICollectionLoadResponse SelectRep_Rule(string TableName);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_TableSharedSitesSp(string AltExtGenSp, string TableName);
	}
}

