//PROJECT NAME: Data
//CLASS NAME: SarbWrt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SarbWrt : ISarbWrt
	{
		readonly IApplicationDB appDB;
		
		public SarbWrt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SarbWrtSp(
			string PItem,
			DateTime? PDate,
			decimal? PPrice,
			decimal? PQty)
		{
			ItemType _PItem = PItem;
			DateType _PDate = PDate;
			AmountType _PPrice = PPrice;
			QtyUnitType _PQty = PQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SarbWrtSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrice", _PPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
