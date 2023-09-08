//PROJECT NAME: CSICustomer
//CLASS NAME: ProfilesCustomerStatementofAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IProfilesCustomerStatementofAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfilesCustomerStatementofAccountSp(DateTime? CutOffDate = null,
		string CustNumStarting = null,
		string CustNumEnding = null);
	}
	
	public class ProfilesCustomerStatementofAccount : IProfilesCustomerStatementofAccount
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfilesCustomerStatementofAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfilesCustomerStatementofAccountSp(DateTime? CutOffDate = null,
		string CustNumStarting = null,
		string CustNumEnding = null)
		{
			DateType _CutOffDate = CutOffDate;
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfilesCustomerStatementofAccountSp";
				
				appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
