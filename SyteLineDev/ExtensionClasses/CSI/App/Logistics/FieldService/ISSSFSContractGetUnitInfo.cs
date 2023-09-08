//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContractGetUnitInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContractGetUnitInfo
	{
		(int? ReturnCode, int? UnitExists,
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
		string Infobar = null);
	}
}

