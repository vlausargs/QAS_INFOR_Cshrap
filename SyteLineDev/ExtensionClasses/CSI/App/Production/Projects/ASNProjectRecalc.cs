//PROJECT NAME: CSIProjects
//CLASS NAME: ASNProjectRecalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IASNProjectRecalc
	{
		int ASNProjectRecalcSp(string ProjNum,
		                       string BolNum,
		                       ref decimal? NewFreightCharges,
		                       ref decimal? NewCodAmount,
		                       ref decimal? NewTotalCharges,
		                       ref string PromptMsg,
		                       ref string PromptButtons);
	}
	
	public class ASNProjectRecalc : IASNProjectRecalc
	{
		readonly IApplicationDB appDB;
		
		public ASNProjectRecalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ASNProjectRecalcSp(string ProjNum,
		                              string BolNum,
		                              ref decimal? NewFreightCharges,
		                              ref decimal? NewCodAmount,
		                              ref decimal? NewTotalCharges,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			ProjNumType _ProjNum = ProjNum;
			BolNumType _BolNum = BolNum;
			AmountType _NewFreightCharges = NewFreightCharges;
			AmountType _NewCodAmount = NewCodAmount;
			AmountType _NewTotalCharges = NewTotalCharges;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ASNProjectRecalcSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BolNum", _BolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewFreightCharges", _NewFreightCharges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewCodAmount", _NewCodAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewTotalCharges", _NewTotalCharges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewFreightCharges = _NewFreightCharges;
				NewCodAmount = _NewCodAmount;
				NewTotalCharges = _NewTotalCharges;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return Severity;
			}
		}
	}
}
