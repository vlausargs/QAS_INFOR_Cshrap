//PROJECT NAME: Production
//CLASS NAME: ICostOpcp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICostOpcp
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
			int? WcOutside) CostOpcpSp(
			int? zero_args,
			Guid? JobrouteRowPointer,
			decimal? JrtItemRunCostTLbr,
			decimal? JrtItemSetupCostT,
			decimal? JrtItemFixOvhdTLbr,
			decimal? JrtItemVarOvhdTLbr,
			decimal? JrtItemFixOvhdTMch,
			decimal? JrtItemVarOvhdTMch,
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

