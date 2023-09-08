//PROJECT NAME: Data
//CLASS NAME: UDFExceptionMsgApp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UDFExceptionMsgApp : IUDFExceptionMsgApp
	{
		readonly IApplicationDB appDB;
		
		public UDFExceptionMsgApp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string UDFExceptionMsgAppFn(
			string Infobar,
			string CaughtMsg,
			string Template)
		{
			InfobarType _Infobar = Infobar;
			InfobarType _CaughtMsg = CaughtMsg;
			InfobarType _Template = Template;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UDFExceptionMsgApp](@Infobar, @CaughtMsg, @Template)";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CaughtMsg", _CaughtMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Template", _Template, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
