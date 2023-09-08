//PROJECT NAME: Production
//CLASS NAME: PmfGetViewList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetViewList : IPmfGetViewList
	{
		readonly IApplicationDB appDB;
		
		public PmfGetViewList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfGetViewListSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetViewListSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
