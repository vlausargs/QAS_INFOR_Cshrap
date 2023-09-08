//PROJECT NAME: Logistics
//CLASS NAME: UomConvAmtQtyInvAdjs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UomConvAmtQtyInvAdjs : IUomConvAmtQtyInvAdjs
	{
		readonly IApplicationDB appDB;
		
		
		public UomConvAmtQtyInvAdjs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ConvertedAmt,
		decimal? ConvertedQty,
		string Infobar,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons) UomConvAmtQtyInvAdjsSp(decimal? AmtToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		decimal? ConvertedAmt,
		decimal? QtyToBeConverted,
		decimal? ConvertedQty,
		string Infobar,
		string PMode,
		string PRecidCo,
		decimal? PMiscCharges,
		decimal? PFreight,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons)
		{
			AmountType _AmtToBeConverted = AmtToBeConverted;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			StringType _FROMBase = FROMBase;
			AmountType _ConvertedAmt = ConvertedAmt;
			QtyUnitType _QtyToBeConverted = QtyToBeConverted;
			QtyUnitType _ConvertedQty = ConvertedQty;
			Infobar _Infobar = Infobar;
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
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UomConvAmtQtyInvAdjsSp";
				
				appDB.AddCommandParameter(cmd, "AmtToBeConverted", _AmtToBeConverted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMBase", _FROMBase, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvertedAmt", _ConvertedAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyToBeConverted", _QtyToBeConverted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvertedQty", _ConvertedQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
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
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConvertedAmt = _ConvertedAmt;
				ConvertedQty = _ConvertedQty;
				Infobar = _Infobar;
				PSalesTax = _PSalesTax;
				PSalesTax2 = _PSalesTax2;
				PLineNet = _PLineNet;
				PPrice = _PPrice;
				PSeq = _PSeq;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, ConvertedAmt, ConvertedQty, Infobar, PSalesTax, PSalesTax2, PLineNet, PPrice, PSeq, PromptMsg, PromptButtons);
			}
		}
	}
}
