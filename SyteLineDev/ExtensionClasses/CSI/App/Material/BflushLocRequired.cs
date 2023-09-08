//PROJECT NAME: Material
//CLASS NAME: BflushLocRequired.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BflushLocRequired : IBflushLocRequired
	{
		readonly IApplicationDB appDB;
		
		public BflushLocRequired(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BflushLocRequiredSp(
			string Item,
			string WC)
		{
			ItemType _Item = Item;
			WcType _WC = WC;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BflushLocRequiredSp](@Item, @WC)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
