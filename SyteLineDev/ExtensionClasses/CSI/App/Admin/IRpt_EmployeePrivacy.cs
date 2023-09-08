//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmployeePrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmployeePrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeePrivacySp(Guid? SessionID,
		string pSite);
	}
}

