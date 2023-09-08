//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherRegisterbyAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VoucherRegisterbyAccount : IRpt_VoucherRegisterbyAccount
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VoucherRegisterbyAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherRegisterbyAccountSp(string StartingAccount = null,
		string EndingAccount = null,
		int? StartingVoucher = null,
		int? EndingVoucher = null,
		DateTime? StartingInvoiceDate = null,
		DateTime? EndingInvoiceDate = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string StartingPO = null,
		string EndingPO = null,
		string StartingGrn = null,
		string EndingGrn = null,
		int? TransToDomCurr = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		string pSite = null)
		{
			AcctType _StartingAccount = StartingAccount;
			AcctType _EndingAccount = EndingAccount;
			VoucherType _StartingVoucher = StartingVoucher;
			VoucherType _EndingVoucher = EndingVoucher;
			GenericDateType _StartingInvoiceDate = StartingInvoiceDate;
			GenericDateType _EndingInvoiceDate = EndingInvoiceDate;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			PoNumType _StartingPO = StartingPO;
			PoNumType _EndingPO = EndingPO;
			GrnNumType _StartingGrn = StartingGrn;
			GrnNumType _EndingGrn = EndingGrn;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VoucherRegisterbyAccountSp";
				
				appDB.AddCommandParameter(cmd, "StartingAccount", _StartingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAccount", _EndingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVoucher", _StartingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVoucher", _EndingVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvoiceDate", _StartingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvoiceDate", _EndingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPO", _StartingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPO", _EndingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingGrn", _StartingGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGrn", _EndingGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
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
