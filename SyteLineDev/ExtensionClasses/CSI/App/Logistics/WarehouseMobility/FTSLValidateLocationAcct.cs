//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateLocationAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateLocationAcct
	{
		int FTSLValidateLocationAcctSp(string Whse,
		                               string Loc,
		                               string Material,
		                               ref string InfoBar);
	}
	
	public class FTSLValidateLocationAcct : IFTSLValidateLocationAcct
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateLocationAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateLocationAcctSp(string Whse,
		                                      string Loc,
		                                      string Material,
		                                      ref string InfoBar)
		{
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ItemType _Material = Material;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateLocationAcctSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Material", _Material, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
