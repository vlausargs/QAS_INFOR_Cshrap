//PROJECT NAME: Data
//CLASS NAME: CheckIntegerMultiple.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckIntegerMultiple : ICheckIntegerMultiple
	{
		readonly IApplicationDB appDB;
		
		public CheckIntegerMultiple(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CheckIntegerMultipleSp(
			decimal? PQtyReleased,
			int? PRatio1,
			string Infobar)
		{
			QtyUnitType _PQtyReleased = PQtyReleased;
			TotalProdMixQuantityType _PRatio1 = PRatio1;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckIntegerMultipleSp";
				
				appDB.AddCommandParameter(cmd, "PQtyReleased", _PQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRatio1", _PRatio1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
