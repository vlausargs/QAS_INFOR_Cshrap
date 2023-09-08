//PROJECT NAME: Production
//CLASS NAME: PreSaveCostAltCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PreSaveCostAltCurrOper : IPreSaveCostAltCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public PreSaveCostAltCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Job,
		int? Suffix,
		string JobType,
		string Infobar) PreSaveCostAltCurrOperSp(string CostingAlt,
		string Item,
		int? OperNum,
		string Wc,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar)
		{
			CostingAlternativeType _CostingAlt = CostingAlt;
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _JobType = JobType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreSaveCostAltCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				JobType = _JobType;
				Infobar = _Infobar;
				
				return (Severity, Job, Suffix, JobType, Infobar);
			}
		}
	}
}
