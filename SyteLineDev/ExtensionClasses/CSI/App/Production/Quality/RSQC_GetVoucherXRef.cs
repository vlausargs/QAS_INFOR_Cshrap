//PROJECT NAME: Production
//CLASS NAME: RSQC_GetVoucherXRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetVoucherXRef : IRSQC_GetVoucherXRef
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetVoucherXRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_voucher,
		string Infobar) RSQC_GetVoucherXRefSp(int? i_vrma,
		int? o_voucher,
		string Infobar)
		{
			QCRcvrNumType _i_vrma = i_vrma;
			VoucherType _o_voucher = o_voucher;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetVoucherXRefSp";
				
				appDB.AddCommandParameter(cmd, "i_vrma", _i_vrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_voucher", _o_voucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_voucher = _o_voucher;
				Infobar = _Infobar;
				
				return (Severity, o_voucher, Infobar);
			}
		}
	}
}
