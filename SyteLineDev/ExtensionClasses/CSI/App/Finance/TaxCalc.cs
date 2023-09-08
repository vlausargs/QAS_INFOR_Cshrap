//PROJECT NAME: Finance
//CLASS NAME: TaxCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TaxCalc : ITaxCalc
	{
		readonly IApplicationDB appDB;
		
		public TaxCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) TaxCalcSp(
			string PInvType,
			string PTaxCode1,
			string PTaxCode2,
			decimal? PFreight,
			string PFrtTaxCode1,
			string PFrtTaxCode2,
			decimal? PMisc,
			string PMiscTaxCode1,
			string PMiscTaxCode2,
			DateTime? PInvDate,
			string PTermsCode,
			int? PUseExchRate,
			string PCurrCode,
			int? PPlaces,
			decimal? PExchRate,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar,
			string CalledFrom = null,
			Guid? tpsProcessId = null,
			string pRefType = null,
			Guid? pHdrPtr = null,
			int? LocalInit = 1,
			int? UseExtFin = null,
			int? UseExternalTaxCalc = null,
			int? EXTGEN_TaxCalcSp_Exists = null,
			int? IsTaxInterfaceAvailable = null,
			int? vrtx_parm_Exists = null,
			decimal? TaxFactor = null,
			int? CoShipmentApprovalRequired = 0,
			string Site = null,
			string DomCurrCode = null,
			int? IsJapanInterfaceAvailable = null)
		{
			DefaultCharType _PInvType = PInvType;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			AmountType _PFreight = PFreight;
			TaxCodeType _PFrtTaxCode1 = PFrtTaxCode1;
			TaxCodeType _PFrtTaxCode2 = PFrtTaxCode2;
			AmountType _PMisc = PMisc;
			TaxCodeType _PMiscTaxCode1 = PMiscTaxCode1;
			TaxCodeType _PMiscTaxCode2 = PMiscTaxCode2;
			GenericDate _PInvDate = PInvDate;
			TermsCodeType _PTermsCode = PTermsCode;
			Flag _PUseExchRate = PUseExchRate;
			CurrCodeType _PCurrCode = PCurrCode;
			GenericIntType _PPlaces = PPlaces;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PSalesTax1 = PSalesTax1;
			AmountType _PSalesTax2 = PSalesTax2;
			Infobar _Infobar = Infobar;
			InfobarType _CalledFrom = CalledFrom;
			RowPointerType _tpsProcessId = tpsProcessId;
			RefType _pRefType = pRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			ListYesNoType _LocalInit = LocalInit;
			IntType _UseExtFin = UseExtFin;
			IntType _UseExternalTaxCalc = UseExternalTaxCalc;
			ListYesNoType _EXTGEN_TaxCalcSp_Exists = EXTGEN_TaxCalcSp_Exists;
			ListYesNoType _IsTaxInterfaceAvailable = IsTaxInterfaceAvailable;
			ListYesNoType _vrtx_parm_Exists = vrtx_parm_Exists;
			ExchRateType _TaxFactor = TaxFactor;
			FlagNyType _CoShipmentApprovalRequired = CoShipmentApprovalRequired;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;
			ListYesNoType _IsJapanInterfaceAvailable = IsJapanInterfaceAvailable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxCalcSp";
				
				appDB.AddCommandParameter(cmd, "PInvType", _PInvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFrtTaxCode1", _PFrtTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFrtTaxCode2", _PFrtTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMisc", _PMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscTaxCode1", _PMiscTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscTaxCode2", _PMiscTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseExchRate", _PUseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlaces", _PPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax1", _PSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tpsProcessId", _tpsProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocalInit", _LocalInit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExtFin", _UseExtFin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExternalTaxCalc", _UseExternalTaxCalc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EXTGEN_TaxCalcSp_Exists", _EXTGEN_TaxCalcSp_Exists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsTaxInterfaceAvailable", _IsTaxInterfaceAvailable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vrtx_parm_Exists", _vrtx_parm_Exists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFactor", _TaxFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipmentApprovalRequired", _CoShipmentApprovalRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsJapanInterfaceAvailable", _IsJapanInterfaceAvailable, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax1 = _PSalesTax1;
				PSalesTax2 = _PSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, PSalesTax1, PSalesTax2, Infobar);
			}
		}
	}
}
