//PROJECT NAME: Finance
//CLASS NAME: FSBGetDescriptionByPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FSBGetDescriptionByPeriod : IFSBGetDescriptionByPeriod
	{
		readonly IApplicationDB appDB;
		
		
		public FSBGetDescriptionByPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PeriodDescription) FSBGetDescriptionByPeriodSp(string PeriodName,
		string PeriodDescription)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			DescriptionType _PeriodDescription = PeriodDescription;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FSBGetDescriptionByPeriodSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodDescription", _PeriodDescription, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PeriodDescription = _PeriodDescription;
				
				return (Severity, PeriodDescription);
			}
		}
	}
}
