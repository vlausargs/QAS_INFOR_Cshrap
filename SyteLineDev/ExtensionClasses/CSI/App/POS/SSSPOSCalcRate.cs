//PROJECT NAME: POS
//CLASS NAME: SSSPOSCalcRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public interface ISSSPOSCalcRate
	{
		(int? ReturnCode, decimal? PriceConv, string Infobar) SSSPOSCalcRateSp(string POSNum,
		int? TransNum,
		string Item,
		decimal? QtyOrderedConv,
		byte? SSSFSYN,
		string BillCode,
		decimal? PriceConv,
		string Infobar,
		string UM,
		string Whse,
		string CoNum = null,
		short? CoLine = null,
		string PromotionCode = null,
		string site = null);
	}
	
	public class SSSPOSCalcRate : ISSSPOSCalcRate
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCalcRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PriceConv, string Infobar) SSSPOSCalcRateSp(string POSNum,
		int? TransNum,
		string Item,
		decimal? QtyOrderedConv,
		byte? SSSFSYN,
		string BillCode,
		decimal? PriceConv,
		string Infobar,
		string UM,
		string Whse,
		string CoNum = null,
		short? CoLine = null,
		string PromotionCode = null,
		string site = null)
		{
			POSMNumType _POSNum = POSNum;
			POSMTransNumType _TransNum = TransNum;
			ItemType _Item = Item;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			ListYesNoType _SSSFSYN = SSSFSYN;
			FSSROBillCodeType _BillCode = BillCode;
			CostPrcType _PriceConv = PriceConv;
			InfobarType _Infobar = Infobar;
			UMType _UM = UM;
			WhseType _Whse = Whse;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			PromotionCodeType _PromotionCode = PromotionCode;
			SiteType _site = site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCalcRateSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSYN", _SSSFSYN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "site", _site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceConv = _PriceConv;
				Infobar = _Infobar;
				
				return (Severity, PriceConv, Infobar);
			}
		}
	}
}
