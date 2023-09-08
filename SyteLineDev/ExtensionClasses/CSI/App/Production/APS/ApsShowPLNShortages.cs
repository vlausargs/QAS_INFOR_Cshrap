//PROJECT NAME: Production
//CLASS NAME: ApsShowPLNShortages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsShowPLNShortages : IApsShowPLNShortages
	{
		readonly IApplicationDB appDB;
		
		public ApsShowPLNShortages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsShowPLNShortagesFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsShowPLNShortages]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
