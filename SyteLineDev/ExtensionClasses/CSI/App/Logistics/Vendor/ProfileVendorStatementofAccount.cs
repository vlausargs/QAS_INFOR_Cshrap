//PROJECT NAME: Logistics
//CLASS NAME: ProfileVendorStatementofAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ProfileVendorStatementofAccount : IProfileVendorStatementofAccount
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileVendorStatementofAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileVendorStatementofAccountSp(DateTime? CutOffDate = null,
		string StartVendNum = null,
		string EndVendNum = null)
		{
			DateType _CutOffDate = CutOffDate;
			VendNumType _StartVendNum = StartVendNum;
			VendNumType _EndVendNum = EndVendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileVendorStatementofAccountSp";
				
				appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendNum", _StartVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
