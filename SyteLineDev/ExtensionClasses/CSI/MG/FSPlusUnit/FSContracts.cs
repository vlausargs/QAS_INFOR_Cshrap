//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSContracts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSContracts")]
	public class FSContracts : ExtensionClassBase
	{

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSContractValidCustSp(string CustNum,
        ref int? CustSeq,
        string Level,
        ref string BillToAddr,
        ref string ShipToAddr,
        ref string ShipToName,
        ref string ShipToAddr1,
        ref string ShipToAddr2,
        ref string ShipToAddr3,
        ref string ShipToAddr4,
        ref string ShipToCity,
        ref string ShipToState,
        ref string ShipToZip,
        ref string ShipToCounty,
        ref string ShipToCountry,
        ref string EndUserType,
        ref string TermsCode,
        ref string TermsCodeDesc,
        ref string Slsman,
        ref string CurrCode,
        ref byte? FixedEuro,
        ref byte? CreditHold,
        ref string TaxCode1,
        ref string TaxCode1Desc,
        ref string TaxCode2,
        ref string TaxCode2Desc,
        ref string Infobar,
        ref string CurAmtFormat,
        ref string CurCstPrcFormat,
        [Optional] ref string PriorCode,
        ref string ShipToStateCode,
        ref string ShipToStateDesc)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSContractValidCustExt = new SSSFSContractValidCustFactory().Create(appDb);

                var result = iSSSFSContractValidCustExt.SSSFSContractValidCustSp(CustNum,
                CustSeq,
                Level,
                BillToAddr,
                ShipToAddr,
                ShipToName,
                ShipToAddr1,
                ShipToAddr2,
                ShipToAddr3,
                ShipToAddr4,
                ShipToCity,
                ShipToState,
                ShipToZip,
                ShipToCounty,
                ShipToCountry,
                EndUserType,
                TermsCode,
                TermsCodeDesc,
                Slsman,
                CurrCode,
                FixedEuro,
                CreditHold,
                TaxCode1,
                TaxCode1Desc,
                TaxCode2,
                TaxCode2Desc,
                Infobar,
                CurAmtFormat,
                CurCstPrcFormat,
                PriorCode,
                ShipToStateCode,
                ShipToStateDesc);

                int Severity = result.ReturnCode.Value;
                CustSeq = result.CustSeq;
                BillToAddr = result.BillToAddr;
                ShipToAddr = result.ShipToAddr;
                ShipToName = result.ShipToName;
                ShipToAddr1 = result.ShipToAddr1;
                ShipToAddr2 = result.ShipToAddr2;
                ShipToAddr3 = result.ShipToAddr3;
                ShipToAddr4 = result.ShipToAddr4;
                ShipToCity = result.ShipToCity;
                ShipToState = result.ShipToState;
                ShipToZip = result.ShipToZip;
                ShipToCounty = result.ShipToCounty;
                ShipToCountry = result.ShipToCountry;
                EndUserType = result.EndUserType;
                TermsCode = result.TermsCode;
                TermsCodeDesc = result.TermsCodeDesc;
                Slsman = result.Slsman;
                CurrCode = result.CurrCode;
                FixedEuro = result.FixedEuro;
                CreditHold = result.CreditHold;
                TaxCode1 = result.TaxCode1;
                TaxCode1Desc = result.TaxCode1Desc;
                TaxCode2 = result.TaxCode2;
                TaxCode2Desc = result.TaxCode2Desc;
                Infobar = result.Infobar;
                CurAmtFormat = result.CurAmtFormat;
                CurCstPrcFormat = result.CurCstPrcFormat;
                PriorCode = result.PriorCode;
                ShipToStateCode = result.ShipToStateCode;
                ShipToStateDesc = result.ShipToStateDesc;
                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContractDefaultsSp(ref string ProductCode,
		ref int? ProrateLines,
		ref DateTime? RenewalDate,
		ref int? UseEndUserTypes,
		ref string OpenStatus,
		ref string CloseStatus,
		ref string PriceBasis,
		ref string ServType,
		ref string BillType,
		ref string BillFreq,
		ref int? AllowCustAddrOverride,
		ref decimal? WaiverCharge,
		ref string Infobar,
		[Optional] ref string TimeZone)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContractDefaultsExt = new SSSFSContractDefaultsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContractDefaultsExt.SSSFSContractDefaultsSp(ProductCode,
				ProrateLines,
				RenewalDate,
				UseEndUserTypes,
				OpenStatus,
				CloseStatus,
				PriceBasis,
				ServType,
				BillType,
				BillFreq,
				AllowCustAddrOverride,
				WaiverCharge,
				Infobar,
				TimeZone);
				
				int Severity = result.ReturnCode.Value;
				ProductCode = result.ProductCode;
				ProrateLines = result.ProrateLines;
				RenewalDate = result.RenewalDate;
				UseEndUserTypes = result.UseEndUserTypes;
				OpenStatus = result.OpenStatus;
				CloseStatus = result.CloseStatus;
				PriceBasis = result.PriceBasis;
				ServType = result.ServType;
				BillType = result.BillType;
				BillFreq = result.BillFreq;
				AllowCustAddrOverride = result.AllowCustAddrOverride;
				WaiverCharge = result.WaiverCharge;
				Infobar = result.Infobar;
				TimeZone = result.TimeZone;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PredisplayServiceContractsSp(ref string PProductCode,
		ref int? PProrateLines,
		ref DateTime? PRenewalDate,
		ref int? PUseEndUserTypes,
		ref string POpenStatus,
		ref string PCloseStatus,
		ref string PPriceBasis,
		ref string PServType,
		ref string PBillType,
		ref string PBillFreq,
		ref int? PAllowCustAddrOverride,
		ref decimal? PWaiverCharge,
		ref string PInfobar,
		[Optional] ref string PTimeZone,
		ref int? PCheckSsnEnabled)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPredisplayServiceContractsExt = new PredisplayServiceContractsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPredisplayServiceContractsExt.PredisplayServiceContractsSp(PProductCode,
				PProrateLines,
				PRenewalDate,
				PUseEndUserTypes,
				POpenStatus,
				PCloseStatus,
				PPriceBasis,
				PServType,
				PBillType,
				PBillFreq,
				PAllowCustAddrOverride,
				PWaiverCharge,
				PInfobar,
				PTimeZone,
				PCheckSsnEnabled);
				
				int Severity = result.ReturnCode.Value;
				PProductCode = result.PProductCode;
				PProrateLines = result.PProrateLines;
				PRenewalDate = result.PRenewalDate;
				PUseEndUserTypes = result.PUseEndUserTypes;
				POpenStatus = result.POpenStatus;
				PCloseStatus = result.PCloseStatus;
				PPriceBasis = result.PPriceBasis;
				PServType = result.PServType;
				PBillType = result.PBillType;
				PBillFreq = result.PBillFreq;
				PAllowCustAddrOverride = result.PAllowCustAddrOverride;
				PWaiverCharge = result.PWaiverCharge;
				PInfobar = result.PInfobar;
				PTimeZone = result.PTimeZone;
				PCheckSsnEnabled = result.PCheckSsnEnabled;
				return Severity;
			}
		}
    }
}
