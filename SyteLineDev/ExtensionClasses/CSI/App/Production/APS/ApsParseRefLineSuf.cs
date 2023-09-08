//PROJECT NAME: Production
//CLASS NAME: ApsParseRefLineSuf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsParseRefLineSuf : IApsParseRefLineSuf
	{
		readonly IApplicationDB appDB;
		
		public ApsParseRefLineSuf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsParseRefLineSufFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsParseRefLineSuf]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
