//PROJECT NAME: Production
//CLASS NAME: EngWBCopyJobRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class EngWBCopyJobRef : IEngWBCopyJobRef
	{
		readonly IApplicationDB appDB;
		
		
		public EngWBCopyJobRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EngWBCopyJobRefSp(Guid? OldRowpointer,
		Guid? NewRowpointer)
		{
			RowPointerType _OldRowpointer = OldRowpointer;
			RowPointerType _NewRowpointer = NewRowpointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EngWBCopyJobRefSp";
				
				appDB.AddCommandParameter(cmd, "OldRowpointer", _OldRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRowpointer", _NewRowpointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
