//PROJECT NAME: CSIMaterial
//CLASS NAME: tmp_phyinvVerifyPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface Itmp_phyinvVerifyPrint
	{
		int tmp_phyinvVerifyPrintSp(Guid? PSessionID,
		                            ref string Infobar);
	}
	
	public class tmp_phyinvVerifyPrint : Itmp_phyinvVerifyPrint
	{
		readonly IApplicationDB appDB;
		
		public tmp_phyinvVerifyPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int tmp_phyinvVerifyPrintSp(Guid? PSessionID,
		                                   ref string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "tmp_phyinvVerifyPrintSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
