//PROJECT NAME: Data
//CLASS NAME: PartitionAndCopyTableWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PartitionAndCopyTableWrapper : IPartitionAndCopyTableWrapper
	{
		readonly IApplicationDB appDB;
		
		public PartitionAndCopyTableWrapper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PartitionAndCopyTableWrapperSp(
			string PTableName,
			string Infobar)
		{
			ObjectNameType _PTableName = PTableName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PartitionAndCopyTableWrapperSp";
				
				appDB.AddCommandParameter(cmd, "PTableName", _PTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
