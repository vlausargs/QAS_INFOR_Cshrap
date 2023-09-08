//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintPackingSlip : IRpt_ReprintPackingSlip
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ReprintPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) Rpt_ReprintPackingSlipSp(int? PStartSlipNum = null,
		int? PEndSlipNum = null,
		int? PrintLineReleaseDescription = null,
		int? PPrPlanItemMatl = null,
		int? PPrSerialNumber = null,
		int? PrintOrderNotes = null,
		int? PrintLineReleaseNotes = null,
		int? PrintinternalNotes = null,
		int? PrintExternalNotes = null,
		int? DisplayHeader = null,
		int? PrintItemOverview = null,
		string InfoBar = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null)
		{
			PackNumType _PStartSlipNum = PStartSlipNum;
			PackNumType _PEndSlipNum = PEndSlipNum;
			FlagNyType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			FlagNyType _PPrPlanItemMatl = PPrPlanItemMatl;
			FlagNyType _PPrSerialNumber = PPrSerialNumber;
			FlagNyType _PrintOrderNotes = PrintOrderNotes;
			FlagNyType _PrintLineReleaseNotes = PrintLineReleaseNotes;
			FlagNyType _PrintinternalNotes = PrintinternalNotes;
			FlagNyType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			InfobarType _InfoBar = InfoBar;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "PStartSlipNum", _PStartSlipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSlipNum", _PEndSlipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrPlanItemMatl", _PPrPlanItemMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrSerialNumber", _PPrSerialNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseNotes", _PrintLineReleaseNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintinternalNotes", _PrintinternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
			}
		}
	}
}
