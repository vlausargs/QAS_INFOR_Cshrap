//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherAuthorization.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VoucherAuthorization : IRpt_VoucherAuthorization
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VoucherAuthorization(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherAuthorizationSp(int? POLineRel = null,
		int? PrintGoodsReceiveNote = null,
		int? DisplayVoucherTotal = null,
		int? TransDomCurr = null,
		int? PageBetweenAuth = null,
		string SortBy = null,
		string StartAuthorizer = null,
		string EndAuthorizer = null,
		int? StartVoucher = null,
		int? EndVoucher = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartVendor = null,
		string EndVendor = null,
		string StartName = null,
		string EndName = null,
		string StartPO = null,
		string EndPO = null,
		string StartGRN = null,
		string EndGRN = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? DisplayHeader = 1,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			FlagNyType _POLineRel = POLineRel;
			FlagNyType _PrintGoodsReceiveNote = PrintGoodsReceiveNote;
			FlagNyType _DisplayVoucherTotal = DisplayVoucherTotal;
			FlagNyType _TransDomCurr = TransDomCurr;
			FlagNyType _PageBetweenAuth = PageBetweenAuth;
			InfobarType _SortBy = SortBy;
			NameType _StartAuthorizer = StartAuthorizer;
			NameType _EndAuthorizer = EndAuthorizer;
			VoucherType _StartVoucher = StartVoucher;
			VoucherType _EndVoucher = EndVoucher;
			GenericDateType _StartInvDate = StartInvDate;
			GenericDateType _EndInvDate = EndInvDate;
			VendNumType _StartVendor = StartVendor;
			VendNumType _EndVendor = EndVendor;
			NameType _StartName = StartName;
			NameType _EndName = EndName;
			PoNumType _StartPO = StartPO;
			PoNumType _EndPO = EndPO;
			GrnNumType _StartGRN = StartGRN;
			GrnNumType _EndGRN = EndGRN;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VoucherAuthorizationSp";
				
				appDB.AddCommandParameter(cmd, "POLineRel", _POLineRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintGoodsReceiveNote", _PrintGoodsReceiveNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayVoucherTotal", _DisplayVoucherTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenAuth", _PageBetweenAuth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartAuthorizer", _StartAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndAuthorizer", _EndAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVoucher", _StartVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVoucher", _EndVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendor", _StartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartName", _StartName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndName", _EndName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPO", _StartPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPO", _EndPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartGRN", _StartGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGRN", _EndGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
