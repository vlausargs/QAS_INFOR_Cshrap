//PROJECT NAME: Data
//CLASS NAME: GetSourceRule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSourceRule : IGetSourceRule
	{
		readonly IApplicationDB appDB;
		
		public GetSourceRule(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetSourceRuleFn(
			string Item,
			DateTime? EffDate)
		{
			ItemType _Item = Item;
			DateType _EffDate = EffDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetSourceRule](@Item, @EffDate)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
