//PROJECT NAME: Production
//CLASS NAME: CostOpcp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CostOpcp : ICostOpcp
	{
		readonly IApplicationDB appDB;
		
		public CostOpcp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			int? WcOutside)
		{
			ListYesNoType _zero_args = zero_args;
			RowPointerType _JobrouteRowPointer = JobrouteRowPointer;
			CostPrcType _JrtItemRunCostTLbr = JrtItemRunCostTLbr;
			CostPrcType _JrtItemSetupCostT = JrtItemSetupCostT;
			CostPrcType _JrtItemFixOvhdTLbr = JrtItemFixOvhdTLbr;
			CostPrcType _JrtItemVarOvhdTLbr = JrtItemVarOvhdTLbr;
			CostPrcType _JrtItemFixOvhdTMch = JrtItemFixOvhdTMch;
			CostPrcType _JrtItemVarOvhdTMch = JrtItemVarOvhdTMch;
			CostPrcType _u_outside = u_outside;
			CostPrcType _l_outside = l_outside;
			CostPrcType _u_run = u_run;
			CostPrcType _l_setup = l_setup;
			CostPrcType _t_fovhd_lbr = t_fovhd_lbr;
			CostPrcType _t_vovhd_lbr = t_vovhd_lbr;
			CostPrcType _t_fovhd_mch = t_fovhd_mch;
			CostPrcType _t_vovhd_mch = t_vovhd_mch;
			OverheadBasisType _WcOverhead = WcOverhead;
			ListYesNoType _WcOutside = WcOutside;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CostOpcpSp";
				
				appDB.AddCommandParameter(cmd, "zero_args", _zero_args, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteRowPointer", _JobrouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtItemRunCostTLbr", _JrtItemRunCostTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtItemSetupCostT", _JrtItemSetupCostT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtItemFixOvhdTLbr", _JrtItemFixOvhdTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtItemVarOvhdTLbr", _JrtItemVarOvhdTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtItemFixOvhdTMch", _JrtItemFixOvhdTMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtItemVarOvhdTMch", _JrtItemVarOvhdTMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "u_outside", _u_outside, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "l_outside", _l_outside, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "u_run", _u_run, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "l_setup", _l_setup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_fovhd_lbr", _t_fovhd_lbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_vovhd_lbr", _t_vovhd_lbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_fovhd_mch", _t_fovhd_mch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_vovhd_mch", _t_vovhd_mch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WcOverhead", _WcOverhead, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WcOutside", _WcOutside, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				u_outside = _u_outside;
				l_outside = _l_outside;
				u_run = _u_run;
				l_setup = _l_setup;
				t_fovhd_lbr = _t_fovhd_lbr;
				t_vovhd_lbr = _t_vovhd_lbr;
				t_fovhd_mch = _t_fovhd_mch;
				t_vovhd_mch = _t_vovhd_mch;
				WcOverhead = _WcOverhead;
				WcOutside = _WcOutside;
				
				return (Severity, u_outside, l_outside, u_run, l_setup, t_fovhd_lbr, t_vovhd_lbr, t_fovhd_mch, t_vovhd_mch, WcOverhead, WcOutside);
			}
		}
	}
}
