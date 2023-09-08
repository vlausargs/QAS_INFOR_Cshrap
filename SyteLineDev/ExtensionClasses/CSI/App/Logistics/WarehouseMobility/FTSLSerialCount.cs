//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLSerialCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLSerialCount
	{
		int FTSLSerialCountSp(string SessionID,
		                      ref string Infobar);
	}
	
	public class FTSLSerialCount : IFTSLSerialCount
	{
		readonly IApplicationDB appDB;
		
		public FTSLSerialCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLSerialCountSp(string SessionID,
		                             ref string Infobar)
		{
			NameType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLSerialCountSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
