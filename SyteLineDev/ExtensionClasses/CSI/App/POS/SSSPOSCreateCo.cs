//PROJECT NAME: POS
//CLASS NAME: SSSPOSCreateCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCreateCo : ISSSPOSCreateCo
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCreateCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TCoNum,
			string Infobar) SSSPOSCreateCoSp(
			string POSNum,
			string POSMTermsCode,
			string CurUserCode,
			string ParmSite,
			string POSMCustNum,
			int? POSMCustSeq,
			decimal? POSMDisc,
			string POSMCustPo,
			Guid? POSMRowPointer,
			string POSMTaxCode1,
			string POSMTaxCode2,
			string POSMShipCode,
			decimal? POSMSalesTax,
			decimal? POSMSalesTax2,
			string POSMFrtTaxCode1,
			string POSMFrtTaxCode2,
			string POSMMscTaxCode1,
			string POSMMscTaxCode2,
			decimal? POSMFreight,
			decimal? POSMMiscCharges,
			string POSMContact,
			string POSMPhone,
			string POSMWhse,
			string POSMSlsman,
			string POSMEndUserType,
			string TCoNum,
			string Infobar)
		{
			POSMNumType _POSNum = POSNum;
			TermsCodeType _POSMTermsCode = POSMTermsCode;
			UserCodeType _CurUserCode = CurUserCode;
			SiteType _ParmSite = ParmSite;
			CustNumType _POSMCustNum = POSMCustNum;
			CustSeqType _POSMCustSeq = POSMCustSeq;
			FSPctType _POSMDisc = POSMDisc;
			CustPoType _POSMCustPo = POSMCustPo;
			RowPointerType _POSMRowPointer = POSMRowPointer;
			TaxCodeType _POSMTaxCode1 = POSMTaxCode1;
			TaxCodeType _POSMTaxCode2 = POSMTaxCode2;
			ShipCodeType _POSMShipCode = POSMShipCode;
			AmountType _POSMSalesTax = POSMSalesTax;
			AmountType _POSMSalesTax2 = POSMSalesTax2;
			TaxCodeType _POSMFrtTaxCode1 = POSMFrtTaxCode1;
			TaxCodeType _POSMFrtTaxCode2 = POSMFrtTaxCode2;
			TaxCodeType _POSMMscTaxCode1 = POSMMscTaxCode1;
			TaxCodeType _POSMMscTaxCode2 = POSMMscTaxCode2;
			AmountType _POSMFreight = POSMFreight;
			AmountType _POSMMiscCharges = POSMMiscCharges;
			ContactType _POSMContact = POSMContact;
			PhoneType _POSMPhone = POSMPhone;
			WhseType _POSMWhse = POSMWhse;
			SlsmanType _POSMSlsman = POSMSlsman;
			EndUserTypeType _POSMEndUserType = POSMEndUserType;
			CoNumType _TCoNum = TCoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCreateCoSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTermsCode", _POSMTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustNum", _POSMCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustSeq", _POSMCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMDisc", _POSMDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustPo", _POSMCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMRowPointer", _POSMRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTaxCode1", _POSMTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTaxCode2", _POSMTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMShipCode", _POSMShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSalesTax", _POSMSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSalesTax2", _POSMSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMFrtTaxCode1", _POSMFrtTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMFrtTaxCode2", _POSMFrtTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMscTaxCode1", _POSMMscTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMscTaxCode2", _POSMMscTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMFreight", _POSMFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMiscCharges", _POSMMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMContact", _POSMContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMPhone", _POSMPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMWhse", _POSMWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSlsman", _POSMSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMEndUserType", _POSMEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoNum", _TCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TCoNum = _TCoNum;
				Infobar = _Infobar;
				
				return (Severity, TCoNum, Infobar);
			}
		}
	}
}
