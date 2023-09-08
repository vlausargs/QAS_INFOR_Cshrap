//PROJECT NAME: Data
//CLASS NAME: MaxInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaxInvNum : IMaxInvNum
	{
		readonly IApplicationDB appDB;
		
		public MaxInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MaxInvNumFn(
			string InvNum1,
			string InvNum2)
		{
			InvNumType _InvNum1 = InvNum1;
			InvNumType _InvNum2 = InvNum2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaxInvNum](@InvNum1, @InvNum2)";
				
				appDB.AddCommandParameter(cmd, "InvNum1", _InvNum1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum2", _InvNum2, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
