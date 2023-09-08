//PROJECT NAME: Material
//CLASS NAME: ForecastCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ForecastCalc : IForecastCalc
	{
		readonly IApplicationDB appDB;
		
		
		public ForecastCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ForecastCalcSp(string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ForecastCalcSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
