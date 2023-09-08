//PROJECT NAME: Production
//CLASS NAME: PmfPnCreateBatchWrk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnCreateBatchWrk
	{
		(int? ReturnCode, string InfoBar) PmfPnCreateBatchWrkSp(string InfoBar = null,
		                                                        string Prefix = null,
		                                                        Guid? SessionId = null,
		                                                        decimal? Sequence = null,
		                                                        Guid? PmfMfgSpecRowPointer = null,
		                                                        Guid? PmfPnBatchWrkRowPointer = null);
	}
	
	public class PmfPnCreateBatchWrk : IPmfPnCreateBatchWrk
	{
		readonly IApplicationDB appDB;
		
		public PmfPnCreateBatchWrk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnCreateBatchWrkSp(string InfoBar = null,
		                                                               string Prefix = null,
		                                                               Guid? SessionId = null,
		                                                               decimal? Sequence = null,
		                                                               Guid? PmfMfgSpecRowPointer = null,
		                                                               Guid? PmfPnBatchWrkRowPointer = null)
		{
			InfobarType _InfoBar = InfoBar;
			LongList _Prefix = Prefix;
			RowPointerType _SessionId = SessionId;
			SequenceType _Sequence = Sequence;
			RowPointerType _PmfMfgSpecRowPointer = PmfMfgSpecRowPointer;
			RowPointerType _PmfPnBatchWrkRowPointer = PmfPnBatchWrkRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnCreateBatchWrkSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PmfMfgSpecRowPointer", _PmfMfgSpecRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PmfPnBatchWrkRowPointer", _PmfPnBatchWrkRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
