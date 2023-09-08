//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARWirePosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARWirePosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARWirePostingSp(byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string pStartingBankCode = null,
		string pEndingBankCode = null,
		DateTime? pStartingReceiptDate = null,
		DateTime? pEndingReciptDate = null,
		int? pStartingWireNumber = null,
		int? pEndingWireNumber = null,
		string pStartCreditMemoNum = null,
		string pEndCreditMemoNum = null,
		byte? PDisplayHeader = null,
		string PSessionIDChar = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ARWirePosting : IRpt_ARWirePosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARWirePosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARWirePostingSp(byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string pStartingBankCode = null,
		string pEndingBankCode = null,
		DateTime? pStartingReceiptDate = null,
		DateTime? pEndingReciptDate = null,
		int? pStartingWireNumber = null,
		int? pEndingWireNumber = null,
		string pStartCreditMemoNum = null,
		string pEndCreditMemoNum = null,
		byte? PDisplayHeader = null,
		string PSessionIDChar = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null)
		{
			ListYesNoType _PDisplayDetail = PDisplayDetail;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			BankCodeType _pStartingBankCode = pStartingBankCode;
			BankCodeType _pEndingBankCode = pEndingBankCode;
			DateTimeType _pStartingReceiptDate = pStartingReceiptDate;
			DateTimeType _pEndingReciptDate = pEndingReciptDate;
			ArCheckNumType _pStartingWireNumber = pStartingWireNumber;
			ArCheckNumType _pEndingWireNumber = pEndingWireNumber;
			InvNumType _pStartCreditMemoNum = pStartCreditMemoNum;
			InvNumType _pEndCreditMemoNum = pEndCreditMemoNum;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _PSessionIDChar = PSessionIDChar;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARWirePostingSp";
				
				appDB.AddCommandParameter(cmd, "PDisplayDetail", _PDisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingBankCode", _pStartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingBankCode", _pEndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingReceiptDate", _pStartingReceiptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingReciptDate", _pEndingReciptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingWireNumber", _pStartingWireNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingWireNumber", _pEndingWireNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCreditMemoNum", _pStartCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCreditMemoNum", _pEndCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
