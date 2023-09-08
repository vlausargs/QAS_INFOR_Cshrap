//PROJECT NAME: Production
//CLASS NAME: ICLM_JobRouteOEECRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_JobRouteOEECRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectOEE(string StrOEE, string StrWaste, decimal? JobRoutesOEE);
		ICollectionLoadResponse SelectWaste(decimal? JobRoutesWASTE, string StrWaste);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_JobRouteOEESp(string AltExtGenSp, decimal? OEE);
	}
}

