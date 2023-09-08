//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefTRRData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefTRRData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefTRRDataSp(string i_trr,
		string o_desc,
		string Infobar);
	}
}

