//PROJECT NAME: Data
//CLASS NAME: TH_InventoryBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TH_InventoryBalance : ITH_InventoryBalance
	{
		readonly IApplicationDB appDB;
		
		public TH_InventoryBalance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TH_InventoryBalanceSp(
			string ItemStarting = null,
			string ItemEnding = null,
			DateTime? TransDateStarting = null,
			DateTime? TransDateEnding = null,
			string WhseStarting = null,
			string WhseEnding = null,
			string LocStarting = null,
			string LocEnding = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			DateTimeType _TransDateStarting = TransDateStarting;
			DateTimeType _TransDateEnding = TransDateEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			LocType _LocStarting = LocStarting;
			LocType _LocEnding = LocEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TH_InventoryBalanceSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
