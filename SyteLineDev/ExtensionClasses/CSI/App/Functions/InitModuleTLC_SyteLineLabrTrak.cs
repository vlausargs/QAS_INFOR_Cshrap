//PROJECT NAME: Data
//CLASS NAME: InitModuleTLC_SYTELINELABRTRAK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTLC_SYTELINELABRTRAK : IInitModuleTLC_SYTELINELABRTRAK
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTLC_SYTELINELABRTRAK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTLC_SYTELINELABRTRAKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTLC_SYTELINELABRTRAKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
