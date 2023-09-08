//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CostToCompleteLogCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CostToCompleteLogCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Tv_Rpt_SetSelect();
		void Tv_Rpt_SetDelete(ICollectionLoadResponse tv_rpt_setLoadResponse);
		ICollectionLoadResponse ProjSelect(string ProjectStarting, string ProjectEnding, int? TaskStarting, int? TaskEnding, string CostCodeStarting, string CostCodeEnding, string ProjectStatus, DateTime? Date);
		(decimal? a_units,
			 decimal? a_cost,
			 decimal? units,
			 decimal? fcst_cost,
			 decimal? plan_units,
			 decimal? plan_cost,
			 DateTime? snap_date, int? rowCount) Ctc_LogLoad(DateTime? Date, string proj_num, int? task_num, string cost_code, DateTime? snap_date, decimal? a_units, decimal? a_cost, decimal? units, decimal? plan_units, decimal? fcst_cost, decimal? plan_cost);
		ICollectionLoadResponse NontableSelect(string proj_num, string proj_desc, string stat, string cust_num, int? cust_seq, string name, string contract, DateTime? snap_date, int? task_num, string task_desc, string cost_class, string cost_code, string cost_desc, decimal? a_units, decimal? a_cost, decimal? units, decimal? plan_units, decimal? fcst_cost, decimal? plan_cost, decimal? cost_to_complete, decimal? cost_to_complete_units);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse Tv_Rpt_Set1Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_CostToCompleteLogSp(string AltExtGenSp, string ProjectStarting, string ProjectEnding, int? TaskStarting, int? TaskEnding, string CostCodeStarting, string CostCodeEnding, string ProjectStatus, DateTime? Date, int? DateOffset, int? Printcost, int? DisplayHeader, string pSite);
	}
}

