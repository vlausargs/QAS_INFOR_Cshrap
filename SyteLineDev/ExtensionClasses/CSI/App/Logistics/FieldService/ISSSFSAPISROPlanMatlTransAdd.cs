//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAPISROPlanMatlTransAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAPISROPlanMatlTransAdd
	{
		(int? ReturnCode,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar) SSSFSAPISROPlanMatlTransAddSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			DateTime? TransDate,
			string TransType,
			string Item,
			string Whse,
			string Lot,
			string Loc,
			string PartnerID,
			decimal? QtyConv,
			string UM,
			decimal? CostConv,
			decimal? PriceConv,
			string SerNum,
			string Notes,
			string Desc,
			int? PostFlag,
			string ReasonCode,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar);
	}
}

