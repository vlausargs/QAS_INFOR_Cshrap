//PROJECT NAME: Reporting
//CLASS NAME: Rpt_POVoucherRegisterbyAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_POVoucherRegisterbyAccount : IRpt_POVoucherRegisterbyAccount
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_POVoucherRegisterbyAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_POVoucherRegisterbyAccountSp(string StartAccount = null,
		string EndAccount = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		int? TransDomCurr = 1,
		int? StartVoucher = null,
		int? EndVoucher = null,
		string StartVendor = null,
		string EndVendor = null,
		string StartPO = null,
		string EndPO = null,
		string StartGRN = null,
		string EndGRN = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? PDisplayHeader = null,
		string PMessageLanguage = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			AcctType _StartAccount = StartAccount;
			AcctType _EndAccount = EndAccount;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			GenericDateType _StartInvDate = StartInvDate;
			GenericDateType _EndInvDate = EndInvDate;
			FlagNyType _TransDomCurr = TransDomCurr;
			VoucherType _StartVoucher = StartVoucher;
			VoucherType _EndVoucher = EndVoucher;
			VendNumType _StartVendor = StartVendor;
			VendNumType _EndVendor = EndVendor;
			PoNumType _StartPO = StartPO;
			PoNumType _EndPO = EndPO;
			GrnNumType _StartGRN = StartGRN;
			GrnNumType _EndGRN = EndGRN;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_POVoucherRegisterbyAccountSp";
				
				appDB.AddCommandParameter(cmd, "StartAccount", _StartAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndAccount", _EndAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVoucher", _StartVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVoucher", _EndVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendor", _StartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPO", _StartPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPO", _EndPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartGRN", _StartGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGRN", _EndGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
