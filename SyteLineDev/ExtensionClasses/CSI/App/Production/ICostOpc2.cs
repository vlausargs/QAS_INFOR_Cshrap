//PROJECT NAME: Production
//CLASS NAME: ICostOpc2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICostOpc2
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
			int? WcOutside) CostOpc2Sp(
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
			int? WcOutside,
			decimal? ItemLaborPct,
			decimal? ItemMachPct);
	}
}

