//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VendorASNReconciliation.cs

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
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.DataCollection;

namespace CSI.Reporting
{
	public class Rpt_VendorASNReconciliation : IRpt_VendorASNReconciliation
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly IAddProcessErrorLog iAddProcessErrorLog;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IReportNotesExist iReportNotesExist;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IUomConvQty iUomConvQty;
		readonly IStringUtil stringUtil;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
		public Rpt_VendorASNReconciliation(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			IAddProcessErrorLog iAddProcessErrorLog,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IReportNotesExist iReportNotesExist,
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IUomConvQty iUomConvQty,
			IStringUtil stringUtil,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.iAddProcessErrorLog = iAddProcessErrorLog;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iReportNotesExist = iReportNotesExist;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iUomConvQty = iUomConvQty;
			this.stringUtil = stringUtil;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_VendorASNReconciliationSp(
			string StartingGrn = null,
			string EndingGrn = null,
			string StartingVendor = null,
			string EndingVendor = null,
			DateTime? StartingHdrDate = null,
			DateTime? EndingHdrDate = null,
			int? ExceptionsOnly = 0,
			int? PrintGrnHdrNotes = 0,
			int? PrintGrnLineNotes = 0,
			int? ShowInternalNotes = 0,
			int? ShowExternalNotes = 0,
			int? StartingHdrDateOffset = null,
			int? EndingHdrDateOffset = null,
			int? DisplayHeader = 1,
			int? TaskId = null,
			string pSite = null,
			int? PrintItemOverview = 0)
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			string GrnHdrVendNum = null;
			string GrnHdrGrnNum = null;
			DateTime? GrnHdrGrnHdrDate = null;
			string GrnHdrShipCode = null;
			DateTime? GrnHdrShippedDate = null;
			Guid? GrnHdrRowpointer = null;
			int? GrnHdrNoteEXISTSFlag = null;
			int? GrnHdrNoteExist = null;
			string GrnHdrTable = null;
			string RecEmployeeName = null;
			Guid? RecEmployeeRowpointer = null;
			string PoitemUM = null;
			string PoitemItem = null;
			Guid? PoitemRowpointer = null;
			decimal? GrnLineQtyShippedConv = null;
			decimal? GrnLineQtyRec = null;
			decimal? GrnLineQtyRej = null;
			string GrnLineGrnNum = null;
			string GrnLineVendNum = null;
			int? GrnLineGrnLine = null;
			string GrnLinePoNum = null;
			int? GrnLinePoLine = null;
			int? GrnLinePoRelease = null;
			string GrnLineUM = null;
			Guid? GrnLineRowpointer = null;
			int? GrnLineNoteEXISTSFlag = null;
			int? GrnLineNoteExist = null;
			string GrnLineTable = null;
			string ShipcodeDescription = null;
			Guid? ShipcodeRowpointer = null;
			Guid? VendorRowpointer = null;
			string InsEmployeeName = null;
			Guid? InsEmployeeRowpointer = null;
			RowPointerType _ItemRowpointer = DBNull.Value;
			Guid? ItemRowpointer = null;
			string VendaddrName = null;
			Guid? VendaddrRowpointer = null;
			int? Severity = null;
			decimal? t_qtu_shipped = null;
			int? P_at_least_one = null;
			string Infobar = null;
			decimal? t_qtu_discrepancy = null;
			int? P_discrepancy = null;
			decimal? convfactor = null;
			string LowCharacter = null;
			string HighCharacter = null;
			string ItemOverview = null;
			ICollectionLoadRequest grn_hdr_vendor_employee_crsLoadRequestForCursor = null;
			ICollectionLoadResponse grn_hdr_vendor_employee_crsLoadResponseForCursor = null;
			int grn_hdr_vendor_employee_crs_CursorFetch_Status = -1;
			int grn_hdr_vendor_employee_crs_CursorCounter = -1;
			ICollectionLoadRequest grn_line_poitem_crsLoadRequestForCursor = null;
			ICollectionLoadResponse grn_line_poitem_crsLoadResponseForCursor = null;
			int grn_line_poitem_crs_CursorFetch_Status = -1;
			int grn_line_poitem_crs_CursorCounter = -1;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_VendorASNReconciliationSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN ");

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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_VendorASNReconciliationSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_VendorASNReconciliationSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("")))
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

					var ALTGEN = AltExtGen_Rpt_VendorASNReconciliationSp(_ALTGEN_SpName,
						StartingGrn,
						EndingGrn,
						StartingVendor,
						EndingVendor,
						StartingHdrDate,
						EndingHdrDate,
						ExceptionsOnly,
						PrintGrnHdrNotes,
						PrintGrnLineNotes,
						ShowInternalNotes,
						ShowExternalNotes,
						StartingHdrDateOffset,
						EndingHdrDateOffset,
						DisplayHeader,
						TaskId,
						pSite,
						PrintItemOverview);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_VendorASNReconciliationSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_VendorASNReconciliationSp("dbo.EXTGEN_Rpt_VendorASNReconciliationSp",
					StartingGrn,
					EndingGrn,
					StartingVendor,
					EndingVendor,
					StartingHdrDate,
					EndingHdrDate,
					ExceptionsOnly,
					PrintGrnHdrNotes,
					PrintGrnLineNotes,
					ShowInternalNotes,
					ShowExternalNotes,
					StartingHdrDateOffset,
					EndingHdrDateOffset,
					DisplayHeader,
					TaskId,
					pSite,
					PrintItemOverview);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("VendorASNReconciliationReport"), "COMMITTED") == true)
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
				ContextName: "Rpt_VendorASNReconciliationSp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			LowCharacter = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
			HighCharacter = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @headerset TABLE (
				    vend_num             NVARCHAR (7)    ,
				    vname                NVARCHAR (60)   ,
				    rec_employee_name    NVARCHAR (50)   ,
				    ins_employee_name    NVARCHAR (50)   ,
				    grn_hdr_date         DATETIME        ,
				    grn_num              NVARCHAR (30)   ,
				    ship_code            NVARCHAR (4)    ,
				    shipcode_description NVARCHAR (40)   ,
				    shipped_date         DATETIME        ,
				    grn_hdr_table        SYSNAME          NULL,
				    grn_hdr_note_exist   TINYINT          NULL,
				    grn_hdr_row_pointer  UNIQUEIDENTIFIER NULL);
				SELECT * into #tv_headerset from @headerset ");

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @detailset TABLE (
				    l_grn_num            NVARCHAR (30)   ,
				    l_vend_num           NVARCHAR (7)    ,
				    grn_line             SMALLINT        ,
				    po_num               NVARCHAR (10)   ,
				    po_line              SMALLINT        ,
				    po_release           SMALLINT        ,
				    item                 NVARCHAR (30)   ,
				    qty_shipped          DECIMAL (19, 8) ,
				    grn_line_u_m         NVARCHAR (3)    ,
				    qty_received         DECIMAL (19, 8) ,
				    poitem_u_m           NVARCHAR (3)    ,
				    qty_rejected         DECIMAL (19, 8) ,
				    qty_discrepancy      DECIMAL (19, 8) ,
				    poline_u_m           NVARCHAR (3)    ,
				    grn_line_table       SYSNAME          NULL,
				    grn_line_note_exist  TINYINT          NULL,
				    grn_line_row_pointer UNIQUEIDENTIFIER NULL,
				    item_overview        NVARCHAR (MAX)  );
				SELECT * into #tv_detailset from @detailset ");

			GrnHdrTable = "grn_hdr";
			GrnLineTable = "grn_line";
			Severity = 0;
			StartingGrn = stringUtil.IsNull(
				StartingGrn,
				LowCharacter);
			EndingGrn = stringUtil.IsNull(
				EndingGrn,
				HighCharacter);
			StartingVendor = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"VendNumType",
					StartingVendor),
				LowCharacter);
			EndingVendor = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"VendNumType",
					EndingVendor),
				HighCharacter);

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: StartingHdrDate,
				Offset: StartingHdrDateOffset,
				IsEndDate: 0);
			StartingHdrDate = ApplyDateOffset.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: EndingHdrDate,
				Offset: EndingHdrDateOffset,
				IsEndDate: 1);
			EndingHdrDate = ApplyDateOffset1.Date;

			#endregion ExecuteMethodCall

			#region Cursor Statement

			#region CRUD LoadToRecord
			grn_hdr_vendor_employee_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"grn_hdr.vend_num","grn_hdr.vend_num"},
					{"grn_hdr.grn_num","grn_hdr.grn_num"},
					{"grn_hdr.grn_hdr_date","grn_hdr.grn_hdr_date"},
					{"grn_hdr.ship_code","grn_hdr.ship_code"},
					{"grn_hdr.shipped_date","grn_hdr.shipped_date"},
					{"grn_hdr.rowpointer","grn_hdr.rowpointer"},
					{"vendor.rowpointer","vendor.rowpointer"},
					{"vendaddr.name","vendaddr.name"},
					{"vendaddr.rowpointer","vendaddr.rowpointer"},
					{"shipcode.description","shipcode.description"},
					{"shipcode.rowpointer","shipcode.rowpointer"},
					{"rec_employee.name","rec_employee.name"},
					{"rec_employee.rowpointer","rec_employee.rowpointer"},
					{"ins_employee.name","ins_employee.name"},
					{"ins_employee.rowpointer","ins_employee.rowpointer"},
					{"grn_hdr.NoteEXISTSFlag","grn_hdr.NoteEXISTSFlag"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "grn_hdr",
				fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN vendor ON vendor.vend_num = grn_hdr.vend_num INNER JOIN vendaddr ON vendaddr.vend_num = grn_hdr.vend_num INNER JOIN shipcode ON shipcode.ship_code = grn_hdr.ship_code LEFT OUTER JOIN employee AS rec_employee ON rec_employee.emp_num = grn_hdr.rec_emp_num LEFT OUTER JOIN employee AS ins_employee ON ins_employee.emp_num = grn_hdr.ins_emp_num"),
				whereClause: collectionLoadRequestFactory.Clause("(grn_hdr.grn_num BETWEEN {4} AND {5}) AND (grn_hdr.grn_hdr_date BETWEEN {0} AND {2}) AND (grn_hdr.vend_num BETWEEN {1} AND {3})", StartingHdrDate, StartingVendor, EndingHdrDate, EndingVendor, StartingGrn, EndingGrn),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			#endregion  LoadToRecord

			#endregion Cursor Statement
			grn_hdr_vendor_employee_crsLoadResponseForCursor = this.appDB.Load(grn_hdr_vendor_employee_crsLoadRequestForCursor);
			grn_hdr_vendor_employee_crs_CursorFetch_Status = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			grn_hdr_vendor_employee_crs_CursorCounter = -1;

			while (sQLUtil.SQLBool(sQLUtil.SQLEqual(1, 1)))
			{
				grn_hdr_vendor_employee_crs_CursorCounter++;
				if (grn_hdr_vendor_employee_crsLoadResponseForCursor.Items.Count > grn_hdr_vendor_employee_crs_CursorCounter)
				{
					GrnHdrVendNum = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(0);
					GrnHdrGrnNum = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(1);
					GrnHdrGrnHdrDate = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<DateTime?>(2);
					GrnHdrShipCode = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(3);
					GrnHdrShippedDate = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<DateTime?>(4);
					GrnHdrRowpointer = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<Guid?>(5);
					VendorRowpointer = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<Guid?>(6);
					VendaddrName = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(7);
					VendaddrRowpointer = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<Guid?>(8);
					ShipcodeDescription = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(9);
					ShipcodeRowpointer = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<Guid?>(10);
					RecEmployeeName = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(11);
					RecEmployeeRowpointer = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<Guid?>(12);
					InsEmployeeName = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<string>(13);
					InsEmployeeRowpointer = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<Guid?>(14);
					GrnHdrNoteEXISTSFlag = grn_hdr_vendor_employee_crsLoadResponseForCursor.Items[grn_hdr_vendor_employee_crs_CursorCounter].GetValue<int?>(15);
				}
				grn_hdr_vendor_employee_crs_CursorFetch_Status = (grn_hdr_vendor_employee_crs_CursorCounter == grn_hdr_vendor_employee_crsLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLNotEqual(grn_hdr_vendor_employee_crs_CursorFetch_Status, 0) == true)
				{
					break;
				}
				GrnHdrNoteExist = 0;
				if (sQLUtil.SQLNotEqual(PrintGrnHdrNotes, 0) == true)
				{
					GrnHdrNoteExist = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn(
						GrnHdrTable,
						GrnHdrRowpointer,
						ShowInternalNotes,
						ShowExternalNotes,
						GrnHdrNoteEXISTSFlag));
				}
				if ((sQLUtil.SQLEqual(PrintGrnHdrNotes, 0) == true))
				{
					GrnHdrRowpointer = null;
				}
				#region Cursor Statement

				#region CRUD LoadToRecord
				grn_line_poitem_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"grn_line.qty_shipped_conv","grn_line.qty_shipped_conv"},
						{"grn_line.qty_rec","grn_line.qty_rec"},
						{"grn_line.qty_rej","grn_line.qty_rej"},
						{"grn_line.grn_num","grn_line.grn_num"},
						{"grn_line.vend_num","grn_line.vend_num"},
						{"grn_line.grn_line","grn_line.grn_line"},
						{"grn_line.po_num","grn_line.po_num"},
						{"grn_line.po_line","grn_line.po_line"},
						{"grn_line.po_release","grn_line.po_release"},
						{"grn_line.u_m","grn_line.u_m"},
						{"grn_line.rowpointer","grn_line.rowpointer"},
						{"poitem.u_m","poitem.u_m"},
						{"poitem.item","poitem.item"},
						{"poitem.rowpointer","poitem.rowpointer"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "grn_line",
					fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN poitem ON poitem.po_num = grn_line.po_num 
						AND poitem.po_line = grn_line.po_line 
						AND poitem.po_release = grn_line.po_release"),
					whereClause: collectionLoadRequestFactory.Clause("grn_line.vend_num = {0} AND grn_line.grn_num = {1}", GrnHdrVendNum, GrnHdrGrnNum),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				#endregion Cursor Statement
				grn_line_poitem_crsLoadResponseForCursor = this.appDB.Load(grn_line_poitem_crsLoadRequestForCursor);
				grn_line_poitem_crs_CursorFetch_Status = grn_line_poitem_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				grn_line_poitem_crs_CursorCounter = -1;

				while (sQLUtil.SQLEqual(1, 1) == true)
				{
					grn_line_poitem_crs_CursorCounter++;
					if (grn_line_poitem_crsLoadResponseForCursor.Items.Count > grn_line_poitem_crs_CursorCounter)
					{
						GrnLineQtyShippedConv = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<decimal?>(0);
						GrnLineQtyRec = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<decimal?>(1);
						GrnLineQtyRej = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<decimal?>(2);
						GrnLineGrnNum = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(3);
						GrnLineVendNum = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(4);
						GrnLineGrnLine = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(5);
						GrnLinePoNum = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(6);
						GrnLinePoLine = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(7);
						GrnLinePoRelease = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(8);
						GrnLineUM = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(9);
						GrnLineRowpointer = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<Guid?>(10);
						PoitemUM = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(11);
						PoitemItem = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(12);
						PoitemRowpointer = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<Guid?>(13);
					}
					grn_line_poitem_crs_CursorFetch_Status = (grn_line_poitem_crs_CursorCounter == grn_line_poitem_crsLoadResponseForCursor.Items.Count ? -1 : 0);

					if (sQLUtil.SQLNotEqual(grn_line_poitem_crs_CursorFetch_Status, 0) == true)
					{
						break;
					}
					t_qtu_shipped = 0;
					P_at_least_one = 1;

					#region CRUD ExecuteFunctionCall

					//Please Generate the bounce for this function: Getumcf
					convfactor = this.iGetumcf.GetumcfFn(
						PoitemUM,
						PoitemItem,
						GrnHdrVendNum,
						"P");
					#endregion ExecuteFunctionCall

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: UomConvQtySp
					var UomConvQty = this.iUomConvQty.UomConvQtySp(
						QtyToBeConverted: GrnLineQtyShippedConv,
						UomConvFactor: convfactor,
						FROMBase: "To Base",
						ConvertedQty: t_qtu_shipped,
						Infobar: Infobar);
					Severity = UomConvQty.ReturnCode;
					t_qtu_shipped = UomConvQty.ConvertedQty;
					Infobar = UomConvQty.Infobar;

					#endregion ExecuteMethodCall

					if (sQLUtil.SQLNotEqual(Severity, 0) == true)
					{
						goto END_OF_PROG;
					}
					t_qtu_discrepancy = (decimal?)(t_qtu_shipped - (GrnLineQtyRec + GrnLineQtyRej));
					if (sQLUtil.SQLNotEqual(t_qtu_discrepancy, 0) == true)
					{
						P_discrepancy = 1;

						break;
					}
				}
				//Deallocate Cursor grn_line_poitem_crs
				if (sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLAnd((sQLUtil.SQLEqual(ExceptionsOnly, 1)), (sQLUtil.SQLNot(sQLUtil.SQLEqual(P_discrepancy, 1)))), (sQLUtil.SQLAnd((sQLUtil.SQLNot(sQLUtil.SQLEqual(ExceptionsOnly, 1))), (sQLUtil.SQLNot(sQLUtil.SQLEqual(P_at_least_one, 1))))))))
				{
					continue;
				}

				#region CRUD LoadResponseWithoutTable
				var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "vend_num", variableUtil.GetValue<string>(GrnHdrVendNum,true)},
					{ "vname", variableUtil.GetValue<string>(VendaddrName,true)},
					{ "rec_employee_name", variableUtil.GetValue<string>(RecEmployeeName,true)},
					{ "ins_employee_name", variableUtil.GetValue<string>(InsEmployeeName,true)},
					{ "grn_hdr_date", variableUtil.GetValue<DateTime?>(GrnHdrGrnHdrDate,true)},
					{ "grn_num", variableUtil.GetValue<string>(GrnHdrGrnNum,true)},
					{ "ship_code", variableUtil.GetValue<string>(GrnHdrShipCode,true)},
					{ "shipcode_description", variableUtil.GetValue<string>(ShipcodeDescription,true)},
					{ "shipped_date", variableUtil.GetValue<DateTime?>(GrnHdrShippedDate,true)},
					{ "grn_hdr_table", variableUtil.GetValue<string>(GrnHdrTable,true)},
					{ "grn_hdr_note_exist", variableUtil.GetValue<int?>(GrnHdrNoteExist,true)},
					{ "grn_hdr_row_pointer", variableUtil.GetValue<Guid?>(GrnHdrRowpointer,true)},
				});

				var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
				Data = nonTableLoadResponse;
				#endregion CRUD LoadResponseWithoutTable

				#region CRUD InsertByRecords
				var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_HeaderSet",
				items: nonTableLoadResponse.Items);

				this.appDB.Insert(nonTableInsertRequest);
				#endregion InsertByRecords

				#region Cursor Statement

				#region CRUD LoadToRecord
				grn_line_poitem_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"qty_shipped_conv","grn_line.qty_shipped_conv"},
						{"qty_rec","grn_line.qty_rec"},
						{"qty_rej","grn_line.qty_rej"},
						{"grn_num","grn_line.grn_num"},
						{"vend_num","grn_line.vend_num"},
						{"grn_line","grn_line.grn_line"},
						{"po_num","grn_line.po_num"},
						{"po_line","grn_line.po_line"},
						{"po_release","grn_line.po_release"},
						{"u_m","grn_line.u_m"},
						{"rowpointer","grn_line.rowpointer"},
						{"u_m_","poitem.u_m"},
						{"item","poitem.item"},
						{"rowpointer_","poitem.rowpointer"},
						{"NoteEXISTSFlag","grn_line.NoteEXISTSFlag"},
						{"col0",$"CAST (NULL AS NVARCHAR)"},
						{"u0","item_lang.overview"},
						{"u1","item.overview"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "grn_line",
					fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN poitem ON (poitem.po_num = grn_line.po_num) 
						AND (poitem.po_line = grn_line.po_line) 
						AND (poitem.po_release = grn_line.po_release) LEFT OUTER JOIN vendor ON poitem.po_vend_num = vendor.vend_num LEFT OUTER JOIN item ON poitem.item = item.item LEFT OUTER JOIN item_lang ON item_lang.item = poitem.item 
						AND item_lang.lang_code = vendor.lang_code"),
					whereClause: collectionLoadRequestFactory.Clause("(grn_line.grn_num = {1}) AND (grn_line.vend_num = {0})", GrnHdrVendNum, GrnHdrGrnNum),
					orderByClause: collectionLoadRequestFactory.Clause(" grn_line.grn_num"));
				#endregion  LoadToRecord

				#endregion Cursor Statement
				grn_line_poitem_crsLoadResponseForCursor = this.appDB.Load(grn_line_poitem_crsLoadRequestForCursor);
				foreach (var grn_line1Item in grn_line_poitem_crsLoadResponseForCursor.Items)
				{
					grn_line1Item.SetValue<decimal?>("qty_shipped_conv", grn_line1Item.GetValue<decimal?>("qty_shipped_conv"));
					grn_line1Item.SetValue<decimal?>("qty_rec", grn_line1Item.GetValue<decimal?>("qty_rec"));
					grn_line1Item.SetValue<decimal?>("qty_rej", grn_line1Item.GetValue<decimal?>("qty_rej"));
					grn_line1Item.SetValue<string>("grn_num", grn_line1Item.GetValue<string>("grn_num"));
					grn_line1Item.SetValue<string>("vend_num", grn_line1Item.GetValue<string>("vend_num"));
					grn_line1Item.SetValue<int?>("grn_line", grn_line1Item.GetValue<int?>("grn_line"));
					grn_line1Item.SetValue<string>("po_num", grn_line1Item.GetValue<string>("po_num"));
					grn_line1Item.SetValue<int?>("po_line", grn_line1Item.GetValue<int?>("po_line"));
					grn_line1Item.SetValue<int?>("po_release", grn_line1Item.GetValue<int?>("po_release"));
					grn_line1Item.SetValue<string>("u_m", grn_line1Item.GetValue<string>("u_m"));
					grn_line1Item.SetValue<Guid?>("rowpointer", grn_line1Item.GetValue<Guid?>("rowpointer"));
					grn_line1Item.SetValue<string>("u_m_", grn_line1Item.GetValue<string>("u_m_"));
					grn_line1Item.SetValue<string>("item", grn_line1Item.GetValue<string>("item"));
					grn_line1Item.SetValue<Guid?>("rowpointer_", grn_line1Item.GetValue<Guid?>("rowpointer_"));
					grn_line1Item.SetValue<int?>("NoteEXISTSFlag", grn_line1Item.GetValue<int?>("NoteEXISTSFlag"));
					grn_line1Item.SetValue<string>("col0", stringUtil.Left(stringUtil.IsNull(
						grn_line1Item.GetValue<string>("u0"),
						grn_line1Item.GetValue<string>("u1")), 100));
				};

				grn_line_poitem_crs_CursorFetch_Status = grn_line_poitem_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				grn_line_poitem_crs_CursorCounter = -1;

				while (sQLUtil.SQLBool(sQLUtil.SQLEqual(1, 1)))
				{
					grn_line_poitem_crs_CursorCounter++;
					if (grn_line_poitem_crsLoadResponseForCursor.Items.Count > grn_line_poitem_crs_CursorCounter)
					{
						GrnLineQtyShippedConv = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<decimal?>(0);
						GrnLineQtyRec = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<decimal?>(1);
						GrnLineQtyRej = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<decimal?>(2);
						GrnLineGrnNum = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(3);
						GrnLineVendNum = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(4);
						GrnLineGrnLine = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(5);
						GrnLinePoNum = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(6);
						GrnLinePoLine = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(7);
						GrnLinePoRelease = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(8);
						GrnLineUM = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(9);
						GrnLineRowpointer = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<Guid?>(10);
						PoitemUM = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(11);
						PoitemItem = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(12);
						PoitemRowpointer = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<Guid?>(13);
						GrnLineNoteEXISTSFlag = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<int?>(14);
						ItemOverview = grn_line_poitem_crsLoadResponseForCursor.Items[grn_line_poitem_crs_CursorCounter].GetValue<string>(15);
					}
					grn_line_poitem_crs_CursorFetch_Status = (grn_line_poitem_crs_CursorCounter == grn_line_poitem_crsLoadResponseForCursor.Items.Count ? -1 : 0);

					if (sQLUtil.SQLNotEqual(grn_line_poitem_crs_CursorFetch_Status, 0) == true)
					{
						break;
					}
					GrnLineNoteExist = 0;
					if (sQLUtil.SQLNotEqual(PrintGrnLineNotes, 0) == true)
					{
						GrnLineNoteExist = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn(
							GrnLineTable,
							GrnLineRowpointer,
							ShowInternalNotes,
							ShowExternalNotes,
							GrnLineNoteEXISTSFlag));
					}
					if ((sQLUtil.SQLEqual(PrintGrnLineNotes, 0) == true))
					{
						GrnLineRowpointer = null;
					}

					#region CRUD LoadToVariable
					var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ItemRowpointer,"item.rowpointer"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "item",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", PoitemItem),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var itemLoadResponse = this.appDB.Load(itemLoadRequest);
					if (itemLoadResponse.Items.Count > 0)
					{
						ItemRowpointer = _ItemRowpointer;
					}
					#endregion  LoadToVariable

					if (sQLUtil.SQLNotEqual(itemLoadResponse.Items.Count, 1) == true)
					{
						ItemRowpointer = null;
					}
					t_qtu_shipped = 0;
					t_qtu_discrepancy = 0;

					#region CRUD ExecuteFunctionCall

					//Please Generate the bounce for this function: Getumcf
					convfactor = this.iGetumcf.GetumcfFn(
						PoitemUM,
						PoitemItem,
						GrnHdrVendNum,
						"P");
					#endregion ExecuteFunctionCall

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: UomConvQtySp
					var UomConvQty1 = this.iUomConvQty.UomConvQtySp(
						QtyToBeConverted: GrnLineQtyShippedConv,
						UomConvFactor: convfactor,
						FROMBase: "To Base",
						ConvertedQty: t_qtu_shipped,
						Infobar: Infobar);
					Severity = UomConvQty1.ReturnCode;
					t_qtu_shipped = UomConvQty1.ConvertedQty;
					Infobar = UomConvQty1.Infobar;

					#endregion ExecuteMethodCall

					if (sQLUtil.SQLNotEqual(Severity, 0) == true)
					{
						goto END_OF_PROG;
					}
					t_qtu_discrepancy = (decimal?)(t_qtu_shipped - (GrnLineQtyRec + GrnLineQtyRej));
					if (sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLAnd((sQLUtil.SQLEqual(ExceptionsOnly, 1)), (sQLUtil.SQLNotEqual(t_qtu_discrepancy, 0))), (sQLUtil.SQLNot(sQLUtil.SQLEqual(ExceptionsOnly, 1))))))
					{
						#region CRUD LoadResponseWithoutTable
						var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
						{
							{ "l_grn_num", variableUtil.GetValue<string>(GrnLineGrnNum,true)},
							{ "l_vend_num", variableUtil.GetValue<string>(GrnLineVendNum,true)},
							{ "grn_line", variableUtil.GetValue<int?>(GrnLineGrnLine,true)},
							{ "po_num", variableUtil.GetValue<string>(GrnLinePoNum,true)},
							{ "po_line", variableUtil.GetValue<int?>(GrnLinePoLine,true)},
							{ "po_release", variableUtil.GetValue<int?>(GrnLinePoRelease,true)},
							{ "item", variableUtil.GetValue<string>(PoitemItem,true)},
							{ "qty_shipped", variableUtil.GetValue<decimal?>(GrnLineQtyShippedConv,true)},
							{ "grn_line_u_m", variableUtil.GetValue<string>(GrnLineUM,true)},
							{ "qty_received", variableUtil.GetValue<decimal?>(GrnLineQtyRec,true)},
							{ "Poitem_u_m", variableUtil.GetValue<string>(PoitemUM,true)},
							{ "qty_rejected", variableUtil.GetValue<decimal?>(GrnLineQtyRej,true)},
							{ "qty_discrepancy", variableUtil.GetValue<decimal?>(t_qtu_discrepancy,true)},
							{ "PoLine_u_m", variableUtil.GetValue<string>(PoitemUM,true)},
							{ "grn_line_table", variableUtil.GetValue<string>(GrnLineTable,true)},
							{ "grn_line_note_exist", variableUtil.GetValue<int?>(GrnLineNoteExist,true)},
							{ "grn_line_row_pointer", variableUtil.GetValue<Guid?>(GrnLineRowpointer,true)},
							{ "item_overview", variableUtil.GetValue<string>(ItemOverview,true)},
						});

						var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
						Data = nonTable1LoadResponse;
						#endregion CRUD LoadResponseWithoutTable

						#region CRUD InsertByRecords
						var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_DetailSet",
						items: nonTable1LoadResponse.Items);

						this.appDB.Insert(nonTable1InsertRequest);
						#endregion InsertByRecords
					}
				}
				//Deallocate Cursor grn_line_poitem_crs
			}
		//Deallocate Cursor grn_hdr_vendor_employee_crs
		END_OF_PROG:;
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (TaskId != null)
				{
					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: AddProcessErrorLogSp
					var AddProcessErrorLog = this.iAddProcessErrorLog.AddProcessErrorLogSp(
						ProcessID: TaskId,
						InfobarText: Infobar,
						MessageSeverity: Severity);

					#endregion ExecuteMethodCall
				}
			}

			#region CRUD LoadToRecord
			var tv_HeaderSetLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"vend_num","#tv_HeaderSet.vend_num"},
					{"vname","#tv_HeaderSet.vname"},
					{"rec_employee_name","#tv_HeaderSet.rec_employee_name"},
					{"ins_employee_name","#tv_HeaderSet.ins_employee_name"},
					{"grn_hdr_date","#tv_HeaderSet.grn_hdr_date"},
					{"grn_num","#tv_HeaderSet.grn_num"},
					{"ship_code","#tv_HeaderSet.ship_code"},
					{"shipcode_description","#tv_HeaderSet.shipcode_description"},
					{"shipped_date","#tv_HeaderSet.shipped_date"},
					{"grn_hdr_table","#tv_HeaderSet.grn_hdr_table"},
					{"grn_hdr_note_exist","#tv_HeaderSet.grn_hdr_note_exist"},
					{"grn_hdr_row_pointer","#tv_HeaderSet.grn_hdr_row_pointer"},
					{"l_grn_num","#tv_DetailSet.l_grn_num"},
					{"l_vend_num","#tv_DetailSet.l_vend_num"},
					{"grn_line","#tv_DetailSet.grn_line"},
					{"po_num","#tv_DetailSet.po_num"},
					{"po_line","#tv_DetailSet.po_line"},
					{"po_release","#tv_DetailSet.po_release"},
					{"item","#tv_DetailSet.item"},
					{"qty_shipped","#tv_DetailSet.qty_shipped"},
					{"grn_line_u_m","#tv_DetailSet.grn_line_u_m"},
					{"qty_received","#tv_DetailSet.qty_received"},
					{"poitem_u_m","#tv_DetailSet.poitem_u_m"},
					{"qty_rejected","#tv_DetailSet.qty_rejected"},
					{"qty_discrepancy","#tv_DetailSet.qty_discrepancy"},
					{"poline_u_m","#tv_DetailSet.poline_u_m"},
					{"grn_line_table","#tv_DetailSet.grn_line_table"},
					{"grn_line_note_exist","#tv_DetailSet.grn_line_note_exist"},
					{"grn_line_row_pointer","#tv_DetailSet.grn_line_row_pointer"},
					{"item_overview","#tv_DetailSet.item_overview"},
					{"line_releas","CAST (NULL AS NVARCHAR)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_HeaderSet",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN #tv_DetailSet ON (l_grn_num = grn_num) 
					AND (l_vend_num = vend_num)"),
				whereClause: collectionLoadRequestFactory.Clause("{0} = 0", Severity),
				orderByClause: collectionLoadRequestFactory.Clause(" vend_num"));
			var tv_HeaderSetLoadResponse = this.appDB.Load(tv_HeaderSetLoadRequest);
			#endregion  LoadToRecord

			foreach (var tv_HeaderSetItem in tv_HeaderSetLoadResponse.Items)
			{
				tv_HeaderSetItem.SetValue<string>("vend_num", tv_HeaderSetItem.GetValue<string>("vend_num"));
				tv_HeaderSetItem.SetValue<string>("vname", tv_HeaderSetItem.GetValue<string>("vname"));
				tv_HeaderSetItem.SetValue<string>("rec_employee_name", tv_HeaderSetItem.GetValue<string>("rec_employee_name"));
				tv_HeaderSetItem.SetValue<string>("ins_employee_name", tv_HeaderSetItem.GetValue<string>("ins_employee_name"));
				tv_HeaderSetItem.SetValue<DateTime?>("grn_hdr_date", tv_HeaderSetItem.GetValue<DateTime?>("grn_hdr_date"));
				tv_HeaderSetItem.SetValue<string>("grn_num", tv_HeaderSetItem.GetValue<string>("grn_num"));
				tv_HeaderSetItem.SetValue<string>("ship_code", tv_HeaderSetItem.GetValue<string>("ship_code"));
				tv_HeaderSetItem.SetValue<string>("shipcode_description", tv_HeaderSetItem.GetValue<string>("shipcode_description"));
				tv_HeaderSetItem.SetValue<DateTime?>("shipped_date", tv_HeaderSetItem.GetValue<DateTime?>("shipped_date"));
				tv_HeaderSetItem.SetValue<string>("grn_hdr_table", tv_HeaderSetItem.GetValue<string>("grn_hdr_table"));
				tv_HeaderSetItem.SetValue<int?>("grn_hdr_note_exist", tv_HeaderSetItem.GetValue<int?>("grn_hdr_note_exist"));
				tv_HeaderSetItem.SetValue<Guid?>("grn_hdr_row_pointer", tv_HeaderSetItem.GetValue<Guid?>("grn_hdr_row_pointer"));
				tv_HeaderSetItem.SetValue<string>("l_grn_num", tv_HeaderSetItem.GetValue<string>("l_grn_num"));
				tv_HeaderSetItem.SetValue<string>("l_vend_num", tv_HeaderSetItem.GetValue<string>("l_vend_num"));
				tv_HeaderSetItem.SetValue<int?>("grn_line", tv_HeaderSetItem.GetValue<int?>("grn_line"));
				tv_HeaderSetItem.SetValue<string>("po_num", tv_HeaderSetItem.GetValue<string>("po_num"));
				tv_HeaderSetItem.SetValue<int?>("po_line", tv_HeaderSetItem.GetValue<int?>("po_line"));
				tv_HeaderSetItem.SetValue<int?>("po_release", tv_HeaderSetItem.GetValue<int?>("po_release"));
				tv_HeaderSetItem.SetValue<string>("item", tv_HeaderSetItem.GetValue<string>("item"));
				tv_HeaderSetItem.SetValue<decimal?>("qty_shipped", tv_HeaderSetItem.GetValue<decimal?>("qty_shipped"));
				tv_HeaderSetItem.SetValue<string>("grn_line_u_m", tv_HeaderSetItem.GetValue<string>("grn_line_u_m"));
				tv_HeaderSetItem.SetValue<decimal?>("qty_received", tv_HeaderSetItem.GetValue<decimal?>("qty_received"));
				tv_HeaderSetItem.SetValue<string>("poitem_u_m", tv_HeaderSetItem.GetValue<string>("poitem_u_m"));
				tv_HeaderSetItem.SetValue<decimal?>("qty_rejected", tv_HeaderSetItem.GetValue<decimal?>("qty_rejected"));
				tv_HeaderSetItem.SetValue<decimal?>("qty_discrepancy", tv_HeaderSetItem.GetValue<decimal?>("qty_discrepancy"));
				tv_HeaderSetItem.SetValue<string>("poline_u_m", tv_HeaderSetItem.GetValue<string>("poline_u_m"));
				tv_HeaderSetItem.SetValue<string>("grn_line_table", tv_HeaderSetItem.GetValue<string>("grn_line_table"));
				tv_HeaderSetItem.SetValue<int?>("grn_line_note_exist", tv_HeaderSetItem.GetValue<int?>("grn_line_note_exist"));
				tv_HeaderSetItem.SetValue<Guid?>("grn_line_row_pointer", tv_HeaderSetItem.GetValue<Guid?>("grn_line_row_pointer"));
				tv_HeaderSetItem.SetValue<string>("item_overview", tv_HeaderSetItem.GetValue<string>("item_overview"));
				tv_HeaderSetItem.SetValue<string>("line_releas", (tv_HeaderSetItem.GetValue<string>("item") != null && tv_HeaderSetItem.GetValue<int?>("po_release") != null && sQLUtil.SQLNotEqual(tv_HeaderSetItem.GetValue<int?>("po_release"), 0) == true ? stringUtil.Concat(
					stringUtil.IsNull(
						tv_HeaderSetItem.GetValue<int?>("po_line"),
						0),
					"-",
					tv_HeaderSetItem.GetValue<int?>("po_release")) :
				tv_HeaderSetItem.GetValue<string>("item") != null && (tv_HeaderSetItem.GetValue<int?>("po_release") == null || sQLUtil.SQLEqual(tv_HeaderSetItem.GetValue<int?>("po_release"), 0) == true) ? Convert.ToString(stringUtil.IsNull<int?>(
					tv_HeaderSetItem.GetValue<int?>("po_line"),
					0)) : convertToUtil.ToString<int?>(null)));
			};

			Data = tv_HeaderSetLoadResponse;

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_VendorASNReconciliationSp(
			string AltExtGenSp,
			string StartingGrn = null,
			string EndingGrn = null,
			string StartingVendor = null,
			string EndingVendor = null,
			DateTime? StartingHdrDate = null,
			DateTime? EndingHdrDate = null,
			int? ExceptionsOnly = 0,
			int? PrintGrnHdrNotes = 0,
			int? PrintGrnLineNotes = 0,
			int? ShowInternalNotes = 0,
			int? ShowExternalNotes = 0,
			int? StartingHdrDateOffset = null,
			int? EndingHdrDateOffset = null,
			int? DisplayHeader = 1,
			int? TaskId = null,
			string pSite = null,
			int? PrintItemOverview = 0)
		{
			GrnNumType _StartingGrn = StartingGrn;
			GrnNumType _EndingGrn = EndingGrn;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			DateType _StartingHdrDate = StartingHdrDate;
			DateType _EndingHdrDate = EndingHdrDate;
			ListYesNoType _ExceptionsOnly = ExceptionsOnly;
			ListYesNoType _PrintGrnHdrNotes = PrintGrnHdrNotes;
			ListYesNoType _PrintGrnLineNotes = PrintGrnLineNotes;
			ListYesNoType _ShowInternalNotes = ShowInternalNotes;
			ListYesNoType _ShowExternalNotes = ShowExternalNotes;
			DateOffsetType _StartingHdrDateOffset = StartingHdrDateOffset;
			DateOffsetType _EndingHdrDateOffset = EndingHdrDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			ListYesNoType _PrintItemOverview = PrintItemOverview;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "StartingGrn", _StartingGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGrn", _EndingGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingHdrDate", _StartingHdrDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingHdrDate", _EndingHdrDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptionsOnly", _ExceptionsOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintGrnHdrNotes", _PrintGrnHdrNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintGrnLineNotes", _PrintGrnLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternalNotes", _ShowInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternalNotes", _ShowExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingHdrDateOffset", _StartingHdrDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingHdrDateOffset", _EndingHdrDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);

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
