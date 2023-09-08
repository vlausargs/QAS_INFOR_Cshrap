//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAPISROPlanLaborTransAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAPISROPlanLaborTransAdd
	{
		(int? ReturnCode,
			int? TransNum,
			Guid? RowPtr,
			string Infobar) SSSFSAPISROPlanLaborTransAddSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			DateTime? TransDate,
			string PartnerID,
			DateTime? StartDate,
			DateTime? EndDate,
			string WorkCode,
			decimal? HoursWorked,
			decimal? HoursToBill,
			decimal? LbrCost,
			decimal? LbrPrice,
			string Notes,
			int? PostFlag,
			int? TransNum,
			Guid? RowPtr,
			string Infobar);
	}
}

