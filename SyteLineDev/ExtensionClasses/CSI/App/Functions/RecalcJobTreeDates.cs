//PROJECT NAME: Data
//CLASS NAME: RecalcJobTreeDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RecalcJobTreeDates : IRecalcJobTreeDates
	{
		readonly IApplicationDB appDB;
		
		public RecalcJobTreeDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RecalcJobTreeDatesSp(
			string pJob,
			int? pSuffix,
			decimal? PHrsPerDay,
			int? PoverwriteDates,
			string Infobar)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			GenericDecimalType _PHrsPerDay = PHrsPerDay;
			ListYesNoType _PoverwriteDates = PoverwriteDates;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RecalcJobTreeDatesSp";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHrsPerDay", _PHrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoverwriteDates", _PoverwriteDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
