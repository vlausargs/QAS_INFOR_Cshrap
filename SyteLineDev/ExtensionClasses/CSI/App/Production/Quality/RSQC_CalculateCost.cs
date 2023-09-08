//PROJECT NAME: Production
//CLASS NAME: RSQC_CalculateCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CalculateCost : IRSQC_CalculateCost
	{
		readonly IApplicationDB appDB;
		
		public RSQC_CalculateCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_CalculateCostSp(
			string i_num)
		{
			QCDocNumType _i_num = i_num;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CalculateCostSp";
				
				appDB.AddCommandParameter(cmd, "i_num", _i_num, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
