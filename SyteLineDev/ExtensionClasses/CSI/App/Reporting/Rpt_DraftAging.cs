//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DraftAging.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_DraftAging : IRpt_DraftAging
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_DraftAging(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_DraftAgingSp(string BegCusNum = null,
		string EndCusNum = null,
		DateTime? ExBegDueDate = null,
		DateTime? ExEndDueDate = null,
		int? ExBegDateOffset = null,
		int? ExEndDateOffset = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _BegCusNum = BegCusNum;
			CustNumType _EndCusNum = EndCusNum;
			DateType _ExBegDueDate = ExBegDueDate;
			DateType _ExEndDueDate = ExEndDueDate;
			DateOffsetType _ExBegDateOffset = ExBegDateOffset;
			DateOffsetType _ExEndDateOffset = ExEndDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_DraftAgingSp";
				
				appDB.AddCommandParameter(cmd, "BegCusNum", _BegCusNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCusNum", _EndCusNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegDueDate", _ExBegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndDueDate", _ExEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegDateOffset", _ExBegDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndDateOffset", _ExEndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
