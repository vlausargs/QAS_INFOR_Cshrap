//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderSaveDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderSaveDist : IVoucherBuilderSaveDist
	{
		readonly IApplicationDB appDB;
		
		
		public VoucherBuilderSaveDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? VoucherBuilderSaveDistSp(Guid? PRowPointer,
		int? PSelected,
		decimal? PQtyVoucher,
		decimal? PUnitMatCostConv,
		decimal? PFreight,
		decimal? PMiscCharges,
		string PTransNat,
		string PTransNat2,
		DateTime? GLDistDate,
		string PVendorInvoice,
		DateTime? PInvoiceDate,
		string PTerms,
		string PAuthorizer,
		Guid? PProcessID,
		string PVendNum,
		int? PVoucher,
		int? PClearSel,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		DateTime? TaxDate)
		{
			RowPointerType _PRowPointer = PRowPointer;
			ListYesNoType _PSelected = PSelected;
			QtyUnitNoNegType _PQtyVoucher = PQtyVoucher;
			CostPrcType _PUnitMatCostConv = PUnitMatCostConv;
			AmountType _PFreight = PFreight;
			AmountType _PMiscCharges = PMiscCharges;
			TransNatType _PTransNat = PTransNat;
			TransNat2Type _PTransNat2 = PTransNat2;
			DateType _GLDistDate = GLDistDate;
			VendInvNumType _PVendorInvoice = PVendorInvoice;
			DateType _PInvoiceDate = PInvoiceDate;
			TermsCodeType _PTerms = PTerms;
			UsernameType _PAuthorizer = PAuthorizer;
			RowPointerType _PProcessID = PProcessID;
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			ListYesNoType _PClearSel = PClearSel;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PSalesTax2 = PSalesTax2;
			DateType _TaxDate = TaxDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherBuilderSaveDistSp";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSelected", _PSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyVoucher", _PQtyVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitMatCostConv", _PUnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLDistDate", _GLDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorInvoice", _PVendorInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceDate", _PInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTerms", _PTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAuthorizer", _PAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PClearSel", _PClearSel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDate", _TaxDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
