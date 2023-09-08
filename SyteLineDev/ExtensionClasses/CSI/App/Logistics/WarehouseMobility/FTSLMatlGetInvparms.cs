//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLMatlGetInvparms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLMatlGetInvparms
	{
		int FTSLMatlGetInvparmsSp(ref string DefWhse,
		                          ref byte? NegFlag,
		                          ref string Infobar);
	}
	
	public class FTSLMatlGetInvparms : IFTSLMatlGetInvparms
	{
		readonly IApplicationDB appDB;
		
		public FTSLMatlGetInvparms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLMatlGetInvparmsSp(ref string DefWhse,
		                                 ref byte? NegFlag,
		                                 ref string Infobar)
		{
			WhseType _DefWhse = DefWhse;
			ListYesNoType _NegFlag = NegFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLMatlGetInvparmsSp";
				
				appDB.AddCommandParameter(cmd, "DefWhse", _DefWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NegFlag", _NegFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DefWhse = _DefWhse;
				NegFlag = _NegFlag;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
