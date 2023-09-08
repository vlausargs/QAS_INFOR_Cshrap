//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateVendor
	{
		(int? ReturnCode, string Name,
		string Infobar) RSQC_ValidateVendorSp(int? ValidateVendor,
		string VendNum,
		string Name,
		string Infobar);
	}
}

