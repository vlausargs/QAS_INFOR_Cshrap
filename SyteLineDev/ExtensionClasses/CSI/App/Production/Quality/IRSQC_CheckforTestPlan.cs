//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckforTestPlan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckforTestPlan
	{
		(int? ReturnCode, string o_output,
		string Infobar) RSQC_CheckforTestPlanSp(int? i_rcvr,
		string o_output,
		string Infobar);
	}
}

