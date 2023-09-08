//PROJECT NAME: Production
//CLASS NAME: ICLM_InvMsNomCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_InvMsNomCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereStr, string Filter);
		void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse);
		void Invmsnom1Insert(ICollectionLoadResponse InvMsNom1ExecResultLoadResponse);
		ICollectionLoadResponse Invmsnom2Select();
		ICollectionLoadResponse Invmsnom3Select(string ProjNum, string InvMsNum);
		void Invmsnom3Update(int? DerCurrentPeriod, DateTime? DerCurrentPeriodStart, DateTime? DerCurrentPeriodEnd, decimal? DerTotPerPlanInvAmt, decimal? DerTotPerNomPlanInvAmt, decimal? DerTotYrPlanInvAmt, decimal? DerTotYrNomPlanInvAmt, decimal? DerTotPerActInvAmt, decimal? DerTotPerNomActInvAmt, decimal? DerTotYrActInvAmt, decimal? DerTotYrNomActInvAmt, int? DerNominated, decimal? DerActInvAmt, DateTime? DerActDate, ICollectionLoadResponse InvMsNom3LoadResponse);
		ICollectionLoadResponse Dynamicparameters1Select();
		void Dynamicparameters1Delete(ICollectionLoadResponse DynamicParameters1LoadResponse);
		ICollectionLoadResponse NontableSelect();
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_InvMsNomSp(string AltExtGenSp, DateTime? PActDate, DateTime? PPlanDate, string Filter);
	}
}

