//PROJECT NAME: Data
//CLASS NAME: GetW2CodeDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetW2CodeDesc : IGetW2CodeDesc
	{
		readonly IApplicationDB appDB;
		
		public GetW2CodeDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetW2CodeDescFn(
			string pW2Code)
		{
			W2CodeType _pW2Code = pW2Code;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetW2CodeDesc](@pW2Code)";
				
				appDB.AddCommandParameter(cmd, "pW2Code", _pW2Code, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
