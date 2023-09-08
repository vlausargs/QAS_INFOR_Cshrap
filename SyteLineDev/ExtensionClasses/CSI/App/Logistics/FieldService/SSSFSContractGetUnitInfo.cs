//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractGetUnitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractGetUnitInfo : ISSSFSContractGetUnitInfo
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSContractGetUnitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? UnitExists,
		int? ItemExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string Item,
		string Description,
		string ItemUM,
		decimal? ContBasisConv,
		int? CurrentMeterAmt,
		int? StartMeterAmt,
		int? BilledThruMeterAmt,
		decimal? Rate,
		string UnitOfRate,
		decimal? MeterRate,
		int? MeterAllow,
		decimal? ProrateRate,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		DateTime? DueDate,
		DateTime? MinBillThru,
		int? InclWaiverCharge,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string PromptMsgSerContLine,
		string Infobar) SSSFSContractGetUnitInfoSp(string Contract,
		string SerNum,
		string ContPriceBasis = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? UnitOfRateLookup = 1,
		int? UnitExists = 0,
		int? ItemExists = 0,
		string UnitCustNum = null,
		int? UnitCustSeq = 0,
		string Item = null,
		string Description = null,
		string ItemUM = null,
		decimal? ContBasisConv = null,
		int? CurrentMeterAmt = null,
		int? StartMeterAmt = null,
		int? BilledThruMeterAmt = null,
		decimal? Rate = 0,
		string UnitOfRate = null,
		decimal? MeterRate = null,
		int? MeterAllow = null,
		decimal? ProrateRate = null,
		string TaxCode1 = null,
		string TaxCode1Desc = null,
		string TaxCode2 = null,
		string TaxCode2Desc = null,
		DateTime? DueDate = null,
		DateTime? MinBillThru = null,
		int? InclWaiverCharge = 0,
		string PromptMsgBadCust = null,
		string PromptMsgNoUnit = null,
		string PromptMsgSerContLine = null,
		string Infobar = null)
		{
			FSContractType _Contract = Contract;
			SerNumType _SerNum = SerNum;
			FSContPriceBasisType _ContPriceBasis = ContPriceBasis;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			ListYesNoType _UnitOfRateLookup = UnitOfRateLookup;
			ListYesNoType _UnitExists = UnitExists;
			ListYesNoType _ItemExists = ItemExists;
			CustNumType _UnitCustNum = UnitCustNum;
			CustSeqType _UnitCustSeq = UnitCustSeq;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UMType _ItemUM = ItemUM;
			CostPrcType _ContBasisConv = ContBasisConv;
			FSMeterAmtType _CurrentMeterAmt = CurrentMeterAmt;
			FSMeterAmtType _StartMeterAmt = StartMeterAmt;
			FSMeterAmtType _BilledThruMeterAmt = BilledThruMeterAmt;
			CostPrcType _Rate = Rate;
			FSContUnitOfRateType _UnitOfRate = UnitOfRate;
			CostPrcType _MeterRate = MeterRate;
			FSMeterAmtType _MeterAllow = MeterAllow;
			CostPrcType _ProrateRate = ProrateRate;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			DateTimeType _DueDate = DueDate;
			DateType _MinBillThru = MinBillThru;
			ListYesNoType _InclWaiverCharge = InclWaiverCharge;
			Infobar _PromptMsgBadCust = PromptMsgBadCust;
			Infobar _PromptMsgNoUnit = PromptMsgNoUnit;
			Infobar _PromptMsgSerContLine = PromptMsgSerContLine;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContractGetUnitInfoSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContPriceBasis", _ContPriceBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfRateLookup", _UnitOfRateLookup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitExists", _UnitExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustNum", _UnitCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustSeq", _UnitCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContBasisConv", _ContBasisConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrentMeterAmt", _CurrentMeterAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartMeterAmt", _StartMeterAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BilledThruMeterAmt", _BilledThruMeterAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rate", _Rate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitOfRate", _UnitOfRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MeterRate", _MeterRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MeterAllow", _MeterAllow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProrateRate", _ProrateRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MinBillThru", _MinBillThru, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InclWaiverCharge", _InclWaiverCharge, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgBadCust", _PromptMsgBadCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNoUnit", _PromptMsgNoUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgSerContLine", _PromptMsgSerContLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitExists = _UnitExists;
				ItemExists = _ItemExists;
				UnitCustNum = _UnitCustNum;
				UnitCustSeq = _UnitCustSeq;
				Item = _Item;
				Description = _Description;
				ItemUM = _ItemUM;
				ContBasisConv = _ContBasisConv;
				CurrentMeterAmt = _CurrentMeterAmt;
				StartMeterAmt = _StartMeterAmt;
				BilledThruMeterAmt = _BilledThruMeterAmt;
				Rate = _Rate;
				UnitOfRate = _UnitOfRate;
				MeterRate = _MeterRate;
				MeterAllow = _MeterAllow;
				ProrateRate = _ProrateRate;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				DueDate = _DueDate;
				MinBillThru = _MinBillThru;
				InclWaiverCharge = _InclWaiverCharge;
				PromptMsgBadCust = _PromptMsgBadCust;
				PromptMsgNoUnit = _PromptMsgNoUnit;
				PromptMsgSerContLine = _PromptMsgSerContLine;
				Infobar = _Infobar;
				
				return (Severity, UnitExists, ItemExists, UnitCustNum, UnitCustSeq, Item, Description, ItemUM, ContBasisConv, CurrentMeterAmt, StartMeterAmt, BilledThruMeterAmt, Rate, UnitOfRate, MeterRate, MeterAllow, ProrateRate, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, DueDate, MinBillThru, InclWaiverCharge, PromptMsgBadCust, PromptMsgNoUnit, PromptMsgSerContLine, Infobar);
			}
		}
	}
}
