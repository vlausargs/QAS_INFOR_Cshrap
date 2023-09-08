//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmProcessed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmProcessed
	{
		int LoadESBBankStmProcessedSp(string DocumentID,
		                              byte? Processed,
		                              ref string InfoBar);
	}
	
	public class LoadESBBankStmProcessed : ILoadESBBankStmProcessed
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmProcessed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmProcessedSp(string DocumentID,
		                                     byte? Processed,
		                                     ref string InfoBar)
		{
			MarkupElementValueType _DocumentID = DocumentID;
			ListYesNoType _Processed = Processed;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmProcessedSp";
				
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Processed", _Processed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
