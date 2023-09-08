//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostVerifyPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IFatranPostVerifyPrint
	{
		int FatranPostVerifyPrintSp(ref Guid? ProcessID,
		                            ref string Infobar);
	}
	
	public class FatranPostVerifyPrint : IFatranPostVerifyPrint
	{
		readonly IApplicationDB appDB;
		
		public FatranPostVerifyPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FatranPostVerifyPrintSp(ref Guid? ProcessID,
		                                   ref string Infobar)
		{
			RowPointer _ProcessID = ProcessID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FatranPostVerifyPrintSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProcessID = _ProcessID;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
