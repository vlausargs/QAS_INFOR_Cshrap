//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherRegister.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VoucherRegister : IRpt_VoucherRegister
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VoucherRegister(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherRegisterSp(string Sortby = "P",
		int? PrintPoLineRel = null,
		int? PrintGRN = null,
		int? DisplayVoucherTotals = null,
		int? StartingVoucher = null,
		int? EndingVoucher = null,
		DateTime? StartingInvoiceDate = null,
		DateTime? EndingInvoiceDate = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string StartingName = null,
		string EndingName = null,
		string StartingPO = null,
		string EndingPO = null,
		string StartingGrn = null,
		string EndingGrn = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		int? StartingInvDateOffSet = null,
		int? EndingInvDateOffSet = null,
		string pSite = null)
		{
			StringType _Sortby = Sortby;
			ListYesNoType _PrintPoLineRel = PrintPoLineRel;
			ListYesNoType _PrintGRN = PrintGRN;
			ListYesNoType _DisplayVoucherTotals = DisplayVoucherTotals;
			VoucherType _StartingVoucher = StartingVoucher;
			VoucherType _EndingVoucher = EndingVoucher;
			DateType _StartingInvoiceDate = StartingInvoiceDate;
			DateType _EndingInvoiceDate = EndingInvoiceDate;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			NameType _StartingName = StartingName;
			NameType _EndingName = EndingName;
			PoNumType _StartingPO = StartingPO;
			PoNumType _EndingPO = EndingPO;
			GrnNumType _StartingGrn = StartingGrn;
			GrnNumType _EndingGrn = EndingGrn;
			FlagNyType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			DateOffsetType _StartingInvDateOffSet = StartingInvDateOffSet;
			DateOffsetType _EndingInvDateOffSet = EndingInvDateOffSet;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VoucherRegisterSp";
				
				appDB.AddCommandParameter(cmd, "Sortby", _Sortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPoLineRel", _PrintPoLineRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintGRN", _PrintGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayVoucherTotals", _DisplayVoucherTotals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVoucher", _StartingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVoucher", _EndingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvoiceDate", _StartingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvoiceDate", _EndingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingName", _StartingName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingName", _EndingName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPO", _StartingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPO", _EndingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingGrn", _StartingGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGrn", _EndingGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvDateOffSet", _StartingInvDateOffSet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvDateOffSet", _EndingInvDateOffSet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
