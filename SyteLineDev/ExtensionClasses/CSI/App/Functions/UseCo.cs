//PROJECT NAME: Data
//CLASS NAME: UseCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UseCo : IUseCo
	{
		readonly IApplicationDB appDB;
		
		public UseCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UseCoFn(
			int? DetailDisplay)
		{
			IntType _DetailDisplay = DetailDisplay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UseCo](@DetailDisplay)";
				
				appDB.AddCommandParameter(cmd, "DetailDisplay", _DetailDisplay, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
