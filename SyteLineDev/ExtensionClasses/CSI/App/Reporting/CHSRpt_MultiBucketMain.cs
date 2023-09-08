//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_MultiBucketMain.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_MultiBucketMain
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_MultiBucketMainSp(string SessionID,
		short? RptLines,
		byte? BalColIsLast,
		int? BGCount,
		string pSite = null);
	}
	
	public class CHSRpt_MultiBucketMain : ICHSRpt_MultiBucketMain
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_MultiBucketMain(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_MultiBucketMainSp(string SessionID,
		short? RptLines,
		byte? BalColIsLast,
		int? BGCount,
		string pSite = null)
		{
			StringType _SessionID = SessionID;
			FormPositionType _RptLines = RptLines;
			ListYesNoType _BalColIsLast = BalColIsLast;
			IntType _BGCount = BGCount;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_MultiBucketMainSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptLines", _RptLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalColIsLast", _BalColIsLast, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGCount", _BGCount, ParameterDirection.Input);
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
