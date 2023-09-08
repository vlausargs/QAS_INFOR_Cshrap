//PROJECT NAME: Production
//CLASS NAME: LocalDisplayForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class LocalDisplayForCurrOper : ILocalDisplayForCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public LocalDisplayForCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? WcStat,
		string Infobar) LocalDisplayForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		int? WcStat,
		string Infobar)
		{
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _JobType = JobType;
			ListYesNoType _WcStat = WcStat;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LocalDisplayForCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WcStat", _WcStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WcStat = _WcStat;
				Infobar = _Infobar;
				
				return (Severity, WcStat, Infobar);
			}
		}
	}
}
