//PROJECT NAME: Finance
//CLASS NAME: MultiFSBInitPeriodsTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBInitPeriodsTable
	{
		int? MultiFSBInitPeriodsTableSp(string PeriodName,
		                                string PeriodDesc);
	}
	
	public class MultiFSBInitPeriodsTable : IMultiFSBInitPeriodsTable
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBInitPeriodsTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MultiFSBInitPeriodsTableSp(string PeriodName,
		                                       string PeriodDesc)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			DescriptionType _PeriodDesc = PeriodDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBInitPeriodsTableSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodDesc", _PeriodDesc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
