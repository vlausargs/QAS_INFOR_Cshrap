//PROJECT NAME: Logistics
//CLASS NAME: ProfileAPEftPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ProfileAPEftPosting : IProfileAPEftPosting
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileAPEftPosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileAPEftPostingSp(Guid? ProcessID = null,
		string BankCode = null,
		string StartVendNum = null,
		string EndVendNum = null,
		DateTime? StartPayDate = null,
		DateTime? EndPayDate = null,
		string StartVendName = null,
		string EndVendName = null)
		{
			RowPointerType _ProcessID = ProcessID;
			BankCodeType _BankCode = BankCode;
			VendNumType _StartVendNum = StartVendNum;
			VendNumType _EndVendNum = EndVendNum;
			DateType _StartPayDate = StartPayDate;
			DateType _EndPayDate = EndPayDate;
			NameType _StartVendName = StartVendName;
			NameType _EndVendName = EndVendName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileAPEftPostingSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendNum", _StartVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPayDate", _StartPayDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPayDate", _EndPayDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendName", _StartVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendName", _EndVendName, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
