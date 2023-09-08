//PROJECT NAME: Logistics
//CLASS NAME: GetCoitemSumOrderedQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCoitemSumOrderedQty : IGetCoitemSumOrderedQty
	{
		readonly IApplicationDB appDB;
		
		
		public GetCoitemSumOrderedQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TotalOrdered) GetCoitemSumOrderedQtySp(string CoNum,
		int? CoLine,
		decimal? TotalOrdered)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			QtyUnitType _TotalOrdered = TotalOrdered;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoitemSumOrderedQtySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalOrdered", _TotalOrdered, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotalOrdered = _TotalOrdered;
				
				return (Severity, TotalOrdered);
			}
		}
	}
}
