//PROJECT NAME: Data
//CLASS NAME: BldLstWhseJobmatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BldLstWhseJobmatl : IBldLstWhseJobmatl
	{
		readonly IApplicationDB appDB;
		
		public BldLstWhseJobmatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BldLstWhseJobmatlSp(
			string Job,
			int? Suffix,
			int? StartOperNum,
			int? EndOperNum,
			string CurWhse,
			string ReprintPick)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _StartOperNum = StartOperNum;
			OperNumType _EndOperNum = EndOperNum;
			WhseType _CurWhse = CurWhse;
			StringType _ReprintPick = ReprintPick;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BldLstWhseJobmatlSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOperNum", _StartOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOperNum", _EndOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReprintPick", _ReprintPick, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
