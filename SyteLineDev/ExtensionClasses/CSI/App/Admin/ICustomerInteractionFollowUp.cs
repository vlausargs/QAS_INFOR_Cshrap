//PROJECT NAME: Admin
//CLASS NAME: ICustomerInteractionFollowUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICustomerInteractionFollowUp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CustomerInteractionFollowUpSp(DateTime? StartDate,
		DateTime? EndDate,
		string Action,
		string SiteRef = null);
	}
}

