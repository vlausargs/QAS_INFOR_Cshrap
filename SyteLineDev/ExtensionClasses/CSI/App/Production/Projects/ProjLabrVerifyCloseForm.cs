//PROJECT NAME: CSIProjects
//CLASS NAME: ProjLabrVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjLabrVerifyCloseForm
	{
		int ProjLabrVerifyCloseFormSp(Guid? PSessionID,
		                              ref string Infobar);
	}
	
	public class ProjLabrVerifyCloseForm : IProjLabrVerifyCloseForm
	{
		readonly IApplicationDB appDB;
		
		public ProjLabrVerifyCloseForm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjLabrVerifyCloseFormSp(Guid? PSessionID,
		                                     ref string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjLabrVerifyCloseFormSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
