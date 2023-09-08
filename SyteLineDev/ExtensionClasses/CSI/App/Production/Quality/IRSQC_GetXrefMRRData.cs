//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefMRRData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefMRRData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefMRRDataSp(string i_mrr,
		string o_desc,
		string Infobar);
	}
}

