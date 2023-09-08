//PROJECT NAME: CSIProduct
//CLASS NAME: EngWBJobmatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IEngWBJobmatl
	{
		(int? ReturnCode, short? JobmatlSequence, string JobmatlItem, string JobmatlDescription, string JobmatlMatlType, decimal? JobmatlMatlQtyConv, double? JobmatlDerUOMConvFactor, string JobmatlUnits, string JobmatlUM, decimal? JobmatlScrapFact, short? JobmatlBomSeq, byte? JobmatlBackflush, string JobmatlBflushLoc, string JobmatlRefType, string JobmatlRefNum, short? JobmatlRefLineSuf, short? JobmatlRefRelease, DateTime? JobmatlEffectDate, DateTime? JobmatlObsDate, string JobmatlFeature, string JobmatlOptCode, decimal? JobmatlProbable, decimal? JobmatlIncPrice, decimal? JobmatlCost, decimal? JobmatlMatlCost, decimal? JobmatlLbrCost, decimal? JobmatlFOvhdCost, decimal? JobmatlVOvhdCost, decimal? JobmatlMFOvhdCost, decimal? JobmatlMVOvhdCost, decimal? JobmatlOutCost, decimal? JobmatlCostConv, decimal? JobmatlMatlCostConv, decimal? JobmatlLbrCostConv, decimal? JobmatlFOvhdCostConv, decimal? JobmatlVOvhdCostConv, decimal? JobmatlOutCostConv, short? JobmatlAltGroup, short? JobmatlAltGroupRank, byte? ItemPhantomFlag) EngWBJobmatlSp(Guid? JobmatlRowPointer,
		short? JobmatlSequence,
		string JobmatlItem,
		string JobmatlDescription,
		string JobmatlMatlType,
		decimal? JobmatlMatlQtyConv,
		double? JobmatlDerUOMConvFactor,
		string JobmatlUnits,
		string JobmatlUM,
		decimal? JobmatlScrapFact,
		short? JobmatlBomSeq,
		byte? JobmatlBackflush,
		string JobmatlBflushLoc,
		string JobmatlRefType,
		string JobmatlRefNum,
		short? JobmatlRefLineSuf,
		short? JobmatlRefRelease,
		DateTime? JobmatlEffectDate,
		DateTime? JobmatlObsDate,
		string JobmatlFeature,
		string JobmatlOptCode,
		decimal? JobmatlProbable,
		decimal? JobmatlIncPrice,
		decimal? JobmatlCost,
		decimal? JobmatlMatlCost,
		decimal? JobmatlLbrCost,
		decimal? JobmatlFOvhdCost,
		decimal? JobmatlVOvhdCost,
		decimal? JobmatlMFOvhdCost,
		decimal? JobmatlMVOvhdCost,
		decimal? JobmatlOutCost,
		decimal? JobmatlCostConv,
		decimal? JobmatlMatlCostConv,
		decimal? JobmatlLbrCostConv,
		decimal? JobmatlFOvhdCostConv,
		decimal? JobmatlVOvhdCostConv,
		decimal? JobmatlOutCostConv,
		short? JobmatlAltGroup,
		short? JobmatlAltGroupRank,
		byte? ItemPhantomFlag = null);
	}
	
	public class EngWBJobmatl : IEngWBJobmatl
	{
		readonly IApplicationDB appDB;
		
		public EngWBJobmatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? JobmatlSequence, string JobmatlItem, string JobmatlDescription, string JobmatlMatlType, decimal? JobmatlMatlQtyConv, double? JobmatlDerUOMConvFactor, string JobmatlUnits, string JobmatlUM, decimal? JobmatlScrapFact, short? JobmatlBomSeq, byte? JobmatlBackflush, string JobmatlBflushLoc, string JobmatlRefType, string JobmatlRefNum, short? JobmatlRefLineSuf, short? JobmatlRefRelease, DateTime? JobmatlEffectDate, DateTime? JobmatlObsDate, string JobmatlFeature, string JobmatlOptCode, decimal? JobmatlProbable, decimal? JobmatlIncPrice, decimal? JobmatlCost, decimal? JobmatlMatlCost, decimal? JobmatlLbrCost, decimal? JobmatlFOvhdCost, decimal? JobmatlVOvhdCost, decimal? JobmatlMFOvhdCost, decimal? JobmatlMVOvhdCost, decimal? JobmatlOutCost, decimal? JobmatlCostConv, decimal? JobmatlMatlCostConv, decimal? JobmatlLbrCostConv, decimal? JobmatlFOvhdCostConv, decimal? JobmatlVOvhdCostConv, decimal? JobmatlOutCostConv, short? JobmatlAltGroup, short? JobmatlAltGroupRank, byte? ItemPhantomFlag) EngWBJobmatlSp(Guid? JobmatlRowPointer,
		short? JobmatlSequence,
		string JobmatlItem,
		string JobmatlDescription,
		string JobmatlMatlType,
		decimal? JobmatlMatlQtyConv,
		double? JobmatlDerUOMConvFactor,
		string JobmatlUnits,
		string JobmatlUM,
		decimal? JobmatlScrapFact,
		short? JobmatlBomSeq,
		byte? JobmatlBackflush,
		string JobmatlBflushLoc,
		string JobmatlRefType,
		string JobmatlRefNum,
		short? JobmatlRefLineSuf,
		short? JobmatlRefRelease,
		DateTime? JobmatlEffectDate,
		DateTime? JobmatlObsDate,
		string JobmatlFeature,
		string JobmatlOptCode,
		decimal? JobmatlProbable,
		decimal? JobmatlIncPrice,
		decimal? JobmatlCost,
		decimal? JobmatlMatlCost,
		decimal? JobmatlLbrCost,
		decimal? JobmatlFOvhdCost,
		decimal? JobmatlVOvhdCost,
		decimal? JobmatlMFOvhdCost,
		decimal? JobmatlMVOvhdCost,
		decimal? JobmatlOutCost,
		decimal? JobmatlCostConv,
		decimal? JobmatlMatlCostConv,
		decimal? JobmatlLbrCostConv,
		decimal? JobmatlFOvhdCostConv,
		decimal? JobmatlVOvhdCostConv,
		decimal? JobmatlOutCostConv,
		short? JobmatlAltGroup,
		short? JobmatlAltGroupRank,
		byte? ItemPhantomFlag = null)
		{
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			JobmatlSequenceType _JobmatlSequence = JobmatlSequence;
			ItemType _JobmatlItem = JobmatlItem;
			DescriptionType _JobmatlDescription = JobmatlDescription;
			MatlTypeType _JobmatlMatlType = JobmatlMatlType;
			QtyPerType _JobmatlMatlQtyConv = JobmatlMatlQtyConv;
			UMConvFactorType _JobmatlDerUOMConvFactor = JobmatlDerUOMConvFactor;
			JobmatlUnitsType _JobmatlUnits = JobmatlUnits;
			UMType _JobmatlUM = JobmatlUM;
			ScrapFactorType _JobmatlScrapFact = JobmatlScrapFact;
			EcnBomSeqType _JobmatlBomSeq = JobmatlBomSeq;
			ListYesNoType _JobmatlBackflush = JobmatlBackflush;
			LocType _JobmatlBflushLoc = JobmatlBflushLoc;
			RefTypeIJKPRTType _JobmatlRefType = JobmatlRefType;
			JobPoProjReqTrnNumType _JobmatlRefNum = JobmatlRefNum;
			SuffixPoLineProjTaskReqTrnLineType _JobmatlRefLineSuf = JobmatlRefLineSuf;
			OperNumPoReleaseType _JobmatlRefRelease = JobmatlRefRelease;
			DateType _JobmatlEffectDate = JobmatlEffectDate;
			DateType _JobmatlObsDate = JobmatlObsDate;
			FeatureType _JobmatlFeature = JobmatlFeature;
			OptCodeType _JobmatlOptCode = JobmatlOptCode;
			ProbableType _JobmatlProbable = JobmatlProbable;
			CostPrcType _JobmatlIncPrice = JobmatlIncPrice;
			CostPrcType _JobmatlCost = JobmatlCost;
			CostPrcType _JobmatlMatlCost = JobmatlMatlCost;
			CostPrcType _JobmatlLbrCost = JobmatlLbrCost;
			CostPrcType _JobmatlFOvhdCost = JobmatlFOvhdCost;
			CostPrcType _JobmatlVOvhdCost = JobmatlVOvhdCost;
			CostPrcType _JobmatlMFOvhdCost = JobmatlMFOvhdCost;
			CostPrcType _JobmatlMVOvhdCost = JobmatlMVOvhdCost;
			CostPrcType _JobmatlOutCost = JobmatlOutCost;
			CostPrcType _JobmatlCostConv = JobmatlCostConv;
			CostPrcType _JobmatlMatlCostConv = JobmatlMatlCostConv;
			CostPrcType _JobmatlLbrCostConv = JobmatlLbrCostConv;
			CostPrcType _JobmatlFOvhdCostConv = JobmatlFOvhdCostConv;
			CostPrcType _JobmatlVOvhdCostConv = JobmatlVOvhdCostConv;
			CostPrcType _JobmatlOutCostConv = JobmatlOutCostConv;
			JobmatlSequenceType _JobmatlAltGroup = JobmatlAltGroup;
			JobmatlRankType _JobmatlAltGroupRank = JobmatlAltGroupRank;
			ListYesNoType _ItemPhantomFlag = ItemPhantomFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EngWBJobmatlSp";
				
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlSequence", _JobmatlSequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlItem", _JobmatlItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlDescription", _JobmatlDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlMatlType", _JobmatlMatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlMatlQtyConv", _JobmatlMatlQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlDerUOMConvFactor", _JobmatlDerUOMConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlUnits", _JobmatlUnits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlUM", _JobmatlUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlScrapFact", _JobmatlScrapFact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlBomSeq", _JobmatlBomSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlBackflush", _JobmatlBackflush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlBflushLoc", _JobmatlBflushLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlRefType", _JobmatlRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlRefNum", _JobmatlRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlRefLineSuf", _JobmatlRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlRefRelease", _JobmatlRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlEffectDate", _JobmatlEffectDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlObsDate", _JobmatlObsDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlFeature", _JobmatlFeature, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlOptCode", _JobmatlOptCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlProbable", _JobmatlProbable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlIncPrice", _JobmatlIncPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlCost", _JobmatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlMatlCost", _JobmatlMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlLbrCost", _JobmatlLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlFOvhdCost", _JobmatlFOvhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlVOvhdCost", _JobmatlVOvhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlMFOvhdCost", _JobmatlMFOvhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlMVOvhdCost", _JobmatlMVOvhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlOutCost", _JobmatlOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlCostConv", _JobmatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlMatlCostConv", _JobmatlMatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlLbrCostConv", _JobmatlLbrCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlFOvhdCostConv", _JobmatlFOvhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlVOvhdCostConv", _JobmatlVOvhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlOutCostConv", _JobmatlOutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlAltGroup", _JobmatlAltGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlAltGroupRank", _JobmatlAltGroupRank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemPhantomFlag", _ItemPhantomFlag, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobmatlSequence = _JobmatlSequence;
				JobmatlItem = _JobmatlItem;
				JobmatlDescription = _JobmatlDescription;
				JobmatlMatlType = _JobmatlMatlType;
				JobmatlMatlQtyConv = _JobmatlMatlQtyConv;
				JobmatlDerUOMConvFactor = _JobmatlDerUOMConvFactor;
				JobmatlUnits = _JobmatlUnits;
				JobmatlUM = _JobmatlUM;
				JobmatlScrapFact = _JobmatlScrapFact;
				JobmatlBomSeq = _JobmatlBomSeq;
				JobmatlBackflush = _JobmatlBackflush;
				JobmatlBflushLoc = _JobmatlBflushLoc;
				JobmatlRefType = _JobmatlRefType;
				JobmatlRefNum = _JobmatlRefNum;
				JobmatlRefLineSuf = _JobmatlRefLineSuf;
				JobmatlRefRelease = _JobmatlRefRelease;
				JobmatlEffectDate = _JobmatlEffectDate;
				JobmatlObsDate = _JobmatlObsDate;
				JobmatlFeature = _JobmatlFeature;
				JobmatlOptCode = _JobmatlOptCode;
				JobmatlProbable = _JobmatlProbable;
				JobmatlIncPrice = _JobmatlIncPrice;
				JobmatlCost = _JobmatlCost;
				JobmatlMatlCost = _JobmatlMatlCost;
				JobmatlLbrCost = _JobmatlLbrCost;
				JobmatlFOvhdCost = _JobmatlFOvhdCost;
				JobmatlVOvhdCost = _JobmatlVOvhdCost;
				JobmatlMFOvhdCost = _JobmatlMFOvhdCost;
				JobmatlMVOvhdCost = _JobmatlMVOvhdCost;
				JobmatlOutCost = _JobmatlOutCost;
				JobmatlCostConv = _JobmatlCostConv;
				JobmatlMatlCostConv = _JobmatlMatlCostConv;
				JobmatlLbrCostConv = _JobmatlLbrCostConv;
				JobmatlFOvhdCostConv = _JobmatlFOvhdCostConv;
				JobmatlVOvhdCostConv = _JobmatlVOvhdCostConv;
				JobmatlOutCostConv = _JobmatlOutCostConv;
				JobmatlAltGroup = _JobmatlAltGroup;
				JobmatlAltGroupRank = _JobmatlAltGroupRank;
				ItemPhantomFlag = _ItemPhantomFlag;
				
				return (Severity, JobmatlSequence, JobmatlItem, JobmatlDescription, JobmatlMatlType, JobmatlMatlQtyConv, JobmatlDerUOMConvFactor, JobmatlUnits, JobmatlUM, JobmatlScrapFact, JobmatlBomSeq, JobmatlBackflush, JobmatlBflushLoc, JobmatlRefType, JobmatlRefNum, JobmatlRefLineSuf, JobmatlRefRelease, JobmatlEffectDate, JobmatlObsDate, JobmatlFeature, JobmatlOptCode, JobmatlProbable, JobmatlIncPrice, JobmatlCost, JobmatlMatlCost, JobmatlLbrCost, JobmatlFOvhdCost, JobmatlVOvhdCost, JobmatlMFOvhdCost, JobmatlMVOvhdCost, JobmatlOutCost, JobmatlCostConv, JobmatlMatlCostConv, JobmatlLbrCostConv, JobmatlFOvhdCostConv, JobmatlVOvhdCostConv, JobmatlOutCostConv, JobmatlAltGroup, JobmatlAltGroupRank, ItemPhantomFlag);
			}
		}
	}
}
