//PROJECT NAME: Logistics
//CLASS NAME: AutoVoucherPromptSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AutoVoucherPromptSave : IAutoVoucherPromptSave
	{
		readonly IApplicationDB appDB;
		
		
		public AutoVoucherPromptSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AutoVoucherPromptSaveSp(Guid? PProcessID,
		decimal? PFreight,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		DateTime? GLDistDate,
		string PVendorInvoice,
		DateTime? PInvoiceDate,
		string PTerms,
		DateTime? PTaxDate)
		{
			RowPointerType _PProcessID = PProcessID;
			AmountType _PFreight = PFreight;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PSalesTax2 = PSalesTax2;
			DateType _GLDistDate = GLDistDate;
			VendInvNumType _PVendorInvoice = PVendorInvoice;
			DateType _PInvoiceDate = PInvoiceDate;
			TermsCodeType _PTerms = PTerms;
			DateType _PTaxDate = PTaxDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutoVoucherPromptSaveSp";
				
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLDistDate", _GLDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorInvoice", _PVendorInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceDate", _PInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTerms", _PTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxDate", _PTaxDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
