//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APPaymentTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_APPaymentTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_APPaymentTransactionSp(string PaymentType = null,
		string BankCode = null,
		byte? DisplayDistDetail = null,
		string VendorStarting = null,
		string VendorEnding = null,
		byte? DisplayHeader = null,
		DateTime? PayDateStarting = null,
		DateTime? PayDateEnding = null,
		short? PayDateStartingOffset = null,
		short? PayDateEndingOffset = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_APPaymentTransaction : IRpt_APPaymentTransaction
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_APPaymentTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_APPaymentTransactionSp(string PaymentType = null,
		string BankCode = null,
		byte? DisplayDistDetail = null,
		string VendorStarting = null,
		string VendorEnding = null,
		byte? DisplayHeader = null,
		DateTime? PayDateStarting = null,
		DateTime? PayDateEnding = null,
		short? PayDateStartingOffset = null,
		short? PayDateEndingOffset = null,
		string BGSessionId = null,
		string pSite = null)
		{
			Infobar _PaymentType = PaymentType;
			BankCodeType _BankCode = BankCode;
			ListYesNoType _DisplayDistDetail = DisplayDistDetail;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DateType _PayDateStarting = PayDateStarting;
			DateType _PayDateEnding = PayDateEnding;
			DateOffsetType _PayDateStartingOffset = PayDateStartingOffset;
			DateOffsetType _PayDateEndingOffset = PayDateEndingOffset;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_APPaymentTransactionSp";
				
				appDB.AddCommandParameter(cmd, "PaymentType", _PaymentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayDistDetail", _DisplayDistDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDateStarting", _PayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDateEnding", _PayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDateStartingOffset", _PayDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDateEndingOffset", _PayDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
