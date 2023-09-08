//PROJECT NAME: Data
//CLASS NAME: IFillUpTtPr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFillUpTtPr
	{
		(int? ReturnCode,
			string t_plans) FillUpTtPrSp(
			string emp_num,
			decimal? empr_con,
			string t_plans);
	}
}

