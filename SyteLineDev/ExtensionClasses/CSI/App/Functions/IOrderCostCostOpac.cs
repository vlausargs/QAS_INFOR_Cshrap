//PROJECT NAME: Data
//CLASS NAME: IOrderCostCostOpac.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IOrderCostCostOpac
	{
		(int? ReturnCode,
			decimal? u_outside,
			decimal? l_outside,
			decimal? u_run,
			decimal? l_setup,
			decimal? t_fovhd_lbr,
			decimal? t_vovhd_lbr,
			decimal? t_fovhd_mch,
			decimal? t_vovhd_mch,
			decimal? Total,
			string WcOverhead,
			int? WcOutside) OrderCostCostOpacSp(
			int? zero_args,
			Guid? JobrouteRowPointer,
			decimal? u_outside,
			decimal? l_outside,
			decimal? u_run,
			decimal? l_setup,
			decimal? t_fovhd_lbr,
			decimal? t_vovhd_lbr,
			decimal? t_fovhd_mch,
			decimal? t_vovhd_mch,
			decimal? Total,
			string WcOverhead,
			int? WcOutside);
	}
}

