//PROJECT NAME: Production
//CLASS NAME: PmfPrintLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPrintLine : IPmfPrintLine
	{
		readonly IApplicationDB appDB;
		
		public PmfPrintLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfPrintLineSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPrintLineSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
