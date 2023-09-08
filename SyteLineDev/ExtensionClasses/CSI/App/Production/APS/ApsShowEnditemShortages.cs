//PROJECT NAME: Production
//CLASS NAME: ApsShowEnditemShortages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsShowEnditemShortages : IApsShowEnditemShortages
	{
		readonly IApplicationDB appDB;
		
		public ApsShowEnditemShortages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsShowEnditemShortagesFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsShowEnditemShortages]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
