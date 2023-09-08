//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARDirectDebitPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARDirectDebitPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARDirectDebitPostingSp(byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string pStartingBankCode = null,
		string pEndingBankCode = null,
		DateTime? pStartingDueDate = null,
		DateTime? pEndingDueDate = null,
		int? pStartingDirectDebitNumber = null,
		int? pEndingDirectDebitNumber = null,
		byte? PDisplayHeader = null,
		string PSessionIDChar = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ARDirectDebitPosting : IRpt_ARDirectDebitPosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARDirectDebitPosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARDirectDebitPostingSp(byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string pStartingBankCode = null,
		string pEndingBankCode = null,
		DateTime? pStartingDueDate = null,
		DateTime? pEndingDueDate = null,
		int? pStartingDirectDebitNumber = null,
		int? pEndingDirectDebitNumber = null,
		byte? PDisplayHeader = null,
		string PSessionIDChar = null,
		string pSite = null,
		string BGUser = null)
		{
			ListYesNoType _PDisplayDetail = PDisplayDetail;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			BankCodeType _pStartingBankCode = pStartingBankCode;
			BankCodeType _pEndingBankCode = pEndingBankCode;
			DateTimeType _pStartingDueDate = pStartingDueDate;
			DateTimeType _pEndingDueDate = pEndingDueDate;
			DirectDebitNumType _pStartingDirectDebitNumber = pStartingDirectDebitNumber;
			DirectDebitNumType _pEndingDirectDebitNumber = pEndingDirectDebitNumber;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _PSessionIDChar = PSessionIDChar;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARDirectDebitPostingSp";
				
				appDB.AddCommandParameter(cmd, "PDisplayDetail", _PDisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingBankCode", _pStartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingBankCode", _pEndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingDueDate", _pStartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingDueDate", _pEndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingDirectDebitNumber", _pStartingDirectDebitNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingDirectDebitNumber", _pEndingDirectDebitNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
