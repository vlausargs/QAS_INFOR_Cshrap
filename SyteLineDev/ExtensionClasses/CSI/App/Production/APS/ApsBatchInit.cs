//PROJECT NAME: Production
//CLASS NAME: ApsBatchInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBatchInit : IApsBatchInit
	{
		readonly IApplicationDB appDB;
		
		public ApsBatchInit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBatchInitSp(
			int? AltNo)
		{
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsBatchInitSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
