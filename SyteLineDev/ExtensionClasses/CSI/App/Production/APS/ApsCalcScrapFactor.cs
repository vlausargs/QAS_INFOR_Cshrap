//PROJECT NAME: Production
//CLASS NAME: ApsCalcScrapFactor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCalcScrapFactor : IApsCalcScrapFactor
	{
		readonly IApplicationDB appDB;
		
		public ApsCalcScrapFactor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCalcScrapFactorFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCalcScrapFactor]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
