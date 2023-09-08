//PROJECT NAME: CSIReport
//CLASS NAME: AU_Rpt_QAProcessPhase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IAU_Rpt_QAProcessPhase
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_Rpt_QAProcessPhaseSp(string QAProcessID = null,
		string pSite = null);
	}
	
	public class AU_Rpt_QAProcessPhase : IAU_Rpt_QAProcessPhase
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public AU_Rpt_QAProcessPhase(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) AU_Rpt_QAProcessPhaseSp(string QAProcessID = null,
		string pSite = null)
		{
			AU_QAProcessIDType _QAProcessID = QAProcessID;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_Rpt_QAProcessPhaseSp";
				
				appDB.AddCommandParameter(cmd, "QAProcessID", _QAProcessID, ParameterDirection.Input);
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
