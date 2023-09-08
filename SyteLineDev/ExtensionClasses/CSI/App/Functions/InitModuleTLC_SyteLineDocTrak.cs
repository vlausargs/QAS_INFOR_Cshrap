//PROJECT NAME: Data
//CLASS NAME: InitModuleTLC_SYTELINEDOCTRAK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTLC_SYTELINEDOCTRAK : IInitModuleTLC_SYTELINEDOCTRAK
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTLC_SYTELINEDOCTRAK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTLC_SYTELINEDOCTRAKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTLC_SYTELINEDOCTRAKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
