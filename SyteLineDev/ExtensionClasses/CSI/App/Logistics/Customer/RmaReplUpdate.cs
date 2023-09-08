//PROJECT NAME: Logistics
//CLASS NAME: RmaReplUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplUpdate : IRmaReplUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public RmaReplUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RmaReplUpdateSp(string PRmaNum,
		int? PRmaLine,
		string PItem,
		string PItemDesc,
		string PCustItem,
		decimal? PQtyToReturnConv,
		string PItemUM,
		decimal? PUnitPriceConv,
		string PCoNum,
		int? PCoLine,
		int? PRepair,
		string PPricecode,
		string PCustNum,
		string Infobar,
		int? IncludeTaxInPrice)
		{
			RmaNumType _PRmaNum = PRmaNum;
			RmaLineType _PRmaLine = PRmaLine;
			ItemType _PItem = PItem;
			DescriptionType _PItemDesc = PItemDesc;
			CustItemType _PCustItem = PCustItem;
			QtyUnitNoNegType _PQtyToReturnConv = PQtyToReturnConv;
			UMType _PItemUM = PItemUM;
			CostPrcNoNegType _PUnitPriceConv = PUnitPriceConv;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			ListYesNoType _PRepair = PRepair;
			PriceCodeType _PPricecode = PPricecode;
			CustNumType _PCustNum = PCustNum;
			InfobarType _Infobar = Infobar;
			ListYesNoType _IncludeTaxInPrice = IncludeTaxInPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaReplUpdateSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRmaLine", _PRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToReturnConv", _PQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemUM", _PItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPriceConv", _PUnitPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRepair", _PRepair, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPricecode", _PPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeTaxInPrice", _IncludeTaxInPrice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
