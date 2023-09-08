//PROJECT NAME: Logistics
//CLASS NAME: POBuilderCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POBuilderCopy : IPOBuilderCopy
	{
		readonly IApplicationDB appDB;
		
		public POBuilderCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) POBuilderCopySP(
			Guid? ProcessID,
			string SiteRef,
			string Item,
			string Description,
			string VendItem,
			decimal? QtyOrdered,
			decimal? QtyOrderedConv,
			string UM,
			string Stat,
			decimal? PlanCost,
			decimal? PlanCostConv,
			decimal? UnitMatCost,
			decimal? UnitMatCostConv,
			decimal? UnitDutyCost,
			decimal? UnitDutyCostConv,
			decimal? UnitFreightCost,
			decimal? UnitFreightCostConv,
			decimal? UnitBrokerageCost,
			decimal? UnitBrokerageCostConv,
			decimal? UnitLocalFreight,
			decimal? UnitLocalFreightConv,
			decimal? UnitInsuranceCost,
			decimal? UnitInsuranceCostConv,
			DateTime? DueDate,
			DateTime? ReleaseDate,
			string NonInvAcct,
			string NonInvAcctUnit1,
			string NonInvAcctUnit2,
			string NonInvAcctUnit3,
			string NonInvAcctUnit4,
			int? LcOverride,
			Guid? ApsPlanRowPointer,
			string ManufacturerId,
			string ManufacturerItem,
			string Infobar)
		{
			RowPointerType _ProcessID = ProcessID;
			SiteType _SiteRef = SiteRef;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			VendItemType _VendItem = VendItem;
			QtyUnitNoNegType _QtyOrdered = QtyOrdered;
			QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
			UMType _UM = UM;
			PoitemStatType _Stat = Stat;
			CostPrcType _PlanCost = PlanCost;
			CostPrcType _PlanCostConv = PlanCostConv;
			CostPrcType _UnitMatCost = UnitMatCost;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitLocalFreight = UnitLocalFreight;
			CostPrcType _UnitLocalFreightConv = UnitLocalFreightConv;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			DateType _DueDate = DueDate;
			DateType _ReleaseDate = ReleaseDate;
			AcctType _NonInvAcct = NonInvAcct;
			UnitCode1Type _NonInvAcctUnit1 = NonInvAcctUnit1;
			UnitCode2Type _NonInvAcctUnit2 = NonInvAcctUnit2;
			UnitCode3Type _NonInvAcctUnit3 = NonInvAcctUnit3;
			UnitCode4Type _NonInvAcctUnit4 = NonInvAcctUnit4;
			ListYesNoType _LcOverride = LcOverride;
			RowPointerType _ApsPlanRowPointer = ApsPlanRowPointer;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POBuilderCopySP";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCost", _PlanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCostConv", _PlanCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLocalFreight", _UnitLocalFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLocalFreightConv", _UnitLocalFreightConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcct", _NonInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit1", _NonInvAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit2", _NonInvAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit3", _NonInvAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit4", _NonInvAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcOverride", _LcOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsPlanRowPointer", _ApsPlanRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
