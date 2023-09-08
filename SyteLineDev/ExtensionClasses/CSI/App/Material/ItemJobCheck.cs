//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemJobCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemJobCheck
	{
		(int? ReturnCode, string Infobar) ItemJobCheckSp(string Item,
		byte? LotTracked,
		string Infobar,
		string PSite = null);
	}
	
	public class ItemJobCheck : IItemJobCheck
	{
		readonly IApplicationDB appDB;
		
		public ItemJobCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemJobCheckSp(string Item,
		byte? LotTracked,
		string Infobar,
		string PSite = null)
		{
			ItemType _Item = Item;
			ListYesNoType _LotTracked = LotTracked;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemJobCheckSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
