//PROJECT NAME: Material
//CLASS NAME: MrpWbGetDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbGetDate : IMrpWbGetDate
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbGetDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? ReleaseDate,
		string Infobar) MrpWbGetDateSp(string RefTab,
		string Item,
		string SupplySite,
		decimal? ReqdQty,
		DateTime? DueDate,
		DateTime? ReleaseDate,
		string Infobar)
		{
			StringType _RefTab = RefTab;
			ItemType _Item = Item;
			SiteType _SupplySite = SupplySite;
			QtyTotlType _ReqdQty = ReqdQty;
			DateType _DueDate = DueDate;
			DateType _ReleaseDate = ReleaseDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbGetDateSp";
				
				appDB.AddCommandParameter(cmd, "RefTab", _RefTab, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplySite", _SupplySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReleaseDate = _ReleaseDate;
				Infobar = _Infobar;
				
				return (Severity, ReleaseDate, Infobar);
			}
		}
	}
}
