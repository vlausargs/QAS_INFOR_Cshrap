//PROJECT NAME: CSICustomer
//CLASS NAME: CoBlanketQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoBlanketQtyValid
	{
		(int? ReturnCode, string Infobar) CoBlanketQtyValidSp(string CoNum,
		short? CoLine,
		string Item,
		decimal? BlanketQtyConv,
		string Infobar,
		string Site = null);
	}
	
	public class CoBlanketQtyValid : ICoBlanketQtyValid
	{
		readonly IApplicationDB appDB;
		
		public CoBlanketQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CoBlanketQtyValidSp(string CoNum,
		short? CoLine,
		string Item,
		decimal? BlanketQtyConv,
		string Infobar,
		string Site = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ItemType _Item = Item;
			QtyUnitType _BlanketQtyConv = BlanketQtyConv;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoBlanketQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQtyConv", _BlanketQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
