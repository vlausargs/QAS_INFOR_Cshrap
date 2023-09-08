//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportVendorToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportVendorToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportVendorToIGFSp(
			string VendNum,
			string Infobar);
	}
}

