//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispSetCGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispSetCGS
	{
		(int? ReturnCode,
			string CgsMatlAcct,
			string CgsMatlAcctUnit1,
			string CgsMatlAcctUnit2,
			string CgsMatlAcctUnit3,
			string CgsMatlAcctUnit4,
			string CgsLbrAcct,
			string CgsLbrAcctUnit1,
			string CgsLbrAcctUnit2,
			string CgsLbrAcctUnit3,
			string CgsLbrAcctUnit4,
			string CgsFovAcct,
			string CgsFovAcctUnit1,
			string CgsFovAcctUnit2,
			string CgsFovAcctUnit3,
			string CgsFovAcctUnit4,
			string CgsVovAcct,
			string CgsVovAcctUnit1,
			string CgsVovAcctUnit2,
			string CgsVovAcctUnit3,
			string CgsVovAcctUnit4,
			string CgsOutAcct,
			string CgsOutAcctUnit1,
			string CgsOutAcctUnit2,
			string CgsOutAcctUnit3,
			string CgsOutAcctUnit4,
			string Infobar) SSSRMXDispSetCGSSp(
			string EndUserType,
			string Whse,
			string Item,
			string CgsMatlAcct,
			string CgsMatlAcctUnit1,
			string CgsMatlAcctUnit2,
			string CgsMatlAcctUnit3,
			string CgsMatlAcctUnit4,
			string CgsLbrAcct,
			string CgsLbrAcctUnit1,
			string CgsLbrAcctUnit2,
			string CgsLbrAcctUnit3,
			string CgsLbrAcctUnit4,
			string CgsFovAcct,
			string CgsFovAcctUnit1,
			string CgsFovAcctUnit2,
			string CgsFovAcctUnit3,
			string CgsFovAcctUnit4,
			string CgsVovAcct,
			string CgsVovAcctUnit1,
			string CgsVovAcctUnit2,
			string CgsVovAcctUnit3,
			string CgsVovAcctUnit4,
			string CgsOutAcct,
			string CgsOutAcctUnit1,
			string CgsOutAcctUnit2,
			string CgsOutAcctUnit3,
			string CgsOutAcctUnit4,
			string Infobar);
	}
}

