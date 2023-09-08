//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerCheckInformationCRUD.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerCheckInformationCRUD : IRpt_GeneralLedgerCheckInformationCRUD
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;

		public Rpt_GeneralLedgerCheckInformationCRUD(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
		}

		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_GeneralLedgerCheckInformationSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}

		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_GeneralLedgerCheckInformationSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}

		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);

			this.appDB.Insert(optional_module1InsertRequest);
		}

		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName: "#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}

		public string Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;

			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName: "#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if (tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}

			return ALTGEN_SpName;
		}

		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName: "#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}

		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_GeneralLedgerCheckInformationSp(
			string AltExtGenSp,
			string AccountStarting = null,
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
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

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
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

				dtReturn = appDB.ExecuteQuery(cmd);

				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

				return (resultSet, returnCode);
			}
		}

	}
}
