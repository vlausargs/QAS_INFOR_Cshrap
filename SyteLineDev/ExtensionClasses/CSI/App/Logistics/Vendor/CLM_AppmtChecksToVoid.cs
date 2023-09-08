//PROJECT NAME: Logistics
//CLASS NAME: CLM_AppmtChecksToVoid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_AppmtChecksToVoid : ICLM_AppmtChecksToVoid
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_AppmtChecksToVoid(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_AppmtChecksToVoidSp(string PPayCode,
		string PBankCode,
		string PStartingVendNum,
		string PEndingVendNum,
		string PStartingVendName,
		string PEndingVendName,
		int? PStartingCheckNum,
		int? PEndingCheckNum)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				AppmtPayTypeType _PPayCode = PPayCode;
				BankCodeType _PBankCode = PBankCode;
				VendNumType _PStartingVendNum = PStartingVendNum;
				VendNumType _PEndingVendNum = PEndingVendNum;
				NameType _PStartingVendName = PStartingVendName;
				NameType _PEndingVendName = PEndingVendName;
				ApCheckNumType _PStartingCheckNum = PStartingCheckNum;
				ApCheckNumType _PEndingCheckNum = PEndingCheckNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_AppmtChecksToVoidSp";
					
					appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingCheckNum", _PStartingCheckNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingCheckNum", _PEndingCheckNum, ParameterDirection.Input);
					
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
