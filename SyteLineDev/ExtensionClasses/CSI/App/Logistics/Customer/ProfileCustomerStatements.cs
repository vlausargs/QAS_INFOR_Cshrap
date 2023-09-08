//PROJECT NAME: Logistics
//CLASS NAME: ProfileCustomerStatements.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ProfileCustomerStatements : IProfileCustomerStatements
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileCustomerStatements(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileCustomerStatementsSP(DateTime? StatementDate = null,
		int? ShowActive = null,
		string BeginCustNum = null,
		string EndCustNum = null,
		string SiteGroup = null,
		string StateCycle = null,
		int? PrZeroBal = null,
		int? PrCreditBal = null,
		string PrOpenItem2 = null,
		string InvDue = null,
		int? HidePaid = null,
		int? PrOpenPay = null,
		int? StatementDateOffset = null)
		{
			DateType _StatementDate = StatementDate;
			ListYesNoType _ShowActive = ShowActive;
			CustNumType _BeginCustNum = BeginCustNum;
			CustNumType _EndCustNum = EndCustNum;
			SiteGroupType _SiteGroup = SiteGroup;
			StringType _StateCycle = StateCycle;
			ListYesNoType _PrZeroBal = PrZeroBal;
			ListYesNoType _PrCreditBal = PrCreditBal;
			StringType _PrOpenItem2 = PrOpenItem2;
			StringType _InvDue = InvDue;
			IntType _HidePaid = HidePaid;
			ListYesNoType _PrOpenPay = PrOpenPay;
			DateOffsetType _StatementDateOffset = StatementDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileCustomerStatementsSP";
				
				appDB.AddCommandParameter(cmd, "StatementDate", _StatementDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowActive", _ShowActive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCustNum", _BeginCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateCycle", _StateCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrZeroBal", _PrZeroBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrCreditBal", _PrCreditBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrOpenItem2", _PrOpenItem2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDue", _InvDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HidePaid", _HidePaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrOpenPay", _PrOpenPay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatementDateOffset", _StatementDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
