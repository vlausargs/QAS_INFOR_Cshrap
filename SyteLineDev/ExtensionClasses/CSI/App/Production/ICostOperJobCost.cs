//PROJECT NAME: Production
//CLASS NAME: ICostOperJobCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
    public interface ICostOperJobCost
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
            int? WcOutside,
            decimal? CostoperUHrsMch,
            decimal? CostoperLHrsOut,
            decimal? CostoperUHrsLbrOut,
            decimal? JrtSchRunTicksLbrOut,
            int? WcAvailableOut) CostOperJobCostSp(
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
            decimal? CostoperUHrsMch,
            decimal? CostoperLHrsOut = null,
            decimal? CostoperUHrsLbrOut = null,
            decimal? JrtSchRunTicksLbrOut = null,
            int? WcAvailableOut = null);

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
            decimal? CostoperUHrsMch, 
            decimal? CostoperLHrsOut, 
            decimal? CostoperUHrsLbrOut, 
            decimal? JrtSchRunTicksLbrOut, 
            int? WcAvailableOut) CostOperJobCostSp(
            int? zero_args, 
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
            decimal? JobrouteEfficiency, 
            decimal? JobrouteRunRateLbr, 
            decimal? JobrouteSetupRate, 
            decimal? JobrouteFixovhdRate, 
            decimal? JobrouteVarovhdRate, 
            decimal? JobrouteFovhdRateMch, 
            decimal? JobrouteVovhdRateMch, 
            decimal? JrtSchRunTicksLbr, 
            decimal? JrtSchSetupTicks, 
            decimal? JrtSchRunTicksMch, 
            string wc, 
            string WcOverhead, 
            int? WcOutside, 
            decimal? CostoperUHrsMch);

    }
}

