//PROJECT NAME: Finance
//CLASS NAME: SSSVTXAvaTaxExemptProcessSL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXAvaTaxExemptProcessSL : ISSSVTXAvaTaxExemptProcessSL
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXAvaTaxExemptProcessSL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oCMInvNum,
			string Infobar) SSSVTXAvaTaxExemptProcessSLSp(
			string pInvNum,
			decimal? pAvalaraTax,
			decimal? pAvalaraTax2,
			string oCMInvNum,
			string Infobar)
		{
			InvNumType _pInvNum = pInvNum;
			AmountType _pAvalaraTax = pAvalaraTax;
			AmountType _pAvalaraTax2 = pAvalaraTax2;
			InvNumType _oCMInvNum = oCMInvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXAvaTaxExemptProcessSLSp";
				
				appDB.AddCommandParameter(cmd, "pInvNum", _pInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAvalaraTax", _pAvalaraTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAvalaraTax2", _pAvalaraTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oCMInvNum", _oCMInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oCMInvNum = _oCMInvNum;
				Infobar = _Infobar;
				
				return (Severity, oCMInvNum, Infobar);
			}
		}
	}
}
