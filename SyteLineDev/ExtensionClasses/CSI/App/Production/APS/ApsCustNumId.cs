//PROJECT NAME: Production
//CLASS NAME: ApsCustNumId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCustNumId : IApsCustNumId
	{
		readonly IApplicationDB appDB;
		
		public ApsCustNumId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsCustNumIdFn(
			string PCustNum)
		{
			CustNumType _PCustNum = PCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCustNumId](@PCustNum)";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
