//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARAdjustmentPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARAdjustmentPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARAdjustmentPostingSp(byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartingBankCode = null,
		string PEndingBankCode = null,
		DateTime? PStartingReceiptDate = null,
		DateTime? PEndingReceiptDate = null,
		int? PStartingChkNumber = null,
		int? PEndingChkNumber = null,
		byte? PDisplayHeader = null,
		string PSessionIDChar = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ARAdjustmentPosting : IRpt_ARAdjustmentPosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARAdjustmentPosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARAdjustmentPostingSp(byte? PDisplayDetail = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartingBankCode = null,
		string PEndingBankCode = null,
		DateTime? PStartingReceiptDate = null,
		DateTime? PEndingReceiptDate = null,
		int? PStartingChkNumber = null,
		int? PEndingChkNumber = null,
		byte? PDisplayHeader = null,
		string PSessionIDChar = null,
		string pSite = null,
		string BGUser = null)
		{
			ListYesNoType _PDisplayDetail = PDisplayDetail;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			BankCodeType _PStartingBankCode = PStartingBankCode;
			BankCodeType _PEndingBankCode = PEndingBankCode;
			DateTimeType _PStartingReceiptDate = PStartingReceiptDate;
			DateTimeType _PEndingReceiptDate = PEndingReceiptDate;
			ArCheckNumType _PStartingChkNumber = PStartingChkNumber;
			ArCheckNumType _PEndingChkNumber = PEndingChkNumber;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _PSessionIDChar = PSessionIDChar;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARAdjustmentPostingSp";
				
				appDB.AddCommandParameter(cmd, "PDisplayDetail", _PDisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingBankCode", _PStartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingBankCode", _PEndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingReceiptDate", _PStartingReceiptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingReceiptDate", _PEndingReceiptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingChkNumber", _PStartingChkNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingChkNumber", _PEndingChkNumber, ParameterDirection.Input);
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
