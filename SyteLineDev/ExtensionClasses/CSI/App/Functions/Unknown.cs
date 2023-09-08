//PROJECT NAME: Data
//CLASS NAME: Unknown.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Unknown : IUnknown
	{
		readonly IApplicationDB appDB;
		
		public Unknown(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string UnknownSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UnknownSp]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
