//PROJECT NAME: Production
//CLASS NAME: ICostOpac.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICostOpac
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
			string WcOverhead,
			int? WcOutside) CostOpacSp(
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
			string WcOverhead,
			int? WcOutside);
	}
}

