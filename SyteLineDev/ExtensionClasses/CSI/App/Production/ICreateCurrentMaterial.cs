//PROJECT NAME: Production
//CLASS NAME: ICreateCurrentMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICreateCurrentMaterial
	{
		(int? ReturnCode,
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
			string InfoBar);
	}
}

