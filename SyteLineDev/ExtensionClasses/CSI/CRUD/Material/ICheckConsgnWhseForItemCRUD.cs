//PROJECT NAME: Material
//CLASS NAME: ICheckConsgnWhseForItemCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckConsgnWhseForItemCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		bool WhseForExists(string Whse);
		bool ItemwhseForExists(string Item, string Whse);
		(int? ReturnCode, string Infobar) AltExtGen_CheckConsgnWhseForItemSp(string AltExtGenSp, string Item, string Whse, string Infobar);
	}
}

