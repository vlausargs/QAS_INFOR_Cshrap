//PROJECT NAME: Logistics
//CLASS NAME: VchDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VchDel : IVchDel
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public VchDel(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VchDelSp(int? EndingVoucher,
		DateTime? EndingInvoiceDate,
		int? DeleteLineItemsOnly,
		int? ShowUnpurgableVoucher,
		string Infobar,
		int? InvoiceDateOffset = null)
		{
			VoucherType _EndingVoucher = EndingVoucher;
			DateType _EndingInvoiceDate = EndingInvoiceDate;
			Flag _DeleteLineItemsOnly = DeleteLineItemsOnly;
			Flag _ShowUnpurgableVoucher = ShowUnpurgableVoucher;
			InfobarType _Infobar = Infobar;
			DateOffsetType _InvoiceDateOffset = InvoiceDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VchDelSp";
				
				appDB.AddCommandParameter(cmd, "EndingVoucher", _EndingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvoiceDate", _EndingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteLineItemsOnly", _DeleteLineItemsOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowUnpurgableVoucher", _ShowUnpurgableVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvoiceDateOffset", _InvoiceDateOffset, ParameterDirection.Input);
				
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
