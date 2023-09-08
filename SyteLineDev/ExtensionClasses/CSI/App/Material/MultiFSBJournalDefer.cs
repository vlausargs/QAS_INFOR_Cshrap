//PROJECT NAME: Finance
//CLASS NAME: MultiFSBJournalDefer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBJournalDefer : IMultiFSBJournalDefer
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBJournalDefer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? Partition,
			string Infobar) MultiFSBJournalDeferSp(
			string JournalId = null,
			Guid? Partition = null,
			string Infobar = null)
		{
			JournalIdType _JournalId = JournalId;
			GuidType _Partition = Partition;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBJournalDeferSp";
				
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Partition = _Partition;
				Infobar = _Infobar;
				
				return (Severity, Partition, Infobar);
			}
		}
	}
}
