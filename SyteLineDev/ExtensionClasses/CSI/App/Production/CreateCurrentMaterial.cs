//PROJECT NAME: Production
//CLASS NAME: CreateCurrentMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CreateCurrentMaterial : ICreateCurrentMaterial
	{
		readonly IApplicationDB appDB;
		
		public CreateCurrentMaterial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) CreateCurrentMaterialSp(
			string Item,
			int? CreateNonInventoryItems,
			int? JobmatlOperNum,
			int? JobmatlSequence,
			int? JobmatlBomSeq,
			string JobmatlMatlType,
			string JobmatlItem,
			string JobmatlUM,
			string JobmatlDescription,
			string JobmatlRefType,
			string JobmatlUnits,
			decimal? JobmatlScrapFact,
			decimal? JobmatlFmatlovhd,
			decimal? JobmatlVmatlovhd,
			decimal? JobmatlMatlQty,
			decimal? JobmatlCost,
			decimal? JobmatlMatlCost,
			decimal? JobmatlLbrCost,
			decimal? JobmatlFovhdCost,
			decimal? JobmatlVovhdCost,
			decimal? JobmatlOutCost,
			DateTime? JobmatlEffectDate,
			DateTime? JobmatlObsDate,
			int? JobmatlBackflush,
			string JobmatlBflushLoc,
			int? JobmatlAltGroup,
			int? JobmatlAltGroupRank,
			int? JobmatlPlannedAlternate,
			decimal? JobmatlIncPrice,
			string JobmatlManufacturerId,
			string JobmatlManufacturerItem,
			string JobmatlFeature,
			string JobmatlOptCode,
			decimal? JobmatlProbable,
			Guid? JobmatlRowPointer,
			string InfoBar)
		{
			ItemType _Item = Item;
			ListYesNoType _CreateNonInventoryItems = CreateNonInventoryItems;
			OperNumType _JobmatlOperNum = JobmatlOperNum;
			JobmatlSequenceType _JobmatlSequence = JobmatlSequence;
			JobmatlSequenceType _JobmatlBomSeq = JobmatlBomSeq;
			MatlTypeType _JobmatlMatlType = JobmatlMatlType;
			ItemType _JobmatlItem = JobmatlItem;
			UMType _JobmatlUM = JobmatlUM;
			DescriptionType _JobmatlDescription = JobmatlDescription;
			RefTypeIJKPRTType _JobmatlRefType = JobmatlRefType;
			JobmatlUnitsType _JobmatlUnits = JobmatlUnits;
			ScrapFactorType _JobmatlScrapFact = JobmatlScrapFact;
			OverheadRateType _JobmatlFmatlovhd = JobmatlFmatlovhd;
			OverheadRateType _JobmatlVmatlovhd = JobmatlVmatlovhd;
			QtyPerType _JobmatlMatlQty = JobmatlMatlQty;
			CostPrcType _JobmatlCost = JobmatlCost;
			CostPrcType _JobmatlMatlCost = JobmatlMatlCost;
			CostPrcType _JobmatlLbrCost = JobmatlLbrCost;
			CostPrcType _JobmatlFovhdCost = JobmatlFovhdCost;
			CostPrcType _JobmatlVovhdCost = JobmatlVovhdCost;
			CostPrcType _JobmatlOutCost = JobmatlOutCost;
			DateType _JobmatlEffectDate = JobmatlEffectDate;
			DateType _JobmatlObsDate = JobmatlObsDate;
			ListYesNoType _JobmatlBackflush = JobmatlBackflush;
			LocType _JobmatlBflushLoc = JobmatlBflushLoc;
			JobmatlSequenceType _JobmatlAltGroup = JobmatlAltGroup;
			JobmatlRankType _JobmatlAltGroupRank = JobmatlAltGroupRank;
			ListYesNoType _JobmatlPlannedAlternate = JobmatlPlannedAlternate;
			CostPrcType _JobmatlIncPrice = JobmatlIncPrice;
			ManufacturerIdType _JobmatlManufacturerId = JobmatlManufacturerId;
			ManufacturerItemType _JobmatlManufacturerItem = JobmatlManufacturerItem;
			FeatureType _JobmatlFeature = JobmatlFeature;
			OptCodeType _JobmatlOptCode = JobmatlOptCode;
			ProbableType _JobmatlProbable = JobmatlProbable;
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCurrentMaterialSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateNonInventoryItems", _CreateNonInventoryItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlOperNum", _JobmatlOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlSequence", _JobmatlSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlBomSeq", _JobmatlBomSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlMatlType", _JobmatlMatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlItem", _JobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlUM", _JobmatlUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlDescription", _JobmatlDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRefType", _JobmatlRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlUnits", _JobmatlUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlScrapFact", _JobmatlScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlFmatlovhd", _JobmatlFmatlovhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlVmatlovhd", _JobmatlVmatlovhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlMatlQty", _JobmatlMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlCost", _JobmatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlMatlCost", _JobmatlMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlLbrCost", _JobmatlLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlFovhdCost", _JobmatlFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlVovhdCost", _JobmatlVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlOutCost", _JobmatlOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlEffectDate", _JobmatlEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlObsDate", _JobmatlObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlBackflush", _JobmatlBackflush, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlBflushLoc", _JobmatlBflushLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlAltGroup", _JobmatlAltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlAltGroupRank", _JobmatlAltGroupRank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlPlannedAlternate", _JobmatlPlannedAlternate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlIncPrice", _JobmatlIncPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlManufacturerId", _JobmatlManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlManufacturerItem", _JobmatlManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlFeature", _JobmatlFeature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlOptCode", _JobmatlOptCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlProbable", _JobmatlProbable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
