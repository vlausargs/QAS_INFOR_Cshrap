//PROJECT NAME: Production
//CLASS NAME: CostOperJobCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
    public class CostOperJobCost : ICostOperJobCost
    {
        readonly IApplicationDB appDB;

        public CostOperJobCost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
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
            int? WcAvailableOut = null)
        {
            ListYesNoType _zero_args = zero_args;
            RowPointerType _JobrouteRowPointer = JobrouteRowPointer;
            QtyPerType _u_qty = u_qty;
            QtyPerType _l_qty = l_qty;
            CostPrcType _u_outside = u_outside;
            CostPrcType _l_outside = l_outside;
            CostPrcType _u_run = u_run;
            CostPrcType _l_setup = l_setup;
            CostPrcType _u_fovhd_lbr = u_fovhd_lbr;
            CostPrcType _l_fovhd_lbr = l_fovhd_lbr;
            CostPrcType _u_vovhd_lbr = u_vovhd_lbr;
            CostPrcType _l_vovhd_lbr = l_vovhd_lbr;
            CostPrcType _u_fovhd_mch = u_fovhd_mch;
            CostPrcType _u_vovhd_mch = u_vovhd_mch;
            OverheadBasisType _WcOverhead = WcOverhead;
            ListYesNoType _WcOutside = WcOutside;
            RunTicksType _CostoperUHrsMch = CostoperUHrsMch;
            RunTicksType _CostoperLHrsOut = CostoperLHrsOut;
            RunTicksType _CostoperUHrsLbrOut = CostoperUHrsLbrOut;
            RunTicksType _JrtSchRunTicksLbrOut = JrtSchRunTicksLbrOut;
            ByteType _WcAvailableOut = WcAvailableOut;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CostOperJobCostSp";

                appDB.AddCommandParameter(cmd, "zero_args", _zero_args, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobrouteRowPointer", _JobrouteRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "u_qty", _u_qty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "l_qty", _l_qty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "u_outside", _u_outside, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "l_outside", _l_outside, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "u_run", _u_run, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "l_setup", _l_setup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "u_fovhd_lbr", _u_fovhd_lbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "l_fovhd_lbr", _l_fovhd_lbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "u_vovhd_lbr", _u_vovhd_lbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "l_vovhd_lbr", _l_vovhd_lbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "u_fovhd_mch", _u_fovhd_mch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "u_vovhd_mch", _u_vovhd_mch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WcOverhead", _WcOverhead, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WcOutside", _WcOutside, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CostoperUHrsMch", _CostoperUHrsMch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CostoperLHrsOut", _CostoperLHrsOut, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CostoperUHrsLbrOut", _CostoperUHrsLbrOut, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JrtSchRunTicksLbrOut", _JrtSchRunTicksLbrOut, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WcAvailableOut", _WcAvailableOut, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                u_qty = _u_qty;
                l_qty = _l_qty;
                u_outside = _u_outside;
                l_outside = _l_outside;
                u_run = _u_run;
                l_setup = _l_setup;
                u_fovhd_lbr = _u_fovhd_lbr;
                l_fovhd_lbr = _l_fovhd_lbr;
                u_vovhd_lbr = _u_vovhd_lbr;
                l_vovhd_lbr = _l_vovhd_lbr;
                u_fovhd_mch = _u_fovhd_mch;
                u_vovhd_mch = _u_vovhd_mch;
                WcOverhead = _WcOverhead;
                WcOutside = _WcOutside;
                CostoperUHrsMch = _CostoperUHrsMch;
                CostoperLHrsOut = _CostoperLHrsOut;
                CostoperUHrsLbrOut = _CostoperUHrsLbrOut;
                JrtSchRunTicksLbrOut = _JrtSchRunTicksLbrOut;
                WcAvailableOut = _WcAvailableOut;

                return (Severity, u_qty, l_qty, u_outside, l_outside, u_run, l_setup, u_fovhd_lbr, l_fovhd_lbr, u_vovhd_lbr, l_vovhd_lbr, u_fovhd_mch, u_vovhd_mch, WcOverhead, WcOutside, CostoperUHrsMch, CostoperLHrsOut, CostoperUHrsLbrOut, JrtSchRunTicksLbrOut, WcAvailableOut);
            }
        }

        public (
            int? ReturnCode,
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
            int? WcAvailableOut)
        CostOperJobCostSp(
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
            decimal? CostoperUHrsMch
            )
        {

            int? Severity = null;
            decimal? CostoperUHrsLbr = null;
            decimal? CostoperLHrs = null;

            Severity = 0;
            int? WcAvailable = 0;
            if (zero_args == 1)
            {
                u_outside = 0.0M;
                l_outside = 0.0M;
                u_run = 0.0M;
                l_setup = 0.0M;
                u_fovhd_lbr = 0.0M;
                l_fovhd_lbr = 0.0M;
                u_vovhd_lbr = 0.0M;
                l_vovhd_lbr = 0.0M;
                u_fovhd_mch = 0.0M;
                u_vovhd_mch = 0.0M;

            }

            if (wc != null)
            {
                WcAvailable = 1;
                CostoperUHrsLbr = (JrtSchRunTicksLbr == null || JobrouteEfficiency == null || u_qty == null) ? null : (decimal?)(JrtSchRunTicksLbr / JobrouteEfficiency * u_qty);
                CostoperLHrs = (JrtSchSetupTicks == null || JobrouteEfficiency == null || l_qty == null) ? null : (decimal?)(JrtSchSetupTicks / JobrouteEfficiency * l_qty);
                CostoperUHrsMch = (JrtSchRunTicksMch == null || JobrouteEfficiency == null || u_qty == null) ? null : (decimal?)(JrtSchRunTicksMch / JobrouteEfficiency * u_qty);
                if (WcOutside == 1)
                {
                    u_outside = (u_outside == null || JobrouteRunRateLbr == null || JrtSchRunTicksLbr == null || u_qty == null) ? null : (decimal?)(u_outside + JobrouteRunRateLbr * JrtSchRunTicksLbr / 100.0M * u_qty);
                    l_outside = (l_outside == null || JobrouteSetupRate == null || JrtSchSetupTicks == null || l_qty == null) ? null : (decimal?)(l_outside + JobrouteSetupRate * JrtSchSetupTicks / 100.0M * l_qty);

                }
                else
                {
                    u_run = (u_run == null || JobrouteRunRateLbr == null || CostoperUHrsLbr == null) ? null : (decimal?)(u_run + JobrouteRunRateLbr * CostoperUHrsLbr);
                    l_setup = (l_setup == null || JobrouteSetupRate == null || CostoperLHrs == null) ? null : (decimal?)(l_setup + JobrouteSetupRate * CostoperLHrs);
                    if (WcOverhead != null && WcOverhead.Contains("L"))
                    {
                        u_fovhd_lbr = (u_fovhd_lbr == null || JobrouteFixovhdRate == null || CostoperUHrsLbr == null) ? null : (decimal?)(u_fovhd_lbr + JobrouteFixovhdRate * CostoperUHrsLbr);
                        l_fovhd_lbr = (l_fovhd_lbr == null || JobrouteFixovhdRate == null || CostoperLHrs == null) ? null : (decimal?)(l_fovhd_lbr + JobrouteFixovhdRate * CostoperLHrs);
                        u_vovhd_lbr = (u_vovhd_lbr == null || JobrouteVarovhdRate == null || CostoperUHrsLbr == null) ? null : (decimal?)(u_vovhd_lbr + JobrouteVarovhdRate * CostoperUHrsLbr);
                        l_vovhd_lbr = (l_vovhd_lbr == null || JobrouteVarovhdRate == null || CostoperLHrs == null) ? null : (decimal?)(l_vovhd_lbr + JobrouteVarovhdRate * CostoperLHrs);

                    }
                    if (WcOverhead != null && WcOverhead.Contains("C"))
                    {
                        u_fovhd_mch = (u_fovhd_mch == null || JobrouteFovhdRateMch == null || CostoperUHrsMch == null) ? null : (decimal?)(u_fovhd_mch + JobrouteFovhdRateMch * CostoperUHrsMch);
                        u_vovhd_mch = (u_vovhd_mch == null || JobrouteVovhdRateMch == null || CostoperUHrsMch == null) ? null : (decimal?)(u_vovhd_mch + JobrouteVovhdRateMch * CostoperUHrsMch);

                    }

                }
            }
            return (Severity, u_qty, l_qty, u_outside, l_outside, u_run, l_setup, u_fovhd_lbr, l_fovhd_lbr, u_vovhd_lbr, l_vovhd_lbr, u_fovhd_mch, u_vovhd_mch, CostoperUHrsMch, CostoperLHrs, CostoperUHrsLbr, JrtSchRunTicksLbr, WcAvailable);
        }
    }
}
