//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefEstimateJobData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefEstimateJobData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefEstimateJobDataSp(string i_job,
		string o_desc,
		string Infobar);
	}
}

