//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_TransferOrderShpRcv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICLM_TransferOrderShpRcv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TransferOrderShpRcvSp(string TrnNum,
		string TOLineItemStatus = "T",
		DateTime? SchedShipDateStarting = null,
		DateTime? SchedShipDateEnding = null,
		DateTime? SchedRcvdDateStarting = null,
		DateTime? SchedRcvdDateEnding = null,
		string CallType = null,
		string FilterString = null);
	}
	
	public class CLM_TransferOrderShpRcv : ICLM_TransferOrderShpRcv
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_TransferOrderShpRcv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_TransferOrderShpRcvSp(string TrnNum,
		string TOLineItemStatus = "T",
		DateTime? SchedShipDateStarting = null,
		DateTime? SchedShipDateEnding = null,
		DateTime? SchedRcvdDateStarting = null,
		DateTime? SchedRcvdDateEnding = null,
		string CallType = null,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				TrnNumType _TrnNum = TrnNum;
				StringType _TOLineItemStatus = TOLineItemStatus;
				DateType _SchedShipDateStarting = SchedShipDateStarting;
				DateType _SchedShipDateEnding = SchedShipDateEnding;
				DateType _SchedRcvdDateStarting = SchedRcvdDateStarting;
				DateType _SchedRcvdDateEnding = SchedRcvdDateEnding;
				StringType _CallType = CallType;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_TransferOrderShpRcvSp";
					
					appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TOLineItemStatus", _TOLineItemStatus, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SchedShipDateStarting", _SchedShipDateStarting, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SchedShipDateEnding", _SchedShipDateEnding, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SchedRcvdDateStarting", _SchedRcvdDateStarting, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SchedRcvdDateEnding", _SchedRcvdDateEnding, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CallType", _CallType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
