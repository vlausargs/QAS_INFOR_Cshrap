//PROJECT NAME: Data
//CLASS NAME: CheckIfEcnPending.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckIfEcnPending : ICheckIfEcnPending
	{
		readonly IApplicationDB appDB;
		
		public CheckIfEcnPending(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckIfEcnPendingFn(
			string Job,
			int? Suffix,
			string Item)
		{
			JobType _Job = Job;
			IntType _Suffix = Suffix;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CheckIfEcnPending](@Job, @Suffix, @Item)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
