//PROJECT NAME: Production
//CLASS NAME: PmfPnAutoReceive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnAutoReceive
	{
		(int? ReturnCode, string InfoBar) PmfPnAutoReceiveSp(string InfoBar = null,
		                                                     Guid? PnRp = null,
		                                                     int? ReceiveMethod = 1,
		                                                     int? Suffix = null,
		                                                     int? OpComplete = 0);
	}
	
	public class PmfPnAutoReceive : IPmfPnAutoReceive
	{
		readonly IApplicationDB appDB;
		
		public PmfPnAutoReceive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnAutoReceiveSp(string InfoBar = null,
		                                                            Guid? PnRp = null,
		                                                            int? ReceiveMethod = 1,
		                                                            int? Suffix = null,
		                                                            int? OpComplete = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			IntType _ReceiveMethod = ReceiveMethod;
			IntType _Suffix = Suffix;
			IntType _OpComplete = OpComplete;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnAutoReceiveSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiveMethod", _ReceiveMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpComplete", _OpComplete, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
