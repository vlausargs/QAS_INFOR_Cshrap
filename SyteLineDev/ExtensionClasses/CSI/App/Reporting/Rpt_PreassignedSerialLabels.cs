//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PreassignedSerialLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PreassignedSerialLabels : IRpt_PreassignedSerialLabels
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PreassignedSerialLabels(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PreassignedSerialLabelsSp(string SerialStarting = null,
		string SerialEnding = null,
		int? IncludePO = 0,
		string PoStarting = null,
		string PoEnding = null,
		int? PoLineStarting = null,
		int? PoLineEnding = null,
		int? PoReleaseStarting = 0,
		int? PoReleaseEnding = 0,
		int? IncludeJob = 0,
		string JobStarting = null,
		string JobEnding = null,
		int? SuffixStarting = null,
		int? SuffixEnding = null,
		int? IncludeTrn = 0,
		string TrnStarting = null,
		string TrnEnding = null,
		int? TrnLineStarting = null,
		int? TrnLineEnding = null,
		string pSite = null)
		{
			SerNumType _SerialStarting = SerialStarting;
			SerNumType _SerialEnding = SerialEnding;
			ListYesNoType _IncludePO = IncludePO;
			PoNumType _PoStarting = PoStarting;
			PoNumType _PoEnding = PoEnding;
			PoLineType _PoLineStarting = PoLineStarting;
			PoLineType _PoLineEnding = PoLineEnding;
			PoReleaseType _PoReleaseStarting = PoReleaseStarting;
			PoReleaseType _PoReleaseEnding = PoReleaseEnding;
			ListYesNoType _IncludeJob = IncludeJob;
			JobType _JobStarting = JobStarting;
			JobType _JobEnding = JobEnding;
			SuffixType _SuffixStarting = SuffixStarting;
			SuffixType _SuffixEnding = SuffixEnding;
			ListYesNoType _IncludeTrn = IncludeTrn;
			TrnNumType _TrnStarting = TrnStarting;
			TrnNumType _TrnEnding = TrnEnding;
			TrnLineType _TrnLineStarting = TrnLineStarting;
			TrnLineType _TrnLineEnding = TrnLineEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PreassignedSerialLabelsSp";
				
				appDB.AddCommandParameter(cmd, "SerialStarting", _SerialStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialEnding", _SerialEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludePO", _IncludePO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoStarting", _PoStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoEnding", _PoEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLineStarting", _PoLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLineEnding", _PoLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoReleaseStarting", _PoReleaseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoReleaseEnding", _PoReleaseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeJob", _IncludeJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTrn", _IncludeTrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnStarting", _TrnStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnEnding", _TrnEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLineStarting", _TrnLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLineEnding", _TrnLineEnding, ParameterDirection.Input);
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
