//PROJECT NAME: Logistics
//CLASS NAME: ProfileRMACreditMemo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ProfileRMACreditMemo : IProfileRMACreditMemo
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileRMACreditMemo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileRMACreditMemoSp(string BCrmNum = null,
		string ECrmNum = null,
		DateTime? BCrmDate = null,
		DateTime? ECrmDate = null)
		{
			InvNumType _BCrmNum = BCrmNum;
			InvNumType _ECrmNum = ECrmNum;
			DateType _BCrmDate = BCrmDate;
			DateType _ECrmDate = ECrmDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileRMACreditMemoSp";
				
				appDB.AddCommandParameter(cmd, "BCrmNum", _BCrmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECrmNum", _ECrmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCrmDate", _BCrmDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECrmDate", _ECrmDate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
