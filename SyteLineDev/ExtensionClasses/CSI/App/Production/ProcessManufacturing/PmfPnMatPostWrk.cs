//PROJECT NAME: Production
//CLASS NAME: PmfPnMatPostWrk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnMatPostWrk
	{
		(int? ReturnCode, string InfoBar) PmfPnMatPostWrkSp(string InfoBar = null,
		                                                    Guid? SessId = null,
		                                                    DateTime? TranDate = null);
	}
	
	public class PmfPnMatPostWrk : IPmfPnMatPostWrk
	{
		readonly IApplicationDB appDB;
		
		public PmfPnMatPostWrk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnMatPostWrkSp(string InfoBar = null,
		                                                           Guid? SessId = null,
		                                                           DateTime? TranDate = null)
		{
			InfobarType _InfoBar = InfoBar;
			GuidType _SessId = SessId;
			DateTimeType _TranDate = TranDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnMatPostWrkSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessId", _SessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranDate", _TranDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
