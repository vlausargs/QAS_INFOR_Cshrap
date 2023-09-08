//PROJECT NAME: Data
//CLASS NAME: CalcQtyItemPS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcQtyItemPS : ICalcQtyItemPS
	{
		readonly IApplicationDB appDB;
		
		public CalcQtyItemPS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CalcQtyItemPSSp(
			string Item,
			string PSStatus)
		{
			ItemType _Item = Item;
			InfobarType _PSStatus = PSStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcQtyItemPSSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSStatus", _PSStatus, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
