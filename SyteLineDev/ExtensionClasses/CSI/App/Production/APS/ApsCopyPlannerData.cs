//PROJECT NAME: Production
//CLASS NAME: ApsCopyPlannerData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCopyPlannerData : IApsCopyPlannerData
	{
		readonly IApplicationDB appDB;
		
		
		public ApsCopyPlannerData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCopyPlannerDataSp(int? AltNo)
		{
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsCopyPlannerDataSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
