//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSRODefaultQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSRODefaultQty : ISSSFSSRODefaultQty
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSRODefaultQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Qty) SSSFSSRODefaultQtySp(string RefNum,
		int? RefLine,
		decimal? Qty)
		{
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLine = RefLine;
			QtyUnitType _Qty = Qty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSRODefaultQtySp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Qty = _Qty;
				
				return (Severity, Qty);
			}
		}
	}
}
