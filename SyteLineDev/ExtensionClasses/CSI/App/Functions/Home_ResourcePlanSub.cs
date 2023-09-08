//PROJECT NAME: Data
//CLASS NAME: Home_ResourcePlanSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Home_ResourcePlanSub : IHome_ResourcePlanSub
	{
		readonly IApplicationDB appDB;
		
		public Home_ResourcePlanSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Home_ResourcePlanSubSp(
			int? AltNum = 0,
			string FilterString = null)
		{
			ApsAltNoType _AltNum = AltNum;
			LongListType _FilterString = FilterString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_ResourcePlanSubSp";
				
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
