//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractGetItemInfo : ISSSFSContractGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSContractGetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SerialTracked,
		string UnitOfRate,
		string Description,
		string ItemUM,
		int? ItemExists,
		decimal? Rate,
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
		string ContPriceBasis,
		string PromptMsgNI,
		string Infobar,
		int? IsOpenNonInvForm) SSSFSContractGetItemInfoSp(string Contract,
		string Item,
		DateTime? StartDate = null,
		int? UnitOfRateLookup = 1,
		int? SerialTracked = null,
		string UnitOfRate = null,
		string Description = null,
		string ItemUM = null,
		int? ItemExists = 0,
		decimal? Rate = null,
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
		string ContPriceBasis = null,
		string PromptMsgNI = null,
		string SerNum = null,
		string Infobar = null,
		int? IsOpenNonInvForm = 0)
		{
			FSContractType _Contract = Contract;
			ItemType _Item = Item;
			DateTimeType _StartDate = StartDate;
			ListYesNoType _UnitOfRateLookup = UnitOfRateLookup;
			ListYesNoType _SerialTracked = SerialTracked;
			FSContUnitOfRateType _UnitOfRate = UnitOfRate;
			DescriptionType _Description = Description;
			UMType _ItemUM = ItemUM;
			ListYesNoType _ItemExists = ItemExists;
			CostPrcType _Rate = Rate;
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
			FSContPriceBasisType _ContPriceBasis = ContPriceBasis;
			Infobar _PromptMsgNI = PromptMsgNI;
			SerNumType _SerNum = SerNum;
			Infobar _Infobar = Infobar;
			ListYesNoType _IsOpenNonInvForm = IsOpenNonInvForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContractGetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfRateLookup", _UnitOfRateLookup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitOfRate", _UnitOfRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rate", _Rate, ParameterDirection.InputOutput);
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
				appDB.AddCommandParameter(cmd, "ContPriceBasis", _ContPriceBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNI", _PromptMsgNI, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsOpenNonInvForm", _IsOpenNonInvForm, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerialTracked = _SerialTracked;
				UnitOfRate = _UnitOfRate;
				Description = _Description;
				ItemUM = _ItemUM;
				ItemExists = _ItemExists;
				Rate = _Rate;
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
				ContPriceBasis = _ContPriceBasis;
				PromptMsgNI = _PromptMsgNI;
				Infobar = _Infobar;
				IsOpenNonInvForm = _IsOpenNonInvForm;
				
				return (Severity, SerialTracked, UnitOfRate, Description, ItemUM, ItemExists, Rate, MeterRate, MeterAllow, ProrateRate, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, DueDate, MinBillThru, InclWaiverCharge, ContPriceBasis, PromptMsgNI, Infobar, IsOpenNonInvForm);
			}
		}
	}
}
