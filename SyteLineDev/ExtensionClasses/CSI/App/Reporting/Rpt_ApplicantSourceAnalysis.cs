//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ApplicantSourceAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ApplicantSourceAnalysis : IRpt_ApplicantSourceAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ApplicantSourceAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ApplicantSourceAnalysisSp(string PStartingApplicant = null,
		string PEndingApplicant = null,
		DateTime? PStartingReceivedDate = null,
		DateTime? PEndingReceivedDate = null,
		string PStartingPosition = null,
		string PEndingPosition = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			AppNumType _PStartingApplicant = PStartingApplicant;
			AppNumType _PEndingApplicant = PEndingApplicant;
			DateType _PStartingReceivedDate = PStartingReceivedDate;
			DateType _PEndingReceivedDate = PEndingReceivedDate;
			JobIdType _PStartingPosition = PStartingPosition;
			JobIdType _PEndingPosition = PEndingPosition;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ApplicantSourceAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "PStartingApplicant", _PStartingApplicant, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingApplicant", _PEndingApplicant, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingReceivedDate", _PStartingReceivedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingReceivedDate", _PEndingReceivedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingPosition", _PStartingPosition, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingPosition", _PEndingPosition, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
