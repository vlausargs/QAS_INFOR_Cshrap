//PROJECT NAME: Logistics
//CLASS NAME: ARPayPostCreateTmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPayPostCreateTmp : IARPayPostCreateTmp
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ARPayPostCreateTmp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ARPayPostCreateTmpSp(string PStartCustNum,
		string PEndCustNum,
		string PStartBnkCode,
		string PEndBnkCode,
		DateTime? StartDate,
		DateTime? EndDate,
		int? StartChkNum,
		int? EndChkNum,
		string StartCreditMemo,
		string EndCreditMemo,
		string PType,
		Guid? PSessionID,
		int? CalledFromBackground = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _PStartCustNum = PStartCustNum;
				CustNumType _PEndCustNum = PEndCustNum;
				BankCodeType _PStartBnkCode = PStartBnkCode;
				BankCodeType _PEndBnkCode = PEndBnkCode;
				DateTimeType _StartDate = StartDate;
				DateTimeType _EndDate = EndDate;
				ArCheckNumType _StartChkNum = StartChkNum;
				ArCheckNumType _EndChkNum = EndChkNum;
				InvNumType _StartCreditMemo = StartCreditMemo;
				InvNumType _EndCreditMemo = EndCreditMemo;
				ArpmtTypeType _PType = PType;
				RowPointer _PSessionID = PSessionID;
				ListYesNoType _CalledFromBackground = CalledFromBackground;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ARPayPostCreateTmpSp";
					
					appDB.AddCommandParameter(cmd, "PStartCustNum", _PStartCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndCustNum", _PEndCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartBnkCode", _PStartBnkCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndBnkCode", _PEndBnkCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartChkNum", _StartChkNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndChkNum", _EndChkNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCreditMemo", _StartCreditMemo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCreditMemo", _EndCreditMemo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CalledFromBackground", _CalledFromBackground, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
