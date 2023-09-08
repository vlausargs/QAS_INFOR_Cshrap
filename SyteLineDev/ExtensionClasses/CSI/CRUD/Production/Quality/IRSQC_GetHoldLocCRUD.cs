//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetHoldLocCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetHoldLocCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string o_hold_loc, int? o_use_hold_loc, int? rowCount) Rs_QcparmsuLoad(string o_hold_loc, int? o_use_hold_loc);
		(int? ReturnCode, string o_hold_loc,int? o_use_hold_loc) AltExtGen_RSQC_GetHoldLocSp(string AltExtGenSp, string o_hold_loc, int? o_use_hold_loc);
	}
}

