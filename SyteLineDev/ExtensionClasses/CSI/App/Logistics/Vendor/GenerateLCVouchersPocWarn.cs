//PROJECT NAME: CSIVendor
//CLASS NAME: GenerateLCVouchersPocWarn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateLCVouchersPocWarn
	{
		int GenerateLCVouchersPocWarnSp(string RefNum,
		                                string RefType,
		                                ref string Infobar);
	}
	
	public class GenerateLCVouchersPocWarn : IGenerateLCVouchersPocWarn
	{
		readonly IApplicationDB appDB;
		
		public GenerateLCVouchersPocWarn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GenerateLCVouchersPocWarnSp(string RefNum,
		                                       string RefType,
		                                       ref string Infobar)
		{
			PoTrnNumType _RefNum = RefNum;
			RefTypePTType _RefType = RefType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateLCVouchersPocWarnSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
