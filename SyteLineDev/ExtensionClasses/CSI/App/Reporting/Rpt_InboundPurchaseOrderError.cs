//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundPurchaseOrderError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InboundPurchaseOrderError
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundPurchaseOrderErrorSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? RecDateStarting = null,
		DateTime? RecDateEnding = null,
		short? RecDateStartingOffset = null,
		short? RecDateEndingOffset = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_InboundPurchaseOrderError : IRpt_InboundPurchaseOrderError
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InboundPurchaseOrderError(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundPurchaseOrderErrorSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? RecDateStarting = null,
		DateTime? RecDateEnding = null,
		short? RecDateStartingOffset = null,
		short? RecDateEndingOffset = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _RecDateStarting = RecDateStarting;
			DateType _RecDateEnding = RecDateEnding;
			DateOffsetType _RecDateStartingOffset = RecDateStartingOffset;
			DateOffsetType _RecDateEndingOffset = RecDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InboundPurchaseOrderErrorSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecDateStarting", _RecDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecDateEnding", _RecDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecDateStartingOffset", _RecDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecDateEndingOffset", _RecDateEndingOffset, ParameterDirection.Input);
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
