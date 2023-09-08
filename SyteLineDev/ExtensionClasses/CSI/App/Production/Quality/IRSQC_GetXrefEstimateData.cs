//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefEstimateData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefEstimateData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefEstimateDataSp(string i_co,
		string o_desc,
		string Infobar);
	}
}

