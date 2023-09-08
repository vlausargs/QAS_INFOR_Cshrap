//PROJECT NAME: Production
//CLASS NAME: PmfFmImportProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmImportProcess
	{
		int? PmfFmImportProcessSp(Guid? SessionID);
	}
	
	public class PmfFmImportProcess : IPmfFmImportProcess
	{
		readonly IApplicationDB appDB;
		
		public PmfFmImportProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmImportProcessSp(Guid? SessionID)
		{
			GuidType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmImportProcessSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
