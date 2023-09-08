//PROJECT NAME: Material
//CLASS NAME: ICheckItemAllsForSiteCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckItemAllsForSiteCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string Site, int? rowCount) LoadParms(string Site);
		bool Item_AllForExists(string Site, string SupplySite, string Item);
		(int? ReturnCode, string Infobar) AltExtGen_CheckItemAllsForSiteSp(string AltExtGenSp, string Site, string SupplySite, string Item, string Infobar);
	}
}

