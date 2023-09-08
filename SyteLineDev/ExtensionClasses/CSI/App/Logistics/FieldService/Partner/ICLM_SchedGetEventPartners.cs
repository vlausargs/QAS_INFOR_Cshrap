//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SchedGetEventPartners.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ICLM_SchedGetEventPartners
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetEventPartnersSp(string Username,
		string FilterUsername,
		string FilterName,
		int? FilterType,
		string SelectedPartnerList);
	}
}

