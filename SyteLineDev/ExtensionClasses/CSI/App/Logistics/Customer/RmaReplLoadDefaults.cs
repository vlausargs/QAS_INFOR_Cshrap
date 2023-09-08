//PROJECT NAME: Logistics
//CLASS NAME: RmaReplLoadDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplLoadDefaults : IRmaReplLoadDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public RmaReplLoadDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PItem,
		string RCustItem,
		string RItemDesc,
		string RItemUM,
		decimal? RUnitPrice,
		int? RItemSerTrack,
		int? IncludeTaxInPrice,
		string Infobar) RmaReplLoadDefaultsSp(string PRmaNum,
		int? PRmaLine,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PItem,
		decimal? PQtyToReturnConv,
		string PPricecode,
		string RCustItem,
		string RItemDesc,
		string RItemUM,
		decimal? RUnitPrice,
		int? RItemSerTrack,
		int? IncludeTaxInPrice,
		string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			RmaLineType _PRmaLine = PRmaLine;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			ItemType _PItem = PItem;
			QtyUnitNoNegType _PQtyToReturnConv = PQtyToReturnConv;
			PriceCodeType _PPricecode = PPricecode;
			ItemType _RCustItem = RCustItem;
			DescriptionType _RItemDesc = RItemDesc;
			UMType _RItemUM = RItemUM;
			CostPrcNoNegType _RUnitPrice = RUnitPrice;
			ListYesNoType _RItemSerTrack = RItemSerTrack;
			ListYesNoType _IncludeTaxInPrice = IncludeTaxInPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaReplLoadDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRmaLine", _PRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyToReturnConv", _PQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPricecode", _PPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RCustItem", _RCustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemDesc", _RItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemUM", _RItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RUnitPrice", _RUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemSerTrack", _RItemSerTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeTaxInPrice", _IncludeTaxInPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItem = _PItem;
				RCustItem = _RCustItem;
				RItemDesc = _RItemDesc;
				RItemUM = _RItemUM;
				RUnitPrice = _RUnitPrice;
				RItemSerTrack = _RItemSerTrack;
				IncludeTaxInPrice = _IncludeTaxInPrice;
				Infobar = _Infobar;
				
				return (Severity, PItem, RCustItem, RItemDesc, RItemUM, RUnitPrice, RItemSerTrack, IncludeTaxInPrice, Infobar);
			}
		}
	}
}
