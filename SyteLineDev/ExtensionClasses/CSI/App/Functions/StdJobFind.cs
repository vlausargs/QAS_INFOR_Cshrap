//PROJECT NAME: Data
//CLASS NAME: StdJobFind.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class StdJobFind : IStdJobFind
	{
		readonly IApplicationDB appDB;
		
		public StdJobFind(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? StdJobFindFn(
			string Job,
			int? OperNum,
			string Item,
			decimal? MatlQty)
		{
			JobType _Job = Job;
			OperNumType _OperNum = OperNum;
			ItemType _Item = Item;
			QtyPerType _MatlQty = MatlQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[StdJobFind](@Job, @OperNum, @Item, @MatlQty)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
