//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitWarrDelCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitWarrDelCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Fs_Unit_WarrSelect(int? CompId, string WarrCode);
		void Fs_Unit_WarrDelete(ICollectionLoadResponse fs_unit_warrLoadResponse);
		int? AltExtGen_SSSFSUnitWarrDelSp(string AltExtGenSp, int? CompId, string WarrCode);
	}
}

