//PROJECT NAME: CSIAPS
//CLASS NAME: GetResourceServiceInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IGetResourceServiceInfo
	{
		int GetResourceServiceInfoSp(string RESID,
		                             ref string SrvSchFrequency,
		                             ref string SrvSchFrequencyType,
		                             ref string Infobar);
	}
	
	public class GetResourceServiceInfo : IGetResourceServiceInfo
	{
		readonly IApplicationDB appDB;
		
		public GetResourceServiceInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetResourceServiceInfoSp(string RESID,
		                                    ref string SrvSchFrequency,
		                                    ref string SrvSchFrequencyType,
		                                    ref string Infobar)
		{
			ApsOrderType _RESID = RESID;
			MO_ScheduleFrequencyType _SrvSchFrequency = SrvSchFrequency;
			MO_ScheduleFrequencyTypeType _SrvSchFrequencyType = SrvSchFrequencyType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetResourceServiceInfoSp";
				
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SrvSchFrequency", _SrvSchFrequency, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SrvSchFrequencyType", _SrvSchFrequencyType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SrvSchFrequency = _SrvSchFrequency;
				SrvSchFrequencyType = _SrvSchFrequencyType;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
