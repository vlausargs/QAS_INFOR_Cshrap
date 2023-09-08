//PROJECT NAME: Production
//CLASS NAME: ApsPriorityOf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPriorityOf : IApsPriorityOf
	{
		readonly IApplicationDB appDB;
		
		public ApsPriorityOf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPriorityOfFn(
			int? POrderCode)
		{
			IntType _POrderCode = POrderCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPriorityOf](@POrderCode)";
				
				appDB.AddCommandParameter(cmd, "POrderCode", _POrderCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
