//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPaymentPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARPaymentPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPaymentPostingSp(byte? PDisplayDetail = (byte)1,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string pStartingBankCode = null,
		string pEndingBankCode = null,
		DateTime? pStartingReceiptDate = null,
		DateTime? pEndingReceiptDate = null,
		int? pStartingCheckNumber = null,
		int? pEndingCheckNumber = null,
		byte? PDisplayHeader = (byte)1,
		string PSessionIDChar = null,
		string PStartCreditMemo = null,
		string PEndCreditMemo = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ARPaymentPosting : IRpt_ARPaymentPosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARPaymentPosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPaymentPostingSp(byte? PDisplayDetail = (byte)1,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string pStartingBankCode = null,
		string pEndingBankCode = null,
		DateTime? pStartingReceiptDate = null,
		DateTime? pEndingReceiptDate = null,
		int? pStartingCheckNumber = null,
		int? pEndingCheckNumber = null,
		byte? PDisplayHeader = (byte)1,
		string PSessionIDChar = null,
		string PStartCreditMemo = null,
		string PEndCreditMemo = null,
		string pSite = null,
		string BGUser = null)
		{
			ListYesNoType _PDisplayDetail = PDisplayDetail;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			BankCodeType _pStartingBankCode = pStartingBankCode;
			BankCodeType _pEndingBankCode = pEndingBankCode;
			DateTimeType _pStartingReceiptDate = pStartingReceiptDate;
			DateTimeType _pEndingReceiptDate = pEndingReceiptDate;
			ArCheckNumType _pStartingCheckNumber = pStartingCheckNumber;
			ArCheckNumType _pEndingCheckNumber = pEndingCheckNumber;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _PSessionIDChar = PSessionIDChar;
			InvNumType _PStartCreditMemo = PStartCreditMemo;
			InvNumType _PEndCreditMemo = PEndCreditMemo;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARPaymentPostingSp";
				
				appDB.AddCommandParameter(cmd, "PDisplayDetail", _PDisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingBankCode", _pStartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingBankCode", _pEndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingReceiptDate", _pStartingReceiptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingReceiptDate", _pEndingReceiptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingCheckNumber", _pStartingCheckNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingCheckNumber", _pEndingCheckNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCreditMemo", _PStartCreditMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCreditMemo", _PEndCreditMemo, ParameterDirection.Input);
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
