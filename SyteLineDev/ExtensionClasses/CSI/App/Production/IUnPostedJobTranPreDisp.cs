//PROJECT NAME: Production
//CLASS NAME: IUnPostedJobTranPreDisp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IUnPostedJobTranPreDisp
	{
		(int? ReturnCode, int? rpt_in_hrs,
		int? job_stockrm,
		string check_oper_seq) UnPostedJobTranPreDispSp(int? rpt_in_hrs,
		int? job_stockrm,
		string check_oper_seq);
	}
}

