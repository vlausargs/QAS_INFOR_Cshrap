//PROJECT NAME: CSIVendor
//CLASS NAME: PurchaseOrderPreDisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPurchaseOrderPreDisplay
	{
		int PurchaseOrderPreDisplaySP(ref byte? Amend_Po,
		                              ref string Po_Change,
		                              ref byte? Vendor_Required,
		                              ref byte? Track_Tax_Free_Imports,
		                              ref string Country);
	}
	
	public class PurchaseOrderPreDisplay : IPurchaseOrderPreDisplay
	{
		readonly IApplicationDB appDB;
		
		public PurchaseOrderPreDisplay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PurchaseOrderPreDisplaySP(ref byte? Amend_Po,
		                                     ref string Po_Change,
		                                     ref byte? Vendor_Required,
		                                     ref byte? Track_Tax_Free_Imports,
		                                     ref string Country)
		{
			ListYesNoType _Amend_Po = Amend_Po;
			ListAlwaysSometimesNeverType _Po_Change = Po_Change;
			ByteType _Vendor_Required = Vendor_Required;
			ListYesNoType _Track_Tax_Free_Imports = Track_Tax_Free_Imports;
			CountryType _Country = Country;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurchaseOrderPreDisplaySP";
				
				appDB.AddCommandParameter(cmd, "Amend_Po", _Amend_Po, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Po_Change", _Po_Change, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Vendor_Required", _Vendor_Required, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Track_Tax_Free_Imports", _Track_Tax_Free_Imports, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Amend_Po = _Amend_Po;
				Po_Change = _Po_Change;
				Vendor_Required = _Vendor_Required;
				Track_Tax_Free_Imports = _Track_Tax_Free_Imports;
				Country = _Country;
				
				return Severity;
			}
		}
	}
}
