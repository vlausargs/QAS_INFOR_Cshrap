//PROJECT NAME: Production
//CLASS NAME: ApsSkipRepProjDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSkipRepProjDate : IApsSkipRepProjDate
	{
		readonly IApplicationDB appDB;
		
		public ApsSkipRepProjDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSkipRepProjDateFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSkipRepProjDate]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
