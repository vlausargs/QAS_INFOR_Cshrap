//PROJECT NAME: Data
//CLASS NAME: RepCoBln.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepCoBln : IRepCoBln
	{
		readonly IApplicationDB appDB;
		
		public RepCoBln(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepCoBlnSp(
			string CoNum,
			int? CoLine,
			string Item,
			string CustItem,
			string FeatStr,
			decimal? BlanketQty,
			DateTime? EffDate,
			DateTime? ExpDate,
			decimal? ContPrice,
			string Stat,
			DateTime? PromiseDate,
			string Pricecode,
			string UM,
			decimal? BlanketQtyConv,
			decimal? ContPriceConv,
			string ShipSite,
			string Description,
			string ConfigId,
			string NonInvAcct,
			string NonInvAcctUnit1,
			string NonInvAcctUnit2,
			string NonInvAcctUnit3,
			string NonInvAcctUnit4,
			decimal? CostConv,
			string OrigSite,
			string ManufacturerId,
			string ManufacturerItem,
			string Infobar,
			int? RepFromTrigger = 0,
			string UETListPairs = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ItemType _Item = Item;
			CustItemType _CustItem = CustItem;
			FeatStrType _FeatStr = FeatStr;
			QtyTotlType _BlanketQty = BlanketQty;
			DateType _EffDate = EffDate;
			DateType _ExpDate = ExpDate;
			CostPrcType _ContPrice = ContPrice;
			CoBlnStatusType _Stat = Stat;
			DateType _PromiseDate = PromiseDate;
			PriceCodeType _Pricecode = Pricecode;
			UMType _UM = UM;
			QtyTotlType _BlanketQtyConv = BlanketQtyConv;
			CostPrcType _ContPriceConv = ContPriceConv;
			SiteType _ShipSite = ShipSite;
			DescriptionType _Description = Description;
			ConfigIdType _ConfigId = ConfigId;
			AcctType _NonInvAcct = NonInvAcct;
			UnitCode1Type _NonInvAcctUnit1 = NonInvAcctUnit1;
			UnitCode2Type _NonInvAcctUnit2 = NonInvAcctUnit2;
			UnitCode3Type _NonInvAcctUnit3 = NonInvAcctUnit3;
			UnitCode4Type _NonInvAcctUnit4 = NonInvAcctUnit4;
			CostPrcType _CostConv = CostConv;
			SiteType _OrigSite = OrigSite;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			Infobar _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			VeryLongListType _UETListPairs = UETListPairs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepCoBlnSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQty", _BlanketQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpDate", _ExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContPrice", _ContPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromiseDate", _PromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQtyConv", _BlanketQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContPriceConv", _ContPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcct", _NonInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit1", _NonInvAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit2", _NonInvAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit3", _NonInvAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit4", _NonInvAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigSite", _OrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
