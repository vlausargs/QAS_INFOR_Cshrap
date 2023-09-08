//PROJECT NAME: Finance
//CLASS NAME: GetNextReconciliationTypeNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetNextReconciliationTypeNum : IGetNextReconciliationTypeNum
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextReconciliationTypeNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextCheckNumber) GetNextReconciliationTypeNumSp(string BankCode,
		string PayType,
		int? NextCheckNumber)
		{
			BankCodeType _BankCode = BankCode;
			LongList _PayType = PayType;
			GlCheckNumType _NextCheckNumber = NextCheckNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextReconciliationTypeNumSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextCheckNumber", _NextCheckNumber, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextCheckNumber = _NextCheckNumber;
				
				return (Severity, NextCheckNumber);
			}
		}
	}
}
