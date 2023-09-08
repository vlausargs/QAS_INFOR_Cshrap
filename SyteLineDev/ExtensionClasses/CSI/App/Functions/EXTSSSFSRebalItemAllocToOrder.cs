//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSRebalItemAllocToOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSRebalItemAllocToOrder : IEXTSSSFSRebalItemAllocToOrder
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSRebalItemAllocToOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CoitemCount,
			string Infobar) EXTSSSFSRebalItemAllocToOrderSp(
			int? CoitemCount,
			string Infobar)
		{
			IntType _CoitemCount = CoitemCount;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSRebalItemAllocToOrderSp";
				
				appDB.AddCommandParameter(cmd, "CoitemCount", _CoitemCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoitemCount = _CoitemCount;
				Infobar = _Infobar;
				
				return (Severity, CoitemCount, Infobar);
			}
		}
	}
}
