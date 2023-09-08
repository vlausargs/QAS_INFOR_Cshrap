//PROJECT NAME: Data
//CLASS NAME: IVendaddrUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVendaddrUpd
	{
		(int? ReturnCode,
			string InfoBar) VendaddrUpdSP(
			string Vendnum,
			string Name = null,
			string City = null,
			string State = null,
			string Zip = null,
			string County = null,
			string Country = null,
			string FaxNum = null,
			string TelexNum = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			int? PayHold = null,
			string PayHoldUser = null,
			DateTime? PayHoldDate = null,
			string PayHoldReason = null,
			string InternetEmailURL = null,
			string InternalEmailAddr = null,
			string ExternalEmailAddr = null,
			int? UseLongName = 0,
			string LongName = null,
			string InfoBar = null);
	}
}

