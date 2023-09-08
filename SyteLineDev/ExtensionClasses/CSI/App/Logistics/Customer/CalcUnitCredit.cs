//PROJECT NAME: Logistics
//CLASS NAME: CalcUnitCredit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalcUnitCredit : ICalcUnitCredit
	{
		readonly IApplicationDB appDB;
		
		
		public CalcUnitCredit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PUnitCreditConv,
		string Infobar,
		int? PIncludeTaxInPrice) CalcUnitCreditSp(string PRmaNum,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PItem,
		string PUM,
		decimal? PQtyToReturnConv,
		string PPricecode,
		string PCustItem = null,
		decimal? PUnitCreditConv = null,
		string Infobar = null,
		int? PIncludeTaxInPrice = null)
		{
			RmaNumType _PRmaNum = PRmaNum;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			ItemType _PItem = PItem;
			UMType _PUM = PUM;
			QtyUnitNoNegType _PQtyToReturnConv = PQtyToReturnConv;
			PriceCodeType _PPricecode = PPricecode;
			ItemType _PCustItem = PCustItem;
			CostPrcNoNegType _PUnitCreditConv = PUnitCreditConv;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PIncludeTaxInPrice = PIncludeTaxInPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcUnitCreditSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToReturnConv", _PQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPricecode", _PPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCreditConv", _PUnitCreditConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PIncludeTaxInPrice", _PIncludeTaxInPrice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitCreditConv = _PUnitCreditConv;
				Infobar = _Infobar;
				PIncludeTaxInPrice = _PIncludeTaxInPrice;
				
				return (Severity, PUnitCreditConv, Infobar, PIncludeTaxInPrice);
			}
		}
	}
}
