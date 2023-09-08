//PROJECT NAME: Data
//CLASS NAME: UDFExceptionMsg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UDFExceptionMsg : IUDFExceptionMsg
	{
		readonly IApplicationDB appDB;
		
		public UDFExceptionMsg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string UDFExceptionMsgFn(
			string CaughtMsg,
			string Template)
		{
			InfobarType _CaughtMsg = CaughtMsg;
			InfobarType _Template = Template;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UDFExceptionMsg](@CaughtMsg, @Template)";
				
				appDB.AddCommandParameter(cmd, "CaughtMsg", _CaughtMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Template", _Template, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
