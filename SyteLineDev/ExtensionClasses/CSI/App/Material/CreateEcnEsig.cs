//PROJECT NAME: Material
//CLASS NAME: CreateEcnEsig.cs

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

namespace CSI.Material
{
	public class CreateEcnEsig : ICreateEcnEsig
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IInterpretText iInterpretText;
		readonly IStringUtil stringUtil;
		readonly IGetLabel iGetLabel;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICreateEcnEsigCRUD iCreateEcnEsigCRUD;

		public CreateEcnEsig(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IInterpretText iInterpretText,
			IStringUtil stringUtil,
			IGetLabel iGetLabel,
			ISQLValueComparerUtil sQLUtil,
			ICreateEcnEsigCRUD iCreateEcnEsigCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.iInterpretText = iInterpretText;
			this.stringUtil = stringUtil;
			this.iGetLabel = iGetLabel;
			this.sQLUtil = sQLUtil;
			this.iCreateEcnEsigCRUD = iCreateEcnEsigCRUD;
		}

		public (
			int? ReturnCode,
			Guid? EsigRowpointer)
		CreateEcnEsigSp(
			string UserName,
			string ReasonCode,
			string ECNNum,
			Guid? EsigRowpointer)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			string UserDesc = null;
			string ReasonDescription = null;
			string Stat = null;
			string Orig = null;
			string ReqDate = null;
			string AppDate = null;
			string EffectDate = null;
			string CompDate = null;
			string PriorCode = null;
			string PriDescription = null;
			string EcnReasonCode = null;
			string EcnReasonDescription = null;
			string DistCode = null;
			string DistDescription = null;
			string EcnLine = null;
			string Job = null;
			string Suffix = null;
			string ECNItemTypeCode = null;
			string ECNItemType = null;
			string ActionCode = null;
			string EcniGroup = null;
			string Item = null;
			string ItemDescription = null;
			string ItemStat = null;
			string Revision = null;
			string OperNum = null;
			string WC = null;
			string WCDescription = null;
			string BflushType = null;
			string SchedHrs = null;
			string RunBasisMch = null;
			string RunMchHours = null;
			string RunBasisLbr = null;
			string RunLbrHours = null;
			string MoveHrs = null;
			string QueueHrs = null;
			string SetupHrs = null;
			string FinishHrs = null;
			string OffsetHrs = null;
			string ObsDate = null;
			string SpecificNoteContent = null;
			string SystemNoteContent = null;
			string UserNoteContent = null;
			string SpecificNoteDesc = null;
			string SystemNoteDesc = null;
			string UserNoteDesc = null;
			string MatlItem = null;
			string MatlDescription = null;
			string AltGroup = null;
			string AltGroupRank = null;
			string Sequence = null;
			string MatlType = null;
			string MatlQtyConv = null;
			string Units = null;
			string UM = null;
			string BOMSeq = null;
			string Feature = null;
			string FeatureDescription = null;
			string OptCode = null;
			string Probable = null;
			string IncPrice = null;
			string MatlCostConv = null;
			string LbrCostConv = null;
			string FovhdCostConv = null;
			string VovhdCostConv = null;
			string OutCostConv = null;
			string CostConv = null;
			string RefSeq = null;
			string Bubble = null;
			string RefDes = null;
			string AssySeq = null;
			string EstimateOperation = null;
			string EstimateReference = null;
			string CurrentMaterial = null;
			string CurrentReference = null;
			int? Counter = null;
			int? Enabled = null;
			int? Severity = null;
			string Infobar = null;
			ICollectionLoadResponse ecn_crsLoadResponseForCursor = null;
			int ecn_crs_CursorFetch_Status = -1;
			int ecn_crs_CursorCounter = -1;
			if (this.iCreateEcnEsigCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCreateEcnEsigCRUD.Optional_Module1Select();
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CreateEcnEsigSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCreateEcnEsigCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCreateEcnEsigCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCreateEcnEsigCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCreateEcnEsigCRUD.AltExtGen_CreateEcnEsigSp(ALTGEN_SpName,
						UserName,
						ReasonCode,
						ECNNum,
						EsigRowpointer);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, EsigRowpointer);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCreateEcnEsigCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCreateEcnEsigCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CreateEcnEsigSp") != null)
			{
				var EXTGEN = this.iCreateEcnEsigCRUD.AltExtGen_CreateEcnEsigSp("dbo.EXTGEN_CreateEcnEsigSp",
					UserName,
					ReasonCode,
					ECNNum,
					EsigRowpointer);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.EsigRowpointer);
				}
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InterpretTextSp
			var InterpretText = this.iInterpretText.InterpretTextSp(
				Text: "FORMAT(sEstimateOperation)",
				InterpretedText: EstimateOperation,
				Infobar: Infobar);
			Severity = InterpretText.ReturnCode;
			EstimateOperation = InterpretText.InterpretedText;
			Infobar = InterpretText.Infobar;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InterpretTextSp
			var InterpretText1 = this.iInterpretText.InterpretTextSp(
				Text: "FORMAT(sCurrentMaterial)",
				InterpretedText: CurrentMaterial,
				Infobar: Infobar);
			Severity = InterpretText1.ReturnCode;
			CurrentMaterial = InterpretText1.InterpretedText;
			Infobar = InterpretText1.Infobar;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InterpretTextSp
			var InterpretText2 = this.iInterpretText.InterpretTextSp(
				Text: "FORMAT(sCurrentMaterial)",
				InterpretedText: CurrentMaterial,
				Infobar: Infobar);
			Severity = InterpretText2.ReturnCode;
			CurrentMaterial = InterpretText2.InterpretedText;
			Infobar = InterpretText2.Infobar;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InterpretTextSp
			var InterpretText3 = this.iInterpretText.InterpretTextSp(
				Text: "FORMAT(sCurrentReference)",
				InterpretedText: CurrentReference,
				Infobar: Infobar);
			Severity = InterpretText3.ReturnCode;
			CurrentReference = InterpretText3.InterpretedText;
			Infobar = InterpretText3.Infobar;

			#endregion ExecuteMethodCall

			(Enabled, rowCount) = this.iCreateEcnEsigCRUD.Esig_TypeLoad(Severity, EstimateOperation, Infobar, CurrentMaterial, CurrentReference, Enabled);
			if (sQLUtil.SQLEqual(Enabled, 0) == true)
			{
				return (Severity = 0, EsigRowpointer);

			}
			(UserDesc, rowCount) = this.iCreateEcnEsigCRUD.UsernamesLoad(UserName, UserDesc);
			(ReasonDescription, rowCount) = this.iCreateEcnEsigCRUD.ReasonLoad(ReasonCode, ReasonDescription);
			EsigRowpointer = Guid.NewGuid();
			var nonTableLoadResponse = this.iCreateEcnEsigCRUD.NontableSelect(UserName, UserDesc, ReasonCode, ReasonDescription, EsigRowpointer);
			this.iCreateEcnEsigCRUD.NontableInsert(nonTableLoadResponse);
			Counter = 0;
			#region Cursor Statement
			ecn_crsLoadResponseForCursor = this.iCreateEcnEsigCRUD.EcnSelect(ECNNum);
			#endregion Cursor Statement
			foreach (var ecnItem in ecn_crsLoadResponseForCursor.Items)
			{
				ecnItem.SetValue<int?>("ecn_num", ecnItem.GetValue<int?>("ecn_num"));
				ecnItem.SetValue<string>("col0", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u0"), "H") == true ? this.iGetLabel.GetLabelFn("@:EcnStatus:H") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u0"), "C") == true ? this.iGetLabel.GetLabelFn("@:EcnStatus:C") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u0"), "A") == true ? this.iGetLabel.GetLabelFn("@:EcnStatus:A") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u0"), "R") == true ? this.iGetLabel.GetLabelFn("@:EcnStatus:R") : null));
				ecnItem.SetValue<string>("orig", ecnItem.GetValue<string>("orig"));
				ecnItem.SetValue<DateTime?>("req_date", ecnItem.GetValue<DateTime?>("req_date"));
				ecnItem.SetValue<DateTime?>("app_date", ecnItem.GetValue<DateTime?>("app_date"));
				ecnItem.SetValue<DateTime?>("effect_date", ecnItem.GetValue<DateTime?>("effect_date"));
				ecnItem.SetValue<DateTime?>("comp_date", ecnItem.GetValue<DateTime?>("comp_date"));
				ecnItem.SetValue<string>("prior_code", ecnItem.GetValue<string>("prior_code"));
				ecnItem.SetValue<string>("description", ecnItem.GetValue<string>("description"));
				ecnItem.SetValue<string>("reason_code", ecnItem.GetValue<string>("reason_code"));
				ecnItem.SetValue<string>("description_", ecnItem.GetValue<string>("description_"));
				ecnItem.SetValue<string>("dist_code", ecnItem.GetValue<string>("dist_code"));
				ecnItem.SetValue<string>("description__", ecnItem.GetValue<string>("description__"));
				ecnItem.SetValue<int?>("ecn_line", ecnItem.GetValue<int?>("ecn_line"));
				ecnItem.SetValue<string>("job", ecnItem.GetValue<string>("job"));
				ecnItem.SetValue<int?>("suffix", ecnItem.GetValue<int?>("suffix"));
				ecnItem.SetValue<string>("ecnitem_type", ecnItem.GetValue<string>("ecnitem_type"));
				ecnItem.SetValue<string>("col1", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "EM") == true ? this.iGetLabel.GetLabelFn("@EstimateMaterial") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "EO") == true ? EstimateOperation : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "ER") == true ? EstimateReference : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "CM") == true ? CurrentMaterial : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "CO") == true ? this.iGetLabel.GetLabelFn("@jobroute-s") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "CR") == true ? CurrentReference : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "JM") == true ? this.iGetLabel.GetLabelFn("@jobmatl") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "JO") == true ? this.iGetLabel.GetLabelFn("@jobroute") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("ecnitem_type"), "JR") == true ? this.iGetLabel.GetLabelFn("@job_ref") : null));
				ecnItem.SetValue<string>("col2", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u1"), "A") == true ? this.iGetLabel.GetLabelFn("@%add") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u1"), "U") == true ? this.iGetLabel.GetLabelFn("@%update") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u1"), "D") == true ? this.iGetLabel.GetLabelFn("@%delete") : null));
				ecnItem.SetValue<string>("ecni_group", ecnItem.GetValue<string>("ecni_group"));
				ecnItem.SetValue<string>("item", ecnItem.GetValue<string>("item"));
				ecnItem.SetValue<string>("description___", ecnItem.GetValue<string>("description___"));
				ecnItem.SetValue<string>("col3", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u2"), "R") == true ? this.iGetLabel.GetLabelFn("@:EcnItemStatus:R") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u2"), "A") == true ? this.iGetLabel.GetLabelFn("@:EcnItemStatus:A") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u2"), "N") == true ? this.iGetLabel.GetLabelFn("@:EcnItemStatus:N") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u2"), "H") == true ? this.iGetLabel.GetLabelFn("@:EcnItemStatus:R") : null));
				ecnItem.SetValue<string>("revision", ecnItem.GetValue<string>("revision"));
				ecnItem.SetValue<int?>("oper_num", ecnItem.GetValue<int?>("oper_num"));
				ecnItem.SetValue<string>("wc", ecnItem.GetValue<string>("wc"));
				ecnItem.SetValue<string>("description____", ecnItem.GetValue<string>("description____"));
				ecnItem.SetValue<string>("col4", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u3"), "L") == true ? this.iGetLabel.GetLabelFn("@:BflushType:L") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u3"), "C") == true ? this.iGetLabel.GetLabelFn("@:BflushType:C") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u3"), "B") == true ? this.iGetLabel.GetLabelFn("@:BflushType:B") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u3"), "N") == true ? this.iGetLabel.GetLabelFn("@:BflushType:N") : null));
				ecnItem.SetValue<decimal?>("sched_hrs", ecnItem.GetValue<decimal?>("sched_hrs"));
				ecnItem.SetValue<string>("col5", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u4"), "H") == true ? this.iGetLabel.GetLabelFn("@:RunBasisMch:H") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u4"), "P") == true ? this.iGetLabel.GetLabelFn("@:RunBasisMch:P") : null));
				ecnItem.SetValue<decimal?>("run_mch_hrs", ecnItem.GetValue<decimal?>("run_mch_hrs"));
				ecnItem.SetValue<string>("col6", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u5"), "H") == true ? this.iGetLabel.GetLabelFn("@:RunBasisLbr:H") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u5"), "P") == true ? this.iGetLabel.GetLabelFn("@:RunBasisLbr:P") : null));
				ecnItem.SetValue<decimal?>("run_lbr_hrs", ecnItem.GetValue<decimal?>("run_lbr_hrs"));
				ecnItem.SetValue<decimal?>("move_hrs", ecnItem.GetValue<decimal?>("move_hrs"));
				ecnItem.SetValue<decimal?>("queue_hrs", ecnItem.GetValue<decimal?>("queue_hrs"));
				ecnItem.SetValue<decimal?>("setup_hrs", ecnItem.GetValue<decimal?>("setup_hrs"));
				ecnItem.SetValue<decimal?>("finish_hrs", ecnItem.GetValue<decimal?>("finish_hrs"));
				ecnItem.SetValue<decimal?>("offset_hrs", ecnItem.GetValue<decimal?>("offset_hrs"));
				ecnItem.SetValue<DateTime?>("effect_date_", ecnItem.GetValue<DateTime?>("effect_date_"));
				ecnItem.SetValue<DateTime?>("obs_date", ecnItem.GetValue<DateTime?>("obs_date"));
				ecnItem.SetValue<string>("NoteContent", ecnItem.GetValue<string>("NoteContent"));
				ecnItem.SetValue<string>("NoteContent_", ecnItem.GetValue<string>("NoteContent_"));
				ecnItem.SetValue<string>("NoteContent__", ecnItem.GetValue<string>("NoteContent__"));
				ecnItem.SetValue<string>("NoteDesc", ecnItem.GetValue<string>("NoteDesc"));
				ecnItem.SetValue<string>("NoteDesc_", ecnItem.GetValue<string>("NoteDesc_"));
				ecnItem.SetValue<string>("NoteDesc__", ecnItem.GetValue<string>("NoteDesc__"));
				ecnItem.SetValue<string>("matl_item", ecnItem.GetValue<string>("matl_item"));
				ecnItem.SetValue<string>("description_____", ecnItem.GetValue<string>("description_____"));
				ecnItem.SetValue<int?>("alt_group", ecnItem.GetValue<int?>("alt_group"));
				ecnItem.SetValue<int?>("alt_group_rank", ecnItem.GetValue<int?>("alt_group_rank"));
				ecnItem.SetValue<int?>("sequence", ecnItem.GetValue<int?>("sequence"));
				ecnItem.SetValue<string>("col7", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u6"), "M") == true ? this.iGetLabel.GetLabelFn("@:MatlType:M") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u6"), "T") == true ? this.iGetLabel.GetLabelFn("@:MatlType:T") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u6"), "F") == true ? this.iGetLabel.GetLabelFn("@:MatlType:F") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u6"), "O") == true ? this.iGetLabel.GetLabelFn("@:MatlType:O") : null));
				ecnItem.SetValue<decimal?>("matl_qty_conv", ecnItem.GetValue<decimal?>("matl_qty_conv"));
				ecnItem.SetValue<string>("col8", (sQLUtil.SQLEqual(ecnItem.GetValue<string>("u7"), "U") == true ? this.iGetLabel.GetLabelFn("@:JobmatlUnits:U") : sQLUtil.SQLEqual(ecnItem.GetValue<string>("u7"), "L") == true ? this.iGetLabel.GetLabelFn("@:JobmatlUnits:L") : null));
				ecnItem.SetValue<string>("u_m", ecnItem.GetValue<string>("u_m"));
				ecnItem.SetValue<int?>("bom_seq", ecnItem.GetValue<int?>("bom_seq"));
				ecnItem.SetValue<string>("feature", ecnItem.GetValue<string>("feature"));
				ecnItem.SetValue<string>("description______", ecnItem.GetValue<string>("description______"));
				ecnItem.SetValue<string>("opt_code", ecnItem.GetValue<string>("opt_code"));
				ecnItem.SetValue<decimal?>("probable", ecnItem.GetValue<decimal?>("probable"));
				ecnItem.SetValue<decimal?>("inc_price", ecnItem.GetValue<decimal?>("inc_price"));
				ecnItem.SetValue<decimal?>("matl_cost_conv", ecnItem.GetValue<decimal?>("matl_cost_conv"));
				ecnItem.SetValue<decimal?>("lbr_cost_conv", ecnItem.GetValue<decimal?>("lbr_cost_conv"));
				ecnItem.SetValue<decimal?>("fovhd_cost_conv", ecnItem.GetValue<decimal?>("fovhd_cost_conv"));
				ecnItem.SetValue<decimal?>("vovhd_cost_conv", ecnItem.GetValue<decimal?>("vovhd_cost_conv"));
				ecnItem.SetValue<decimal?>("out_cost_conv", ecnItem.GetValue<decimal?>("out_cost_conv"));
				ecnItem.SetValue<decimal?>("cost_conv", ecnItem.GetValue<decimal?>("cost_conv"));
				ecnItem.SetValue<int?>("ref_seq", ecnItem.GetValue<int?>("ref_seq"));
				ecnItem.SetValue<string>("bubble", ecnItem.GetValue<string>("bubble"));
				ecnItem.SetValue<string>("ref_des", ecnItem.GetValue<string>("ref_des"));
				ecnItem.SetValue<string>("assy_seq", ecnItem.GetValue<string>("assy_seq"));
			};

			ecn_crs_CursorFetch_Status = ecn_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			ecn_crs_CursorCounter = -1;

			ecn_crs_CursorCounter++;
			if (ecn_crsLoadResponseForCursor.Items.Count > ecn_crs_CursorCounter)
			{
				ECNNum = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(0));
				Stat = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(1);
				Orig = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(2);
				ReqDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(3));
				AppDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(4));
				EffectDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(5));
				CompDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(6));
				PriorCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(7);
				PriDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(8);
				EcnReasonCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(9);
				EcnReasonDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(10);
				DistCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(11);
				DistDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(12);
				EcnLine = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(13));
				Job = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(14);
				Suffix = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(15));
				ECNItemTypeCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(16);
				ECNItemType = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(17);
				ActionCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(18);
				EcniGroup = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(19);
				Item = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(20);
				ItemDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(21);
				ItemStat = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(22);
				Revision = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(23);
				OperNum = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(24));
				WC = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(25);
				WCDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(26);
				BflushType = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(27);
				SchedHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(28));
				RunBasisMch = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(29);
				RunMchHours = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(30));
				RunBasisLbr = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(31);
				RunLbrHours = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(32));
				MoveHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(33));
				QueueHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(34));
				SetupHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(35));
				FinishHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(36));
				OffsetHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(37));
				EffectDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(38));
				ObsDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(39));
				SpecificNoteContent = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(40);
				SystemNoteContent = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(41);
				UserNoteContent = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(42);
				SpecificNoteDesc = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(43);
				SystemNoteDesc = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(44);
				UserNoteDesc = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(45);
				MatlItem = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(46);
				MatlDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(47);
				AltGroup = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(48));
				AltGroupRank = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(49));
				Sequence = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(50));
				MatlType = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(51);
				MatlQtyConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(52));
				Units = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(53);
				UM = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(54);
				BOMSeq = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(55));
				Feature = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(56);
				FeatureDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(57);
				OptCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(58);
				Probable = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(59));
				IncPrice = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(60));
				MatlCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(61));
				LbrCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(62));
				FovhdCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(63));
				VovhdCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(64));
				OutCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(65));
				CostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(66));
				RefSeq = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(67));
				Bubble = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(68);
				RefDes = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(69);
				AssySeq = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(70);
			}
			ecn_crs_CursorFetch_Status = (ecn_crs_CursorCounter == ecn_crsLoadResponseForCursor.Items.Count ? -1 : 0);

			while (sQLUtil.SQLEqual(ecn_crs_CursorFetch_Status, 0) == true)
			{
				if (sQLUtil.SQLNotEqual(Counter, 0) == true)
				{
					Counter = (int?)(Counter + 1);

				}
				if (sQLUtil.SQLEqual(Counter, 0) == true)
				{
					var nonTable1LoadResponse = this.iCreateEcnEsigCRUD.Nontable1Select(EsigRowpointer, Counter, ECNNum);
					this.iCreateEcnEsigCRUD.Nontable1Insert(nonTable1LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable2LoadResponse = this.iCreateEcnEsigCRUD.Nontable2Select(EsigRowpointer, Counter, Stat);
					this.iCreateEcnEsigCRUD.Nontable2Insert(nonTable2LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable3LoadResponse = this.iCreateEcnEsigCRUD.Nontable3Select(EsigRowpointer, Counter, Orig);
					this.iCreateEcnEsigCRUD.Nontable3Insert(nonTable3LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable4LoadResponse = this.iCreateEcnEsigCRUD.Nontable4Select(EsigRowpointer, Counter, ReqDate);
					this.iCreateEcnEsigCRUD.Nontable4Insert(nonTable4LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable5LoadResponse = this.iCreateEcnEsigCRUD.Nontable5Select(EsigRowpointer, Counter, AppDate);
					this.iCreateEcnEsigCRUD.Nontable5Insert(nonTable5LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable6LoadResponse = this.iCreateEcnEsigCRUD.Nontable6Select(EsigRowpointer, Counter, EffectDate);
					this.iCreateEcnEsigCRUD.Nontable6Insert(nonTable6LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable7LoadResponse = this.iCreateEcnEsigCRUD.Nontable7Select(EsigRowpointer, Counter, CompDate);
					this.iCreateEcnEsigCRUD.Nontable7Insert(nonTable7LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable8LoadResponse = this.iCreateEcnEsigCRUD.Nontable8Select(EsigRowpointer, Counter, PriorCode);
					this.iCreateEcnEsigCRUD.Nontable8Insert(nonTable8LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable9LoadResponse = this.iCreateEcnEsigCRUD.Nontable9Select(EsigRowpointer, Counter, PriDescription);
					this.iCreateEcnEsigCRUD.Nontable9Insert(nonTable9LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable10LoadResponse = this.iCreateEcnEsigCRUD.Nontable10Select(EsigRowpointer, Counter, ReasonCode);
					this.iCreateEcnEsigCRUD.Nontable10Insert(nonTable10LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable11LoadResponse = this.iCreateEcnEsigCRUD.Nontable11Select(EsigRowpointer, Counter, ReasonDescription);
					this.iCreateEcnEsigCRUD.Nontable11Insert(nonTable11LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable12LoadResponse = this.iCreateEcnEsigCRUD.Nontable12Select(EsigRowpointer, Counter, DistCode);
					this.iCreateEcnEsigCRUD.Nontable12Insert(nonTable12LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable13LoadResponse = this.iCreateEcnEsigCRUD.Nontable13Select(EsigRowpointer, Counter, DistDescription);
					this.iCreateEcnEsigCRUD.Nontable13Insert(nonTable13LoadResponse);

				}
				if (stringUtil.In(ECNItemTypeCode, new object[] { "EO", "CO", "JO" }))
				{
					Counter = (int?)(Counter + 1);
					var nonTable14LoadResponse = this.iCreateEcnEsigCRUD.Nontable14Select(EsigRowpointer, Counter, EcnLine);
					this.iCreateEcnEsigCRUD.Nontable14Insert(nonTable14LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable15LoadResponse = this.iCreateEcnEsigCRUD.Nontable15Select(EsigRowpointer, Counter, Job);
					this.iCreateEcnEsigCRUD.Nontable15Insert(nonTable15LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable16LoadResponse = this.iCreateEcnEsigCRUD.Nontable16Select(EsigRowpointer, Counter, Suffix);
					this.iCreateEcnEsigCRUD.Nontable16Insert(nonTable16LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable17LoadResponse = this.iCreateEcnEsigCRUD.Nontable17Select(EsigRowpointer, Counter, ECNItemType);
					this.iCreateEcnEsigCRUD.Nontable17Insert(nonTable17LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable18LoadResponse = this.iCreateEcnEsigCRUD.Nontable18Select(EsigRowpointer, Counter, ActionCode);
					this.iCreateEcnEsigCRUD.Nontable18Insert(nonTable18LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable19LoadResponse = this.iCreateEcnEsigCRUD.Nontable19Select(EsigRowpointer, Counter, EcniGroup);
					this.iCreateEcnEsigCRUD.Nontable19Insert(nonTable19LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable20LoadResponse = this.iCreateEcnEsigCRUD.Nontable20Select(EsigRowpointer, Counter, Item);
					this.iCreateEcnEsigCRUD.Nontable20Insert(nonTable20LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable21LoadResponse = this.iCreateEcnEsigCRUD.Nontable21Select(EsigRowpointer, Counter, ItemDescription);
					this.iCreateEcnEsigCRUD.Nontable21Insert(nonTable21LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable22LoadResponse = this.iCreateEcnEsigCRUD.Nontable22Select(EsigRowpointer, Counter, ItemStat);
					this.iCreateEcnEsigCRUD.Nontable22Insert(nonTable22LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable23LoadResponse = this.iCreateEcnEsigCRUD.Nontable23Select(EsigRowpointer, Counter, Revision);
					this.iCreateEcnEsigCRUD.Nontable23Insert(nonTable23LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable24LoadResponse = this.iCreateEcnEsigCRUD.Nontable24Select(EsigRowpointer, Counter, OperNum);
					this.iCreateEcnEsigCRUD.Nontable24Insert(nonTable24LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable25LoadResponse = this.iCreateEcnEsigCRUD.Nontable25Select(EsigRowpointer, Counter, WC);
					this.iCreateEcnEsigCRUD.Nontable25Insert(nonTable25LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable26LoadResponse = this.iCreateEcnEsigCRUD.Nontable26Select(EsigRowpointer, Counter, WCDescription);
					this.iCreateEcnEsigCRUD.Nontable26Insert(nonTable26LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable27LoadResponse = this.iCreateEcnEsigCRUD.Nontable27Select(EsigRowpointer, Counter, BflushType);
					this.iCreateEcnEsigCRUD.Nontable27Insert(nonTable27LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable28LoadResponse = this.iCreateEcnEsigCRUD.Nontable28Select(EsigRowpointer, Counter, SchedHrs);
					this.iCreateEcnEsigCRUD.Nontable28Insert(nonTable28LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable29LoadResponse = this.iCreateEcnEsigCRUD.Nontable29Select(EsigRowpointer, Counter, RunBasisMch);
					this.iCreateEcnEsigCRUD.Nontable29Insert(nonTable29LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable30LoadResponse = this.iCreateEcnEsigCRUD.Nontable30Select(EsigRowpointer, Counter, RunMchHours);
					this.iCreateEcnEsigCRUD.Nontable30Insert(nonTable30LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable31LoadResponse = this.iCreateEcnEsigCRUD.Nontable31Select(EsigRowpointer, Counter, RunBasisLbr);
					this.iCreateEcnEsigCRUD.Nontable31Insert(nonTable31LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable32LoadResponse = this.iCreateEcnEsigCRUD.Nontable32Select(EsigRowpointer, Counter, RunLbrHours);
					this.iCreateEcnEsigCRUD.Nontable32Insert(nonTable32LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable33LoadResponse = this.iCreateEcnEsigCRUD.Nontable33Select(EsigRowpointer, Counter, MoveHrs);
					this.iCreateEcnEsigCRUD.Nontable33Insert(nonTable33LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable34LoadResponse = this.iCreateEcnEsigCRUD.Nontable34Select(EsigRowpointer, Counter, QueueHrs);
					this.iCreateEcnEsigCRUD.Nontable34Insert(nonTable34LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable35LoadResponse = this.iCreateEcnEsigCRUD.Nontable35Select(EsigRowpointer, Counter, SetupHrs);
					this.iCreateEcnEsigCRUD.Nontable35Insert(nonTable35LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable36LoadResponse = this.iCreateEcnEsigCRUD.Nontable36Select(EsigRowpointer, Counter, FinishHrs);
					this.iCreateEcnEsigCRUD.Nontable36Insert(nonTable36LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable37LoadResponse = this.iCreateEcnEsigCRUD.Nontable37Select(EsigRowpointer, Counter, OffsetHrs);
					this.iCreateEcnEsigCRUD.Nontable37Insert(nonTable37LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable38LoadResponse = this.iCreateEcnEsigCRUD.Nontable38Select(EsigRowpointer, Counter, EffectDate);
					this.iCreateEcnEsigCRUD.Nontable38Insert(nonTable38LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable39LoadResponse = this.iCreateEcnEsigCRUD.Nontable39Select(EsigRowpointer, Counter, ObsDate);
					this.iCreateEcnEsigCRUD.Nontable39Insert(nonTable39LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable40LoadResponse = this.iCreateEcnEsigCRUD.Nontable40Select(EsigRowpointer, Counter, SpecificNoteDesc);
					this.iCreateEcnEsigCRUD.Nontable40Insert(nonTable40LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable41LoadResponse = this.iCreateEcnEsigCRUD.Nontable41Select(EsigRowpointer, Counter, SpecificNoteContent);
					this.iCreateEcnEsigCRUD.Nontable41Insert(nonTable41LoadResponse);

				}
				if (stringUtil.In(ECNItemTypeCode, new object[] { "EM", "CM", "JM" }))
				{
					Counter = (int?)(Counter + 1);
					var nonTable42LoadResponse = this.iCreateEcnEsigCRUD.Nontable42Select(EsigRowpointer, Counter, EcnLine);
					this.iCreateEcnEsigCRUD.Nontable42Insert(nonTable42LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable43LoadResponse = this.iCreateEcnEsigCRUD.Nontable43Select(EsigRowpointer, Counter, Job);
					this.iCreateEcnEsigCRUD.Nontable43Insert(nonTable43LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable44LoadResponse = this.iCreateEcnEsigCRUD.Nontable44Select(EsigRowpointer, Counter, Suffix);
					this.iCreateEcnEsigCRUD.Nontable44Insert(nonTable44LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable45LoadResponse = this.iCreateEcnEsigCRUD.Nontable45Select(EsigRowpointer, Counter, ECNItemType);
					this.iCreateEcnEsigCRUD.Nontable45Insert(nonTable45LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable46LoadResponse = this.iCreateEcnEsigCRUD.Nontable46Select(EsigRowpointer, Counter, ActionCode);
					this.iCreateEcnEsigCRUD.Nontable46Insert(nonTable46LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable47LoadResponse = this.iCreateEcnEsigCRUD.Nontable47Select(EsigRowpointer, Counter, EcniGroup);
					this.iCreateEcnEsigCRUD.Nontable47Insert(nonTable47LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable48LoadResponse = this.iCreateEcnEsigCRUD.Nontable48Select(EsigRowpointer, Counter, Item);
					this.iCreateEcnEsigCRUD.Nontable48Insert(nonTable48LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable49LoadResponse = this.iCreateEcnEsigCRUD.Nontable49Select(EsigRowpointer, Counter, ItemDescription);
					this.iCreateEcnEsigCRUD.Nontable49Insert(nonTable49LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable50LoadResponse = this.iCreateEcnEsigCRUD.Nontable50Select(EsigRowpointer, Counter, ItemStat);
					this.iCreateEcnEsigCRUD.Nontable50Insert(nonTable50LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable51LoadResponse = this.iCreateEcnEsigCRUD.Nontable51Select(EsigRowpointer, Counter, Revision);
					this.iCreateEcnEsigCRUD.Nontable51Insert(nonTable51LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable52LoadResponse = this.iCreateEcnEsigCRUD.Nontable52Select(EsigRowpointer, Counter, OperNum);
					this.iCreateEcnEsigCRUD.Nontable52Insert(nonTable52LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable53LoadResponse = this.iCreateEcnEsigCRUD.Nontable53Select(EsigRowpointer, Counter, WC);
					this.iCreateEcnEsigCRUD.Nontable53Insert(nonTable53LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable54LoadResponse = this.iCreateEcnEsigCRUD.Nontable54Select(EsigRowpointer, Counter, WCDescription);
					this.iCreateEcnEsigCRUD.Nontable54Insert(nonTable54LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable55LoadResponse = this.iCreateEcnEsigCRUD.Nontable55Select(EsigRowpointer, Counter, EffectDate);
					this.iCreateEcnEsigCRUD.Nontable55Insert(nonTable55LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable56LoadResponse = this.iCreateEcnEsigCRUD.Nontable56Select(EsigRowpointer, Counter, ObsDate);
					this.iCreateEcnEsigCRUD.Nontable56Insert(nonTable56LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable57LoadResponse = this.iCreateEcnEsigCRUD.Nontable57Select(EsigRowpointer, Counter, SpecificNoteDesc);
					this.iCreateEcnEsigCRUD.Nontable57Insert(nonTable57LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable58LoadResponse = this.iCreateEcnEsigCRUD.Nontable58Select(EsigRowpointer, Counter, SpecificNoteContent);
					this.iCreateEcnEsigCRUD.Nontable58Insert(nonTable58LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable59LoadResponse = this.iCreateEcnEsigCRUD.Nontable59Select(EsigRowpointer, Counter, MatlItem);
					this.iCreateEcnEsigCRUD.Nontable59Insert(nonTable59LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable60LoadResponse = this.iCreateEcnEsigCRUD.Nontable60Select(EsigRowpointer, Counter, MatlDescription);
					this.iCreateEcnEsigCRUD.Nontable60Insert(nonTable60LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable61LoadResponse = this.iCreateEcnEsigCRUD.Nontable61Select(EsigRowpointer, Counter, AltGroup);
					this.iCreateEcnEsigCRUD.Nontable61Insert(nonTable61LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable62LoadResponse = this.iCreateEcnEsigCRUD.Nontable62Select(EsigRowpointer, Counter, AltGroupRank);
					this.iCreateEcnEsigCRUD.Nontable62Insert(nonTable62LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable63LoadResponse = this.iCreateEcnEsigCRUD.Nontable63Select(EsigRowpointer, Counter, Sequence);
					this.iCreateEcnEsigCRUD.Nontable63Insert(nonTable63LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable64LoadResponse = this.iCreateEcnEsigCRUD.Nontable64Select(EsigRowpointer, Counter, MatlType);
					this.iCreateEcnEsigCRUD.Nontable64Insert(nonTable64LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable65LoadResponse = this.iCreateEcnEsigCRUD.Nontable65Select(EsigRowpointer, Counter, MatlQtyConv);
					this.iCreateEcnEsigCRUD.Nontable65Insert(nonTable65LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable66LoadResponse = this.iCreateEcnEsigCRUD.Nontable66Select(EsigRowpointer, Counter, Units);
					this.iCreateEcnEsigCRUD.Nontable66Insert(nonTable66LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable67LoadResponse = this.iCreateEcnEsigCRUD.Nontable67Select(EsigRowpointer, Counter, UM);
					this.iCreateEcnEsigCRUD.Nontable67Insert(nonTable67LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable68LoadResponse = this.iCreateEcnEsigCRUD.Nontable68Select(EsigRowpointer, Counter, BOMSeq);
					this.iCreateEcnEsigCRUD.Nontable68Insert(nonTable68LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable69LoadResponse = this.iCreateEcnEsigCRUD.Nontable69Select(EsigRowpointer, Counter, Feature);
					this.iCreateEcnEsigCRUD.Nontable69Insert(nonTable69LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable70LoadResponse = this.iCreateEcnEsigCRUD.Nontable70Select(EsigRowpointer, Counter, FeatureDescription);
					this.iCreateEcnEsigCRUD.Nontable70Insert(nonTable70LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable71LoadResponse = this.iCreateEcnEsigCRUD.Nontable71Select(EsigRowpointer, Counter, OptCode);
					this.iCreateEcnEsigCRUD.Nontable71Insert(nonTable71LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable72LoadResponse = this.iCreateEcnEsigCRUD.Nontable72Select(EsigRowpointer, Counter, Probable);
					this.iCreateEcnEsigCRUD.Nontable72Insert(nonTable72LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable73LoadResponse = this.iCreateEcnEsigCRUD.Nontable73Select(EsigRowpointer, Counter, IncPrice);
					this.iCreateEcnEsigCRUD.Nontable73Insert(nonTable73LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable74LoadResponse = this.iCreateEcnEsigCRUD.Nontable74Select(EsigRowpointer, Counter, MatlCostConv);
					this.iCreateEcnEsigCRUD.Nontable74Insert(nonTable74LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable75LoadResponse = this.iCreateEcnEsigCRUD.Nontable75Select(EsigRowpointer, Counter, LbrCostConv);
					this.iCreateEcnEsigCRUD.Nontable75Insert(nonTable75LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable76LoadResponse = this.iCreateEcnEsigCRUD.Nontable76Select(EsigRowpointer, Counter, FovhdCostConv);
					this.iCreateEcnEsigCRUD.Nontable76Insert(nonTable76LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable77LoadResponse = this.iCreateEcnEsigCRUD.Nontable77Select(EsigRowpointer, Counter, VovhdCostConv);
					this.iCreateEcnEsigCRUD.Nontable77Insert(nonTable77LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable78LoadResponse = this.iCreateEcnEsigCRUD.Nontable78Select(EsigRowpointer, Counter, OutCostConv);
					this.iCreateEcnEsigCRUD.Nontable78Insert(nonTable78LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable79LoadResponse = this.iCreateEcnEsigCRUD.Nontable79Select(EsigRowpointer, Counter, CostConv);
					this.iCreateEcnEsigCRUD.Nontable79Insert(nonTable79LoadResponse);

				}
				if (stringUtil.In(ECNItemTypeCode, new object[] { "ER", "CR", "JR" }))
				{
					Counter = (int?)(Counter + 1);
					var nonTable80LoadResponse = this.iCreateEcnEsigCRUD.Nontable80Select(EsigRowpointer, Counter, EcnLine);
					this.iCreateEcnEsigCRUD.Nontable80Insert(nonTable80LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable81LoadResponse = this.iCreateEcnEsigCRUD.Nontable81Select(EsigRowpointer, Counter, Job);
					this.iCreateEcnEsigCRUD.Nontable81Insert(nonTable81LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable82LoadResponse = this.iCreateEcnEsigCRUD.Nontable82Select(EsigRowpointer, Counter, Suffix);
					this.iCreateEcnEsigCRUD.Nontable82Insert(nonTable82LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable83LoadResponse = this.iCreateEcnEsigCRUD.Nontable83Select(EsigRowpointer, Counter, ECNItemType);
					this.iCreateEcnEsigCRUD.Nontable83Insert(nonTable83LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable84LoadResponse = this.iCreateEcnEsigCRUD.Nontable84Select(EsigRowpointer, Counter, ActionCode);
					this.iCreateEcnEsigCRUD.Nontable84Insert(nonTable84LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable85LoadResponse = this.iCreateEcnEsigCRUD.Nontable85Select(EsigRowpointer, Counter, EcniGroup);
					this.iCreateEcnEsigCRUD.Nontable85Insert(nonTable85LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable86LoadResponse = this.iCreateEcnEsigCRUD.Nontable86Select(EsigRowpointer, Counter, Item);
					this.iCreateEcnEsigCRUD.Nontable86Insert(nonTable86LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable87LoadResponse = this.iCreateEcnEsigCRUD.Nontable87Select(EsigRowpointer, Counter, ItemDescription);
					this.iCreateEcnEsigCRUD.Nontable87Insert(nonTable87LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable88LoadResponse = this.iCreateEcnEsigCRUD.Nontable88Select(EsigRowpointer, Counter, ItemStat);
					this.iCreateEcnEsigCRUD.Nontable88Insert(nonTable88LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable89LoadResponse = this.iCreateEcnEsigCRUD.Nontable89Select(EsigRowpointer, Counter, Revision);
					this.iCreateEcnEsigCRUD.Nontable89Insert(nonTable89LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable90LoadResponse = this.iCreateEcnEsigCRUD.Nontable90Select(EsigRowpointer, Counter, OperNum);
					this.iCreateEcnEsigCRUD.Nontable90Insert(nonTable90LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable91LoadResponse = this.iCreateEcnEsigCRUD.Nontable91Select(EsigRowpointer, Counter, WC);
					this.iCreateEcnEsigCRUD.Nontable91Insert(nonTable91LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable92LoadResponse = this.iCreateEcnEsigCRUD.Nontable92Select(EsigRowpointer, Counter, WCDescription);
					this.iCreateEcnEsigCRUD.Nontable92Insert(nonTable92LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable93LoadResponse = this.iCreateEcnEsigCRUD.Nontable93Select(EsigRowpointer, Counter, SpecificNoteDesc);
					this.iCreateEcnEsigCRUD.Nontable93Insert(nonTable93LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable94LoadResponse = this.iCreateEcnEsigCRUD.Nontable94Select(EsigRowpointer, Counter, SpecificNoteContent);
					this.iCreateEcnEsigCRUD.Nontable94Insert(nonTable94LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable95LoadResponse = this.iCreateEcnEsigCRUD.Nontable95Select(EsigRowpointer, Counter, MatlItem);
					this.iCreateEcnEsigCRUD.Nontable95Insert(nonTable95LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable96LoadResponse = this.iCreateEcnEsigCRUD.Nontable96Select(EsigRowpointer, Counter, MatlDescription);
					this.iCreateEcnEsigCRUD.Nontable96Insert(nonTable96LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable97LoadResponse = this.iCreateEcnEsigCRUD.Nontable97Select(EsigRowpointer, Counter, Sequence);
					this.iCreateEcnEsigCRUD.Nontable97Insert(nonTable97LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable98LoadResponse = this.iCreateEcnEsigCRUD.Nontable98Select(EsigRowpointer, Counter, RefSeq);
					this.iCreateEcnEsigCRUD.Nontable98Insert(nonTable98LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable99LoadResponse = this.iCreateEcnEsigCRUD.Nontable99Select(EsigRowpointer, Counter, Bubble);
					this.iCreateEcnEsigCRUD.Nontable99Insert(nonTable99LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable100LoadResponse = this.iCreateEcnEsigCRUD.Nontable100Select(EsigRowpointer, Counter, RefDes);
					this.iCreateEcnEsigCRUD.Nontable100Insert(nonTable100LoadResponse);
					Counter = (int?)(Counter + 1);
					var nonTable101LoadResponse = this.iCreateEcnEsigCRUD.Nontable101Select(EsigRowpointer, Counter, AssySeq);
					this.iCreateEcnEsigCRUD.Nontable101Insert(nonTable101LoadResponse);

				}
				ecn_crs_CursorCounter++;
				if (ecn_crsLoadResponseForCursor.Items.Count > ecn_crs_CursorCounter)
				{
					ECNNum = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(0));
					Stat = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(1);
					Orig = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(2);
					ReqDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(3));
					AppDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(4));
					EffectDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(5));
					CompDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(6));
					PriorCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(7);
					PriDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(8);
					EcnReasonCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(9);
					EcnReasonDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(10);
					DistCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(11);
					DistDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(12);
					EcnLine = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(13));
					Job = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(14);
					Suffix = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(15));
					ECNItemTypeCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(16);
					ECNItemType = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(17);
					ActionCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(18);
					EcniGroup = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(19);
					Item = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(20);
					ItemDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(21);
					ItemStat = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(22);
					Revision = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(23);
					OperNum = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(24));
					WC = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(25);
					WCDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(26);
					BflushType = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(27);
					SchedHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(28));
					RunBasisMch = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(29);
					RunMchHours = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(30));
					RunBasisLbr = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(31);
					RunLbrHours = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(32));
					MoveHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(33));
					QueueHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(34));
					SetupHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(35));
					FinishHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(36));
					OffsetHrs = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(37));
					EffectDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(38));
					ObsDate = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<DateTime?>(39));
					SpecificNoteContent = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(40);
					SystemNoteContent = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(41);
					UserNoteContent = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(42);
					SpecificNoteDesc = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(43);
					SystemNoteDesc = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(44);
					UserNoteDesc = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(45);
					MatlItem = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(46);
					MatlDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(47);
					AltGroup = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(48));
					AltGroupRank = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(49));
					Sequence = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(50));
					MatlType = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(51);
					MatlQtyConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(52));
					Units = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(53);
					UM = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(54);
					BOMSeq = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(55));
					Feature = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(56);
					FeatureDescription = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(57);
					OptCode = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(58);
					Probable = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(59));
					IncPrice = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(60));
					MatlCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(61));
					LbrCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(62));
					FovhdCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(63));
					VovhdCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(64));
					OutCostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(65));
					CostConv = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<decimal?>(66));
					RefSeq = Convert.ToString(ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<int?>(67));
					Bubble = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(68);
					RefDes = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(69);
					AssySeq = ecn_crsLoadResponseForCursor.Items[ecn_crs_CursorCounter].GetValue<string>(70);
				}
				ecn_crs_CursorFetch_Status = (ecn_crs_CursorCounter == ecn_crsLoadResponseForCursor.Items.Count ? -1 : 0);

			}
			//Deallocate Cursor ecn_crs

			return (Severity, EsigRowpointer);
		}

	}
}
