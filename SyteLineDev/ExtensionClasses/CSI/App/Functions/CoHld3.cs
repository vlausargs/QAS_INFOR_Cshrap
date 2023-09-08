//PROJECT NAME: Data
//CLASS NAME: CoHld3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoHld3 : ICoHld3
	{
		readonly IApplicationDB appDB;
		
		public CoHld3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? POutstandingBalance,
			int? PProcessCreditHold) CoHld3Sp(
			string PCustNum,
			string PSite,
			string PInvDue,
			DateTime? PAgingDate,
			decimal? POutstandingBalance,
			int? PProcessCreditHold)
		{
			CustNumType _PCustNum = PCustNum;
			SiteType _PSite = PSite;
			ArAgeByType _PInvDue = PInvDue;
			DateType _PAgingDate = PAgingDate;
			AmountType _POutstandingBalance = POutstandingBalance;
			FlagNyType _PProcessCreditHold = PProcessCreditHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoHld3Sp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDue", _PInvDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAgingDate", _PAgingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutstandingBalance", _POutstandingBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProcessCreditHold", _PProcessCreditHold, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POutstandingBalance = _POutstandingBalance;
				PProcessCreditHold = _PProcessCreditHold;
				
				return (Severity, POutstandingBalance, PProcessCreditHold);
			}
		}
	}
}
