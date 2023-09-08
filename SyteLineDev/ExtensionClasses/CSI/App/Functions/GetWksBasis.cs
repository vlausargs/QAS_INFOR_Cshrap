//PROJECT NAME: Data
//CLASS NAME: GetWksBasis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetWksBasis : IGetWksBasis
	{
		readonly IApplicationDB appDB;
		
		public GetWksBasis(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetWksBasisFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetWksBasis](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
