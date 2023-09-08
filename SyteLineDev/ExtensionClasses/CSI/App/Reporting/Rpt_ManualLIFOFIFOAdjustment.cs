//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ManualLIFOFIFOAdjustment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ManualLIFOFIFOAdjustment : IRpt_ManualLIFOFIFOAdjustment
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ManualLIFOFIFOAdjustment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ManualLIFOFIFOAdjustmentSp(string SessionIdChar = null,
		string InvAdjAcct = null,
		string InvAdjAcctDesc = null,
		string ItemlifoItem = null,
		string ItemlifoInvAcct = null,
		string ItemlifoLbrAcct = null,
		string ItemlifoFovhdAcct = null,
		string ItemlifoVovhdAcct = null,
		string ItemlifoOutAcct = null,
		string CostMethod = null,
		decimal? DerLocQtyOnHand = null,
		decimal? DerStackValue = null,
		decimal? DerStackQty = null,
		decimal? AdjustedValue = null,
		decimal? AdjustedQuantity = null,
		string Whse = null,
		int? TaskId = null,
		string pSite = null)
		{
			StringType _SessionIdChar = SessionIdChar;
			AcctType _InvAdjAcct = InvAdjAcct;
			DescriptionType _InvAdjAcctDesc = InvAdjAcctDesc;
			ItemType _ItemlifoItem = ItemlifoItem;
			AcctType _ItemlifoInvAcct = ItemlifoInvAcct;
			AcctType _ItemlifoLbrAcct = ItemlifoLbrAcct;
			AcctType _ItemlifoFovhdAcct = ItemlifoFovhdAcct;
			AcctType _ItemlifoVovhdAcct = ItemlifoVovhdAcct;
			AcctType _ItemlifoOutAcct = ItemlifoOutAcct;
			CostMethodType _CostMethod = CostMethod;
			QtyTotlType _DerLocQtyOnHand = DerLocQtyOnHand;
			CostPrcType _DerStackValue = DerStackValue;
			QtyTotlType _DerStackQty = DerStackQty;
			CostPrcType _AdjustedValue = AdjustedValue;
			QtyTotlType _AdjustedQuantity = AdjustedQuantity;
			WhseType _Whse = Whse;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ManualLIFOFIFOAdjustmentSp";
				
				appDB.AddCommandParameter(cmd, "SessionIdChar", _SessionIdChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvAdjAcct", _InvAdjAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvAdjAcctDesc", _InvAdjAcctDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoItem", _ItemlifoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoInvAcct", _ItemlifoInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoLbrAcct", _ItemlifoLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoFovhdAcct", _ItemlifoFovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoVovhdAcct", _ItemlifoVovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoOutAcct", _ItemlifoOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostMethod", _CostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerLocQtyOnHand", _DerLocQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerStackValue", _DerStackValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerStackQty", _DerStackQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustedValue", _AdjustedValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustedQuantity", _AdjustedQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
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
