//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APPostingDraftRemittance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_APPostingDraftRemittance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_APPostingDraftRemittanceSp(string BankCode = null,
		string VendNumStart = null,
		string VendNumEnd = null,
		byte? DisplayHeader = null,
		int? PStartingDraftNum = null,
		int? PEndingDraftNum = null,
		DateTime? PStartingDueDate = null,
		DateTime? PEndingDueDate = null,
		string SSessionIDChar = null,
		string pSite = null);
	}
	
	public class Rpt_APPostingDraftRemittance : IRpt_APPostingDraftRemittance
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_APPostingDraftRemittance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_APPostingDraftRemittanceSp(string BankCode = null,
		string VendNumStart = null,
		string VendNumEnd = null,
		byte? DisplayHeader = null,
		int? PStartingDraftNum = null,
		int? PEndingDraftNum = null,
		DateTime? PStartingDueDate = null,
		DateTime? PEndingDueDate = null,
		string SSessionIDChar = null,
		string pSite = null)
		{
			BankCodeType _BankCode = BankCode;
			VendNumType _VendNumStart = VendNumStart;
			VendNumType _VendNumEnd = VendNumEnd;
			FlagNyType _DisplayHeader = DisplayHeader;
			DraftNumType _PStartingDraftNum = PStartingDraftNum;
			DraftNumType _PEndingDraftNum = PEndingDraftNum;
			DateType _PStartingDueDate = PStartingDueDate;
			DateType _PEndingDueDate = PEndingDueDate;
			StringType _SSessionIDChar = SSessionIDChar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_APPostingDraftRemittanceSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNumStart", _VendNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNumEnd", _VendNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDraftNum", _PStartingDraftNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDraftNum", _PEndingDraftNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDueDate", _PStartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDueDate", _PEndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSessionIDChar", _SSessionIDChar, ParameterDirection.Input);
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
