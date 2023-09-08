//PROJECT NAME: Logistics
//CLASS NAME: CLM_PurchaseOrderReceiving.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchaseOrderReceiving : ICLM_PurchaseOrderReceiving
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PurchaseOrderReceiving(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchaseOrderReceivingSp(string CurWhse,
		string PVendNum,
		DateTime? SDueDate,
		DateTime? EDueDate,
		string PGrnNum,
		int? PGrnLine,
		int? PByGrn,
		string PPoNum,
		int? PPoLine,
		int? PPoRelease,
		string PoitemStatuses,
		DateTime? TransDate = null,
		string FilterString = null,
		int? ReturnToTable = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				WhseType _CurWhse = CurWhse;
				VendNumType _PVendNum = PVendNum;
				CurrentDateType _SDueDate = SDueDate;
				CurrentDateType _EDueDate = EDueDate;
				GrnNumType _PGrnNum = PGrnNum;
				GrnLineType _PGrnLine = PGrnLine;
				FlagNyType _PByGrn = PByGrn;
				PoNumType _PPoNum = PPoNum;
				PoLineType _PPoLine = PPoLine;
				PoReleaseType _PPoRelease = PPoRelease;
				StringType _PoitemStatuses = PoitemStatuses;
				DateTimeType _TransDate = TransDate;
				LongListType _FilterString = FilterString;
				ListYesNoType _ReturnToTable = ReturnToTable;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_PurchaseOrderReceiving";
					
					appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SDueDate", _SDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EDueDate", _EDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PGrnNum", _PGrnNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PGrnLine", _PGrnLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PByGrn", _PByGrn, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PoitemStatuses", _PoitemStatuses, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ReturnToTable", _ReturnToTable, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
