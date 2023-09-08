//PROJECT NAME: Production
//CLASS NAME: ApsNextBatProdID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsNextBatProdID : IApsNextBatProdID
	{
		readonly IApplicationDB appDB;
		
		public ApsNextBatProdID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsNextBatProdIDFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsNextBatProdID]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
