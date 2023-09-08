//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SchedGetUserPartners.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ICLM_SchedGetUserPartners
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetUserPartnersSp(string Username);
	}
}

