//PROJECT NAME: Data
//CLASS NAME: IHome_CostOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHome_CostOper
	{
		(int? ReturnCode,
			decimal? u_qty,
			decimal? l_qty,
			decimal? u_outside,
			decimal? l_outside,
			decimal? u_run,
			decimal? l_setup,
			decimal? u_fovhd_lbr,
			decimal? l_fovhd_lbr,
			decimal? u_vovhd_lbr,
			decimal? l_vovhd_lbr,
			decimal? u_fovhd_mch,
			decimal? u_vovhd_mch,
			string WcOverhead,
			int? WcOutside) Home_CostOperSp(
			int? zero_args,
			Guid? JobrouteRowPointer,
			decimal? u_qty,
			decimal? l_qty,
			decimal? u_outside,
			decimal? l_outside,
			decimal? u_run,
			decimal? l_setup,
			decimal? u_fovhd_lbr,
			decimal? l_fovhd_lbr,
			decimal? u_vovhd_lbr,
			decimal? l_vovhd_lbr,
			decimal? u_fovhd_mch,
			decimal? u_vovhd_mch,
			string WcOverhead,
			int? WcOutside);
	}
}

