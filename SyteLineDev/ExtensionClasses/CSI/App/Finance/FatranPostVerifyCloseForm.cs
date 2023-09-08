//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IFatranPostVerifyCloseForm
	{
		int FatranPostVerifyCloseFormSp(Guid? ProcessID,
		                                ref string Infobar);
	}
	
	public class FatranPostVerifyCloseForm : IFatranPostVerifyCloseForm
	{
		readonly IApplicationDB appDB;
		
		public FatranPostVerifyCloseForm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FatranPostVerifyCloseFormSp(Guid? ProcessID,
		                                       ref string Infobar)
		{
			RowPointer _ProcessID = ProcessID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FatranPostVerifyCloseFormSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
