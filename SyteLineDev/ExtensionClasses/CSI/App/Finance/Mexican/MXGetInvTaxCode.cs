//PROJECT NAME: Finance
//CLASS NAME: MXGetInvTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXGetInvTaxCode : IMXGetInvTaxCode
	{
		readonly IApplicationDB appDB;
		
		public MXGetInvTaxCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MXGetInvTaxCodeFn(
			string InvNum)
		{
			InvNumType _InvNum = InvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MXGetInvTaxCode](@InvNum)";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
