//PROJECT NAME: Logistics
//CLASS NAME: POItemlog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POItemlog : IPOItemlog
	{
		readonly IApplicationDB appDB;
		
		public POItemlog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) POItemlogSp(
			string PAction,
			string PPoNum,
			int? PPoLine,
			int? PPoRelease,
			string PNewItem = null,
			string POldItem = null,
			string PNewUM = null,
			string POldUM = null,
			string PNewStatus = null,
			string POldStatus = null,
			decimal? PNewQty = 0,
			decimal? POldQty = 0,
			decimal? PNewItemCost = 0,
			decimal? POldItemCost = 0,
			decimal? PNewMaterialCost = 0,
			decimal? POldMaterialCost = 0,
			decimal? PNewFreightCost = 0,
			decimal? POldFreightCost = 0,
			decimal? PNewDutyCost = 0,
			decimal? POldDutyCost = 0,
			decimal? PNewBrokerageCost = 0,
			decimal? POldBrokerageCost = 0,
			decimal? PNewInsuranceCost = 0,
			decimal? POldInsuranceCost = 0,
			decimal? PNewLocalFreightCost = 0,
			decimal? POldLocalFreightCost = 0,
			decimal? PNewPlanCost = 0,
			decimal? POldPlanCost = 0,
			DateTime? PNewDueDate = null,
			DateTime? POldDueDate = null,
			DateTime? PNewPromiseDate = null,
			DateTime? POldPromiseDate = null,
			decimal? PNewConvFactor = null,
			decimal? POldConvFactor = null,
			string Infobar = null)
		{
			LongListType _PAction = PAction;
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			ItemType _PNewItem = PNewItem;
			ItemType _POldItem = POldItem;
			UMType _PNewUM = PNewUM;
			UMType _POldUM = POldUM;
			PoitemStatType _PNewStatus = PNewStatus;
			PoitemStatType _POldStatus = POldStatus;
			QtyUnitNoNegType _PNewQty = PNewQty;
			QtyUnitNoNegType _POldQty = POldQty;
			CostPrcType _PNewItemCost = PNewItemCost;
			CostPrcType _POldItemCost = POldItemCost;
			CostPrcType _PNewMaterialCost = PNewMaterialCost;
			CostPrcType _POldMaterialCost = POldMaterialCost;
			CostPrcType _PNewFreightCost = PNewFreightCost;
			CostPrcType _POldFreightCost = POldFreightCost;
			CostPrcType _PNewDutyCost = PNewDutyCost;
			CostPrcType _POldDutyCost = POldDutyCost;
			CostPrcType _PNewBrokerageCost = PNewBrokerageCost;
			CostPrcType _POldBrokerageCost = POldBrokerageCost;
			CostPrcType _PNewInsuranceCost = PNewInsuranceCost;
			CostPrcType _POldInsuranceCost = POldInsuranceCost;
			CostPrcType _PNewLocalFreightCost = PNewLocalFreightCost;
			CostPrcType _POldLocalFreightCost = POldLocalFreightCost;
			CostPrcType _PNewPlanCost = PNewPlanCost;
			CostPrcType _POldPlanCost = POldPlanCost;
			DateType _PNewDueDate = PNewDueDate;
			DateType _POldDueDate = POldDueDate;
			DateType _PNewPromiseDate = PNewPromiseDate;
			DateType _POldPromiseDate = POldPromiseDate;
			UMConvFactorType _PNewConvFactor = PNewConvFactor;
			UMConvFactorType _POldConvFactor = POldConvFactor;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POItemlogSp";
				
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewItem", _PNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldItem", _POldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUM", _PNewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUM", _POldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewStatus", _PNewStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldStatus", _POldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewQty", _PNewQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQty", _POldQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewItemCost", _PNewItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldItemCost", _POldItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewMaterialCost", _PNewMaterialCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldMaterialCost", _POldMaterialCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewFreightCost", _PNewFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldFreightCost", _POldFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDutyCost", _PNewDutyCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldDutyCost", _POldDutyCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewBrokerageCost", _PNewBrokerageCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldBrokerageCost", _POldBrokerageCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewInsuranceCost", _PNewInsuranceCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldInsuranceCost", _POldInsuranceCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewLocalFreightCost", _PNewLocalFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldLocalFreightCost", _POldLocalFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPlanCost", _PNewPlanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldPlanCost", _POldPlanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDueDate", _PNewDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldDueDate", _POldDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPromiseDate", _PNewPromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldPromiseDate", _POldPromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewConvFactor", _PNewConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldConvFactor", _POldConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
