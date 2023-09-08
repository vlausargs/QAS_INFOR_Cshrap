//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefVendorData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefVendorData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefVendorDataSp(string i_vendnum,
		string o_desc,
		string Infobar);
	}
}

