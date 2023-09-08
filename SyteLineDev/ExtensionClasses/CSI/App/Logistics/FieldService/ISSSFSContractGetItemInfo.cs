//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContractGetItemInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContractGetItemInfo
	{
		(int? ReturnCode, int? SerialTracked,
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
		int? IsOpenNonInvForm = 0);
	}
}

