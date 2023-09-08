//PROJECT NAME: CSIReport
//CLASS NAME: ItemABCAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IItemABCAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemABCAnalysisSP(string Process,
		byte? Background,
		int? TaskId,
		string AnalysisMethod,
		string ByValOrUnits,
		string PMTCode,
		int? ABC1,
		int? ABC2,
		int? ABC3,
		string Infobar,
		string pSite = null);
	}
	
	public class ItemABCAnalysis : IItemABCAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ItemABCAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemABCAnalysisSP(string Process,
		byte? Background,
		int? TaskId,
		string AnalysisMethod,
		string ByValOrUnits,
		string PMTCode,
		int? ABC1,
		int? ABC2,
		int? ABC3,
		string Infobar,
		string pSite = null)
		{
			StringType _Process = Process;
			ListYesNoType _Background = Background;
			TaskNumType _TaskId = TaskId;
			StringType _AnalysisMethod = AnalysisMethod;
			StringType _ByValOrUnits = ByValOrUnits;
			StringType _PMTCode = PMTCode;
			IntType _ABC1 = ABC1;
			IntType _ABC2 = ABC2;
			IntType _ABC3 = ABC3;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemABCAnalysisSP";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Background", _Background, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisMethod", _AnalysisMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ByValOrUnits", _ByValOrUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABC1", _ABC1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABC2", _ABC2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABC3", _ABC3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
