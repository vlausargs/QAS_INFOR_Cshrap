//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPartnerHoldCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPartnerHoldCheck
	{
		int? SSSFSPartnerHoldCheckFn(
			string PartnerId);
	}
}

