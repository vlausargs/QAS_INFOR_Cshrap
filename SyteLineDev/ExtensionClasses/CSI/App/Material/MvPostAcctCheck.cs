//PROJECT NAME: Material
//CLASS NAME: MvPostAcctCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MvPostAcctCheck : IMvPostAcctCheck
	{
		readonly IApplicationDB appDB;
		
		public MvPostAcctCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PostAcctChg,
			int? PostCostChg,
			string Infobar) MvPostAcctCheckSp(
			string Item,
			string FromWhse,
			string FromLoc,
			string ToWhse,
			string ToLoc,
			string ItemlocInvAcct,
			string ItemlocLbrAcct,
			string ItemlocFovhdAcct,
			string ItemlocVovhdAcct,
			string ItemlocOutAcct,
			decimal? ItemlocMatlCost,
			decimal? ItemlocLbrCost,
			decimal? ItemlocFovhdCost,
			decimal? ItemlocVovhdCost,
			decimal? ItemlocOutCost,
			string XItemlocInvAcct,
			string XItemlocLbrAcct,
			string XItemlocFovhdAcct,
			string XItemlocVovhdAcct,
			string XItemlocOutAcct,
			decimal? XItemlocMatlCost,
			decimal? XItemlocLbrCost,
			decimal? XItemlocFovhdCost,
			decimal? XItemlocVovhdCost,
			decimal? XItemlocOutCost,
			string ProdcodeInvAdjAcct,
			string ItemCostMethod,
			int? ItemLotTracked,
			int? PostAcctChg,
			int? PostCostChg,
			string Infobar)
		{
			ItemType _Item = Item;
			WhseType _FromWhse = FromWhse;
			LocType _FromLoc = FromLoc;
			WhseType _ToWhse = ToWhse;
			LocType _ToLoc = ToLoc;
			AcctType _ItemlocInvAcct = ItemlocInvAcct;
			AcctType _ItemlocLbrAcct = ItemlocLbrAcct;
			AcctType _ItemlocFovhdAcct = ItemlocFovhdAcct;
			AcctType _ItemlocVovhdAcct = ItemlocVovhdAcct;
			AcctType _ItemlocOutAcct = ItemlocOutAcct;
			CostPrcType _ItemlocMatlCost = ItemlocMatlCost;
			CostPrcType _ItemlocLbrCost = ItemlocLbrCost;
			CostPrcType _ItemlocFovhdCost = ItemlocFovhdCost;
			CostPrcType _ItemlocVovhdCost = ItemlocVovhdCost;
			CostPrcType _ItemlocOutCost = ItemlocOutCost;
			AcctType _XItemlocInvAcct = XItemlocInvAcct;
			AcctType _XItemlocLbrAcct = XItemlocLbrAcct;
			AcctType _XItemlocFovhdAcct = XItemlocFovhdAcct;
			AcctType _XItemlocVovhdAcct = XItemlocVovhdAcct;
			AcctType _XItemlocOutAcct = XItemlocOutAcct;
			CostPrcType _XItemlocMatlCost = XItemlocMatlCost;
			CostPrcType _XItemlocLbrCost = XItemlocLbrCost;
			CostPrcType _XItemlocFovhdCost = XItemlocFovhdCost;
			CostPrcType _XItemlocVovhdCost = XItemlocVovhdCost;
			CostPrcType _XItemlocOutCost = XItemlocOutCost;
			AcctType _ProdcodeInvAdjAcct = ProdcodeInvAdjAcct;
			CostMethodType _ItemCostMethod = ItemCostMethod;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _PostAcctChg = PostAcctChg;
			ListYesNoType _PostCostChg = PostCostChg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MvPostAcctCheckSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocInvAcct", _ItemlocInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocLbrAcct", _ItemlocLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocFovhdAcct", _ItemlocFovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocVovhdAcct", _ItemlocVovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocOutAcct", _ItemlocOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocMatlCost", _ItemlocMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocLbrCost", _ItemlocLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocFovhdCost", _ItemlocFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocVovhdCost", _ItemlocVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocOutCost", _ItemlocOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocInvAcct", _XItemlocInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocLbrAcct", _XItemlocLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocFovhdAcct", _XItemlocFovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocVovhdAcct", _XItemlocVovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocOutAcct", _XItemlocOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocMatlCost", _XItemlocMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocLbrCost", _XItemlocLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocFovhdCost", _XItemlocFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocVovhdCost", _XItemlocVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocOutCost", _XItemlocOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdcodeInvAdjAcct", _ProdcodeInvAdjAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCostMethod", _ItemCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostAcctChg", _PostAcctChg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostCostChg", _PostCostChg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PostAcctChg = _PostAcctChg;
				PostCostChg = _PostCostChg;
				Infobar = _Infobar;
				
				return (Severity, PostAcctChg, PostCostChg, Infobar);
			}
		}
	}
}
