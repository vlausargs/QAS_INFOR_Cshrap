//PROJECT NAME: Logistics
//CLASS NAME: ValidateToBeShippedRecord.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateToBeShippedRecord : IValidateToBeShippedRecord
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateToBeShippedRecord(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pResult,
		string pDoNum) ValidateToBeShippedRecordSP(int? pBatchID = null,
		int? pResult = null,
		string pDoNum = null)
		{
			BatchIdType _pBatchID = pBatchID;
			IntType _pResult = pResult;
			DoNumType _pDoNum = pDoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateToBeShippedRecordSP";
				
				appDB.AddCommandParameter(cmd, "pBatchID", _pBatchID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pResult", _pResult, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pDoNum", _pDoNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pResult = _pResult;
				pDoNum = _pDoNum;
				
				return (Severity, pResult, pDoNum);
			}
		}
	}
}
