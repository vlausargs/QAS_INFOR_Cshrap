//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateOperComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Pojob3PValidateOperComplete : IPojob3PValidateOperComplete
	{
		readonly IApplicationDB appDB;
		
		
		public Pojob3PValidateOperComplete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) Pojob3PValidateOperCompleteSp(string TJob,
		int? TSuffix,
		int? TOper,
		int? TOperComplete,
		string Infobar)
		{
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOper = TOper;
			ListYesNoType _TOperComplete = TOperComplete;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3PValidateOperCompleteSp";
				
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOper", _TOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOperComplete", _TOperComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
