//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidInvContOptAllowNew.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidInvContOptAllowNew
	{
		int FTSLValidInvContOptAllowNewSp(string Location,
		                                  string Container,
		                                  ref string Infobar);
	}
	
	public class FTSLValidInvContOptAllowNew : IFTSLValidInvContOptAllowNew
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidInvContOptAllowNew(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidInvContOptAllowNewSp(string Location,
		                                         string Container,
		                                         ref string Infobar)
		{
			LocType _Location = Location;
			ContainerNumType _Container = Container;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidInvContOptAllowNewSp";
				
				appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Container", _Container, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
