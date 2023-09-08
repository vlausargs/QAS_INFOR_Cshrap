//PROJECT NAME: Data
//CLASS NAME: TransCp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TransCp : ITransCp
	{
		readonly IApplicationDB appDB;
		
		public TransCp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string UETListPairs = null)
		{
			FlagNyType _PAdd = PAdd;
			ExchRateType _PExchRate = PExchRate;
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			FlagNyType _PTextOnly = PTextOnly;
			TrnNumType _TransferTrnNum = TransferTrnNum;
			SiteType _TransferEnteredSite = TransferEnteredSite;
			SiteType _TransferFromSite = TransferFromSite;
			WhseType _TransferFromWhse = TransferFromWhse;
			SiteType _TransferToSite = TransferToSite;
			WhseType _TransferToWhse = TransferToWhse;
			TransferStatusType _TransferStat = TransferStat;
			ShipCodeType _TransferShipCode = TransferShipCode;
			WeightType _TransferWeight = TransferWeight;
			PackagesType _TransferQtyPackages = TransferQtyPackages;
			SiteType _TransferFobSite = TransferFobSite;
			ExchRateType _TransferExchRate = TransferExchRate;
			VendNumType _TransferFreightVendor = TransferFreightVendor;
			VendNumType _TransferDutyVendor = TransferDutyVendor;
			VendNumType _TransferBrokerageVendor = TransferBrokerageVendor;
			VendNumType _TransferInsuranceVendor = TransferInsuranceVendor;
			VendNumType _TransferLocFrtVendor = TransferLocFrtVendor;
			LcAllocPercentType _TransferFrtAllocPercent = TransferFrtAllocPercent;
			LcAllocPercentType _TransferDutyAllocPercent = TransferDutyAllocPercent;
			LcAllocPercentType _TransferBrkAllocPercent = TransferBrkAllocPercent;
			LcAllocPercentType _TransferInsuranceAllocPercent = TransferInsuranceAllocPercent;
			LcAllocPercentType _TransferLocFrtAllocPercent = TransferLocFrtAllocPercent;
			LcAllocTypeType _TransferFrtAllocType = TransferFrtAllocType;
			LcAllocTypeType _TransferDutyAllocType = TransferDutyAllocType;
			LcAllocTypeType _TransferBrkAllocType = TransferBrkAllocType;
			LcAllocTypeType _TransferInsuranceAllocType = TransferInsuranceAllocType;
			LcAllocTypeType _TransferLocFrtAllocType = TransferLocFrtAllocType;
			LcAllocMethodType _TransferFrtAllocMeth = TransferFrtAllocMeth;
			LcAllocMethodType _TransferDutyAllocMeth = TransferDutyAllocMeth;
			LcAllocMethodType _TransferBrkAllocMeth = TransferBrkAllocMeth;
			LcAllocMethodType _TransferInsuranceAllocMeth = TransferInsuranceAllocMeth;
			LcAllocMethodType _TransferLocFrtAllocMeth = TransferLocFrtAllocMeth;
			TransNatType _TransferTransNat = TransferTransNat;
			DeltermType _TransferDelterm = TransferDelterm;
			ProcessIndType _TransferProcessInd = TransferProcessInd;
			AmountType _TransferEstFreightAmt = TransferEstFreightAmt;
			AmountType _TransferEstDutyAmt = TransferEstDutyAmt;
			AmountType _TransferEstBrokerageAmt = TransferEstBrokerageAmt;
			AmountType _TransferEstInsuranceAmt = TransferEstInsuranceAmt;
			AmountType _TransferEstLocFrtAmt = TransferEstLocFrtAmt;
			AmountType _TransferActFreightAmt = TransferActFreightAmt;
			AmountType _TransferActDutyAmt = TransferActDutyAmt;
			AmountType _TransferActBrokerageAmt = TransferActBrokerageAmt;
			AmountType _TransferActInsuranceAmt = TransferActInsuranceAmt;
			AmountType _TransferActLocFrtAmt = TransferActLocFrtAmt;
			AmountType _TransferFreightAmtT = TransferFreightAmtT;
			AmountType _TransferDutyAmtT = TransferDutyAmtT;
			AmountType _TransferBrokerageAmtT = TransferBrokerageAmtT;
			AmountType _TransferInsuranceAmtT = TransferInsuranceAmtT;
			AmountType _TransferLocFrtAmtT = TransferLocFrtAmtT;
			TransNat2Type _TransferTransNat2 = TransferTransNat2;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _TransferExportType = TransferExportType;
			DateType _TransferOrderDate = TransferOrderDate;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			VeryLongListType _UETListPairs = UETListPairs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransCpSp";
				
				appDB.AddCommandParameter(cmd, "PAdd", _PAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextOnly", _PTextOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferTrnNum", _TransferTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferEnteredSite", _TransferEnteredSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFromSite", _TransferFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFromWhse", _TransferFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferToSite", _TransferToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferToWhse", _TransferToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferStat", _TransferStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferShipCode", _TransferShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferWeight", _TransferWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferQtyPackages", _TransferQtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFobSite", _TransferFobSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferExchRate", _TransferExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFreightVendor", _TransferFreightVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDutyVendor", _TransferDutyVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferBrokerageVendor", _TransferBrokerageVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInsuranceVendor", _TransferInsuranceVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLocFrtVendor", _TransferLocFrtVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFrtAllocPercent", _TransferFrtAllocPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDutyAllocPercent", _TransferDutyAllocPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferBrkAllocPercent", _TransferBrkAllocPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInsuranceAllocPercent", _TransferInsuranceAllocPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLocFrtAllocPercent", _TransferLocFrtAllocPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFrtAllocType", _TransferFrtAllocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDutyAllocType", _TransferDutyAllocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferBrkAllocType", _TransferBrkAllocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInsuranceAllocType", _TransferInsuranceAllocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLocFrtAllocType", _TransferLocFrtAllocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFrtAllocMeth", _TransferFrtAllocMeth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDutyAllocMeth", _TransferDutyAllocMeth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferBrkAllocMeth", _TransferBrkAllocMeth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInsuranceAllocMeth", _TransferInsuranceAllocMeth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLocFrtAllocMeth", _TransferLocFrtAllocMeth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferTransNat", _TransferTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDelterm", _TransferDelterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferProcessInd", _TransferProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferEstFreightAmt", _TransferEstFreightAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferEstDutyAmt", _TransferEstDutyAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferEstBrokerageAmt", _TransferEstBrokerageAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferEstInsuranceAmt", _TransferEstInsuranceAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferEstLocFrtAmt", _TransferEstLocFrtAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferActFreightAmt", _TransferActFreightAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferActDutyAmt", _TransferActDutyAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferActBrokerageAmt", _TransferActBrokerageAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferActInsuranceAmt", _TransferActInsuranceAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferActLocFrtAmt", _TransferActLocFrtAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFreightAmtT", _TransferFreightAmtT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDutyAmtT", _TransferDutyAmtT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferBrokerageAmtT", _TransferBrokerageAmtT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInsuranceAmtT", _TransferInsuranceAmtT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLocFrtAmtT", _TransferLocFrtAmtT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferTransNat2", _TransferTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransferExportType", _TransferExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferOrderDate", _TransferOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
