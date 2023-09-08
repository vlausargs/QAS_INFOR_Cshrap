//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AccountsPayableAging.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_AccountsPayableAging
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_AccountsPayableAgingSp(string VendorStarting = null,
		string VendorEnding = null,
		string NameStarting = null,
		string NameEnding = null,
		string CurrCodeStarting = null,
		string CurrCodeEnding = null,
		string SiteGroup = null,
		DateTime? AgingDate = null,
		DateTime? CutOffDate = null,
		byte? PrintPostTrans = null,
		byte? PrintOpenPaymts = null,
		byte? SupZeroBalVch = null,
		byte? TransDomCurr = null,
		byte? UseHistRate = null,
		int? AgeBucket = null,
		string AgingBasis = null,
		string PayHold = null,
		byte? ShowActive = null,
		byte? SortByCurrCode = null,
		byte? SortByNum = null,
		short? AgeDays1 = null,
		short? AgeDays2 = null,
		short? AgeDays3 = null,
		short? AgeDays4 = null,
		short? AgeDays5 = null,
		string AgeDesc1 = null,
		string AgeDesc2 = null,
		string AgeDesc3 = null,
		string AgeDesc4 = null,
		string AgeDesc5 = null,
		short? AgingDateOffset = null,
		short? CutOffDateOffset = null,
		byte? DisplayHeader = null,
		byte? ConsolidateVendors = null,
		int? TaskID = null,
		string pSite = null,
		Guid? ProcessId = null);
	}
	
	public class Rpt_AccountsPayableAging : IRpt_AccountsPayableAging
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_AccountsPayableAging(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_AccountsPayableAgingSp(string VendorStarting = null,
		string VendorEnding = null,
		string NameStarting = null,
		string NameEnding = null,
		string CurrCodeStarting = null,
		string CurrCodeEnding = null,
		string SiteGroup = null,
		DateTime? AgingDate = null,
		DateTime? CutOffDate = null,
		byte? PrintPostTrans = null,
		byte? PrintOpenPaymts = null,
		byte? SupZeroBalVch = null,
		byte? TransDomCurr = null,
		byte? UseHistRate = null,
		int? AgeBucket = null,
		string AgingBasis = null,
		string PayHold = null,
		byte? ShowActive = null,
		byte? SortByCurrCode = null,
		byte? SortByNum = null,
		short? AgeDays1 = null,
		short? AgeDays2 = null,
		short? AgeDays3 = null,
		short? AgeDays4 = null,
		short? AgeDays5 = null,
		string AgeDesc1 = null,
		string AgeDesc2 = null,
		string AgeDesc3 = null,
		string AgeDesc4 = null,
		string AgeDesc5 = null,
		short? AgingDateOffset = null,
		short? CutOffDateOffset = null,
		byte? DisplayHeader = null,
		byte? ConsolidateVendors = null,
		int? TaskID = null,
		string pSite = null,
		Guid? ProcessId = null)
		{
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			NameType _NameStarting = NameStarting;
			NameType _NameEnding = NameEnding;
			CurrCodeType _CurrCodeStarting = CurrCodeStarting;
			CurrCodeType _CurrCodeEnding = CurrCodeEnding;
			SiteGroupType _SiteGroup = SiteGroup;
			DateType _AgingDate = AgingDate;
			DateType _CutOffDate = CutOffDate;
			FlagNyType _PrintPostTrans = PrintPostTrans;
			FlagNyType _PrintOpenPaymts = PrintOpenPaymts;
			FlagNyType _SupZeroBalVch = SupZeroBalVch;
			FlagNyType _TransDomCurr = TransDomCurr;
			FlagNyType _UseHistRate = UseHistRate;
			IntType _AgeBucket = AgeBucket;
			InfobarType _AgingBasis = AgingBasis;
			StringType _PayHold = PayHold;
			FlagNyType _ShowActive = ShowActive;
			FlagNyType _SortByCurrCode = SortByCurrCode;
			FlagNyType _SortByNum = SortByNum;
			AgeDaysType _AgeDays1 = AgeDays1;
			AgeDaysType _AgeDays2 = AgeDays2;
			AgeDaysType _AgeDays3 = AgeDays3;
			AgeDaysType _AgeDays4 = AgeDays4;
			AgeDaysType _AgeDays5 = AgeDays5;
			AgeDescType _AgeDesc1 = AgeDesc1;
			AgeDescType _AgeDesc2 = AgeDesc2;
			AgeDescType _AgeDesc3 = AgeDesc3;
			AgeDescType _AgeDesc4 = AgeDesc4;
			AgeDescType _AgeDesc5 = AgeDesc5;
			DateOffsetType _AgingDateOffset = AgingDateOffset;
			DateOffsetType _CutOffDateOffset = CutOffDateOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			FlagNyType _ConsolidateVendors = ConsolidateVendors;
			TaskNumType _TaskID = TaskID;
			SiteType _pSite = pSite;
			RowPointerType _ProcessId = ProcessId;


			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_AccountsPayableAgingSp";
				
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameStarting", _NameStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameEnding", _NameEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCodeStarting", _CurrCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCodeEnding", _CurrCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingDate", _AgingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPostTrans", _PrintPostTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOpenPaymts", _PrintOpenPaymts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupZeroBalVch", _SupZeroBalVch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeBucket", _AgeBucket, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingBasis", _AgingBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHold", _PayHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowActive", _ShowActive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByCurrCode", _SortByCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByNum", _SortByNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays1", _AgeDays1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays2", _AgeDays2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays3", _AgeDays3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays4", _AgeDays4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays5", _AgeDays5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc1", _AgeDesc1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc2", _AgeDesc2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc3", _AgeDesc3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc4", _AgeDesc4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc5", _AgeDesc5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingDateOffset", _AgingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutOffDateOffset", _CutOffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsolidateVendors", _ConsolidateVendors, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();

				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
