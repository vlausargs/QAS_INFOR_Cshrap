//PROJECT NAME: Data
//CLASS NAME: ItemDockTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemDockTime : IItemDockTime
	{
		readonly IApplicationDB appDB;
		
		public ItemDockTime(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TDockTime,
			string Infobar) ItemDockTimeSp(
			string PItem,
			int? TDockTime,
			string Infobar,
			string Site = null)
		{
			ItemType _PItem = PItem;
			LeadTimeType _TDockTime = TDockTime;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemDockTimeSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDockTime", _TDockTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TDockTime = _TDockTime;
				Infobar = _Infobar;
				
				return (Severity, TDockTime, Infobar);
			}
		}
	}
}
