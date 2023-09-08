//PROJECT NAME: CSICustomer
//CLASS NAME: ItemCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IItemCheck
	{
		int ItemCheckSp(string PItem,
		                ref string Infobar);
	}
	
	public class ItemCheck : IItemCheck
	{
		readonly IApplicationDB appDB;
		
		public ItemCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ItemCheckSp(string PItem,
		                       ref string Infobar)
		{
			ItemType _PItem = PItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCheckSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
