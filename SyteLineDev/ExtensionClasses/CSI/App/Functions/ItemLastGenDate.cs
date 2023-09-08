//PROJECT NAME: Data
//CLASS NAME: ItemLastGenDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemLastGenDate : IItemLastGenDate
	{
		readonly IApplicationDB appDB;
		
		public ItemLastGenDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? ItemLastGenDateFn(
			DateTime? ItemChangeDate)
		{
			DateType _ItemChangeDate = ItemChangeDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemLastGenDate](@ItemChangeDate)";
				
				appDB.AddCommandParameter(cmd, "ItemChangeDate", _ItemChangeDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
