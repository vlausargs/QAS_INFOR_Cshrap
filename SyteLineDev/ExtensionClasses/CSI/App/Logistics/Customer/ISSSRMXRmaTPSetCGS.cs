//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXRmaTPSetCGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXRmaTPSetCGS
	{
		(int? ReturnCode,
			string TCgsMatlAcct,
			string TCgsMatlAcctUnit1,
			string TCgsMatlAcctUnit2,
			string TCgsMatlAcctUnit3,
			string TCgsMatlAcctUnit4,
			string TCgsLbrAcct,
			string TCgsLbrAcctUnit1,
			string TCgsLbrAcctUnit2,
			string TCgsLbrAcctUnit3,
			string TCgsLbrAcctUnit4,
			string TCgsFovhdAcct,
			string TCgsFovhdAcctUnit1,
			string TCgsFovhdAcctUnit2,
			string TCgsFovhdAcctUnit3,
			string TCgsFovhdAcctUnit4,
			string TCgsVovhdAcct,
			string TCgsVovhdAcctUnit1,
			string TCgsVovhdAcctUnit2,
			string TCgsVovhdAcctUnit3,
			string TCgsVovhdAcctUnit4,
			string TCgsOutAcct,
			string TCgsOutAcctUnit1,
			string TCgsOutAcctUnit2,
			string TCgsOutAcctUnit3,
			string TCgsOutAcctUnit4,
			string Infobar) SSSRMXRmaTPSetCGSSp(
			string RmaNum,
			int? RmaLine,
			string TCgsMatlAcct,
			string TCgsMatlAcctUnit1,
			string TCgsMatlAcctUnit2,
			string TCgsMatlAcctUnit3,
			string TCgsMatlAcctUnit4,
			string TCgsLbrAcct,
			string TCgsLbrAcctUnit1,
			string TCgsLbrAcctUnit2,
			string TCgsLbrAcctUnit3,
			string TCgsLbrAcctUnit4,
			string TCgsFovhdAcct,
			string TCgsFovhdAcctUnit1,
			string TCgsFovhdAcctUnit2,
			string TCgsFovhdAcctUnit3,
			string TCgsFovhdAcctUnit4,
			string TCgsVovhdAcct,
			string TCgsVovhdAcctUnit1,
			string TCgsVovhdAcctUnit2,
			string TCgsVovhdAcctUnit3,
			string TCgsVovhdAcctUnit4,
			string TCgsOutAcct,
			string TCgsOutAcctUnit1,
			string TCgsOutAcctUnit2,
			string TCgsOutAcctUnit3,
			string TCgsOutAcctUnit4,
			string Infobar);
	}
}

