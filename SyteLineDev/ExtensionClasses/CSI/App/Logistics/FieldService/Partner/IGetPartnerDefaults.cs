//PROJECT NAME: Logistics
//CLASS NAME: IGetPartnerDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface IGetPartnerDefaults
	{
		(int? ReturnCode,
		int? GPSPollingInterval) GetPartnerDefaultsSp(
			string PartnerId,
			int? GPSPollingInterval);
	}
}

