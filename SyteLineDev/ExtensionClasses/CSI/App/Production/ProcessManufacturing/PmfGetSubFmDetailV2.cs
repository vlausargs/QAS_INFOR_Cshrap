//PROJECT NAME: Production
//CLASS NAME: PmfGetSubFmDetailV2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetSubFmDetailV2
	{
		int? PmfGetSubFmDetailV2Sp();
	}
	
	public class PmfGetSubFmDetailV2 : IPmfGetSubFmDetailV2
	{
		readonly IApplicationDB appDB;
		
		public PmfGetSubFmDetailV2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfGetSubFmDetailV2Sp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetSubFmDetailV2Sp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
