//PROJECT NAME: Logistics
//CLASS NAME: ISchedGetLabelSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedGetLabel
	{
		string SchedGetLabelSp(
			string Username,
			string ScheduleID,
			string ReferenceLabel,
			string PartnerIdLabel,
			string PartnerNameLabel,
			string DescriptionLabel,
			string ApptStatLabel,
			string StatCodeLabel,
			string PriorCodeLabel,
			string CustNameLabel,
			string SroTypeLabel,
			string ApptStartDateLabel,
			string ApptLengthLabel,
			string TerritoryRegionLabel,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			int? RefSeq,
			string PartnerId,
			string PartnerName,
			string Description,
			string ApptStat,
			string StatCode,
			string PriorCode,
			string CustName,
			string SroType,
			DateTime? ApptStartDate,
			string ApptLength,
			string TerritoryRegion);
	}
}

