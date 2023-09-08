//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmPost
	{
		int LoadESBBankStmPostSp(string StmDocumentID,
		                         ref string InfoBar);
	}
	
	public class LoadESBBankStmPost : ILoadESBBankStmPost
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmPostSp(string StmDocumentID,
		                                ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmPostSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
