//PROJECT NAME: Production
//CLASS NAME: ApsParseRefNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsParseRefNum : IApsParseRefNum
	{
		readonly IApplicationDB appDB;
		
		public ApsParseRefNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsParseRefNumFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsParseRefNum]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
