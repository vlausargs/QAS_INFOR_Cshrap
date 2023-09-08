//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefCOData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefCOData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefCODataSp(string i_co,
		string o_desc,
		string Infobar);
	}
}

