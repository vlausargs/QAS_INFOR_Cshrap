//PROJECT NAME: CSIVendor
//CLASS NAME: AU_GetPOBlanketReleaseCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAU_GetPOBlanketReleaseCost
	{
		(int? ReturnCode, decimal? UnitMatCostConv, decimal? UnitFreightCostConv, decimal? UnitDutyCostConv, decimal? UnitBrokerageCostConv, decimal? UnitInsuranceCostConv, decimal? UnitLocFrtCostConv, decimal? ItemCostConv, string Infobar) AU_GetPOBlanketReleaseCostSp(string PoNum,
		short? PoLine,
		short? PoRelease,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		decimal? ItemCostConv,
		string Infobar,
		string AUContractPriceMethod = null,
		string ConTractID = null);
	}
	
	public class AU_GetPOBlanketReleaseCost : IAU_GetPOBlanketReleaseCost
	{
		readonly IApplicationDB appDB;
		
		public AU_GetPOBlanketReleaseCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? UnitMatCostConv, decimal? UnitFreightCostConv, decimal? UnitDutyCostConv, decimal? UnitBrokerageCostConv, decimal? UnitInsuranceCostConv, decimal? UnitLocFrtCostConv, decimal? ItemCostConv, string Infobar) AU_GetPOBlanketReleaseCostSp(string PoNum,
		short? PoLine,
		short? PoRelease,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		decimal? ItemCostConv,
		string Infobar,
		string AUContractPriceMethod = null,
		string ConTractID = null)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			CostPrcType _ItemCostConv = ItemCostConv;
			Infobar _Infobar = Infobar;
			AU_ContractPriceMethodType _AUContractPriceMethod = AUContractPriceMethod;
			AU_ContractIDType _ConTractID = ConTractID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_GetPOBlanketReleaseCostSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCostConv", _ItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AUContractPriceMethod", _AUContractPriceMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConTractID", _ConTractID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitMatCostConv = _UnitMatCostConv;
				UnitFreightCostConv = _UnitFreightCostConv;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitInsuranceCostConv = _UnitInsuranceCostConv;
				UnitLocFrtCostConv = _UnitLocFrtCostConv;
				ItemCostConv = _ItemCostConv;
				Infobar = _Infobar;
				
				return (Severity, UnitMatCostConv, UnitFreightCostConv, UnitDutyCostConv, UnitBrokerageCostConv, UnitInsuranceCostConv, UnitLocFrtCostConv, ItemCostConv, Infobar);
			}
		}
	}
}
