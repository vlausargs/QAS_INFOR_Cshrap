//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsDeleteCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsDeleteCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(Guid? ItemPointer, int? rowCount) LoadItemLoad(string ItmItem, Guid? ItemPointer);
		(int? ReturnCode, string Infobar) AltExtGen_CurrentMaterialsDeleteSp(string AltExtGenSp, string JobType, string ItmItem, string Infobar);
	}
}

