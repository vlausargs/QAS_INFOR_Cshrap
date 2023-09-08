//PROJECT NAME: Logistics
//CLASS NAME: CLM_ArPmtpck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_ArPmtpck : ICLM_ArPmtpck
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ArPmtpck(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ArPmtpckSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		string PCreditMemoNum,
		string PFilter = null,
		Guid? PProcessId = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				BankCodeType _PBankCode = PBankCode;
				CustNumType _PCustNum = PCustNum;
				ArpmtTypeType _PType = PType;
				ArCheckNumType _PCheckNum = PCheckNum;
				InvNumType _PCreditMemoNum = PCreditMemoNum;
				LongListType _PFilter = PFilter;
				RowPointerType _PProcessId = PProcessId;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ArPmtpckSp";
					
					appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFilter", _PFilter, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
					
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
