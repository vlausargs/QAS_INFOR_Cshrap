//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerCheckInformation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerCheckInformation : IRpt_MultiFSBGeneralLedgerCheckInformation
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MultiFSBGeneralLedgerCheckInformation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerCheckInformationSp(string AccountStarting = null,
		string AccountEnding = null,
		string PrintTrxText = null,
		int? AnalyticalLedger = null,
		string AcctUnit1Starting = null,
		string AcctUnit1Ending = null,
		string AcctUnit2Starting = null,
		string AcctUnit2Ending = null,
		string AcctUnit3Starting = null,
		string AcctUnit3Ending = null,
		string AcctUnit4Starting = null,
		string AcctUnit4Ending = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string RefStarting = null,
		string RefEnding = null,
		string VendNumStarting = null,
		string VendNumEnding = null,
		string VoucherStarting = null,
		string VoucherEnding = null,
		DateTime? CheckDateStarting = null,
		DateTime? CheckDateEnding = null,
		int? CheckNumStarting = null,
		int? CheckNumEnding = null,
		decimal? TransNumStarting = null,
		decimal? TransNumEnding = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		int? CheckDateStartingOffset = null,
		int? CheckDateEndingOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string FSBName = null,
		string pSite = null)
		{
			AcctType _AccountStarting = AccountStarting;
			AcctType _AccountEnding = AccountEnding;
			StringType _PrintTrxText = PrintTrxText;
			FlagNyType _AnalyticalLedger = AnalyticalLedger;
			UnitCode1Type _AcctUnit1Starting = AcctUnit1Starting;
			UnitCode1Type _AcctUnit1Ending = AcctUnit1Ending;
			UnitCode2Type _AcctUnit2Starting = AcctUnit2Starting;
			UnitCode2Type _AcctUnit2Ending = AcctUnit2Ending;
			UnitCode3Type _AcctUnit3Starting = AcctUnit3Starting;
			UnitCode3Type _AcctUnit3Ending = AcctUnit3Ending;
			UnitCode4Type _AcctUnit4Starting = AcctUnit4Starting;
			UnitCode4Type _AcctUnit4Ending = AcctUnit4Ending;
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
			ReferenceType _RefStarting = RefStarting;
			ReferenceType _RefEnding = RefEnding;
			VendNumType _VendNumStarting = VendNumStarting;
			VendNumType _VendNumEnding = VendNumEnding;
			InvNumVoucherType _VoucherStarting = VoucherStarting;
			InvNumVoucherType _VoucherEnding = VoucherEnding;
			DateType _CheckDateStarting = CheckDateStarting;
			DateType _CheckDateEnding = CheckDateEnding;
			GlCheckNumType _CheckNumStarting = CheckNumStarting;
			GlCheckNumType _CheckNumEnding = CheckNumEnding;
			MatlTransNumType _TransNumStarting = TransNumStarting;
			MatlTransNumType _TransNumEnding = TransNumEnding;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			DateOffsetType _CheckDateStartingOffset = CheckDateStartingOffset;
			DateOffsetType _CheckDateEndingOffset = CheckDateEndingOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			FSBNameType _FSBName = FSBName;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBGeneralLedgerCheckInformationSp";
				
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTrxText", _PrintTrxText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalyticalLedger", _AnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1Starting", _AcctUnit1Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1Ending", _AcctUnit1Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2Starting", _AcctUnit2Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2Ending", _AcctUnit2Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3Starting", _AcctUnit3Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3Ending", _AcctUnit3Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4Starting", _AcctUnit4Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4Ending", _AcctUnit4Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStarting", _RefStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefEnding", _RefEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNumStarting", _VendNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNumEnding", _VendNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherStarting", _VoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherEnding", _VoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateStarting", _CheckDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateEnding", _CheckDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNumStarting", _CheckNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNumEnding", _CheckNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNumStarting", _TransNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNumEnding", _TransNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateStartingOffset", _CheckDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateEndingOffset", _CheckDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
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
