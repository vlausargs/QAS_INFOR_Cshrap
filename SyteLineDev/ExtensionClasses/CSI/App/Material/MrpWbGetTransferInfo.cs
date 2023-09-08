//PROJECT NAME: Material
//CLASS NAME: MrpWbGetTransferInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbGetTransferInfo : IMrpWbGetTransferInfo
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbGetTransferInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string FromSite,
		string FromWhse,
		string ToWhse,
		decimal? UnitCost,
		int? LeadTime,
		string Infobar) MrpWbGetTransferInfoSp(string TrnNum,
		string Item,
		string FromSite,
		string FromWhse,
		string ToWhse,
		decimal? UnitCost,
		int? LeadTime,
		string Infobar)
		{
			TrnNumType _TrnNum = TrnNum;
			ItemType _Item = Item;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			CostPrcType _UnitCost = UnitCost;
			LeadTimeType _LeadTime = LeadTime;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbGetTransferInfoSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FromSite = _FromSite;
				FromWhse = _FromWhse;
				ToWhse = _ToWhse;
				UnitCost = _UnitCost;
				LeadTime = _LeadTime;
				Infobar = _Infobar;
				
				return (Severity, FromSite, FromWhse, ToWhse, UnitCost, LeadTime, Infobar);
			}
		}
	}
}
