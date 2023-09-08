//PROJECT NAME: Finance
//CLASS NAME: MultiFSBJournalImmediate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBJournalImmediate : IMultiFSBJournalImmediate
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBJournalImmediate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MultiFSBJournalImmediateSp(
			Guid? Partition,
			string Infobar)
		{
			GuidType _Partition = Partition;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBJournalImmediateSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
