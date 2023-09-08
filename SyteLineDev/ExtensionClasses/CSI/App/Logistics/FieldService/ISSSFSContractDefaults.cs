//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContractDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContractDefaults
	{
		(int? ReturnCode, string ProductCode,
		int? ProrateLines,
		DateTime? RenewalDate,
		int? UseEndUserTypes,
		string OpenStatus,
		string CloseStatus,
		string PriceBasis,
		string ServType,
		string BillType,
		string BillFreq,
		int? AllowCustAddrOverride,
		decimal? WaiverCharge,
		string Infobar,
		string TimeZone) SSSFSContractDefaultsSp(string ProductCode,
		int? ProrateLines,
		DateTime? RenewalDate,
		int? UseEndUserTypes,
		string OpenStatus,
		string CloseStatus,
		string PriceBasis,
		string ServType,
		string BillType,
		string BillFreq,
		int? AllowCustAddrOverride,
		decimal? WaiverCharge,
		string Infobar,
		string TimeZone = null);
	}
}

