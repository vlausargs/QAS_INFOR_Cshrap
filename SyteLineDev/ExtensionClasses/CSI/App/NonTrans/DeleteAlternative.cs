//PROJECT NAME: NonTrans
//CLASS NAME: DeleteAlternative.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.NonTrans
{
	public interface IDeleteAlternative
	{
		(int? ReturnCode, string Infobar) DeleteAlternativeSp(string Infobar);
	}
	
	public class DeleteAlternative : IDeleteAlternative
	{
		readonly IApplicationDB appDB;
		
		public DeleteAlternative(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteAlternativeSp(string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteAlternativeSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
