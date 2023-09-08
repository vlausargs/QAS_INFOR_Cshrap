//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefCMRData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefCMRData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefCMRDataSp(string i_cmr,
		string o_desc,
		string Infobar);
	}
}

