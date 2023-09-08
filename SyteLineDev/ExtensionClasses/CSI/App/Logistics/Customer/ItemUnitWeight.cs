//PROJECT NAME: Logistics
//CLASS NAME: ItemUnitWeight.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ItemUnitWeight : IItemUnitWeight
	{
		readonly IApplicationDB appDB;
		
		
		public ItemUnitWeight(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PUnitWeight,
		string Infobar) ItemUnitWeightSp(string PItem,
		decimal? PUnitWeight,
		string Infobar)
		{
			ItemType _PItem = PItem;
			ItemWeightType _PUnitWeight = PUnitWeight;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemUnitWeightSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitWeight", _PUnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitWeight = _PUnitWeight;
				Infobar = _Infobar;
				
				return (Severity, PUnitWeight, Infobar);
			}
		}
	}
}
