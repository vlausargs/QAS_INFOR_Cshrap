//PROJECT NAME: Data
//CLASS NAME: LineFeed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LineFeed : ILineFeed
	{
		readonly IApplicationDB appDB;
		
		public LineFeed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string LineFeedFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LineFeed]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
