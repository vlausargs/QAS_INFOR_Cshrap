//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPostingDraftRemittance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARPostingDraftRemittance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPostingDraftRemittanceSp(string PSessionID = null,
		string StartingBankCode = null,
		string EndingBankCode = null,
		int? StartDraftNumber = null,
		int? EndDraftNumber = null,
		string RemittanceOption = null,
		byte? DisplayHeader = null,
		string Infobar = null,
		string pSite = null);
	}
	
	public class Rpt_ARPostingDraftRemittance : IRpt_ARPostingDraftRemittance
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARPostingDraftRemittance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPostingDraftRemittanceSp(string PSessionID = null,
		string StartingBankCode = null,
		string EndingBankCode = null,
		int? StartDraftNumber = null,
		int? EndDraftNumber = null,
		string RemittanceOption = null,
		byte? DisplayHeader = null,
		string Infobar = null,
		string pSite = null)
		{
			StringType _PSessionID = PSessionID;
			BankCodeType _StartingBankCode = StartingBankCode;
			BankCodeType _EndingBankCode = EndingBankCode;
			DraftNumType _StartDraftNumber = StartDraftNumber;
			DraftNumType _EndDraftNumber = EndDraftNumber;
			CustdrftStatusType _RemittanceOption = RemittanceOption;
			ListYesNoType _DisplayHeader = DisplayHeader;
			Infobar _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARPostingDraftRemittanceSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingBankCode", _StartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingBankCode", _EndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDraftNumber", _StartDraftNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDraftNumber", _EndDraftNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemittanceOption", _RemittanceOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
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
