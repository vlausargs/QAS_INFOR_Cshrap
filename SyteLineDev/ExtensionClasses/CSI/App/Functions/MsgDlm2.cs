//PROJECT NAME: Data
//CLASS NAME: MsgDlm2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MsgDlm2 : IMsgDlm2
	{
		readonly IApplicationDB appDB;
		
		public MsgDlm2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MsgDlm2Sp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MsgDlm2Sp]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
