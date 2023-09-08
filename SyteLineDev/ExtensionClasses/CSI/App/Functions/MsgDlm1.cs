//PROJECT NAME: Data
//CLASS NAME: MsgDlm1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MsgDlm1 : IMsgDlm1
	{
		readonly IApplicationDB appDB;
		
		public MsgDlm1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MsgDlm1Sp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MsgDlm1Sp]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
