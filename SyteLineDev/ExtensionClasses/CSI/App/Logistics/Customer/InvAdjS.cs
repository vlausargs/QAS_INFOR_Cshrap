//PROJECT NAME: Logistics
//CLASS NAME: InvAdjS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvAdjS : IInvAdjS
	{
		readonly IApplicationDB appDB;
		
		
		public InvAdjS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons,
		string InfoBar) InvAdjSSp(string PMode,
		string PRecidCo,
		decimal? PMiscCharges,
		decimal? PFreight,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons,
		string InfoBar)
		{
			StringType _PMode = PMode;
			CoNumType _PRecidCo = PRecidCo;
			CostPrcType _PMiscCharges = PMiscCharges;
			CostPrcType _PFreight = PFreight;
			CostPrcType _PSalesTax = PSalesTax;
			CostPrcType _PSalesTax2 = PSalesTax2;
			CostPrcType _PLineNet = PLineNet;
			CostPrcType _PPrice = PPrice;
			ArDistSeqType _PSeq = PSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvAdjSSp";
				
				appDB.AddCommandParameter(cmd, "PMode", _PMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecidCo", _PRecidCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLineNet", _PLineNet, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrice", _PPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax = _PSalesTax;
				PSalesTax2 = _PSalesTax2;
				PLineNet = _PLineNet;
				PPrice = _PPrice;
				PSeq = _PSeq;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				InfoBar = _InfoBar;
				
				return (Severity, PSalesTax, PSalesTax2, PLineNet, PPrice, PSeq, PromptMsg, PromptButtons, InfoBar);
			}
		}
	}
}
