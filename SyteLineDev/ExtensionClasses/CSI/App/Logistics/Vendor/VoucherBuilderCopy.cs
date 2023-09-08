//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderCopy : IVoucherBuilderCopy
	{
		readonly IApplicationDB appDB;
		
		public VoucherBuilderCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) VoucherBuilderCopySp(
			Guid? PProcessId,
			string PToSite,
			string PVBOrigSite = null,
			string PBuilderVoucher = null,
			int? PSelected = null,
			string PVendNum = null,
			string PCurrCode = null,
			string PType = null,
			string PSite = null,
			int? PVoucher = null,
			DateTime? PDistDate = null,
			string PInvNum = null,
			DateTime? PInvDate = null,
			string PTermsCode = null,
			string PAuthorizer = null,
			int? PFixedRate = null,
			decimal? PExchRate = null,
			int? PITaxInCost = null,
			string PBPoOrigSite = null,
			string PBPoNum = null,
			string PPoNum = null,
			int? PPoLine = null,
			int? PPoRelease = null,
			string PItem = null,
			string PItemDesc = null,
			string PVendItem = null,
			decimal? PQtyRcvd = null,
			decimal? PQtyVoucher = null,
			decimal? POrigQtyVoucher = null,
			string PUm = null,
			decimal? PUnitMatCostConv = null,
			decimal? PPlanCostConv = null,
			decimal? PFreight = null,
			decimal? PMiscCharges = null,
			string PTransNat = null,
			string PTransNat2 = null,
			string PPoTaxCode1 = null,
			string PPoTaxCode2 = null,
			string PPoITaxCode1 = null,
			string PPoITaxCode2 = null,
			string PFrtTaxCode1 = null,
			string PFrtTaxCode2 = null,
			string PMscTaxCode1 = null,
			string PMscTaxCode2 = null,
			DateTime? PPoRecDate = null,
			int? PReadOnly = null,
			decimal? PSalesTax = null,
			decimal? PSalesTax2 = null,
			int? TaxSystem1Enabled = null,
			int? TaxSystem2Enabled = null,
			int? ActiveForPurch1 = null,
			int? ActiveForPurch2 = null,
			string Infobar = null)
		{
			RowPointerType _PProcessId = PProcessId;
			SiteType _PToSite = PToSite;
			SiteType _PVBOrigSite = PVBOrigSite;
			BuilderVoucherType _PBuilderVoucher = PBuilderVoucher;
			ListYesNoType _PSelected = PSelected;
			VendNumType _PVendNum = PVendNum;
			CurrCodeType _PCurrCode = PCurrCode;
			AptrxTypeType _PType = PType;
			SiteType _PSite = PSite;
			VoucherType _PVoucher = PVoucher;
			DateType _PDistDate = PDistDate;
			VendInvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			TermsCodeType _PTermsCode = PTermsCode;
			UsernameType _PAuthorizer = PAuthorizer;
			ListYesNoType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			ListYesNoType _PITaxInCost = PITaxInCost;
			SiteType _PBPoOrigSite = PBPoOrigSite;
			BuilderPoNumType _PBPoNum = PBPoNum;
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			ItemType _PItem = PItem;
			DescriptionType _PItemDesc = PItemDesc;
			VendItemType _PVendItem = PVendItem;
			QtyUnitNoNegType _PQtyRcvd = PQtyRcvd;
			QtyUnitNoNegType _PQtyVoucher = PQtyVoucher;
			QtyUnitNoNegType _POrigQtyVoucher = POrigQtyVoucher;
			UMType _PUm = PUm;
			CostPrcType _PUnitMatCostConv = PUnitMatCostConv;
			CostPrcType _PPlanCostConv = PPlanCostConv;
			AmountType _PFreight = PFreight;
			AmountType _PMiscCharges = PMiscCharges;
			TransNatType _PTransNat = PTransNat;
			TransNatType _PTransNat2 = PTransNat2;
			TaxCodeType _PPoTaxCode1 = PPoTaxCode1;
			TaxCodeType _PPoTaxCode2 = PPoTaxCode2;
			TaxCodeType _PPoITaxCode1 = PPoITaxCode1;
			TaxCodeType _PPoITaxCode2 = PPoITaxCode2;
			TaxCodeType _PFrtTaxCode1 = PFrtTaxCode1;
			TaxCodeType _PFrtTaxCode2 = PFrtTaxCode2;
			TaxCodeType _PMscTaxCode1 = PMscTaxCode1;
			TaxCodeType _PMscTaxCode2 = PMscTaxCode2;
			DateTimeType _PPoRecDate = PPoRecDate;
			ListYesNoType _PReadOnly = PReadOnly;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PSalesTax2 = PSalesTax2;
			ListYesNoType _TaxSystem1Enabled = TaxSystem1Enabled;
			ListYesNoType _TaxSystem2Enabled = TaxSystem2Enabled;
			ListYesNoType _ActiveForPurch1 = ActiveForPurch1;
			ListYesNoType _ActiveForPurch2 = ActiveForPurch2;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherBuilderCopySp";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVBOrigSite", _PVBOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBuilderVoucher", _PBuilderVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSelected", _PSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDate", _PDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAuthorizer", _PAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PITaxInCost", _PITaxInCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBPoOrigSite", _PBPoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBPoNum", _PBPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendItem", _PVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyRcvd", _PQtyRcvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyVoucher", _PQtyVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigQtyVoucher", _POrigQtyVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUm", _PUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitMatCostConv", _PUnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanCostConv", _PPlanCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoTaxCode1", _PPoTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoTaxCode2", _PPoTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoITaxCode1", _PPoITaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoITaxCode2", _PPoITaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFrtTaxCode1", _PFrtTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFrtTaxCode2", _PFrtTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMscTaxCode1", _PMscTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMscTaxCode2", _PMscTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRecDate", _PPoRecDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReadOnly", _PReadOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem1Enabled", _TaxSystem1Enabled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem2Enabled", _TaxSystem2Enabled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveForPurch1", _ActiveForPurch1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveForPurch2", _ActiveForPurch2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
