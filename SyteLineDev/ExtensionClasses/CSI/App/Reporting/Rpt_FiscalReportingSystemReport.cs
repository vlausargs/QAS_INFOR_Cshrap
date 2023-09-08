//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FiscalReportingSystemReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_FiscalReportingSystemReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FiscalReportingSystemReportSp(string StartingFiscalReportingSystem = null,
		string EndingFiscalReportingSystem = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string CurrentYear = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_FiscalReportingSystemReport : IRpt_FiscalReportingSystemReport
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FiscalReportingSystemReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FiscalReportingSystemReportSp(string StartingFiscalReportingSystem = null,
		string EndingFiscalReportingSystem = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string CurrentYear = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			FiscalReportingSystemType _StartingFiscalReportingSystem = StartingFiscalReportingSystem;
			FiscalReportingSystemType _EndingFiscalReportingSystem = EndingFiscalReportingSystem;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			StringType _CurrentYear = CurrentYear;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FiscalReportingSystemReportSp";
				
				appDB.AddCommandParameter(cmd, "StartingFiscalReportingSystem", _StartingFiscalReportingSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingFiscalReportingSystem", _EndingFiscalReportingSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentYear", _CurrentYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
