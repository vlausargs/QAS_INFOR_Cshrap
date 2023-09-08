//PROJECT NAME: CSIReport
//CLASS NAME: AU_Rpt_QAProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IAU_Rpt_QAProcess
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_Rpt_QAProcessSp(string QAprocessIDStarting = null,
		string QAprocessIDEnding = null,
		string QAProcessStarting = null,
		string QAProcessEnding = null,
		string ProcessSourceTypeStarting = null,
		string ProcessSourceTypeEnding = null,
		string ProcessSourceStarting = null,
		string ProcessSourceEnding = null,
		string pSite = null);
	}
	
	public class AU_Rpt_QAProcess : IAU_Rpt_QAProcess
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public AU_Rpt_QAProcess(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) AU_Rpt_QAProcessSp(string QAprocessIDStarting = null,
		string QAprocessIDEnding = null,
		string QAProcessStarting = null,
		string QAProcessEnding = null,
		string ProcessSourceTypeStarting = null,
		string ProcessSourceTypeEnding = null,
		string ProcessSourceStarting = null,
		string ProcessSourceEnding = null,
		string pSite = null)
		{
			AU_QAProcessIDType _QAprocessIDStarting = QAprocessIDStarting;
			AU_QAProcessIDType _QAprocessIDEnding = QAprocessIDEnding;
			AU_QAProcessType _QAProcessStarting = QAProcessStarting;
			AU_QAProcessType _QAProcessEnding = QAProcessEnding;
			RefTypeIJKOPRSTWType _ProcessSourceTypeStarting = ProcessSourceTypeStarting;
			RefTypeIJKOPRSTWType _ProcessSourceTypeEnding = ProcessSourceTypeEnding;
			ReferenceType _ProcessSourceStarting = ProcessSourceStarting;
			ReferenceType _ProcessSourceEnding = ProcessSourceEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_Rpt_QAProcessSp";
				
				appDB.AddCommandParameter(cmd, "QAprocessIDStarting", _QAprocessIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAprocessIDEnding", _QAprocessIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAProcessStarting", _QAProcessStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAProcessEnding", _QAProcessEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceTypeStarting", _ProcessSourceTypeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceTypeEnding", _ProcessSourceTypeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceStarting", _ProcessSourceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceEnding", _ProcessSourceEnding, ParameterDirection.Input);
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
