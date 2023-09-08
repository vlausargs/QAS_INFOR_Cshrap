//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefProdCodeData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefProdCodeData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefProdCodeDataSp(string i_prodcode,
		string o_desc,
		string Infobar);
	}
}

