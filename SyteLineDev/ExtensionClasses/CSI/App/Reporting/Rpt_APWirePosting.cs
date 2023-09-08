//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APWirePosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_APWirePosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_APWirePostingSP(string PaymentType = null,
		string BankCode = null,
		byte? DisplayDistDetail = null,
		string VendorStarting = null,
		string VendorEnding = null,
		byte? DisplayHeader = null,
		DateTime? PayDateStarting = null,
		DateTime? PayDateEnding = null,
		string SessionIDChar = null,
		string PSortNameNum = "Number",
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_APWirePosting : IRpt_APWirePosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_APWirePosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_APWirePostingSP(string PaymentType = null,
		string BankCode = null,
		byte? DisplayDistDetail = null,
		string VendorStarting = null,
		string VendorEnding = null,
		byte? DisplayHeader = null,
		DateTime? PayDateStarting = null,
		DateTime? PayDateEnding = null,
		string SessionIDChar = null,
		string PSortNameNum = "Number",
		int? TaskId = null,
		string pSite = null)
		{
			AppmtPayTypeType _PaymentType = PaymentType;
			BankCodeType _BankCode = BankCode;
			ListYesNoType _DisplayDistDetail = DisplayDistDetail;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DateType _PayDateStarting = PayDateStarting;
			DateType _PayDateEnding = PayDateEnding;
			StringType _SessionIDChar = SessionIDChar;
			LongDescType _PSortNameNum = PSortNameNum;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_APWirePostingSP";
				
				appDB.AddCommandParameter(cmd, "PaymentType", _PaymentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayDistDetail", _DisplayDistDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDateStarting", _PayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDateEnding", _PayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
