//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAPISROPlanMiscTransAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAPISROPlanMiscTransAdd
	{
		(int? ReturnCode,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar) SSSFSAPISROPlanMiscTransAddSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			DateTime? TransDate,
			string PartnerID,
			string Dept,
			string Whse,
			decimal? CostConv,
			decimal? PriceConv,
			string MiscCode,
			string PayType,
			decimal? QtyConv,
			string Notes,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar);
	}
}

