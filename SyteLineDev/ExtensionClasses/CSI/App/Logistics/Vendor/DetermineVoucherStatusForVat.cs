//PROJECT NAME: CSIVendor
//CLASS NAME: DetermineVoucherStatusForVat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IDetermineVoucherStatusForVat
	{
		int DetermineVoucherStatusForVatSp(ref int? stat,
		                                   ref string Infobar);
	}
	
	public class DetermineVoucherStatusForVat : IDetermineVoucherStatusForVat
	{
		readonly IApplicationDB appDB;
		
		public DetermineVoucherStatusForVat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DetermineVoucherStatusForVatSp(ref int? stat,
		                                          ref string Infobar)
		{
			IntType _stat = stat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DetermineVoucherStatusForVatSp";
				
				appDB.AddCommandParameter(cmd, "stat", _stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				stat = _stat;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
