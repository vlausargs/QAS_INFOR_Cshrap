//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Interactions.cs

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
using CSI.Logistics.Customer;
using CSI.Material;
using CSI.POS;
using CSI.Logistics.Vendor;

namespace CSI.Reporting
{
	public class Rpt_Interactions : IRpt_Interactions
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IFormatProspectAddress iFormatProspectAddress;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IFormatContactAddress iFormatContactAddress;
		readonly IFormatVendorAddress iFormatVendorAddress;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IReportNotesExist iReportNotesExist;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IFormatAddress iFormatAddress;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IHighDecimal iHighDecimal;
		readonly IVariableUtil variableUtil;
		readonly IGetFullName iGetFullName;
		readonly ILowDecimal iLowDecimal;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
		public Rpt_Interactions(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IFormatProspectAddress iFormatProspectAddress,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IFormatContactAddress iFormatContactAddress,
			IFormatVendorAddress iFormatVendorAddress,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IReportNotesExist iReportNotesExist,
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IFormatAddress iFormatAddress,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IHighDecimal iHighDecimal,
			IVariableUtil variableUtil,
			IGetFullName iGetFullName,
			ILowDecimal iLowDecimal,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iFormatProspectAddress = iFormatProspectAddress;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iFormatContactAddress = iFormatContactAddress;
			this.iFormatVendorAddress = iFormatVendorAddress;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iReportNotesExist = iReportNotesExist;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.iFormatAddress = iFormatAddress;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.iHighDecimal = iHighDecimal;
			this.variableUtil = variableUtil;
			this.iGetFullName = iGetFullName;
			this.iLowDecimal = iLowDecimal;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
            this.highCharacter = highCharacter;
            this.lowCharacter = lowCharacter;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_InteractionsSp(
			string InteractionType = "C",
			decimal? BegInteractionID = null,
			decimal? EndInteractionID = null,
			string BegRefnum = null,
			string EndRefnum = null,
			DateTime? Beginteraction_date = null,
			DateTime? Endinteraction_date = null,
			DateTime? Begfollow_date = null,
			DateTime? Endfollow_date = null,
			string Begentered_by = null,
			string Endentered_by = null,
			string Begsalesman = null,
			string Endsalesman = null,
			string Begcontact = null,
			string Endcontact = null,
			string Begtopic = null,
			string Endtopic = null,
			string CommStat = null,
			string CommSort = null,
			int? StartingTransDateOffset = null,
			int? EndingTransDateOffset = null,
			int? StartingfollowDateOffset = null,
			int? EndingfollowDateOffset = null,
			int? ShowInternal = 0,
			int? ShowExternal = 0,
			int? DisplayHeader = 0,
			string pSite = null)
		{

			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			string RptSessionID = null;
			string LowCharacterValue = null;
			string HighCharacterValue = null;
			int? Severity = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InteractionsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
			)
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SpName","CAST (NULL AS NVARCHAR)"},
						{"u0","[om].[ModuleName]"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InteractionsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_InteractionsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""))
				)
				{

					#region CRUD LoadToVariable
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
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Rpt_InteractionsSp(ALTGEN_SpName,
						InteractionType,
						BegInteractionID,
						EndInteractionID,
						BegRefnum,
						EndRefnum,
						Beginteraction_date,
						Endinteraction_date,
						Begfollow_date,
						Endfollow_date,
						Begentered_by,
						Endentered_by,
						Begsalesman,
						Endsalesman,
						Begcontact,
						Endcontact,
						Begtopic,
						Endtopic,
						CommStat,
						CommSort,
						StartingTransDateOffset,
						EndingTransDateOffset,
						StartingfollowDateOffset,
						EndingfollowDateOffset,
						ShowInternal,
						ShowExternal,
						DisplayHeader,
						pSite);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
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
					var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD DeleteByRecord
					var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
						items: tv_ALTGEN2LoadResponse.Items);
					this.appDB.Delete(tv_ALTGEN2DeleteRequest);
					#endregion DeleteByRecord

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_InteractionsSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_InteractionsSp("dbo.EXTGEN_Rpt_InteractionsSp",
					InteractionType,
					BegInteractionID,
					EndInteractionID,
					BegRefnum,
					EndRefnum,
					Beginteraction_date,
					Endinteraction_date,
					Begfollow_date,
					Endfollow_date,
					Begentered_by,
					Endentered_by,
					Begsalesman,
					Endsalesman,
					Begcontact,
					Endcontact,
					Begtopic,
					Endtopic,
					CommStat,
					CommSort,
					StartingTransDateOffset,
					EndingTransDateOffset,
					StartingfollowDateOffset,
					EndingfollowDateOffset,
					ShowInternal,
					ShowExternal,
					DisplayHeader,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("InteractionsReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");

			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_InteractionsSp",
				SessionID: convertToUtil.ToGuid(RptSessionID),
				Site: pSite);
			RptSessionID = convertToUtil.ToString(InitSessionContext.SessionID);

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: Beginteraction_date,
				Offset: StartingTransDateOffset,
				IsEndDate: 0);
			Beginteraction_date = ApplyDateOffset.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: Endinteraction_date,
				Offset: EndingTransDateOffset,
				IsEndDate: 1);
			Endinteraction_date = ApplyDateOffset1.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset2 = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: Begfollow_date,
				Offset: StartingfollowDateOffset,
				IsEndDate: 0);
			Begfollow_date = ApplyDateOffset2.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset3 = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: Endfollow_date,
				Offset: EndingfollowDateOffset,
				IsEndDate: 1);
			Endfollow_date = ApplyDateOffset3.Date;

			#endregion ExecuteMethodCall

			LowCharacterValue = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
			HighCharacterValue = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
			BegInteractionID = convertToUtil.ToDecimal(stringUtil.IsNull(
				BegInteractionID,
				this.iLowDecimal.LowDecimalFn("InteractionIdType")));
			EndInteractionID = convertToUtil.ToDecimal(stringUtil.IsNull(
				EndInteractionID,
				this.iHighDecimal.HighDecimalFn("InteractionIdType")));
			BegRefnum = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"CustVendRefNumType",
					BegRefnum),
				LowCharacterValue);
			EndRefnum = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"CustVendRefNumType",
					EndRefnum),
				HighCharacterValue);
			Begentered_by = stringUtil.IsNull(
				Begentered_by,
				LowCharacterValue);
			Endentered_by = stringUtil.IsNull(
				Endentered_by,
				HighCharacterValue);
			Begsalesman = stringUtil.IsNull(
				Begsalesman,
				LowCharacterValue);
			Endsalesman = stringUtil.IsNull(
				Endsalesman,
				HighCharacterValue);
			Begcontact = stringUtil.IsNull(
				Begcontact,
				LowCharacterValue);
			Endcontact = stringUtil.IsNull(
				Endcontact,
				HighCharacterValue);
			Begtopic = stringUtil.IsNull(
				Begtopic,
				LowCharacterValue);
			Endtopic = stringUtil.IsNull(
				Endtopic,
				HighCharacterValue);
			DisplayHeader = (int?)(stringUtil.IsNull(
				DisplayHeader,
				1));
			CommSort = stringUtil.IsNull(
				CommSort,
				"I");
			CommStat = stringUtil.IsNull(
				CommStat,
				"AC");
			ShowInternal = (int?)(stringUtil.IsNull(
				ShowInternal,
				1));
			ShowExternal = (int?)(stringUtil.IsNull(
				ShowExternal,
				1));
			Severity = 0;
			if (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
					CommSort,
					"IF"), 0) == true)
			{

				#region CRUD LoadToRecord
				var interactionLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"InteractionID","interaction.interaction_id"},
						{"Description","interaction.description"},
						{"InteractionCustNum","interaction.ref_num_id"},
						{"CustaddrName","CAST (NULL AS NVARCHAR)"},
						{"InteractionContact","CAST (NULL AS NVARCHAR)"},
						{"InteractionTopic","interaction.topic"},
						{"InteractionCustSeq","interaction.ref_seq"},
						{"InteractionPhone","interaction.phone"},
						{"InteractionStat","interaction.stat"},
						{"InteractionInteractionDate","interaction.interaction_date"},
						{"CustaddrFaxNum","CAST (NULL AS NVARCHAR)"},
						{"InteractionFollowDate","interaction.follow_date"},
						{"CustaddrTelexNum","CAST (NULL AS NVARCHAR)"},
						{"CustomerAddress","CAST (NULL AS NVARCHAR)"},
						{"RowPointer","interaction.RowPointer"},
						{"NoteExists","CAST (NULL AS INT)"},
						{"Salesperson","interaction.slsman"},
						{"Item","i.item"},
						{"LeadId","l.lead_id"},
						{"OppId","o.opp_id"},
						{"EstCoNum","e.co_num"},
						{"EstProjNum","p.proj_num"},
						{"CoNum","c.co_num"},
						{"ProjNum","r.proj_num"},
						{"ItemPriceRequest","q.ipr_id"},
						{"PoNum","h.po_num"},
						{"RefType","interaction.RefType"},
						{"InteractionType","interaction.interaction_type"},
						{"Reference","CAST (NULL AS NVARCHAR)"},
						{"InteractionProspectId","interaction.ref_num_id"},
						{"InteractionContactId","interaction.ref_num_id"},
						{"InteractionVendNum","interaction.ref_num_id"},
						{"u0","interaction.interaction_type"},
						{"u1","custaddr.name"},
						{"u2","vendaddr.name"},
						{"u3","contact.lname"},
						{"u4","contact.fname"},
						{"u5","contact.mi"},
						{"u6","contact.sname"},
						{"u7","interaction.contact"},
						{"u8","custaddr.fax_num"},
						{"u9","vendaddr.fax_num"},
						{"u10","custaddr.telex_num"},
						{"u11","pp.phone"},
						{"u12","vendaddr.telex_num"},
						{"u13","pp.prospect_id"},
						{"u14","interaction.contact_id"},
						{"u15","interaction.NoteExistsFlag"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "interaction",
					fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN customer ON (interaction_type = 'C'
							AND interaction.ref_num_id = customer.cust_num
							AND interaction.ref_seq = customer.Cust_seq) LEFT OUTER JOIN custaddr ON (interaction_type = 'C'
							AND interaction.ref_num_id = custaddr.cust_num
							AND interaction.ref_seq = custaddr.Cust_seq) LEFT OUTER JOIN vendor ON (interaction_type = 'V'
							AND interaction.ref_num_id = vendor.vend_num) LEFT OUTER JOIN vendaddr ON (interaction_type = 'V'
							AND interaction.ref_num_id = vendaddr.vend_num) LEFT OUTER JOIN item AS i ON interaction.RefType = 'I'
						AND interaction.RefRowPointer = i.RowPointer LEFT OUTER JOIN lead AS l ON interaction.RefType = 'L'
						AND interaction.RefRowPointer = l.RowPointer LEFT OUTER JOIN opportunity AS o ON interaction.RefType = 'O'
						AND interaction.RefRowPointer = o.RowPointer LEFT OUTER JOIN co AS e ON interaction.RefType = 'E'
						AND interaction.RefRowPointer = e.RowPointer LEFT OUTER JOIN proj AS p ON interaction.RefType = 'P'
						AND interaction.RefRowPointer = p.RowPointer LEFT OUTER JOIN co AS c ON interaction.RefType = 'C'
						AND interaction.RefRowPointer = c.RowPointer LEFT OUTER JOIN proj AS r ON interaction.RefType = 'R'
						AND interaction.RefRowPointer = r.RowPointer LEFT OUTER JOIN item_price_request AS q ON interaction.RefType = 'Q'
						AND interaction.RefRowPointer = q.RowPointer LEFT OUTER JOIN po AS h ON interaction.RefType = 'H'
						AND interaction.RefRowPointer = h.RowPointer LEFT OUTER JOIN prospect AS pp ON (interaction_type = 'P'
							AND interaction.ref_num_id = pp.prospect_id) LEFT OUTER JOIN contact ON (interaction_type = 'S'
							AND interaction.contact_id = contact.contact_id)"),
					whereClause: collectionLoadRequestFactory.Clause("interaction_id BETWEEN {3} AND {4} AND interaction.interaction_type = {5} AND EXISTS (SELECT TOP 1 * FROM interaction_detail AS id WHERE (ISNULL(id.entered_by, {2}) BETWEEN {8} AND {9}) AND interaction.interaction_id = id.interaction_id AND interaction.interaction_type = {5}) AND interaction.ref_num_id BETWEEN {14} AND {15} AND ISNULL(interaction.interaction_date, dbo.LowDate()) BETWEEN {0} AND {1} AND ISNULL(interaction.follow_date, dbo.LowDate()) BETWEEN {6} AND {7} AND ((charindex(interaction.interaction_type, 'SCP') > 0 AND ISNULL(interaction.slsman, {2}) BETWEEN {10} AND {11}) OR (charindex(interaction.interaction_type, 'SCP') = 0)) AND ISNULL(interaction.contact, {2}) BETWEEN {12} AND {13} AND ISNULL(interaction.topic, {2}) BETWEEN {16} AND {17} AND CHARINDEX(interaction.stat, {18}) > 0", Beginteraction_date, Endinteraction_date, LowCharacterValue, BegInteractionID, EndInteractionID, InteractionType, Begfollow_date, Endfollow_date, Begentered_by, Endentered_by, Begsalesman, Endsalesman, Begcontact, Endcontact, BegRefnum, EndRefnum, Begtopic, Endtopic, CommStat),
					orderByClause: collectionLoadRequestFactory.Clause(" CASE WHEN {0} = 'F' THEN interaction.follow_date ELSE interaction.interaction_date END", CommSort));
				var interactionLoadResponse = this.appDB.Load(interactionLoadRequest);
				#endregion  LoadToRecord

				foreach (var interactionItem in interactionLoadResponse.Items)
				{
					interactionItem.SetValue<decimal?>("InteractionID", interactionItem.GetValue<decimal?>("InteractionID"));
					interactionItem.SetValue<string>("Description", interactionItem.GetValue<string>("Description"));
					interactionItem.SetValue<string>("InteractionCustNum", interactionItem.GetValue<string>("InteractionCustNum"));
					interactionItem.SetValue<string>("CustaddrName", (sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "C") == true ? interactionItem.GetValue<string>("u1") : interactionItem.GetValue<string>("u2")));
					interactionItem.SetValue<string>("InteractionContact", (sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "S") == true ? this.iGetFullName.GetFullNameFn(
						interactionItem.GetValue<string>("u3"),
						interactionItem.GetValue<string>("u4"),
						interactionItem.GetValue<string>("u5"),
						interactionItem.GetValue<string>("u6")) : interactionItem.GetValue<string>("u7")));
					interactionItem.SetValue<string>("InteractionTopic", interactionItem.GetValue<string>("InteractionTopic"));
					interactionItem.SetValue<int?>("InteractionCustSeq", interactionItem.GetValue<int?>("InteractionCustSeq"));
					interactionItem.SetValue<string>("InteractionPhone", interactionItem.GetValue<string>("InteractionPhone"));
					interactionItem.SetValue<string>("InteractionStat", interactionItem.GetValue<string>("InteractionStat"));
					interactionItem.SetValue<DateTime?>("InteractionInteractionDate", interactionItem.GetValue<DateTime?>("InteractionInteractionDate"));
					interactionItem.SetValue<string>("CustaddrFaxNum", (sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "C") == true ? interactionItem.GetValue<string>("u8") : interactionItem.GetValue<string>("u9")));
					interactionItem.SetValue<DateTime?>("InteractionFollowDate", interactionItem.GetValue<DateTime?>("InteractionFollowDate"));
					interactionItem.SetValue<string>("CustaddrTelexNum", (sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "C") == true ? interactionItem.GetValue<string>("u10") :
					sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "P") == true ? convertToUtil.ToString(interactionItem.GetValue<string>("u11")) : interactionItem.GetValue<string>("u12")));
					interactionItem.SetValue<string>("CustomerAddress", (sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "C") == true ? this.iFormatAddress.FormatAddressFn(
						interactionItem.GetValue<string>("InteractionCustNum"),
						interactionItem.GetValue<int?>("InteractionCustSeq")) :
					sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "P") == true ? this.iFormatProspectAddress.FormatProspectAddressFn(interactionItem.GetValue<string>("u13")) :
					sQLUtil.SQLEqual(interactionItem.GetValue<string>("u0"), "S") == true ? this.iFormatContactAddress.FormatContactAddressFn(interactionItem.GetValue<string>("u14")) : this.iFormatVendorAddress.FormatVendorAddressFn(interactionItem.GetValue<string>("InteractionCustNum"))));
					interactionItem.SetValue<Guid?>("RowPointer", interactionItem.GetValue<Guid?>("RowPointer"));
					interactionItem.SetValue<int?>("NoteExists", this.iReportNotesExist.ReportNotesExistFn(
						"interaction",
						interactionItem.GetValue<Guid?>("RowPointer"),
						ShowInternal,
						ShowExternal,
						interactionItem.GetValue<int?>("u15")));
					interactionItem.SetValue<string>("Salesperson", interactionItem.GetValue<string>("Salesperson"));
					interactionItem.SetValue<string>("Item", interactionItem.GetValue<string>("Item"));
					interactionItem.SetValue<string>("LeadId", interactionItem.GetValue<string>("LeadId"));
					interactionItem.SetValue<string>("OppId", interactionItem.GetValue<string>("OppId"));
					interactionItem.SetValue<string>("EstCoNum", interactionItem.GetValue<string>("EstCoNum"));
					interactionItem.SetValue<string>("EstProjNum", interactionItem.GetValue<string>("EstProjNum"));
					interactionItem.SetValue<string>("CoNum", interactionItem.GetValue<string>("CoNum"));
					interactionItem.SetValue<string>("ProjNum", interactionItem.GetValue<string>("ProjNum"));
					interactionItem.SetValue<string>("ItemPriceRequest", interactionItem.GetValue<string>("ItemPriceRequest"));
					interactionItem.SetValue<string>("PoNum", interactionItem.GetValue<string>("PoNum"));
					interactionItem.SetValue<string>("RefType", interactionItem.GetValue<string>("RefType"));
					interactionItem.SetValue<string>("InteractionType", interactionItem.GetValue<string>("u0"));
					interactionItem.SetValue<string>("Reference", (sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "C") == true ? interactionItem.GetValue<string>("CoNum") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "I") == true ? interactionItem.GetValue<string>("Item") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "O") == true ? interactionItem.GetValue<string>("OppId") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "P") == true ? interactionItem.GetValue<string>("EstProjNum") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "L") == true ? interactionItem.GetValue<string>("LeadId") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "R") == true ? interactionItem.GetValue<string>("ProjNum") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "E") == true ? interactionItem.GetValue<string>("EstCoNum") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "Q") == true ? interactionItem.GetValue<string>("ItemPriceRequest") : sQLUtil.SQLEqual(interactionItem.GetValue<string>("RefType"), "H") == true ? interactionItem.GetValue<string>("PoNum") : null));
					interactionItem.SetValue<string>("InteractionCustNum", interactionItem.GetValue<string>("InteractionProspectId"));
					interactionItem.SetValue<string>("InteractionCustNum", interactionItem.GetValue<string>("InteractionContactId"));
					interactionItem.SetValue<string>("InteractionCustNum", interactionItem.GetValue<string>("InteractionVendNum"));
				};

				Data = interactionLoadResponse;

			}
			else
			{

				#region CRUD LoadToRecord
				var interaction1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"InteractionID","interaction.interaction_id"},
						{"Description","interaction.description"},
						{"InteractionCustNum","interaction.ref_num_id"},
						{"CustaddrName","CAST (NULL AS NVARCHAR)"},
						{"InteractionContact","CAST (NULL AS NVARCHAR)"},
						{"InteractionTopic","interaction.topic"},
						{"InteractionCustSeq","interaction.ref_seq"},
						{"InteractionPhone","interaction.phone"},
						{"InteractionStat","interaction.stat"},
						{"InteractionInteractionDate","interaction.interaction_date"},
						{"CustaddrFaxNum","CAST (NULL AS NVARCHAR)"},
						{"InteractionFollowDate","interaction.follow_date"},
						{"CustaddrTelexNum","CAST (NULL AS NVARCHAR)"},
						{"CustomerAddress","CAST (NULL AS NVARCHAR)"},
						{"RowPointer","interaction.RowPointer"},
						{"NoteExists","CAST (NULL AS INT)"},
						{"Salesperson","interaction.slsman"},
						{"Item","i.item"},
						{"LeadId","l.lead_id"},
						{"OppId","o.opp_id"},
						{"EstCoNum","e.co_num"},
						{"EstProjNum","p.proj_num"},
						{"CoNum","c.co_num"},
						{"ProjNum","r.proj_num"},
						{"ItemPriceRequest","q.ipr_id"},
						{"PoNum","h.po_num"},
						{"RefType","interaction.RefType"},
						{"InteractionType","interaction.interaction_type"},
						{"Reference","CAST (NULL AS NVARCHAR)"},
						{"InteractionProspectId","interaction.ref_num_id"},
						{"InteractionContactId","interaction.ref_num_id"},
						{"InteractionVendNum","interaction.ref_num_id"},
						{"u0","interaction.interaction_type"},
						{"u1","custaddr.name"},
						{"u2","vendaddr.name"},
						{"u3","contact.lname"},
						{"u4","contact.fname"},
						{"u5","contact.mi"},
						{"u6","contact.sname"},
						{"u7","interaction.contact"},
						{"u8","custaddr.fax_num"},
						{"u9","vendaddr.fax_num"},
						{"u10","custaddr.telex_num"},
						{"u11","pp.phone"},
						{"u12","vendaddr.telex_num"},
						{"u13","pp.prospect_id"},
						{"u14","interaction.contact_id"},
						{"u15","interaction.NoteExistsFlag"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "interaction",
					fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN customer ON (interaction_type = 'C'
							AND interaction.ref_num_id = customer.cust_num
							AND interaction.ref_seq = customer.Cust_seq) LEFT OUTER JOIN custaddr ON (interaction_type = 'C'
							AND interaction.ref_num_id = custaddr.cust_num
							AND interaction.ref_seq = custaddr.Cust_seq) LEFT OUTER JOIN vendor ON (interaction_type = 'V'
							AND interaction.ref_num_id = vendor.vend_num) LEFT OUTER JOIN vendaddr ON (interaction_type = 'V'
							AND interaction.ref_num_id = vendaddr.vend_num) LEFT OUTER JOIN item AS i ON interaction.RefType = 'I'
						AND interaction.RefRowPointer = i.RowPointer LEFT OUTER JOIN lead AS l ON interaction.RefType = 'L'
						AND interaction.RefRowPointer = l.RowPointer LEFT OUTER JOIN opportunity AS o ON interaction.RefType = 'O'
						AND interaction.RefRowPointer = o.RowPointer LEFT OUTER JOIN co AS e ON interaction.RefType = 'E'
						AND interaction.RefRowPointer = e.RowPointer LEFT OUTER JOIN proj AS p ON interaction.RefType = 'P'
						AND interaction.RefRowPointer = p.RowPointer LEFT OUTER JOIN co AS c ON interaction.RefType = 'C'
						AND interaction.RefRowPointer = c.RowPointer LEFT OUTER JOIN proj AS r ON interaction.RefType = 'R'
						AND interaction.RefRowPointer = r.RowPointer LEFT OUTER JOIN item_price_request AS q ON interaction.RefType = 'Q'
						AND interaction.RefRowPointer = q.RowPointer LEFT OUTER JOIN po AS h ON interaction.RefType = 'H'
						AND interaction.RefRowPointer = h.RowPointer LEFT OUTER JOIN prospect AS pp ON (interaction_type = 'P'
							AND interaction.ref_num_id = pp.prospect_id) LEFT OUTER JOIN contact ON (interaction_type = 'S'
							AND interaction.contact_id = contact.contact_id)"),
					whereClause: collectionLoadRequestFactory.Clause("interaction_id BETWEEN {3} AND {4} AND interaction.interaction_type = {5} AND EXISTS (SELECT TOP 1 * FROM interaction_detail AS id WHERE (ISNULL(id.entered_by, {2}) BETWEEN {8} AND {9}) AND interaction.interaction_id = id.interaction_id AND interaction.interaction_type = {5}) AND interaction.ref_num_id BETWEEN {14} AND {15} AND ISNULL(interaction.interaction_date, dbo.LowDate()) BETWEEN {0} AND {1} AND ISNULL(interaction.follow_date, dbo.LowDate()) BETWEEN {6} AND {7} AND ((charindex(interaction.interaction_type, 'SCP') > 0 AND ISNULL(interaction.slsman, {2}) BETWEEN {10} AND {11}) OR (charindex(interaction.interaction_type, 'SCP') = 0)) AND ISNULL(interaction.contact, {2}) BETWEEN {12} AND {13} AND ISNULL(interaction.topic, {2}) BETWEEN {16} AND {17} AND CHARINDEX(interaction.stat, {18}) > 0", Beginteraction_date, Endinteraction_date, LowCharacterValue, BegInteractionID, EndInteractionID, InteractionType, Begfollow_date, Endfollow_date, Begentered_by, Endentered_by, Begsalesman, Endsalesman, Begcontact, Endcontact, BegRefnum, EndRefnum, Begtopic, Endtopic, CommStat),
					orderByClause: collectionLoadRequestFactory.Clause(" interaction.topic"));
				var interaction1LoadResponse = this.appDB.Load(interaction1LoadRequest);
				#endregion  LoadToRecord

				foreach (var interaction1Item in interaction1LoadResponse.Items)
				{
					interaction1Item.SetValue<decimal?>("InteractionID", interaction1Item.GetValue<decimal?>("InteractionID"));
					interaction1Item.SetValue<string>("Description", interaction1Item.GetValue<string>("Description"));
					interaction1Item.SetValue<string>("InteractionCustNum", interaction1Item.GetValue<string>("InteractionCustNum"));
					interaction1Item.SetValue<string>("CustaddrName", (sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "C") == true ? interaction1Item.GetValue<string>("u1") : interaction1Item.GetValue<string>("u2")));
					interaction1Item.SetValue<string>("InteractionContact", (sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "S") == true ? this.iGetFullName.GetFullNameFn(
						interaction1Item.GetValue<string>("u3"),
						interaction1Item.GetValue<string>("u4"),
						interaction1Item.GetValue<string>("u5"),
						interaction1Item.GetValue<string>("u6")) : interaction1Item.GetValue<string>("u7")));
					interaction1Item.SetValue<string>("InteractionTopic", interaction1Item.GetValue<string>("InteractionTopic"));
					interaction1Item.SetValue<int?>("InteractionCustSeq", interaction1Item.GetValue<int?>("InteractionCustSeq"));
					interaction1Item.SetValue<string>("InteractionPhone", interaction1Item.GetValue<string>("InteractionPhone"));
					interaction1Item.SetValue<string>("InteractionStat", interaction1Item.GetValue<string>("InteractionStat"));
					interaction1Item.SetValue<DateTime?>("InteractionInteractionDate", interaction1Item.GetValue<DateTime?>("InteractionInteractionDate"));
					interaction1Item.SetValue<string>("CustaddrFaxNum", (sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "C") == true ? interaction1Item.GetValue<string>("u8") : interaction1Item.GetValue<string>("u9")));
					interaction1Item.SetValue<DateTime?>("InteractionFollowDate", interaction1Item.GetValue<DateTime?>("InteractionFollowDate"));
					interaction1Item.SetValue<string>("CustaddrTelexNum", (sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "C") == true ? interaction1Item.GetValue<string>("u10") :
					sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "P") == true ? convertToUtil.ToString(interaction1Item.GetValue<string>("u11")) : interaction1Item.GetValue<string>("u12")));
					interaction1Item.SetValue<string>("CustomerAddress", (sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "C") == true ? this.iFormatAddress.FormatAddressFn(
						interaction1Item.GetValue<string>("InteractionCustNum"),
						interaction1Item.GetValue<int?>("InteractionCustSeq")) :
					sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "P") == true ? this.iFormatProspectAddress.FormatProspectAddressFn(interaction1Item.GetValue<string>("u13")) :
					sQLUtil.SQLEqual(interaction1Item.GetValue<string>("u0"), "S") == true ? this.iFormatContactAddress.FormatContactAddressFn(interaction1Item.GetValue<string>("u14")) : this.iFormatVendorAddress.FormatVendorAddressFn(interaction1Item.GetValue<string>("InteractionCustNum"))));
					interaction1Item.SetValue<Guid?>("RowPointer", interaction1Item.GetValue<Guid?>("RowPointer"));
					interaction1Item.SetValue<int?>("NoteExists", this.iReportNotesExist.ReportNotesExistFn(
						"interaction",
						interaction1Item.GetValue<Guid?>("RowPointer"),
						ShowInternal,
						ShowExternal,
						interaction1Item.GetValue<int?>("u15")));
					interaction1Item.SetValue<string>("Salesperson", interaction1Item.GetValue<string>("Salesperson"));
					interaction1Item.SetValue<string>("Item", interaction1Item.GetValue<string>("Item"));
					interaction1Item.SetValue<string>("LeadId", interaction1Item.GetValue<string>("LeadId"));
					interaction1Item.SetValue<string>("OppId", interaction1Item.GetValue<string>("OppId"));
					interaction1Item.SetValue<string>("EstCoNum", interaction1Item.GetValue<string>("EstCoNum"));
					interaction1Item.SetValue<string>("EstProjNum", interaction1Item.GetValue<string>("EstProjNum"));
					interaction1Item.SetValue<string>("CoNum", interaction1Item.GetValue<string>("CoNum"));
					interaction1Item.SetValue<string>("ProjNum", interaction1Item.GetValue<string>("ProjNum"));
					interaction1Item.SetValue<string>("ItemPriceRequest", interaction1Item.GetValue<string>("ItemPriceRequest"));
					interaction1Item.SetValue<string>("PoNum", interaction1Item.GetValue<string>("PoNum"));
					interaction1Item.SetValue<string>("RefType", interaction1Item.GetValue<string>("RefType"));
					interaction1Item.SetValue<string>("InteractionType", interaction1Item.GetValue<string>("u0"));
					interaction1Item.SetValue<string>("Reference", (sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "C") == true ? interaction1Item.GetValue<string>("CoNum") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "I") == true ? interaction1Item.GetValue<string>("Item") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "O") == true ? interaction1Item.GetValue<string>("OppId") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "P") == true ? interaction1Item.GetValue<string>("EstProjNum") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "L") == true ? interaction1Item.GetValue<string>("LeadId") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "R") == true ? interaction1Item.GetValue<string>("ProjNum") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "E") == true ? interaction1Item.GetValue<string>("EstCoNum") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "Q") == true ? interaction1Item.GetValue<string>("ItemPriceRequest") : sQLUtil.SQLEqual(interaction1Item.GetValue<string>("RefType"), "H") == true ? interaction1Item.GetValue<string>("PoNum") : null));
					interaction1Item.SetValue<string>("InteractionCustNum", interaction1Item.GetValue<string>("InteractionProspectId"));
					interaction1Item.SetValue<string>("InteractionCustNum", interaction1Item.GetValue<string>("InteractionContactId"));
					interaction1Item.SetValue<string>("InteractionCustNum", interaction1Item.GetValue<string>("InteractionVendNum"));
				};

				Data = interaction1LoadResponse;

			}
			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: convertToUtil.ToGuid(RptSessionID));

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_InteractionsSp(
			string AltExtGenSp,
			string InteractionType = "C",
			decimal? BegInteractionID = null,
			decimal? EndInteractionID = null,
			string BegRefnum = null,
			string EndRefnum = null,
			DateTime? Beginteraction_date = null,
			DateTime? Endinteraction_date = null,
			DateTime? Begfollow_date = null,
			DateTime? Endfollow_date = null,
			string Begentered_by = null,
			string Endentered_by = null,
			string Begsalesman = null,
			string Endsalesman = null,
			string Begcontact = null,
			string Endcontact = null,
			string Begtopic = null,
			string Endtopic = null,
			string CommStat = null,
			string CommSort = null,
			int? StartingTransDateOffset = null,
			int? EndingTransDateOffset = null,
			int? StartingfollowDateOffset = null,
			int? EndingfollowDateOffset = null,
			int? ShowInternal = 0,
			int? ShowExternal = 0,
			int? DisplayHeader = 0,
			string pSite = null)
		{
			InteractionTypeType _InteractionType = InteractionType;
			InteractionIdType _BegInteractionID = BegInteractionID;
			InteractionIdType _EndInteractionID = EndInteractionID;
			CustVendRefNumType _BegRefnum = BegRefnum;
			CustVendRefNumType _EndRefnum = EndRefnum;
			DateTimeType _Beginteraction_date = Beginteraction_date;
			DateTimeType _Endinteraction_date = Endinteraction_date;
			DateTimeType _Begfollow_date = Begfollow_date;
			DateTimeType _Endfollow_date = Endfollow_date;
			UsernameType _Begentered_by = Begentered_by;
			UsernameType _Endentered_by = Endentered_by;
			SlsmanType _Begsalesman = Begsalesman;
			SlsmanType _Endsalesman = Endsalesman;
			ContactType _Begcontact = Begcontact;
			ContactType _Endcontact = Endcontact;
			CommLogTopicType _Begtopic = Begtopic;
			CommLogTopicType _Endtopic = Endtopic;
			InfobarType _CommStat = CommStat;
			StringType _CommSort = CommSort;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			DateOffsetType _StartingfollowDateOffset = StartingfollowDateOffset;
			DateOffsetType _EndingfollowDateOffset = EndingfollowDateOffset;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegInteractionID", _BegInteractionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInteractionID", _EndInteractionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegRefnum", _BegRefnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRefnum", _EndRefnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Beginteraction_date", _Beginteraction_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endinteraction_date", _Endinteraction_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begfollow_date", _Begfollow_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endfollow_date", _Endfollow_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begentered_by", _Begentered_by, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endentered_by", _Endentered_by, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begsalesman", _Begsalesman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endsalesman", _Endsalesman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begcontact", _Begcontact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endcontact", _Endcontact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begtopic", _Begtopic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endtopic", _Endtopic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommStat", _CommStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommSort", _CommSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingfollowDateOffset", _StartingfollowDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingfollowDateOffset", _EndingfollowDateOffset, ParameterDirection.Input);
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
