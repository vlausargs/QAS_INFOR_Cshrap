//PROJECT NAME: Logistics
//CLASS NAME: VchAuth.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VchAuth : IVchAuth
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public VchAuth(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VchAuthSp(string PText,
		string PStartingAuthorizer,
		string PEndingAuthorizer,
		int? PStartingVoucher,
		int? PEndingVoucher,
		DateTime? PStartingInvoiceDate,
		DateTime? PEndingInvoiceDate,
		string PStartingVendor,
		string PEndingVendor,
		string PAuthStatus,
		string Infobar)
		{
			LongListType _PText = PText;
			UsernameType _PStartingAuthorizer = PStartingAuthorizer;
			UsernameType _PEndingAuthorizer = PEndingAuthorizer;
			VoucherType _PStartingVoucher = PStartingVoucher;
			VoucherType _PEndingVoucher = PEndingVoucher;
			DateType _PStartingInvoiceDate = PStartingInvoiceDate;
			DateType _PEndingInvoiceDate = PEndingInvoiceDate;
			VendNumType _PStartingVendor = PStartingVendor;
			VendNumType _PEndingVendor = PEndingVendor;
			StringType _PAuthStatus = PAuthStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VchAuthSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingAuthorizer", _PStartingAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingAuthorizer", _PEndingAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVoucher", _PStartingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVoucher", _PEndingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingInvoiceDate", _PStartingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingInvoiceDate", _PEndingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendor", _PStartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendor", _PEndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAuthStatus", _PAuthStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
