//PROJECT NAME: Data
//CLASS NAME: SyncCoFromPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SyncCoFromPo : ISyncCoFromPo
	{
		readonly IApplicationDB appDB;
		
		public SyncCoFromPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SyncCoFromPoSp(
			string SourceSite,
			string DemandingSite,
			string DemandingPO,
			int? UpdateHeader = 0,
			int? DeleteLine = 0,
			int? InsertLine = null,
			int? BlanketLine = 0,
			DateTime? PoOrderDate = null,
			int? PoItemsPoLine = null,
			int? PoItemsPoRelease = null,
			string PoItemsDescription = null,
			string PoItemDropShipNum = null,
			int? PoItemDropSeq = null,
			DateTime? PoItemsDueDate = null,
			string PoItems = null,
			decimal? PoItemsPlanCost = null,
			decimal? PoItemsPlanCostConv = null,
			decimal? PoItemsQtyOrderedConv = null,
			string PoItemsStat = null,
			string PoItemsTransNat = null,
			string PoItemsTransNat2 = null,
			string PoItemsUM = null,
			string PoItemsWhse = null,
			DateTime? PoBlnEffDate = null,
			DateTime? PoBlnExpDate = null,
			string PoBlnVendItem = null,
			string PoHeaderDropShipNum = null,
			int? PoHeaderDropSeq = null,
			string PoItemShipAddr = null,
			string Infobar = null)
		{
			SiteType _SourceSite = SourceSite;
			SiteType _DemandingSite = DemandingSite;
			PoNumType _DemandingPO = DemandingPO;
			ListYesNoType _UpdateHeader = UpdateHeader;
			ListYesNoType _DeleteLine = DeleteLine;
			ListYesNoType _InsertLine = InsertLine;
			ListYesNoType _BlanketLine = BlanketLine;
			DateType _PoOrderDate = PoOrderDate;
			PoLineType _PoItemsPoLine = PoItemsPoLine;
			PoReleaseType _PoItemsPoRelease = PoItemsPoRelease;
			DescriptionType _PoItemsDescription = PoItemsDescription;
			CustNumType _PoItemDropShipNum = PoItemDropShipNum;
			CustSeqType _PoItemDropSeq = PoItemDropSeq;
			DateType _PoItemsDueDate = PoItemsDueDate;
			ItemType _PoItems = PoItems;
			CostPrcType _PoItemsPlanCost = PoItemsPlanCost;
			CostPrcType _PoItemsPlanCostConv = PoItemsPlanCostConv;
			QtyUnitType _PoItemsQtyOrderedConv = PoItemsQtyOrderedConv;
			ItemStatusType _PoItemsStat = PoItemsStat;
			TransNatType _PoItemsTransNat = PoItemsTransNat;
			TransNatType _PoItemsTransNat2 = PoItemsTransNat2;
			UMType _PoItemsUM = PoItemsUM;
			WhseType _PoItemsWhse = PoItemsWhse;
			DateType _PoBlnEffDate = PoBlnEffDate;
			DateType _PoBlnExpDate = PoBlnExpDate;
			ItemType _PoBlnVendItem = PoBlnVendItem;
			CustNumType _PoHeaderDropShipNum = PoHeaderDropShipNum;
			CustSeqType _PoHeaderDropSeq = PoHeaderDropSeq;
			DropShipTypeType _PoItemShipAddr = PoItemShipAddr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SyncCoFromPoSp";
				
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingSite", _DemandingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateHeader", _UpdateHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteLine", _DeleteLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsertLine", _InsertLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketLine", _BlanketLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoOrderDate", _PoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsPoLine", _PoItemsPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsPoRelease", _PoItemsPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsDescription", _PoItemsDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemDropShipNum", _PoItemDropShipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemDropSeq", _PoItemDropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsDueDate", _PoItemsDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItems", _PoItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsPlanCost", _PoItemsPlanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsPlanCostConv", _PoItemsPlanCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsQtyOrderedConv", _PoItemsQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsStat", _PoItemsStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsTransNat", _PoItemsTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsTransNat2", _PoItemsTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsUM", _PoItemsUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsWhse", _PoItemsWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoBlnEffDate", _PoBlnEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoBlnExpDate", _PoBlnExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoBlnVendItem", _PoBlnVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoHeaderDropShipNum", _PoHeaderDropShipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoHeaderDropSeq", _PoHeaderDropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemShipAddr", _PoItemShipAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
