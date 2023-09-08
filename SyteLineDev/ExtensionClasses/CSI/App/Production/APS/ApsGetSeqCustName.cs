//PROJECT NAME: Production
//CLASS NAME: ApsGetSeqCustName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetSeqCustName : IApsGetSeqCustName
	{
		readonly IApplicationDB appDB;
		
		public ApsGetSeqCustName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetSeqCustNameFn(
			string PCustNum)
		{
			ApsRulevalType _PCustNum = PCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetSeqCustName](@PCustNum)";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
