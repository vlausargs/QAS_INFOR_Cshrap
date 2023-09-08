//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EstimateJobRouting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateJobRoutingSp(string JobStarting = null,
		string JobEnding = null,
		short? SuffixStarting = null,
		short? SuffixEnding = null,
		string OperStarting = null,
		string OperEnding = null,
		byte? Pageoper = null,
		byte? Reffields = null,
		string Prcfgdetail = null,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? PrintNoteJobRoute = (byte)1,
		byte? PrintNoteJobmatl = (byte)1,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_EstimateJobRouting : IRpt_EstimateJobRouting
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EstimateJobRouting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateJobRoutingSp(string JobStarting = null,
		string JobEnding = null,
		short? SuffixStarting = null,
		short? SuffixEnding = null,
		string OperStarting = null,
		string OperEnding = null,
		byte? Pageoper = null,
		byte? Reffields = null,
		string Prcfgdetail = null,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? PrintNoteJobRoute = (byte)1,
		byte? PrintNoteJobmatl = (byte)1,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			JobType _JobStarting = JobStarting;
			JobType _JobEnding = JobEnding;
			SuffixType _SuffixStarting = SuffixStarting;
			SuffixType _SuffixEnding = SuffixEnding;
			JobType _OperStarting = OperStarting;
			JobType _OperEnding = OperEnding;
			ListYesNoType _Pageoper = Pageoper;
			ListYesNoType _Reffields = Reffields;
			StringType _Prcfgdetail = Prcfgdetail;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _PrintNoteJobRoute = PrintNoteJobRoute;
			FlagNyType _PrintNoteJobmatl = PrintNoteJobmatl;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EstimateJobRoutingSp";
				
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperStarting", _OperStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperEnding", _OperEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pageoper", _Pageoper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reffields", _Reffields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prcfgdetail", _Prcfgdetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintNoteJobRoute", _PrintNoteJobRoute, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintNoteJobmatl", _PrintNoteJobmatl, ParameterDirection.Input);
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
