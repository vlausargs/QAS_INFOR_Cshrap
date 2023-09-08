//PROJECT NAME: Production
//CLASS NAME: PmfFmGetItemsForLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmGetItemsForLine
	{
		int? PmfFmGetItemsForLineSp();
	}
	
	public class PmfFmGetItemsForLine : IPmfFmGetItemsForLine
	{
		readonly IApplicationDB appDB;
		
		public PmfFmGetItemsForLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmGetItemsForLineSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmGetItemsForLineSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
