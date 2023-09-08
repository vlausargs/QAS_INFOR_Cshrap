//PROJECT NAME: Data
//CLASS NAME: MdayCalCalculateHorizon.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MdayCalCalculateHorizon : IMdayCalCalculateHorizon
	{
		readonly IApplicationDB appDB;
		
		public MdayCalCalculateHorizon(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MdayCalCalculateHorizonSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MdayCalCalculateHorizonSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
