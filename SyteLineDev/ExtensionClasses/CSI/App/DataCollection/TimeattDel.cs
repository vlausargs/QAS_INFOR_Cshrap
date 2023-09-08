//PROJECT NAME: DataCollection
//CLASS NAME: TimeattDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class TimeattDel : ITimeattDel
	{
		readonly IApplicationDB appDB;
		
		
		public TimeattDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TimeattDelSp(Guid? RowPointer)
		{
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TimeattDelSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
