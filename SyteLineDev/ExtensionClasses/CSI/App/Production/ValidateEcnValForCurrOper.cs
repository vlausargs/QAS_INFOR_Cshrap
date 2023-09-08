//PROJECT NAME: Production
//CLASS NAME: ValidateEcnValForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateEcnValForCurrOper : IValidateEcnValForCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateEcnValForCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Job,
		int? Suffix,
		string JobType,
		string Infobar) ValidateEcnValForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar)
		{
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _JobType = JobType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateEcnValForCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
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
