//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceMilestoneProgress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InvoiceMilestoneProgress
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceMilestoneProgressSp(string BegProjNum = null,
		string EndProjNum = null,
		string BegInvMsNum = null,
		string EndInvMsNum = null,
		byte? PDisplayHeader = (byte)1,
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_InvoiceMilestoneProgress : IRpt_InvoiceMilestoneProgress
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InvoiceMilestoneProgress(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceMilestoneProgressSp(string BegProjNum = null,
		string EndProjNum = null,
		string BegInvMsNum = null,
		string EndInvMsNum = null,
		byte? PDisplayHeader = (byte)1,
		int? TaskId = null,
		string pSite = null)
		{
			ProjNumType _BegProjNum = BegProjNum;
			ProjNumType _EndProjNum = EndProjNum;
			ProjMsNumType _BegInvMsNum = BegInvMsNum;
			ProjMsNumType _EndInvMsNum = EndInvMsNum;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InvoiceMilestoneProgressSp";
				
				appDB.AddCommandParameter(cmd, "BegProjNum", _BegProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProjNum", _EndProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegInvMsNum", _BegInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvMsNum", _EndInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
