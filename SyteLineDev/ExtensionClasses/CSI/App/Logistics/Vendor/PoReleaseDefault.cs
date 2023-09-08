//PROJECT NAME: Logistics
//CLASS NAME: PoReleaseDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoReleaseDefault : IPoReleaseDefault
	{
		readonly IApplicationDB appDB;
		
		
		public PoReleaseDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Stat,
		string Item,
		string Description,
		string VendItem,
		decimal? BlanketQtyConv,
		string UM,
		decimal? PlanCostConv,
		decimal? ItemCostConv,
		DateTime? EffDate,
		DateTime? ExpDate,
		string Revision,
		string DrawingNbr,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		int? LeadTime,
		string Origin,
		string CommCode,
		decimal? UnitWeight,
		int? SerialTracked,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		decimal? TotalQtyOrderedConv,
		string NonInvAcct,
		string NonInvAcctDesc,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string ManufacturerId,
		string ManufacturerName,
		string ManufacturerItem,
		string ManufacturerItemDesc,
		string Infobar,
		int? AcctIsControl) PoReleaseDefaultSp(string PoNum,
		int? PoLine,
		string Stat,
		string Item,
		string Description,
		string VendItem,
		decimal? BlanketQtyConv,
		string UM,
		decimal? PlanCostConv,
		decimal? ItemCostConv,
		DateTime? EffDate,
		DateTime? ExpDate,
		string Revision,
		string DrawingNbr,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		int? LeadTime,
		string Origin,
		string CommCode,
		decimal? UnitWeight,
		int? SerialTracked,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		decimal? TotalQtyOrderedConv,
		string NonInvAcct,
		string NonInvAcctDesc,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string ManufacturerId,
		string ManufacturerName,
		string ManufacturerItem,
		string ManufacturerItemDesc,
		string Infobar,
		int? AcctIsControl)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoStatType _Stat = Stat;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			VendItemType _VendItem = VendItem;
			QtyUnitNoNegType _BlanketQtyConv = BlanketQtyConv;
			UMType _UM = UM;
			CostPrcType _PlanCostConv = PlanCostConv;
			CostPrcType _ItemCostConv = ItemCostConv;
			DateType _EffDate = EffDate;
			DateType _ExpDate = ExpDate;
			RevisionType _Revision = Revision;
			DrawingNbrType _DrawingNbr = DrawingNbr;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			LeadTimeType _LeadTime = LeadTime;
			EcCodeType _Origin = Origin;
			CommodityCodeType _CommCode = CommCode;
			UnitWeightType _UnitWeight = UnitWeight;
			ListYesNoType _SerialTracked = SerialTracked;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ListYesNoType _ItemExists = ItemExists;
			QtyTotlNoNegType _TotalQtyOrderedConv = TotalQtyOrderedConv;
			AcctType _NonInvAcct = NonInvAcct;
			DescriptionType _NonInvAcctDesc = NonInvAcctDesc;
			UnitCode1Type _NonInvAcctUnit1 = NonInvAcctUnit1;
			UnitCode2Type _NonInvAcctUnit2 = NonInvAcctUnit2;
			UnitCode3Type _NonInvAcctUnit3 = NonInvAcctUnit3;
			UnitCode4Type _NonInvAcctUnit4 = NonInvAcctUnit4;
			UnitCodeAccessType _AccessUnit1 = AccessUnit1;
			UnitCodeAccessType _AccessUnit2 = AccessUnit2;
			UnitCodeAccessType _AccessUnit3 = AccessUnit3;
			UnitCodeAccessType _AccessUnit4 = AccessUnit4;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			NameType _ManufacturerName = ManufacturerName;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			DescriptionType _ManufacturerItemDesc = ManufacturerItemDesc;
			Infobar _Infobar = Infobar;
			ListYesNoType _AcctIsControl = AcctIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoReleaseDefaultSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BlanketQtyConv", _BlanketQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanCostConv", _PlanCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCostConv", _ItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpDate", _ExpDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DrawingNbr", _DrawingNbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalQtyOrderedConv", _TotalQtyOrderedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcct", _NonInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctDesc", _NonInvAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit1", _NonInvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit2", _NonInvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit3", _NonInvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit4", _NonInvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit1", _AccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit2", _AccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit3", _AccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit4", _AccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerName", _ManufacturerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerItemDesc", _ManufacturerItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctIsControl", _AcctIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Stat = _Stat;
				Item = _Item;
				Description = _Description;
				VendItem = _VendItem;
				BlanketQtyConv = _BlanketQtyConv;
				UM = _UM;
				PlanCostConv = _PlanCostConv;
				ItemCostConv = _ItemCostConv;
				EffDate = _EffDate;
				ExpDate = _ExpDate;
				Revision = _Revision;
				DrawingNbr = _DrawingNbr;
				UnitMatCostConv = _UnitMatCostConv;
				UnitFreightCostConv = _UnitFreightCostConv;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitInsuranceCostConv = _UnitInsuranceCostConv;
				UnitLocFrtCostConv = _UnitLocFrtCostConv;
				LeadTime = _LeadTime;
				Origin = _Origin;
				CommCode = _CommCode;
				UnitWeight = _UnitWeight;
				SerialTracked = _SerialTracked;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				ItemExists = _ItemExists;
				TotalQtyOrderedConv = _TotalQtyOrderedConv;
				NonInvAcct = _NonInvAcct;
				NonInvAcctDesc = _NonInvAcctDesc;
				NonInvAcctUnit1 = _NonInvAcctUnit1;
				NonInvAcctUnit2 = _NonInvAcctUnit2;
				NonInvAcctUnit3 = _NonInvAcctUnit3;
				NonInvAcctUnit4 = _NonInvAcctUnit4;
				AccessUnit1 = _AccessUnit1;
				AccessUnit2 = _AccessUnit2;
				AccessUnit3 = _AccessUnit3;
				AccessUnit4 = _AccessUnit4;
				ManufacturerId = _ManufacturerId;
				ManufacturerName = _ManufacturerName;
				ManufacturerItem = _ManufacturerItem;
				ManufacturerItemDesc = _ManufacturerItemDesc;
				Infobar = _Infobar;
				AcctIsControl = _AcctIsControl;
				
				return (Severity, Stat, Item, Description, VendItem, BlanketQtyConv, UM, PlanCostConv, ItemCostConv, EffDate, ExpDate, Revision, DrawingNbr, UnitMatCostConv, UnitFreightCostConv, UnitDutyCostConv, UnitBrokerageCostConv, UnitInsuranceCostConv, UnitLocFrtCostConv, LeadTime, Origin, CommCode, UnitWeight, SerialTracked, TaxCode1, TaxCode2, ItemExists, TotalQtyOrderedConv, NonInvAcct, NonInvAcctDesc, NonInvAcctUnit1, NonInvAcctUnit2, NonInvAcctUnit3, NonInvAcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, ManufacturerId, ManufacturerName, ManufacturerItem, ManufacturerItemDesc, Infobar, AcctIsControl);
			}
		}
	}
}
