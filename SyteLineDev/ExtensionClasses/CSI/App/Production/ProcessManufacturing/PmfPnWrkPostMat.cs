//PROJECT NAME: Production
//CLASS NAME: PmfPnWrkPostMat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnWrkPostMat : IPmfPnWrkPostMat
	{
		readonly IApplicationDB appDB;
		
		public PmfPnWrkPostMat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfPnWrkPostMatSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnWrkPostMatSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
