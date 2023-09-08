//PROJECT NAME: Data
//CLASS NAME: Home_PurchaseOrderVariancebyItemSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Home_PurchaseOrderVariancebyItemSub : IHome_PurchaseOrderVariancebyItemSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Home_PurchaseOrderVariancebyItemSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) Home_PurchaseOrderVariancebyItemSubSp(
			string StartingItem = null,
			string EndingItem = null,
			string POType = null,
			string POStatus = null,
			string POLineRelStatus = null,
			decimal? ToleranceFactor = null,
			int? TransDomCurr = null,
			DateTime? StartingDueDate = null,
			DateTime? EndingDueDate = null,
			int? StartingDueDateOffset = null,
			int? EndingDueDateOffset = null,
			DateTime? StartingLastRcvdDate = null,
			DateTime? EndingLastRcvdDate = null,
			int? StartingLastRcvdDateOffset = null,
			int? EndingLastRcvdDateOffset = null,
			string StartingPO = null,
			string EndingPO = null,
			string StartingVendor = null,
			string EndingVendor = null,
			DateTime? StartingOrderDate = null,
			DateTime? EndingOrderDate = null,
			int? StartingOrderDateOffset = null,
			int? EndingOrderDateOffset = null,
			int? TaskId = null,
			string Infobar = null)
		{
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			StringType _POType = POType;
			StringType _POStatus = POStatus;
			StringType _POLineRelStatus = POLineRelStatus;
			MarkupType _ToleranceFactor = ToleranceFactor;
			FlagNyType _TransDomCurr = TransDomCurr;
			DateType _StartingDueDate = StartingDueDate;
			DateType _EndingDueDate = EndingDueDate;
			DateOffsetType _StartingDueDateOffset = StartingDueDateOffset;
			DateOffsetType _EndingDueDateOffset = EndingDueDateOffset;
			DateType _StartingLastRcvdDate = StartingLastRcvdDate;
			DateType _EndingLastRcvdDate = EndingLastRcvdDate;
			DateOffsetType _StartingLastRcvdDateOffset = StartingLastRcvdDateOffset;
			DateOffsetType _EndingLastRcvdDateOffset = EndingLastRcvdDateOffset;
			PoNumType _StartingPO = StartingPO;
			PoNumType _EndingPO = EndingPO;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			DateType _StartingOrderDate = StartingOrderDate;
			DateType _EndingOrderDate = EndingOrderDate;
			DateOffsetType _StartingOrderDateOffset = StartingOrderDateOffset;
			DateOffsetType _EndingOrderDateOffset = EndingOrderDateOffset;
			TaskNumType _TaskId = TaskId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_PurchaseOrderVariancebyItemSubSp";
				
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POType", _POType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POStatus", _POStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POLineRelStatus", _POLineRelStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToleranceFactor", _ToleranceFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDueDate", _StartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDueDate", _EndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDueDateOffset", _StartingDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDueDateOffset", _EndingDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLastRcvdDate", _StartingLastRcvdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLastRcvdDate", _EndingLastRcvdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLastRcvdDateOffset", _StartingLastRcvdDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLastRcvdDateOffset", _EndingLastRcvdDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPO", _StartingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPO", _EndingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrderDate", _StartingOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrderDate", _EndingOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrderDateOffset", _StartingOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrderDateOffset", _EndingOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
