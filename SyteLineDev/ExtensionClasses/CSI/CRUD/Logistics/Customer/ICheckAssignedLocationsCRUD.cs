//PROJECT NAME: Logistics
//CLASS NAME: ICheckAssignedLocationsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckAssignedLocationsCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		bool Tmp_Pick_List_LocForExists(Guid? ProcessId);
		(string PCoitemCoNum,
			 int? PCoitemCoLine,
			 int? PCoitemCoRelease,
			 string PCoitemItem,
			 string PCoitemLoc,
			 decimal? PQtyToPick, int? rowCount) Tmp_Pick_List_Loc1Load(Guid? ProcessId, decimal? PQtyToPick, string PCoitemCoNum, int? PCoitemCoLine, int? PCoitemCoRelease, string PCoitemItem, string PCoitemLoc);
		(int? ReturnCode, string Infobar) AltExtGen_CheckAssignedLocationsSp(string AltExtGenSp, Guid? ProcessId, string Infobar);
	}
}

