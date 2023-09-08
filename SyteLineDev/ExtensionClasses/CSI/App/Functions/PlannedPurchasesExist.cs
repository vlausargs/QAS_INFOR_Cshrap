//PROJECT NAME: Data
//CLASS NAME: PlannedPurchasesExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PlannedPurchasesExist : IPlannedPurchasesExist
	{
		readonly IApplicationDB appDB;
		
		public PlannedPurchasesExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PlannedPurchasesExistFn(
			string Item,
			DateTime? EndDate)
		{
			ItemType _Item = Item;
			DateType _EndDate = EndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PlannedPurchasesExist](@Item, @EndDate)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
