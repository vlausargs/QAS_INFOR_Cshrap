//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VendorOpenRecordsReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VendorOpenRecordsReport : IRpt_VendorOpenRecordsReport
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VendorOpenRecordsReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VendorOpenRecordsReportSp(string VendNumStarting = null,
		string VendNumEnding = null,
		string StatStarting = null,
		string StatEnding = null,
		string pSite = null)
		{
			VendNumType _VendNumStarting = VendNumStarting;
			VendNumType _VendNumEnding = VendNumEnding;
			VendorStatusType _StatStarting = StatStarting;
			VendorStatusType _StatEnding = StatEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VendorOpenRecordsReportSp";
				
				appDB.AddCommandParameter(cmd, "VendNumStarting", _VendNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNumEnding", _VendNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatStarting", _StatStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatEnding", _StatEnding, ParameterDirection.Input);
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
