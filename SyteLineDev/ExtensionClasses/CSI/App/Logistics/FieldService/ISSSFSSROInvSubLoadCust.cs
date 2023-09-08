//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubLoadCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubLoadCust
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROInvSubLoadCustSp(
			string SroNum,
			string StartCustNum,
			string EndCustNum,
			string Infobar);
	}
}

