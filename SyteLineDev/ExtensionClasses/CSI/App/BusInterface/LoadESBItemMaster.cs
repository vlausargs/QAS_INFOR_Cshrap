//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBItemMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBItemMaster
	{
		int LoadESBItemMasterSp(string DerBODID,
		                        string ActionExpression,
		                        string Item,
		                        string Description,
		                        string AbcCode,
		                        string CommCode,
		                        string DerCostMethod,
		                        string DerProductCode,
		                        string DerBackflush,
		                        string UM,
		                        decimal? UnitCost,
		                        string DerSerialTracked,
		                        string DerLotTracked,
		                        string DerBODPMTCode,
		                        decimal? OrderMin,
		                        decimal? OrderMax,
		                        string AltItem,
		                        decimal? NetWeightMeasure,
		                        string OrderConfigurable,
		                        string CommodityJurisdiction,
		                        string ECCNUSMLValue,
		                        string ExportComplianceProgram,
		                        string SchedBNum,
		                        string HTSCode,
		                        string RevisionID,
		                        string LastModificationPerson,
		                        string TrackingIndicator,
		                        decimal? LotSize,
		                        string SpecificationName,
		                        ref string Infobar);
	}
	
	public class LoadESBItemMaster : ILoadESBItemMaster
	{
		readonly IApplicationDB appDB;
		
		public LoadESBItemMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBItemMasterSp(string DerBODID,
		                               string ActionExpression,
		                               string Item,
		                               string Description,
		                               string AbcCode,
		                               string CommCode,
		                               string DerCostMethod,
		                               string DerProductCode,
		                               string DerBackflush,
		                               string UM,
		                               decimal? UnitCost,
		                               string DerSerialTracked,
		                               string DerLotTracked,
		                               string DerBODPMTCode,
		                               decimal? OrderMin,
		                               decimal? OrderMax,
		                               string AltItem,
		                               decimal? NetWeightMeasure,
		                               string OrderConfigurable,
		                               string CommodityJurisdiction,
		                               string ECCNUSMLValue,
		                               string ExportComplianceProgram,
		                               string SchedBNum,
		                               string HTSCode,
		                               string RevisionID,
		                               string LastModificationPerson,
		                               string TrackingIndicator,
		                               decimal? LotSize,
		                               string SpecificationName,
		                               ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			AbcCodeType _AbcCode = AbcCode;
			CommodityCodeType _CommCode = CommCode;
			StringType _DerCostMethod = DerCostMethod;
			StringType _DerProductCode = DerProductCode;
			StringType _DerBackflush = DerBackflush;
			UMType _UM = UM;
			CostPrcType _UnitCost = UnitCost;
			StringType _DerSerialTracked = DerSerialTracked;
			StringType _DerLotTracked = DerLotTracked;
			StringType _DerBODPMTCode = DerBODPMTCode;
			QtyUnitType _OrderMin = OrderMin;
			QtyUnitType _OrderMax = OrderMax;
			ItemType _AltItem = AltItem;
			ItemWeightType _NetWeightMeasure = NetWeightMeasure;
			StringType _OrderConfigurable = OrderConfigurable;
			CommodityJurisdictionType _CommodityJurisdiction = CommodityJurisdiction;
			ECCNUSMLValueType _ECCNUSMLValue = ECCNUSMLValue;
			ExportComplianceProgramType _ExportComplianceProgram = ExportComplianceProgram;
			SchedBNumType _SchedBNum = SchedBNum;
			HTSCodeType _HTSCode = HTSCode;
			RevisionType _RevisionID = RevisionID;
			UsernameType _LastModificationPerson = LastModificationPerson;
			StringType _TrackingIndicator = TrackingIndicator;
			LotSizeType _LotSize = LotSize;
			DrawingNbrType _SpecificationName = SpecificationName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBItemMasterSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AbcCode", _AbcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerCostMethod", _DerCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerProductCode", _DerProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerBackflush", _DerBackflush, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerSerialTracked", _DerSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerLotTracked", _DerLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerBODPMTCode", _DerBODPMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderMin", _OrderMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderMax", _OrderMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltItem", _AltItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NetWeightMeasure", _NetWeightMeasure, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderConfigurable", _OrderConfigurable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommodityJurisdiction", _CommodityJurisdiction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCNUSMLValue", _ECCNUSMLValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportComplianceProgram", _ExportComplianceProgram, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedBNum", _SchedBNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HTSCode", _HTSCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionID", _RevisionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastModificationPerson", _LastModificationPerson, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackingIndicator", _TrackingIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotSize", _LotSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SpecificationName", _SpecificationName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
