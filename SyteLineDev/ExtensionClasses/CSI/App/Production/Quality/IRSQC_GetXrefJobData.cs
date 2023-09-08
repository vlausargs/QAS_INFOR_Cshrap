//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefJobData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefJobData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefJobDataSp(string i_job,
		string o_desc,
		string Infobar);
	}
}

