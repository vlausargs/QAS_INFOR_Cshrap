//PROJECT NAME: CSIMaterial
//CLASS NAME: PrintInvShtsVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IPrintInvShtsVerifyCloseForm
	{
		int PrintInvShtsVerifyCloseFormSp(Guid? PSessionID,
		                                  ref string Infobar);
	}
	
	public class PrintInvShtsVerifyCloseForm : IPrintInvShtsVerifyCloseForm
	{
		readonly IApplicationDB appDB;
		
		public PrintInvShtsVerifyCloseForm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PrintInvShtsVerifyCloseFormSp(Guid? PSessionID,
		                                         ref string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInvShtsVerifyCloseFormSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
