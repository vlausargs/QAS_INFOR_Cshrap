//PROJECT NAME: CSICustomer
//CLASS NAME: GetMarkupFromItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetMarkupFromItem
	{
		int GetMarkupFromItemSp(string Item,
		                        ref decimal? Markup);
	}
	
	public class GetMarkupFromItem : IGetMarkupFromItem
	{
		readonly IApplicationDB appDB;
		
		public GetMarkupFromItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetMarkupFromItemSp(string Item,
		                               ref decimal? Markup)
		{
			ItemType _Item = Item;
			MarkupType _Markup = Markup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMarkupFromItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Markup", _Markup, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Markup = _Markup;
				
				return Severity;
			}
		}
	}
}
