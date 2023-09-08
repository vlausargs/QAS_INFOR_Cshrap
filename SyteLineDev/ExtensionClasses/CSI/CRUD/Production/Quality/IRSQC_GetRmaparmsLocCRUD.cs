//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetRmaparmsLocCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetRmaparmsLocCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string Loc, int? NeedsQC, int? rowCount) Rs_QcparmcuLoad(string Loc, int? NeedsQC);
		(int? ReturnCode, string Loc,int? NeedsQC) AltExtGen_RSQC_GetRmaparmsLocSp(string AltExtGenSp, string Loc, int? NeedsQC);
	}
}

