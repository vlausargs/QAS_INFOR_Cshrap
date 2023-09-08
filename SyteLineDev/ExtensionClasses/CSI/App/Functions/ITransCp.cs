//PROJECT NAME: Data
//CLASS NAME: ITransCp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransCp
	{
		(int? ReturnCode,
			string Infobar) TransCpSp(
			int? PAdd,
			decimal? PExchRate,
			string PFromCurrCode,
			int? PTextOnly,
			string TransferTrnNum,
			string TransferEnteredSite,
			string TransferFromSite,
			string TransferFromWhse,
			string TransferToSite,
			string TransferToWhse,
			string TransferStat,
			string TransferShipCode,
			decimal? TransferWeight,
			int? TransferQtyPackages,
			string TransferFobSite,
			decimal? TransferExchRate,
			string TransferFreightVendor,
			string TransferDutyVendor,
			string TransferBrokerageVendor,
			string TransferInsuranceVendor,
			string TransferLocFrtVendor,
			decimal? TransferFrtAllocPercent,
			decimal? TransferDutyAllocPercent,
			decimal? TransferBrkAllocPercent,
			decimal? TransferInsuranceAllocPercent,
			decimal? TransferLocFrtAllocPercent,
			string TransferFrtAllocType,
			string TransferDutyAllocType,
			string TransferBrkAllocType,
			string TransferInsuranceAllocType,
			string TransferLocFrtAllocType,
			string TransferFrtAllocMeth,
			string TransferDutyAllocMeth,
			string TransferBrkAllocMeth,
			string TransferInsuranceAllocMeth,
			string TransferLocFrtAllocMeth,
			string TransferTransNat,
			string TransferDelterm,
			string TransferProcessInd,
			decimal? TransferEstFreightAmt,
			decimal? TransferEstDutyAmt,
			decimal? TransferEstBrokerageAmt,
			decimal? TransferEstInsuranceAmt,
			decimal? TransferEstLocFrtAmt,
			decimal? TransferActFreightAmt,
			decimal? TransferActDutyAmt,
			decimal? TransferActBrokerageAmt,
			decimal? TransferActInsuranceAmt,
			decimal? TransferActLocFrtAmt,
			decimal? TransferFreightAmtT,
			decimal? TransferDutyAmtT,
			decimal? TransferBrokerageAmtT,
			decimal? TransferInsuranceAmtT,
			decimal? TransferLocFrtAmtT,
			string TransferTransNat2,
			string Infobar,
			string TransferExportType,
			DateTime? TransferOrderDate,
			int? RepFromTrigger = 0,
			string RepFromSite = null,
			string UETListPairs = null);
	}
}

