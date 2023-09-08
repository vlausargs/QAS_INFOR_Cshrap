//PROJECT NAME: Logistics
//CLASS NAME: ICLM_LocalAppointments.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ICLM_LocalAppointments
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LocalAppointmentsSp(int? IncludeAppointment = 0,
		int? IncludeFutureService = 0,
		int? DaysAhead = 0,
		int? UnassignedOnly = 0,
		int? IncludeSROLine = 0,
		int? IncludeSROOperation = 0,
		string FCity = null,
		string FState = null,
		string FZip = null,
		string FCounty = null,
		string FCountry = null,
		string FTerritoryRegion = null,
		string FPartnerID = null,
		string FDept = null,
		string FSroType = null);
	}
}

