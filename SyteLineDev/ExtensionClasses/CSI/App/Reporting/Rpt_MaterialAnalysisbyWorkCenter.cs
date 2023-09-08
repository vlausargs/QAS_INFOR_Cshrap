//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialAnalysisbyWorkCenter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MaterialAnalysisbyWorkCenter : IRpt_MaterialAnalysisbyWorkCenter
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MaterialAnalysisbyWorkCenter(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MaterialAnalysisbyWorkCenterSp(string StartingWc = null,
		string EndingWc = null,
		string StartingIterm = null,
		string EndingIterm = null,
		DateTime? StartingTransDate = null,
		DateTime? EndingTransDate = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		int? ShowDetail = null,
		int? ShowHeader = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null)
		{
			WcType _StartingWc = StartingWc;
			WcType _EndingWc = EndingWc;
			ItemType _StartingIterm = StartingIterm;
			ItemType _EndingIterm = EndingIterm;
			DateType _StartingTransDate = StartingTransDate;
			DateType _EndingTransDate = EndingTransDate;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			FlagNyType _ShowDetail = ShowDetail;
			FlagNyType _ShowHeader = ShowHeader;
			SiteType _pSite = pSite;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MaterialAnalysisbyWorkCenterSp";
				
				appDB.AddCommandParameter(cmd, "StartingWc", _StartingWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWc", _EndingWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingIterm", _StartingIterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingIterm", _EndingIterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDate", _StartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDate", _EndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowHeader", _ShowHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
