//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubGetRangeDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubGetRangeDesc
	{
		(int? ReturnCode,
			string OBillRange1,
			string OBillRange2) SSSFSConInvSubGetRangeDescSp(
			string IContPriceBasis,
			DateTime? IBillingStartDate,
			DateTime? IBillingEndDate,
			int? IBillingStartMeter,
			int? IBillingEndMeter,
			string OBillRange1,
			string OBillRange2);
	}
}

