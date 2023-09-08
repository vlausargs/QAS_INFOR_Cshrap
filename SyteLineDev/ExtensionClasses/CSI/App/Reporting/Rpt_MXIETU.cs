//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXIETU.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MXIETU : IRpt_MXIETU
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MXIETU(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXIETUSp(string EntityStarting = null,
		string EntityEnding = null,
		DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		string IetuClasification = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		string ReportMode = "D",
		int? DisplayHeader = 0,
		string pSite = null)
		{
			VendNumType _EntityStarting = EntityStarting;
			VendNumType _EntityEnding = EntityEnding;
			DateType _ReconDateStarting = ReconDateStarting;
			DateType _ReconDateEnding = ReconDateEnding;
			StringType _IetuClasification = IetuClasification;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			StringType _ReportMode = ReportMode;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MXIETUSp";
				
				appDB.AddCommandParameter(cmd, "EntityStarting", _EntityStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntityEnding", _EntityEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReconDateStarting", _ReconDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReconDateEnding", _ReconDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IetuClasification", _IetuClasification, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportMode", _ReportMode, ParameterDirection.Input);
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
