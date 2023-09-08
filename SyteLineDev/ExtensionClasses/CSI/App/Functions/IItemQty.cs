//PROJECT NAME: Data
//CLASS NAME: IItemQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemQty
	{
		(int? ReturnCode,
			string Infobar) ItemQtySp(
			string TransType,
			string WhseType,
			string Whse,
			string Item,
			decimal? DeltaQty,
			string Loc,
			string Lot = null,
			decimal? UnitCost = null,
			decimal? MatlCost = null,
			decimal? LbrCost = null,
			decimal? FovhdCost = null,
			decimal? VovhdCost = null,
			decimal? OutCost = null,
			int? MrbFlag = 0,
			string TrnNum = null,
			int? TrnLine = null,
			decimal? TransNum = null,
			decimal? RsvdNum = null,
			string InSerialStat = "I",
			int? AllQtys = 1,
			string Workkey = null,
			string Infobar = null,
			string ImportDocId = null,
			int? UpdateTaxFreeImportQty = 1,
			int? ValidateImportDocId = 1,
			string ContainerNum = null);
	}
}

