//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjInitDataBinding.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetProjInitDataBinding
	{
		int GetProjInitDataBindingSp(ref string RetCode,
		                             ref byte? AutoInvMs,
		                             ref string WipRelMethod,
		                             ref string RevCalcMethod,
		                             ref decimal? RevCalcPct,
		                             ref decimal? RevCalcAmt,
		                             ref string CostCalcMethod,
		                             ref decimal? CostCalcPct,
		                             ref decimal? CostCalcAmt,
		                             ref string InvMethod,
		                             ref string TaxCode1,
		                             ref string TaxCode1Desc,
		                             ref string TaxCode2,
		                             ref string TaxCode2Desc,
		                             ref byte? VarTaxFreeImports);
	}
	
	public class GetProjInitDataBinding : IGetProjInitDataBinding
	{
		readonly IApplicationDB appDB;
		
		public GetProjInitDataBinding(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetProjInitDataBindingSp(ref string RetCode,
		                                    ref byte? AutoInvMs,
		                                    ref string WipRelMethod,
		                                    ref string RevCalcMethod,
		                                    ref decimal? RevCalcPct,
		                                    ref decimal? RevCalcAmt,
		                                    ref string CostCalcMethod,
		                                    ref decimal? CostCalcPct,
		                                    ref decimal? CostCalcAmt,
		                                    ref string InvMethod,
		                                    ref string TaxCode1,
		                                    ref string TaxCode1Desc,
		                                    ref string TaxCode2,
		                                    ref string TaxCode2Desc,
		                                    ref byte? VarTaxFreeImports)
		{
			RetCodeType _RetCode = RetCode;
			ListYesNoType _AutoInvMs = AutoInvMs;
			ProjWipRelMethodType _WipRelMethod = WipRelMethod;
			ProjRevCalcMethodType _RevCalcMethod = RevCalcMethod;
			ProjCalcPercentType _RevCalcPct = RevCalcPct;
			ProjCalcAmountType _RevCalcAmt = RevCalcAmt;
			ProjCostCalcMethodType _CostCalcMethod = CostCalcMethod;
			ProjCalcPercentType _CostCalcPct = CostCalcPct;
			ProjCalcAmountType _CostCalcAmt = CostCalcAmt;
			ProjInvMethodType _InvMethod = InvMethod;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			ListYesNoType _VarTaxFreeImports = VarTaxFreeImports;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProjInitDataBindingSp";
				
				appDB.AddCommandParameter(cmd, "RetCode", _RetCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoInvMs", _AutoInvMs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WipRelMethod", _WipRelMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevCalcMethod", _RevCalcMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevCalcPct", _RevCalcPct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevCalcAmt", _RevCalcAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCalcMethod", _CostCalcMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCalcPct", _CostCalcPct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCalcAmt", _CostCalcAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvMethod", _InvMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VarTaxFreeImports", _VarTaxFreeImports, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RetCode = _RetCode;
				AutoInvMs = _AutoInvMs;
				WipRelMethod = _WipRelMethod;
				RevCalcMethod = _RevCalcMethod;
				RevCalcPct = _RevCalcPct;
				RevCalcAmt = _RevCalcAmt;
				CostCalcMethod = _CostCalcMethod;
				CostCalcPct = _CostCalcPct;
				CostCalcAmt = _CostCalcAmt;
				InvMethod = _InvMethod;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				VarTaxFreeImports = _VarTaxFreeImports;
				
				return Severity;
			}
		}
	}
}
