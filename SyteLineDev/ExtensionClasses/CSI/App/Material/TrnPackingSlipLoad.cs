//PROJECT NAME: Material
//CLASS NAME: TrnPackingSlipLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TrnPackingSlipLoad : ITrnPackingSlipLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public TrnPackingSlipLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) TrnPackingSlipLoadSp(string TrnNum,
		int? BegTrnLine,
		int? EndTrnLine,
		string LineStatT,
		string LineStatC,
		DateTime? BegDueDate,
		DateTime? EndDueDate)
		{
			ProjNumType _TrnNum = TrnNum;
			TrnLineType _BegTrnLine = BegTrnLine;
			TrnLineType _EndTrnLine = EndTrnLine;
			TransferStatusType _LineStatT = LineStatT;
			TransferStatusType _LineStatC = LineStatC;
			DateType _BegDueDate = BegDueDate;
			DateType _EndDueDate = EndDueDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnPackingSlipLoadSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTrnLine", _BegTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTrnLine", _EndTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineStatT", _LineStatT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineStatC", _LineStatC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDueDate", _BegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
