//PROJECT NAME: CSIVendor
//CLASS NAME: ValidatePoVendNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePoVendNum
	{
		int ValidatePoVendNumSp(byte? PNew,
		                        string PVendNum,
		                        string PPrevVendNum,
		                        string PPo,
		                        DateTime? OrdDate,
		                        ref string CurrencyCode,
		                        ref string Whse,
		                        ref string WhseDesc,
		                        ref string Terms,
		                        ref string TermsDesc,
		                        ref string ShipCode,
		                        ref string ShipCodeDesc,
		                        ref string Category,
		                        ref string CategoryDesc,
		                        ref string Fob,
		                        ref byte? PrintPrice,
		                        ref string LongAddress,
		                        ref byte? FixedEuro,
		                        ref decimal? TRate,
		                        ref string TaxCode1,
		                        ref string TaxCode1Desc,
		                        ref string TaxCode2,
		                        ref string TaxCode2Desc,
		                        ref string TransNat,
		                        ref string TransNatDesc,
		                        ref string TransNat2,
		                        ref string TransNat2Desc,
		                        ref string Delterm,
		                        ref string DeltermDesc,
		                        ref string ProcessInd,
		                        ref string Infobar,
		                        ref string VendType,
		                        ref string VendContact,
		                        ref string VendPhone,
		                        ref byte? VendLcrReq,
		                        ref string CurrAmtFormat,
		                        ref string CurrAmtTotFormat,
		                        ref string CurrCstPrcFormat,
		                        ref string VendorName,
		                        ref string VendCountry,
		                        ref string VendFax,
		                        ref string VendTelex,
		                        ref byte? AutoVoucher,
		                        ref byte? PoAutoReceiveDemandingSitePo,
		                        ref byte? PoAutoShipDemandingSiteCo,
		                        ref string PoAutoShipSourceSite,
		                        ref byte? IncludeTaxInCost);
	}
	
	public class ValidatePoVendNum : IValidatePoVendNum
	{
		readonly IApplicationDB appDB;
		
		public ValidatePoVendNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidatePoVendNumSp(byte? PNew,
		                               string PVendNum,
		                               string PPrevVendNum,
		                               string PPo,
		                               DateTime? OrdDate,
		                               ref string CurrencyCode,
		                               ref string Whse,
		                               ref string WhseDesc,
		                               ref string Terms,
		                               ref string TermsDesc,
		                               ref string ShipCode,
		                               ref string ShipCodeDesc,
		                               ref string Category,
		                               ref string CategoryDesc,
		                               ref string Fob,
		                               ref byte? PrintPrice,
		                               ref string LongAddress,
		                               ref byte? FixedEuro,
		                               ref decimal? TRate,
		                               ref string TaxCode1,
		                               ref string TaxCode1Desc,
		                               ref string TaxCode2,
		                               ref string TaxCode2Desc,
		                               ref string TransNat,
		                               ref string TransNatDesc,
		                               ref string TransNat2,
		                               ref string TransNat2Desc,
		                               ref string Delterm,
		                               ref string DeltermDesc,
		                               ref string ProcessInd,
		                               ref string Infobar,
		                               ref string VendType,
		                               ref string VendContact,
		                               ref string VendPhone,
		                               ref byte? VendLcrReq,
		                               ref string CurrAmtFormat,
		                               ref string CurrAmtTotFormat,
		                               ref string CurrCstPrcFormat,
		                               ref string VendorName,
		                               ref string VendCountry,
		                               ref string VendFax,
		                               ref string VendTelex,
		                               ref byte? AutoVoucher,
		                               ref byte? PoAutoReceiveDemandingSitePo,
		                               ref byte? PoAutoShipDemandingSiteCo,
		                               ref string PoAutoShipSourceSite,
		                               ref byte? IncludeTaxInCost)
		{
			Flag _PNew = PNew;
			VendNumType _PVendNum = PVendNum;
			VendNumType _PPrevVendNum = PPrevVendNum;
			PoNumType _PPo = PPo;
			DateType _OrdDate = OrdDate;
			CurrCodeType _CurrencyCode = CurrencyCode;
			WhseType _Whse = Whse;
			NameType _WhseDesc = WhseDesc;
			TermsCodeType _Terms = Terms;
			NameType _TermsDesc = TermsDesc;
			ShipCodeType _ShipCode = ShipCode;
			NameType _ShipCodeDesc = ShipCodeDesc;
			CategoryType _Category = Category;
			NameType _CategoryDesc = CategoryDesc;
			FOBType _Fob = Fob;
			ListYesNoType _PrintPrice = PrintPrice;
			LongAddress _LongAddress = LongAddress;
			Flag _FixedEuro = FixedEuro;
			ExchRateType _TRate = TRate;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			TransNatType _TransNat = TransNat;
			DescriptionType _TransNatDesc = TransNatDesc;
			TransNat2Type _TransNat2 = TransNat2;
			DescriptionType _TransNat2Desc = TransNat2Desc;
			DeltermType _Delterm = Delterm;
			DescriptionType _DeltermDesc = DeltermDesc;
			ProcessIndType _ProcessInd = ProcessInd;
			InfobarType _Infobar = Infobar;
			VendTypeType _VendType = VendType;
			ContactType _VendContact = VendContact;
			PhoneType _VendPhone = VendPhone;
			ListYesNoType _VendLcrReq = VendLcrReq;
			InputMaskType _CurrAmtFormat = CurrAmtFormat;
			InputMaskType _CurrAmtTotFormat = CurrAmtTotFormat;
			InputMaskType _CurrCstPrcFormat = CurrCstPrcFormat;
			NameType _VendorName = VendorName;
			CountryType _VendCountry = VendCountry;
			PhoneType _VendFax = VendFax;
			PhoneType _VendTelex = VendTelex;
			ListYesNoType _AutoVoucher = AutoVoucher;
			ListYesNoType _PoAutoReceiveDemandingSitePo = PoAutoReceiveDemandingSitePo;
			ListYesNoType _PoAutoShipDemandingSiteCo = PoAutoShipDemandingSiteCo;
			SiteType _PoAutoShipSourceSite = PoAutoShipSourceSite;
			ListYesNoType _IncludeTaxInCost = IncludeTaxInCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePoVendNumSp";
				
				appDB.AddCommandParameter(cmd, "PNew", _PNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrevVendNum", _PPrevVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPo", _PPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdDate", _OrdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyCode", _CurrencyCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WhseDesc", _WhseDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Terms", _Terms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsDesc", _TermsDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCodeDesc", _ShipCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CategoryDesc", _CategoryDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Fob", _Fob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LongAddress", _LongAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixedEuro", _FixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRate", _TRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNatDesc", _TransNatDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2Desc", _TransNat2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeltermDesc", _DeltermDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendType", _VendType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendContact", _VendContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendPhone", _VendPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendLcrReq", _VendLcrReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrAmtFormat", _CurrAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrAmtTotFormat", _CurrAmtTotFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", _CurrCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendorName", _VendorName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendCountry", _VendCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendFax", _VendFax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendTelex", _VendTelex, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoVoucher", _AutoVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoAutoReceiveDemandingSitePo", _PoAutoReceiveDemandingSitePo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoAutoShipDemandingSiteCo", _PoAutoShipDemandingSiteCo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoAutoShipSourceSite", _PoAutoShipSourceSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeTaxInCost", _IncludeTaxInCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrencyCode = _CurrencyCode;
				Whse = _Whse;
				WhseDesc = _WhseDesc;
				Terms = _Terms;
				TermsDesc = _TermsDesc;
				ShipCode = _ShipCode;
				ShipCodeDesc = _ShipCodeDesc;
				Category = _Category;
				CategoryDesc = _CategoryDesc;
				Fob = _Fob;
				PrintPrice = _PrintPrice;
				LongAddress = _LongAddress;
				FixedEuro = _FixedEuro;
				TRate = _TRate;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				TransNat = _TransNat;
				TransNatDesc = _TransNatDesc;
				TransNat2 = _TransNat2;
				TransNat2Desc = _TransNat2Desc;
				Delterm = _Delterm;
				DeltermDesc = _DeltermDesc;
				ProcessInd = _ProcessInd;
				Infobar = _Infobar;
				VendType = _VendType;
				VendContact = _VendContact;
				VendPhone = _VendPhone;
				VendLcrReq = _VendLcrReq;
				CurrAmtFormat = _CurrAmtFormat;
				CurrAmtTotFormat = _CurrAmtTotFormat;
				CurrCstPrcFormat = _CurrCstPrcFormat;
				VendorName = _VendorName;
				VendCountry = _VendCountry;
				VendFax = _VendFax;
				VendTelex = _VendTelex;
				AutoVoucher = _AutoVoucher;
				PoAutoReceiveDemandingSitePo = _PoAutoReceiveDemandingSitePo;
				PoAutoShipDemandingSiteCo = _PoAutoShipDemandingSiteCo;
				PoAutoShipSourceSite = _PoAutoShipSourceSite;
				IncludeTaxInCost = _IncludeTaxInCost;
				
				return Severity;
			}
		}
	}
}
