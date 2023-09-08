//PROJECT NAME: Data
//CLASS NAME: MsgStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MsgStr : IMsgStr
	{
		readonly IApplicationDB appDB;
		
		public MsgStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MsgStrFn(
			string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MsgStr](@Infobar)";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
