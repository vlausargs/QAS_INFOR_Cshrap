//PROJECT NAME: CSICustomer
//CLASS NAME: PmtpckPreUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckPreUpd
	{
		int PmtpckPreUpdSp(Guid? ArpmtRowPointer,
		                   ref string Infobar);
	}
	
	public class PmtpckPreUpd : IPmtpckPreUpd
	{
		readonly IApplicationDB appDB;
		
		public PmtpckPreUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PmtpckPreUpdSp(Guid? ArpmtRowPointer,
		                          ref string Infobar)
		{
			RowPointerType _ArpmtRowPointer = ArpmtRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckPreUpdSp";
				
				appDB.AddCommandParameter(cmd, "ArpmtRowPointer", _ArpmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
