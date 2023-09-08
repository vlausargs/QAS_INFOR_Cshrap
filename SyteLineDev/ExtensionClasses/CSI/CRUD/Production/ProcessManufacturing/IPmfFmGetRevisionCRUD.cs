//PROJECT NAME: Production
//CLASS NAME: IPmfFmGetRevisionCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmGetRevisionCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? NextRevNo, int? rowCount) Pmf_FormulaasfmLoad(string Fm, string FmVer, int? NextRevNo);
		(int? ReturnCode, string InfoBar,int? NextRevNo) AltExtGen_PmfFmGetRevisionSp(string AltExtGenSp, string InfoBar, string Fm, string FmVer, int? NextRevNo);
	}
}

