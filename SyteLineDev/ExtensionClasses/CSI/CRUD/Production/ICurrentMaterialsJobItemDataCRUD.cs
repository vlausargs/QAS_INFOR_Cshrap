//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsJobItemDataCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsJobItemDataCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? ItemPlanFlag, int? rowCount) LoadItem(string Item, int? ItemPlanFlag);
		(int? ReturnCode, int? ItemPlanFlag) AltExtGen_CurrentMaterialsJobItemDataSp(string AltExtGenSp, string Item, int? ItemPlanFlag);
	}
}

