//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBExpenseReportLinePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBExpenseReportLinePost
	{
		int LoadESBExpenseReportLinePostSp(string DocumentID,
		                                   ref string Infobar);
	}
	
	public class LoadESBExpenseReportLinePost : ILoadESBExpenseReportLinePost
	{
		readonly IApplicationDB appDB;
		
		public LoadESBExpenseReportLinePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBExpenseReportLinePostSp(string DocumentID,
		                                          ref string Infobar)
		{
			StringType _DocumentID = DocumentID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBExpenseReportLinePostSp";
				
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
