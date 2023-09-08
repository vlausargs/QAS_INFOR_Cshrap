//PROJECT NAME: Production
//CLASS NAME: PmfUmClsDetGetDescription.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfUmClsDetGetDescription : IPmfUmClsDetGetDescription
	{
		readonly IApplicationDB appDB;
		
		public PmfUmClsDetGetDescription(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfUmClsDetGetDescriptionSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfUmClsDetGetDescriptionSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
