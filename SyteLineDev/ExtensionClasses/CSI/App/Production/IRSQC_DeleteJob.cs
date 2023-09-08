//PROJECT NAME: Production
//CLASS NAME: IRSQC_DeleteJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRSQC_DeleteJob
	{
		(int? ReturnCode, string Infobar) RSQC_DeleteJobSp(string i_job,
		int? i_suffix,
		string Infobar);
	}
}

