//PROJECT NAME: CSIMaterial
//CLASS NAME: PhyinvItemV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IPhyinvItemV
	{
		int PhyinvItemVSp(string Whse,
		                  string Item,
		                  ref byte? LotTracked,
		                  ref byte? SerialTracked,
		                  ref string Infobar);
	}
	
	public class PhyinvItemV : IPhyinvItemV
	{
		readonly IApplicationDB appDB;
		
		public PhyinvItemV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PhyinvItemVSp(string Whse,
		                         string Item,
		                         ref byte? LotTracked,
		                         ref byte? SerialTracked,
		                         ref string Infobar)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerialTracked = SerialTracked;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyinvItemVSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotTracked = _LotTracked;
				SerialTracked = _SerialTracked;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
