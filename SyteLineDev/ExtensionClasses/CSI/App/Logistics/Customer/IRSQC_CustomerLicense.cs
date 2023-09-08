//PROJECT NAME: Logistics
//CLASS NAME: IRSQC_CustomerLicense.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRSQC_CustomerLicense
	{
		(int? ReturnCode, int? IsQCLicensed) RSQC_CustomerLicenseSp(int? IsQCLicensed);
	}
}

