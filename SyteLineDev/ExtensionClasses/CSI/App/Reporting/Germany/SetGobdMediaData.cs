//PROJECT NAME: Reporting
//CLASS NAME: SetGoBDMediaData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.Germany
{
	public interface ISetGoBDMediaData
	{
		int? SetGoBDMediaDataSp(Guid? ProcessId,
		                        string GoBDMediaDocument = null);
	}
	
	public class SetGoBDMediaData : ISetGoBDMediaData
	{
		IApplicationDB appDB;
		
		public SetGoBDMediaData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetGoBDMediaDataSp(Guid? ProcessId,
		                               string GoBDMediaDocument = null)
		{
			RowPointerType _ProcessId = ProcessId;
			StringType _GoBDMediaDocument = GoBDMediaDocument;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetGoBDMediaDataSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GoBDMediaDocument", _GoBDMediaDocument, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
