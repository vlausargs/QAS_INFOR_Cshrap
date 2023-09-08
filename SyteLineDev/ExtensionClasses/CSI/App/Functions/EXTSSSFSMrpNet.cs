//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSMrpNet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSMrpNet : IEXTSSSFSMrpNet
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSMrpNet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSMrpNetSp(
			Guid? ProcessId,
			string ItemItem,
			string Whse)
		{
			RowPointerType _ProcessId = ProcessId;
			ItemType _ItemItem = ItemItem;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSMrpNetSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
