//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChargebackTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ChargebackTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ChargebackTransactionSp(string CustomerNumStarting = null,
		string CustomerNumEnding = null,
		int? CheckNumStarting = null,
		int? CheckNumEnding = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		string ChargebackTypeStarting = null,
		string ChargebackTypeEnding = null,
		DateTime? PostedDateStarting = null,
		DateTime? PostedDateEnding = null,
		short? PostedDateStartingOffset = null,
		short? PostedDateEndingOffset = null,
		byte? PrintApprovedChargeback = (byte)1,
		byte? PrintDeinedChargeback = (byte)1,
		byte? PrintPendingChargeback = (byte)1,
		string Sortby = "C",
		byte? PDisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_ChargebackTransaction : IRpt_ChargebackTransaction
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ChargebackTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ChargebackTransactionSp(string CustomerNumStarting = null,
		string CustomerNumEnding = null,
		int? CheckNumStarting = null,
		int? CheckNumEnding = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		string ChargebackTypeStarting = null,
		string ChargebackTypeEnding = null,
		DateTime? PostedDateStarting = null,
		DateTime? PostedDateEnding = null,
		short? PostedDateStartingOffset = null,
		short? PostedDateEndingOffset = null,
		byte? PrintApprovedChargeback = (byte)1,
		byte? PrintDeinedChargeback = (byte)1,
		byte? PrintPendingChargeback = (byte)1,
		string Sortby = "C",
		byte? PDisplayHeader = (byte)1,
		string pSite = null)
		{
			CustNumType _CustomerNumStarting = CustomerNumStarting;
			CustNumType _CustomerNumEnding = CustomerNumEnding;
			ArCheckNumType _CheckNumStarting = CheckNumStarting;
			ArCheckNumType _CheckNumEnding = CheckNumEnding;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			ChargebackTypeType _ChargebackTypeStarting = ChargebackTypeStarting;
			ChargebackTypeType _ChargebackTypeEnding = ChargebackTypeEnding;
			DateTimeType _PostedDateStarting = PostedDateStarting;
			DateTimeType _PostedDateEnding = PostedDateEnding;
			DateOffsetType _PostedDateStartingOffset = PostedDateStartingOffset;
			DateOffsetType _PostedDateEndingOffset = PostedDateEndingOffset;
			ListYesNoType _PrintApprovedChargeback = PrintApprovedChargeback;
			ListYesNoType _PrintDeinedChargeback = PrintDeinedChargeback;
			ListYesNoType _PrintPendingChargeback = PrintPendingChargeback;
			StringType _Sortby = Sortby;
			FlagNyType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ChargebackTransactionSp";
				
				appDB.AddCommandParameter(cmd, "CustomerNumStarting", _CustomerNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerNumEnding", _CustomerNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNumStarting", _CheckNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNumEnding", _CheckNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargebackTypeStarting", _ChargebackTypeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargebackTypeEnding", _ChargebackTypeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostedDateStarting", _PostedDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostedDateEnding", _PostedDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostedDateStartingOffset", _PostedDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostedDateEndingOffset", _PostedDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintApprovedChargeback", _PrintApprovedChargeback, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDeinedChargeback", _PrintDeinedChargeback, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPendingChargeback", _PrintPendingChargeback, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sortby", _Sortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
