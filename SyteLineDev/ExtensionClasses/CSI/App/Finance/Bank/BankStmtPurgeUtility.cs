//PROJECT NAME: Finance
//CLASS NAME: BankStmtPurgeUtility.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Bank
{
	public class BankStmtPurgeUtility : IBankStmtPurgeUtility
	{
		readonly IApplicationDB appDB;
		
		public BankStmtPurgeUtility(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) BankStmtPurgeUtilitySp(
			DateTime? PeriodStartingDate,
			DateTime? PeriodEndingDate,
			string ReferenceTypeStarting,
			string ReferenceTypeEnding,
			string ReferenceNumberStarting,
			string ReferenceNumberEnding,
			int? PeriodEndingDateOffset,
			string InfoBar)
		{
			DateTimeType _PeriodStartingDate = PeriodStartingDate;
			DateTimeType _PeriodEndingDate = PeriodEndingDate;
			ReferenceType _ReferenceTypeStarting = ReferenceTypeStarting;
			ReferenceType _ReferenceTypeEnding = ReferenceTypeEnding;
			StringType _ReferenceNumberStarting = ReferenceNumberStarting;
			StringType _ReferenceNumberEnding = ReferenceNumberEnding;
			DateOffsetType _PeriodEndingDateOffset = PeriodEndingDateOffset;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BankStmtPurgeUtilitySp";
				
				appDB.AddCommandParameter(cmd, "PeriodStartingDate", _PeriodStartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEndingDate", _PeriodEndingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceTypeStarting", _ReferenceTypeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceTypeEnding", _ReferenceTypeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceNumberStarting", _ReferenceNumberStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceNumberEnding", _ReferenceNumberEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEndingDateOffset", _PeriodEndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
