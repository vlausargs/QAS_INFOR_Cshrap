//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadBankStm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadBankStm
	{
		int LoadBankStmSp(string DocumentID,
		                  byte? Processed,
		                  ref string InfoBar);
	}
	
	public class LoadBankStm : ILoadBankStm
	{
		readonly IApplicationDB appDB;
		
		public LoadBankStm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadBankStmSp(string DocumentID,
		                         byte? Processed,
		                         ref string InfoBar)
		{
			MarkupDocumentNameType _DocumentID = DocumentID;
			ListYesNoType _Processed = Processed;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadBankStmSp";
				
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
