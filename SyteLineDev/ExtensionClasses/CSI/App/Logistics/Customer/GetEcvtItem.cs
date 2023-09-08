//PROJECT NAME: Logistics
//CLASS NAME: GetEcvtItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetEcvtItem : IGetEcvtItem
	{
		readonly IApplicationDB appDB;
		
		
		public GetEcvtItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CommCode,
		decimal? UnitWeight,
		string Origin) GetEcvtItemSp(string Item,
		string CommCode,
		decimal? UnitWeight,
		string Origin)
		{
			ItemType _Item = Item;
			CommodityCodeType _CommCode = CommCode;
			UnitWeightType _UnitWeight = UnitWeight;
			EcCodeType _Origin = Origin;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEcvtItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CommCode = _CommCode;
				UnitWeight = _UnitWeight;
				Origin = _Origin;
				
				return (Severity, CommCode, UnitWeight, Origin);
			}
		}
	}
}
