//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXDIOTExeptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MXDIOTExeptions : IRpt_MXDIOTExeptions
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MXDIOTExeptions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXDIOTExeptionsSp(DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		int? Reprint = 0,
		int? Close = 0,
		string PrintOrCommit = "P",
		string ReportType = "D",
		string pSite = null)
		{
			DateType _ReconDateStarting = ReconDateStarting;
			DateType _ReconDateEnding = ReconDateEnding;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			ByteType _Reprint = Reprint;
			ByteType _Close = Close;
			StringType _PrintOrCommit = PrintOrCommit;
			StringType _ReportType = ReportType;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MXDIOTExeptionsSp";
				
				appDB.AddCommandParameter(cmd, "ReconDateStarting", _ReconDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReconDateEnding", _ReconDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reprint", _Reprint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Close", _Close, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrCommit", _PrintOrCommit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportType", _ReportType, ParameterDirection.Input);
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
