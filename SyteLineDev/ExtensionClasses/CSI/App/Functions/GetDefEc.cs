//PROJECT NAME: Data
//CLASS NAME: GetDefEc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetDefEc : IGetDefEc
	{
		readonly IApplicationDB appDB;
		
		public GetDefEc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetDefEcFn(
			string VendNum)
		{
			VendNumType _VendNum = VendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetDefEc](@VendNum)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
