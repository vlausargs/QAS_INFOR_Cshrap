//PROJECT NAME: CSICodes
//CLASS NAME: PortalEstimateToHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPortalEstimateToHistory
	{
		int PortalEstimateToHistorySp(string CoNum,
		                              string pCpFOrdType,
		                              ref string Infobar);
	}
	
	public class PortalEstimateToHistory : IPortalEstimateToHistory
	{
		readonly IApplicationDB appDB;
		
		public PortalEstimateToHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalEstimateToHistorySp(string CoNum,
		                                     string pCpFOrdType,
		                                     ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoTypeType _pCpFOrdType = pCpFOrdType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalEstimateToHistorySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCpFOrdType", _pCpFOrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
