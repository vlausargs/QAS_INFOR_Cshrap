//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerWorksheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerWorksheet : IRpt_MultiFSBGeneralLedgerWorksheet
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MultiFSBGeneralLedgerWorksheet(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerWorksheetSp(DateTime? ExOptacAsOfDate = null,
		string ExStartingAccount = null,
		string ExEndingAccount = null,
		string ExOptacChartType = null,
		int? TAnalyticalLedger = null,
		int? DateOffset = null,
		int? DisplayHeader = null,
		string FSBName = null,
		string pSite = null)
		{
			DateType _ExOptacAsOfDate = ExOptacAsOfDate;
			AcctType _ExStartingAccount = ExStartingAccount;
			AcctType _ExEndingAccount = ExEndingAccount;
			InfobarType _ExOptacChartType = ExOptacChartType;
			ListYesNoType _TAnalyticalLedger = TAnalyticalLedger;
			DateOffsetType _DateOffset = DateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FSBNameType _FSBName = FSBName;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBGeneralLedgerWorksheetSp";
				
				appDB.AddCommandParameter(cmd, "ExOptacAsOfDate", _ExOptacAsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExStartingAccount", _ExStartingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndingAccount", _ExEndingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacChartType", _ExOptacChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAnalyticalLedger", _TAnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
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
