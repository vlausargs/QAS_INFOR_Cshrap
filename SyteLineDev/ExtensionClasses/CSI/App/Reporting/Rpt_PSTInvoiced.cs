//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PSTInvoiced.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PSTInvoiced : IRpt_PSTInvoiced
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PSTInvoiced(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PSTInvoicedSp(DateTime? SPerDate = null,
		DateTime? EPerDate = null,
		int? SPerDateOffSET = null,
		int? EPerDateOffSET = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			DateType _SPerDate = SPerDate;
			DateType _EPerDate = EPerDate;
			DateOffsetType _SPerDateOffSET = SPerDateOffSET;
			DateOffsetType _EPerDateOffSET = EPerDateOffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PSTInvoicedSp";
				
				appDB.AddCommandParameter(cmd, "SPerDate", _SPerDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPerDate", _EPerDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPerDateOffSET", _SPerDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPerDateOffSET", _EPerDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
