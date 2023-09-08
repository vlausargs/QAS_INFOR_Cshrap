//PROJECT NAME: Reporting
//CLASS NAME: SSSRFQRpt_SendQuote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ISSSRFQRpt_SendQuote
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRFQRpt_SendQuoteSp(string RfqNum,
		int? RfqLine,
		int? RfqSeq,
		byte? Resend,
		byte? Preview,
		string pSite = null);
	}
	
	public class SSSRFQRpt_SendQuote : ISSSRFQRpt_SendQuote
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRFQRpt_SendQuote(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRFQRpt_SendQuoteSp(string RfqNum,
		int? RfqLine,
		int? RfqSeq,
		byte? Resend,
		byte? Preview,
		string pSite = null)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RFQSeqType _RfqSeq = RfqSeq;
			ListYesNoType _Resend = Resend;
			ListYesNoType _Preview = Preview;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQRpt_SendQuoteSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Resend", _Resend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Preview", _Preview, ParameterDirection.Input);
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
