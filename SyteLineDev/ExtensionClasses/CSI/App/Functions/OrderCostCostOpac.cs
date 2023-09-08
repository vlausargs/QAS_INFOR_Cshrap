//PROJECT NAME: Data
//CLASS NAME: OrderCostCostOpac.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class OrderCostCostOpac : IOrderCostCostOpac
	{
		readonly IApplicationDB appDB;
		
		public OrderCostCostOpac(IApplicationDB appDB)
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
			int? WcOutside)
		{
			ListYesNoType _zero_args = zero_args;
			RowPointerType _JobrouteRowPointer = JobrouteRowPointer;
			CostPrcType _u_outside = u_outside;
			CostPrcType _l_outside = l_outside;
			CostPrcType _u_run = u_run;
			CostPrcType _l_setup = l_setup;
			CostPrcType _t_fovhd_lbr = t_fovhd_lbr;
			CostPrcType _t_vovhd_lbr = t_vovhd_lbr;
			CostPrcType _t_fovhd_mch = t_fovhd_mch;
			CostPrcType _t_vovhd_mch = t_vovhd_mch;
			CostPrcType _Total = Total;
			OverheadBasisType _WcOverhead = WcOverhead;
			ListYesNoType _WcOutside = WcOutside;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "OrderCostCostOpacSp";
				
				appDB.AddCommandParameter(cmd, "zero_args", _zero_args, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteRowPointer", _JobrouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "u_outside", _u_outside, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "l_outside", _l_outside, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "u_run", _u_run, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "l_setup", _l_setup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_fovhd_lbr", _t_fovhd_lbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_vovhd_lbr", _t_vovhd_lbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_fovhd_mch", _t_fovhd_mch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_vovhd_mch", _t_vovhd_mch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Total", _Total, ParameterDirection.InputOutput);
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
				Total = _Total;
				WcOverhead = _WcOverhead;
				WcOutside = _WcOutside;
				
				return (Severity, u_outside, l_outside, u_run, l_setup, t_fovhd_lbr, t_vovhd_lbr, t_fovhd_mch, t_vovhd_mch, Total, WcOverhead, WcOutside);
			}
		}
	}
}
