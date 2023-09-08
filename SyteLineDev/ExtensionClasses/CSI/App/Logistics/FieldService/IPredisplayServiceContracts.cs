//PROJECT NAME: Logistics
//CLASS NAME: IPredisplayServiceContracts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface IPredisplayServiceContracts
	{
		(int? ReturnCode, string PProductCode,
		int? PProrateLines,
		DateTime? PRenewalDate,
		int? PUseEndUserTypes,
		string POpenStatus,
		string PCloseStatus,
		string PPriceBasis,
		string PServType,
		string PBillType,
		string PBillFreq,
		int? PAllowCustAddrOverride,
		decimal? PWaiverCharge,
		string PInfobar,
		string PTimeZone,
		int? PCheckSsnEnabled) PredisplayServiceContractsSp(string PProductCode,
		int? PProrateLines,
		DateTime? PRenewalDate,
		int? PUseEndUserTypes,
		string POpenStatus,
		string PCloseStatus,
		string PPriceBasis,
		string PServType,
		string PBillType,
		string PBillFreq,
		int? PAllowCustAddrOverride,
		decimal? PWaiverCharge,
		string PInfobar,
		string PTimeZone = null,
		int? PCheckSsnEnabled = null);
	}
}

