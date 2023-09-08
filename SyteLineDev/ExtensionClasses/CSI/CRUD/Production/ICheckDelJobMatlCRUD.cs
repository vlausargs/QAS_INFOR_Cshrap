//PROJECT NAME: Production
//CLASS NAME: ICheckDelJobMatlCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckDelJobMatlCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		bool JobmatlForExists(string Job, int? Suffix, int? OperNum, int? AltGroup);
		(int? ReturnCode, string Infobar) AltExtGen_CheckDelJobMatlSp(string AltExtGenSp, string Job, int? Suffix, int? OperNum, int? AltGroup, int? AltGroupRank, string Infobar);
	}
}

