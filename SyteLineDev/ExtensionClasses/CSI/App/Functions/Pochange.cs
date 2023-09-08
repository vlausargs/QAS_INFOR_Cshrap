//PROJECT NAME: Data
//CLASS NAME: Pochange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Pochange : IPochange
	{
		readonly IApplicationDB appDB;
		
		public Pochange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PochangeSp(
			Guid? PRowPointer,
			string PPoNum,
			string PTableName)
		{
			RowPointerType _PRowPointer = PRowPointer;
			PoNumType _PPoNum = PPoNum;
			LongListType _PTableName = PTableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PochangeSp";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTableName", _PTableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
