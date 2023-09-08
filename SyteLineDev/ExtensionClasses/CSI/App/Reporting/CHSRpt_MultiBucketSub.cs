//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_MultiBucketSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_MultiBucketSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_MultiBucketSubSp(string SessionID,
		int? ReportID,
		short? RptLines,
		byte? BalColIsLast,
		string pSite = null);
	}
	
	public class CHSRpt_MultiBucketSub : ICHSRpt_MultiBucketSub
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_MultiBucketSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_MultiBucketSubSp(string SessionID,
		int? ReportID,
		short? RptLines,
		byte? BalColIsLast,
		string pSite = null)
		{
			StringType _SessionID = SessionID;
			IntType _ReportID = ReportID;
			FormPositionType _RptLines = RptLines;
			ListYesNoType _BalColIsLast = BalColIsLast;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_MultiBucketSubSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportID", _ReportID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptLines", _RptLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalColIsLast", _BalColIsLast, ParameterDirection.Input);
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
