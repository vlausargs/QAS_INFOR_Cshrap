//PROJECT NAME: Logistics
//CLASS NAME: ProfileOrderInvoicing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ProfileOrderInvoicing : IProfileOrderInvoicing
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileOrderInvoicing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileOrderInvoicingSp(string StartInvNum = null,
		string EndInvNum = null,
		string StartOrderNum = null,
		string EndOrderNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string CalledFrom = "REPRINT",
		Guid? ProcessID = null)
		{
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			DateType _StartInvDate = StartInvDate;
			DateType _EndInvDate = EndInvDate;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			StringType _CalledFrom = CalledFrom;
			RowPointerType _ProcessID = ProcessID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileOrderInvoicingSp";
				
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
