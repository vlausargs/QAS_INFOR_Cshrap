//PROJECT NAME: Data
//CLASS NAME: SerialPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SerialPrefix : ISerialPrefix
	{
		readonly IApplicationDB appDB;
		
		public SerialPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SerialPrefixFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SerialPrefix]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
