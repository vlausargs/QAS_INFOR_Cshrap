//PROJECT NAME: CSICustomer
//CLASS NAME: MoveEstimatesToHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IMoveEstimatesToHistory
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) MoveEstimatesToHistorySp(string Process = "P",
		string StartingEstimate = null,
		string EndingEstimate = null,
		DateTime? StartingQuoteDate = null,
		DateTime? EndingQuoteDate = null,
		DateTime? StartingExpDate = null,
		DateTime? EndingExpDate = null,
		string OldStatus = null,
		string Infobar = null);
	}
	
	public class MoveEstimatesToHistory : IMoveEstimatesToHistory
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MoveEstimatesToHistory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) MoveEstimatesToHistorySp(string Process = "P",
		string StartingEstimate = null,
		string EndingEstimate = null,
		DateTime? StartingQuoteDate = null,
		DateTime? EndingQuoteDate = null,
		DateTime? StartingExpDate = null,
		DateTime? EndingExpDate = null,
		string OldStatus = null,
		string Infobar = null)
		{
			StringType _Process = Process;
			CoNumType _StartingEstimate = StartingEstimate;
			CoNumType _EndingEstimate = EndingEstimate;
			DateType _StartingQuoteDate = StartingQuoteDate;
			DateType _EndingQuoteDate = EndingQuoteDate;
			DateType _StartingExpDate = StartingExpDate;
			DateType _EndingExpDate = EndingExpDate;
			StringType _OldStatus = OldStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveEstimatesToHistorySp";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingEstimate", _StartingEstimate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEstimate", _EndingEstimate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingQuoteDate", _StartingQuoteDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingQuoteDate", _EndingQuoteDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingExpDate", _StartingExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingExpDate", _EndingExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStatus", _OldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
