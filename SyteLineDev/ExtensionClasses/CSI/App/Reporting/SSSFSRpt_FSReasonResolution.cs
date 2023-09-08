//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_FSReasonResolution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_FSReasonResolution : ISSSFSRpt_FSReasonResolution
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_FSReasonResolution(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_FSReasonResolutionSp(string Incident,
		string StartingReasonCode1,
		string EndingReasonCode1,
		string StartingReasonCode2,
		string EndingReasonCode2,
		int? PrintReason,
		int? PrintRes,
		string pSite = null)
		{
			FSIncNumType _Incident = Incident;
			FSReasonType _StartingReasonCode1 = StartingReasonCode1;
			FSReasonType _EndingReasonCode1 = EndingReasonCode1;
			FSReasonType _StartingReasonCode2 = StartingReasonCode2;
			FSReasonType _EndingReasonCode2 = EndingReasonCode2;
			ListYesNoType _PrintReason = PrintReason;
			ListYesNoType _PrintRes = PrintRes;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_FSReasonResolutionSp";
				
				appDB.AddCommandParameter(cmd, "Incident", _Incident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingReasonCode1", _StartingReasonCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingReasonCode1", _EndingReasonCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingReasonCode2", _StartingReasonCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingReasonCode2", _EndingReasonCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReason", _PrintReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRes", _PrintRes, ParameterDirection.Input);
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
