//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetVendorData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetVendorData
	{
		(int? ReturnCode, string Infobar) RSQC_GetVendorDataSp(string i_vendor,
		string o_stat,
		string o_desc,
		string Infobar);
	}
}

