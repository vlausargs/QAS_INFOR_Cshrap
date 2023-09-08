//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SchedGetToBeSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ICLM_SchedGetToBeSched
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetToBeSchedSp(int? InclInc = null,
		int? InclSro = null,
		int? InclSroLine = null,
		int? InclSroOper = null,
		int? InclPlanLabor = null,
		string Owner = null,
		string SroType = null,
		int? InclMiscTime = null,
		string City = null,
		string State = null,
		string Zip = null,
		string County = null,
		string Country = null,
		string TerritoryRegion = null,
		int? UseRegion = null,
		string Dept = null);
	}
}

