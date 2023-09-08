//PROJECT NAME: Finance
//CLASS NAME: VoidAPPostedPaymentsPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class VoidAPPostedPaymentsPre : IVoidAPPostedPaymentsPre
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public VoidAPPostedPaymentsPre(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) VoidAPPostedPaymentsPreSp(Guid? SessionID,
		string pBankCode,
		int? pBegCheckNum,
		int? pEndCheckNum,
		string PayType)
		{
			RowPointerType _SessionID = SessionID;
			BankCodeType _pBankCode = pBankCode;
			GlCheckNumType _pBegCheckNum = pBegCheckNum;
			GlCheckNumType _pEndCheckNum = pEndCheckNum;
			GlbankTypeType _PayType = PayType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoidAPPostedPaymentsPreSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegCheckNum", _pBegCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCheckNum", _pEndCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
