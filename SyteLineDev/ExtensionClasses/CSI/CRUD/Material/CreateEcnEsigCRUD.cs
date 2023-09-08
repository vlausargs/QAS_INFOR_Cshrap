//PROJECT NAME: Material
//CLASS NAME: CreateEcnEsigCRUD.cs

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
	public class CreateEcnEsigCRUD : ICreateEcnEsigCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;

		public CreateEcnEsigCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CreateEcnEsigSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CreateEcnEsigSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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

		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
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

			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}

		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
				tableName: "#tv_ALTGEN", 
                loadForChange: true, 
                lockingType: LockingType.None,
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

		public (int? Enabled, int? rowCount) Esig_TypeLoad(int? Severity, string EstimateOperation, string Infobar, string CurrentMaterial, string CurrentReference, int? Enabled)
		{
			ListYesNoType _Enabled = DBNull.Value;

			var esig_typeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Enabled,"esig_type.enabled"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "esig_type",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("esig_type.esig_type = 'PostECN'"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var esig_typeLoadResponse = this.appDB.Load(esig_typeLoadRequest);
			if (esig_typeLoadResponse.Items.Count > 0)
			{
				Enabled = _Enabled;
			}

			int rowCount = esig_typeLoadResponse.Items.Count;
			return (Enabled, rowCount);
		}

		public (string UserDesc, int? rowCount) UsernamesLoad(string UserName, string UserDesc)
		{
			LongDescType _UserDesc = DBNull.Value;

			var UserNamesLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_UserDesc,"UserNames.UserDesc"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "UserNames",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("UserNames.Username = {0}", UserName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var UserNamesLoadResponse = this.appDB.Load(UserNamesLoadRequest);
			if (UserNamesLoadResponse.Items.Count > 0)
			{
				UserDesc = _UserDesc;
			}

			int rowCount = UserNamesLoadResponse.Items.Count;
			return (UserDesc, rowCount);
		}

		public (string ReasonDescription, int? rowCount) ReasonLoad(string ReasonCode, string ReasonDescription)
		{
			DescriptionType _ReasonDescription = DBNull.Value;

			var reasonLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ReasonDescription,"reason.description"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "reason",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("reason.reason_code = {0} AND reason.reason_class = 'ESIG'", ReasonCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var reasonLoadResponse = this.appDB.Load(reasonLoadRequest);
			if (reasonLoadResponse.Items.Count > 0)
			{
				ReasonDescription = _ReasonDescription;
			}

			int rowCount = reasonLoadResponse.Items.Count;
			return (ReasonDescription, rowCount);
		}

		public ICollectionLoadResponse NontableSelect(string UserName, string UserDesc, string ReasonCode, string ReasonDescription, Guid? EsigRowpointer)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "Username", UserName},
					{ "UserDesc", UserDesc},
					{ "reason_code", ReasonCode},
					{ "reason_description", ReasonDescription},
					{ "esig_type", "PostECN"},
					{ "RowPointer", EsigRowpointer},
			});

			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature",
				items: nonTableLoadResponse.Items);

			this.appDB.Insert(nonTableInsertRequest);
		}

		public ICollectionLoadResponse EcnSelect(string ECNNum)
		{
			var ecn_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ecn_num","ecn.ecn_num"},
					{"col0","CAST (NULL AS NVARCHAR)"},
					{"orig","ecn.orig"},
					{"req_date","ecn.req_date"},
					{"app_date","ecn.app_date"},
					{"effect_date","ecn.effect_date"},
					{"comp_date","ecn.comp_date"},
					{"prior_code","ecn.prior_code"},
					{"description","ecnpri.description"},
					{"reason_code","ecn.reason_code"},
					{"description_","reason.description"},
					{"dist_code","ecn.dist_code"},
					{"description__","ecndist.description"},
					{"ecn_line","ecnitem.ecn_line"},
					{"job","ecnitem.job"},
					{"suffix","ecnitem.suffix"},
					{"ecnitem_type","ecnitem.ecnitem_type"},
					{"col1","CAST (NULL AS NVARCHAR)"},
					{"col2","CAST (NULL AS NVARCHAR)"},
					{"ecni_group","ecnitem.ecni_group"},
					{"item","ecnitem.item"},
					{"description___","item.description"},
					{"col3","CAST (NULL AS NVARCHAR)"},
					{"revision","ecnitem.revision"},
					{"oper_num","ecnitem.oper_num"},
					{"wc","ecnitem.wc"},
					{"description____","wc.description"},
					{"col4","CAST (NULL AS NVARCHAR)"},
					{"sched_hrs","ecnitem.sched_hrs"},
					{"col5","CAST (NULL AS NVARCHAR)"},
					{"run_mch_hrs","ecnitem.run_mch_hrs"},
					{"col6","CAST (NULL AS NVARCHAR)"},
					{"run_lbr_hrs","ecnitem.run_lbr_hrs"},
					{"move_hrs","ecnitem.move_hrs"},
					{"queue_hrs","ecnitem.queue_hrs"},
					{"setup_hrs","ecnitem.setup_hrs"},
					{"finish_hrs","ecnitem.finish_hrs"},
					{"offset_hrs","ecnitem.offset_hrs"},
					{"effect_date_","ecnitem.effect_date"},
					{"obs_date","ecnitem.obs_date"},
					{"NoteContent","spc.NoteContent"},
					{"NoteContent_","syn.NoteContent"},
					{"NoteContent__","usn.NoteContent"},
					{"NoteDesc","spc.NoteDesc"},
					{"NoteDesc_","syn.NoteDesc"},
					{"NoteDesc__","usn.NoteDesc"},
					{"matl_item","ecnitem.matl_item"},
					{"description_____","i.description"},
					{"alt_group","ecnitem.alt_group"},
					{"alt_group_rank","ecnitem.alt_group_rank"},
					{"sequence","ecnitem.sequence"},
					{"col7","CAST (NULL AS NVARCHAR)"},
					{"matl_qty_conv","ecnitem.matl_qty_conv"},
					{"col8","CAST (NULL AS NVARCHAR)"},
					{"u_m","ecnitem.u_m"},
					{"bom_seq","ecnitem.bom_seq"},
					{"feature","ecnitem.feature"},
					{"description______","feature.description"},
					{"opt_code","ecnitem.opt_code"},
					{"probable","ecnitem.probable"},
					{"inc_price","ecnitem.inc_price"},
					{"matl_cost_conv","ecnitem.matl_cost_conv"},
					{"lbr_cost_conv","ecnitem.lbr_cost_conv"},
					{"fovhd_cost_conv","ecnitem.fovhd_cost_conv"},
					{"vovhd_cost_conv","ecnitem.vovhd_cost_conv"},
					{"out_cost_conv","ecnitem.out_cost_conv"},
					{"cost_conv","ecnitem.cost_conv"},
					{"ref_seq","ecnitem.ref_seq"},
					{"bubble","ecnitem.bubble"},
					{"ref_des","ecnitem.ref_des"},
					{"assy_seq","ecnitem.assy_seq"},
					{"u0","ecn.stat"},
					{"u1","ecnitem.action_code"},
					{"u2","ecnitem.stat"},
					{"u3","ecnitem.bflush_type"},
					{"u4","ecnitem.run_basis_mch"},
					{"u5","ecnitem.run_basis_lbr"},
					{"u6","ecnitem.matl_type"},
					{"u7","ecnitem.units"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "ecn",
				fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN ecnpri ON ecnpri.prior_code = ecn.prior_code LEFT OUTER JOIN reason ON reason.reason_code = ecn.reason_code
					AND reason.reason_class = 'ECN' LEFT OUTER JOIN ecndist ON ecndist.dist_code = ecn.dist_code LEFT OUTER JOIN ecnitem ON ecnitem.ecn_num = ecn.ecn_num LEFT OUTER JOIN item ON item.item = ecnitem.item LEFT OUTER JOIN item AS i ON i.item = ecnitem.matl_item LEFT OUTER JOIN wc ON wc.wc = ecnitem.wc LEFT OUTER JOIN feature ON feature.feature = ecnitem.feature LEFT OUTER JOIN ObjectNotes AS obn ON obn.RefRowPointer = ecnitem.RowPointer LEFT OUTER JOIN NoteHeaders AS nhs ON nhs.NoteHeaderToken = obn.NoteHeaderToken
					AND nhs.ObjectName = 'ecnbomnotes' LEFT OUTER JOIN SystemNotes AS syn ON syn.SystemNoteToken = obn.SystemNoteToken LEFT OUTER JOIN SpecificNotes AS spc ON spc.SpecificNoteToken = obn.SpecificNoteToken LEFT OUTER JOIN UserNotes AS usn ON usn.UserNoteToken = obn.UserNoteToken"),
				whereClause: collectionLoadRequestFactory.Clause("ecn.ecn_num = {0}", ECNNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			return this.appDB.Load(ecn_crsLoadRequestForCursor);
		}
		public ICollectionLoadResponse Nontable1Select(Guid? EsigRowpointer, int? Counter, string ECNNum)
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sECN"},
					{ "column_value", ECNNum},
					{ "key_sequence", "1"},
			});

			return this.appDB.Load(nonTable1LoadRequest);
		}
		public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
		{
			var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable1LoadResponse.Items);

			this.appDB.Insert(nonTable1InsertRequest);
		}

		public ICollectionLoadResponse Nontable2Select(Guid? EsigRowpointer, int? Counter, string Stat)
		{
			var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sStatus"},
					{ "column_value", Stat},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable2LoadRequest);
		}
		public void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse)
		{
			var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable2LoadResponse.Items);

			this.appDB.Insert(nonTable2InsertRequest);
		}

		public ICollectionLoadResponse Nontable3Select(Guid? EsigRowpointer, int? Counter, string Orig)
		{
			var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOriginator"},
					{ "column_value", Orig},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable3LoadRequest);
		}
		public void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse)
		{
			var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable3LoadResponse.Items);

			this.appDB.Insert(nonTable3InsertRequest);
		}

		public ICollectionLoadResponse Nontable4Select(Guid? EsigRowpointer, int? Counter, string ReqDate)
		{
			var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRequestedDate"},
					{ "column_value", ReqDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable4LoadRequest);
		}
		public void Nontable4Insert(ICollectionLoadResponse nonTable4LoadResponse)
		{
			var nonTable4InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable4LoadResponse.Items);

			this.appDB.Insert(nonTable4InsertRequest);
		}

		public ICollectionLoadResponse Nontable5Select(Guid? EsigRowpointer, int? Counter, string AppDate)
		{
			var nonTable5LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sApprovedDate"},
					{ "column_value", AppDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable5LoadRequest);
		}
		public void Nontable5Insert(ICollectionLoadResponse nonTable5LoadResponse)
		{
			var nonTable5InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable5LoadResponse.Items);

			this.appDB.Insert(nonTable5InsertRequest);
		}

		public ICollectionLoadResponse Nontable6Select(Guid? EsigRowpointer, int? Counter, string EffectDate)
		{
			var nonTable6LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sEffectiveDate"},
					{ "column_value", EffectDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable6LoadRequest);
		}
		public void Nontable6Insert(ICollectionLoadResponse nonTable6LoadResponse)
		{
			var nonTable6InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable6LoadResponse.Items);

			this.appDB.Insert(nonTable6InsertRequest);
		}

		public ICollectionLoadResponse Nontable7Select(Guid? EsigRowpointer, int? Counter, string CompDate)
		{
			var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sCompletedDate"},
					{ "column_value", CompDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable7LoadRequest);
		}
		public void Nontable7Insert(ICollectionLoadResponse nonTable7LoadResponse)
		{
			var nonTable7InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable7LoadResponse.Items);

			this.appDB.Insert(nonTable7InsertRequest);
		}

		public ICollectionLoadResponse Nontable8Select(Guid? EsigRowpointer, int? Counter, string PriorCode)
		{
			var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sPriority"},
					{ "column_value", PriorCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable8LoadRequest);
		}
		public void Nontable8Insert(ICollectionLoadResponse nonTable8LoadResponse)
		{
			var nonTable8InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable8LoadResponse.Items);

			this.appDB.Insert(nonTable8InsertRequest);
		}

		public ICollectionLoadResponse Nontable9Select(Guid? EsigRowpointer, int? Counter, string PriDescription)
		{
			var nonTable9LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sPriorityDescription"},
					{ "column_value", PriDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable9LoadRequest);
		}
		public void Nontable9Insert(ICollectionLoadResponse nonTable9LoadResponse)
		{
			var nonTable9InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable9LoadResponse.Items);

			this.appDB.Insert(nonTable9InsertRequest);
		}

		public ICollectionLoadResponse Nontable10Select(Guid? EsigRowpointer, int? Counter, string ReasonCode)
		{
			var nonTable10LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sReason"},
					{ "column_value", ReasonCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable10LoadRequest);
		}
		public void Nontable10Insert(ICollectionLoadResponse nonTable10LoadResponse)
		{
			var nonTable10InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable10LoadResponse.Items);

			this.appDB.Insert(nonTable10InsertRequest);
		}

		public ICollectionLoadResponse Nontable11Select(Guid? EsigRowpointer, int? Counter, string ReasonDescription)
		{
			var nonTable11LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sReasonDescription"},
					{ "column_value", ReasonDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable11LoadRequest);
		}
		public void Nontable11Insert(ICollectionLoadResponse nonTable11LoadResponse)
		{
			var nonTable11InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable11LoadResponse.Items);

			this.appDB.Insert(nonTable11InsertRequest);
		}

		public ICollectionLoadResponse Nontable12Select(Guid? EsigRowpointer, int? Counter, string DistCode)
		{
			var nonTable12LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sDistribution"},
					{ "column_value", DistCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable12LoadRequest);
		}
		public void Nontable12Insert(ICollectionLoadResponse nonTable12LoadResponse)
		{
			var nonTable12InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable12LoadResponse.Items);

			this.appDB.Insert(nonTable12InsertRequest);
		}

		public ICollectionLoadResponse Nontable13Select(Guid? EsigRowpointer, int? Counter, string DistDescription)
		{
			var nonTable13LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sDistributionDescription"},
					{ "column_value", DistDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable13LoadRequest);
		}
		public void Nontable13Insert(ICollectionLoadResponse nonTable13LoadResponse)
		{
			var nonTable13InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable13LoadResponse.Items);

			this.appDB.Insert(nonTable13InsertRequest);
		}

		public ICollectionLoadResponse Nontable14Select(Guid? EsigRowpointer, int? Counter, string EcnLine)
		{
			var nonTable14LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sLine"},
					{ "column_value", EcnLine},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable14LoadRequest);
		}
		public void Nontable14Insert(ICollectionLoadResponse nonTable14LoadResponse)
		{
			var nonTable14InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable14LoadResponse.Items);

			this.appDB.Insert(nonTable14InsertRequest);
		}

		public ICollectionLoadResponse Nontable15Select(Guid? EsigRowpointer, int? Counter, string Job)
		{
			var nonTable15LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sJob"},
					{ "column_value", Job},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable15LoadRequest);
		}
		public void Nontable15Insert(ICollectionLoadResponse nonTable15LoadResponse)
		{
			var nonTable15InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable15LoadResponse.Items);

			this.appDB.Insert(nonTable15InsertRequest);
		}

		public ICollectionLoadResponse Nontable16Select(Guid? EsigRowpointer, int? Counter, string Suffix)
		{
			var nonTable16LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSuffix"},
					{ "column_value", Suffix},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable16LoadRequest);
		}
		public void Nontable16Insert(ICollectionLoadResponse nonTable16LoadResponse)
		{
			var nonTable16InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable16LoadResponse.Items);

			this.appDB.Insert(nonTable16InsertRequest);
		}

		public ICollectionLoadResponse Nontable17Select(Guid? EsigRowpointer, int? Counter, string ECNItemType)
		{
			var nonTable17LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sType"},
					{ "column_value", ECNItemType},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable17LoadRequest);
		}
		public void Nontable17Insert(ICollectionLoadResponse nonTable17LoadResponse)
		{
			var nonTable17InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable17LoadResponse.Items);

			this.appDB.Insert(nonTable17InsertRequest);
		}

		public ICollectionLoadResponse Nontable18Select(Guid? EsigRowpointer, int? Counter, string ActionCode)
		{
			var nonTable18LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sAction"},
					{ "column_value", ActionCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable18LoadRequest);
		}
		public void Nontable18Insert(ICollectionLoadResponse nonTable18LoadResponse)
		{
			var nonTable18InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable18LoadResponse.Items);

			this.appDB.Insert(nonTable18InsertRequest);
		}

		public ICollectionLoadResponse Nontable19Select(Guid? EsigRowpointer, int? Counter, string EcniGroup)
		{
			var nonTable19LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sGroup"},
					{ "column_value", EcniGroup},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable19LoadRequest);
		}
		public void Nontable19Insert(ICollectionLoadResponse nonTable19LoadResponse)
		{
			var nonTable19InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable19LoadResponse.Items);

			this.appDB.Insert(nonTable19InsertRequest);
		}

		public ICollectionLoadResponse Nontable20Select(Guid? EsigRowpointer, int? Counter, string Item)
		{
			var nonTable20LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sItem"},
					{ "column_value", Item},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable20LoadRequest);
		}
		public void Nontable20Insert(ICollectionLoadResponse nonTable20LoadResponse)
		{
			var nonTable20InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable20LoadResponse.Items);

			this.appDB.Insert(nonTable20InsertRequest);
		}

		public ICollectionLoadResponse Nontable21Select(Guid? EsigRowpointer, int? Counter, string ItemDescription)
		{
			var nonTable21LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sItemDescription"},
					{ "column_value", ItemDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable21LoadRequest);
		}
		public void Nontable21Insert(ICollectionLoadResponse nonTable21LoadResponse)
		{
			var nonTable21InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable21LoadResponse.Items);

			this.appDB.Insert(nonTable21InsertRequest);
		}

		public ICollectionLoadResponse Nontable22Select(Guid? EsigRowpointer, int? Counter, string ItemStat)
		{
			var nonTable22LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sStatus"},
					{ "column_value", ItemStat},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable22LoadRequest);
		}
		public void Nontable22Insert(ICollectionLoadResponse nonTable22LoadResponse)
		{
			var nonTable22InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable22LoadResponse.Items);

			this.appDB.Insert(nonTable22InsertRequest);
		}

		public ICollectionLoadResponse Nontable23Select(Guid? EsigRowpointer, int? Counter, string Revision)
		{
			var nonTable23LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRevision"},
					{ "column_value", Revision},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable23LoadRequest);
		}
		public void Nontable23Insert(ICollectionLoadResponse nonTable23LoadResponse)
		{
			var nonTable23InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable23LoadResponse.Items);

			this.appDB.Insert(nonTable23InsertRequest);
		}

		public ICollectionLoadResponse Nontable24Select(Guid? EsigRowpointer, int? Counter, string OperNum)
		{
			var nonTable24LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOperation"},
					{ "column_value", OperNum},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable24LoadRequest);
		}
		public void Nontable24Insert(ICollectionLoadResponse nonTable24LoadResponse)
		{
			var nonTable24InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable24LoadResponse.Items);

			this.appDB.Insert(nonTable24InsertRequest);
		}

		public ICollectionLoadResponse Nontable25Select(Guid? EsigRowpointer, int? Counter, string WC)
		{
			var nonTable25LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sWC"},
					{ "column_value", WC},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable25LoadRequest);
		}
		public void Nontable25Insert(ICollectionLoadResponse nonTable25LoadResponse)
		{
			var nonTable25InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable25LoadResponse.Items);

			this.appDB.Insert(nonTable25InsertRequest);
		}

		public ICollectionLoadResponse Nontable26Select(Guid? EsigRowpointer, int? Counter, string WCDescription)
		{
			var nonTable26LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sWCDescription"},
					{ "column_value", WCDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable26LoadRequest);
		}
		public void Nontable26Insert(ICollectionLoadResponse nonTable26LoadResponse)
		{
			var nonTable26InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable26LoadResponse.Items);

			this.appDB.Insert(nonTable26InsertRequest);
		}

		public ICollectionLoadResponse Nontable27Select(Guid? EsigRowpointer, int? Counter, string BflushType)
		{
			var nonTable27LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sBackflush"},
					{ "column_value", BflushType},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable27LoadRequest);
		}
		public void Nontable27Insert(ICollectionLoadResponse nonTable27LoadResponse)
		{
			var nonTable27InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable27LoadResponse.Items);

			this.appDB.Insert(nonTable27InsertRequest);
		}

		public ICollectionLoadResponse Nontable28Select(Guid? EsigRowpointer, int? Counter, string SchedHrs)
		{
			var nonTable28LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sFixedSchedHours"},
					{ "column_value", SchedHrs},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable28LoadRequest);
		}
		public void Nontable28Insert(ICollectionLoadResponse nonTable28LoadResponse)
		{
			var nonTable28InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable28LoadResponse.Items);

			this.appDB.Insert(nonTable28InsertRequest);
		}

		public ICollectionLoadResponse Nontable29Select(Guid? EsigRowpointer, int? Counter, string RunBasisMch)
		{
			var nonTable29LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRun-HoursBasis(Mch)"},
					{ "column_value", RunBasisMch},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable29LoadRequest);
		}
		public void Nontable29Insert(ICollectionLoadResponse nonTable29LoadResponse)
		{
			var nonTable29InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable29LoadResponse.Items);

			this.appDB.Insert(nonTable29InsertRequest);
		}

		public ICollectionLoadResponse Nontable30Select(Guid? EsigRowpointer, int? Counter, string RunMchHours)
		{
			var nonTable30LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRunMchHours"},
					{ "column_value", RunMchHours},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable30LoadRequest);
		}
		public void Nontable30Insert(ICollectionLoadResponse nonTable30LoadResponse)
		{
			var nonTable30InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable30LoadResponse.Items);

			this.appDB.Insert(nonTable30InsertRequest);
		}

		public ICollectionLoadResponse Nontable31Select(Guid? EsigRowpointer, int? Counter, string RunBasisLbr)
		{
			var nonTable31LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRun-HoursBasis(Lbr)"},
					{ "column_value", RunBasisLbr},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable31LoadRequest);
		}
		public void Nontable31Insert(ICollectionLoadResponse nonTable31LoadResponse)
		{
			var nonTable31InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable31LoadResponse.Items);

			this.appDB.Insert(nonTable31InsertRequest);
		}

		public ICollectionLoadResponse Nontable32Select(Guid? EsigRowpointer, int? Counter, string RunLbrHours)
		{
			var nonTable32LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRunLbrHours"},
					{ "column_value", RunLbrHours},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable32LoadRequest);
		}
		public void Nontable32Insert(ICollectionLoadResponse nonTable32LoadResponse)
		{
			var nonTable32InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable32LoadResponse.Items);

			this.appDB.Insert(nonTable32InsertRequest);
		}

		public ICollectionLoadResponse Nontable33Select(Guid? EsigRowpointer, int? Counter, string MoveHrs)
		{
			var nonTable33LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMove"},
					{ "column_value", MoveHrs},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable33LoadRequest);
		}
		public void Nontable33Insert(ICollectionLoadResponse nonTable33LoadResponse)
		{
			var nonTable33InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable33LoadResponse.Items);

			this.appDB.Insert(nonTable33InsertRequest);
		}

		public ICollectionLoadResponse Nontable34Select(Guid? EsigRowpointer, int? Counter, string QueueHrs)
		{
			var nonTable34LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sQueue"},
					{ "column_value", QueueHrs},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable34LoadRequest);
		}
		public void Nontable34Insert(ICollectionLoadResponse nonTable34LoadResponse)
		{
			var nonTable34InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable34LoadResponse.Items);

			this.appDB.Insert(nonTable34InsertRequest);
		}

		public ICollectionLoadResponse Nontable35Select(Guid? EsigRowpointer, int? Counter, string SetupHrs)
		{
			var nonTable35LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSetupJob"},
					{ "column_value", SetupHrs},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable35LoadRequest);
		}
		public void Nontable35Insert(ICollectionLoadResponse nonTable35LoadResponse)
		{
			var nonTable35InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable35LoadResponse.Items);

			this.appDB.Insert(nonTable35InsertRequest);
		}

		public ICollectionLoadResponse Nontable36Select(Guid? EsigRowpointer, int? Counter, string FinishHrs)
		{
			var nonTable36LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sFinish"},
					{ "column_value", FinishHrs},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable36LoadRequest);
		}
		public void Nontable36Insert(ICollectionLoadResponse nonTable36LoadResponse)
		{
			var nonTable36InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable36LoadResponse.Items);

			this.appDB.Insert(nonTable36InsertRequest);
		}

		public ICollectionLoadResponse Nontable37Select(Guid? EsigRowpointer, int? Counter, string OffsetHrs)
		{
			var nonTable37LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOffset"},
					{ "column_value", OffsetHrs},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable37LoadRequest);
		}
		public void Nontable37Insert(ICollectionLoadResponse nonTable37LoadResponse)
		{
			var nonTable37InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable37LoadResponse.Items);

			this.appDB.Insert(nonTable37InsertRequest);
		}

		public ICollectionLoadResponse Nontable38Select(Guid? EsigRowpointer, int? Counter, string EffectDate)
		{
			var nonTable38LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sEffective"},
					{ "column_value", EffectDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable38LoadRequest);
		}
		public void Nontable38Insert(ICollectionLoadResponse nonTable38LoadResponse)
		{
			var nonTable38InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable38LoadResponse.Items);

			this.appDB.Insert(nonTable38InsertRequest);
		}

		public ICollectionLoadResponse Nontable39Select(Guid? EsigRowpointer, int? Counter, string ObsDate)
		{
			var nonTable39LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sObsolete"},
					{ "column_value", ObsDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable39LoadRequest);
		}
		public void Nontable39Insert(ICollectionLoadResponse nonTable39LoadResponse)
		{
			var nonTable39InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable39LoadResponse.Items);

			this.appDB.Insert(nonTable39InsertRequest);
		}

		public ICollectionLoadResponse Nontable40Select(Guid? EsigRowpointer, int? Counter, string SpecificNoteDesc)
		{
			var nonTable40LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSubject"},
					{ "column_value", SpecificNoteDesc},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable40LoadRequest);
		}
		public void Nontable40Insert(ICollectionLoadResponse nonTable40LoadResponse)
		{
			var nonTable40InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable40LoadResponse.Items);

			this.appDB.Insert(nonTable40InsertRequest);
		}

		public ICollectionLoadResponse Nontable41Select(Guid? EsigRowpointer, int? Counter, string SpecificNoteContent)
		{
			var nonTable41LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sNotes"},
					{ "column_value", SpecificNoteContent},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable41LoadRequest);
		}
		public void Nontable41Insert(ICollectionLoadResponse nonTable41LoadResponse)
		{
			var nonTable41InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable41LoadResponse.Items);

			this.appDB.Insert(nonTable41InsertRequest);
		}

		public ICollectionLoadResponse Nontable42Select(Guid? EsigRowpointer, int? Counter, string EcnLine)
		{
			var nonTable42LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sLine"},
					{ "column_value", EcnLine},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable42LoadRequest);
		}
		public void Nontable42Insert(ICollectionLoadResponse nonTable42LoadResponse)
		{
			var nonTable42InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable42LoadResponse.Items);

			this.appDB.Insert(nonTable42InsertRequest);
		}

		public ICollectionLoadResponse Nontable43Select(Guid? EsigRowpointer, int? Counter, string Job)
		{
			var nonTable43LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sJob"},
					{ "column_value", Job},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable43LoadRequest);
		}
		public void Nontable43Insert(ICollectionLoadResponse nonTable43LoadResponse)
		{
			var nonTable43InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable43LoadResponse.Items);

			this.appDB.Insert(nonTable43InsertRequest);
		}

		public ICollectionLoadResponse Nontable44Select(Guid? EsigRowpointer, int? Counter, string Suffix)
		{
			var nonTable44LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSuffix"},
					{ "column_value", Suffix},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable44LoadRequest);
		}
		public void Nontable44Insert(ICollectionLoadResponse nonTable44LoadResponse)
		{
			var nonTable44InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable44LoadResponse.Items);

			this.appDB.Insert(nonTable44InsertRequest);
		}

		public ICollectionLoadResponse Nontable45Select(Guid? EsigRowpointer, int? Counter, string ECNItemType)
		{
			var nonTable45LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sType"},
					{ "column_value", ECNItemType},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable45LoadRequest);
		}
		public void Nontable45Insert(ICollectionLoadResponse nonTable45LoadResponse)
		{
			var nonTable45InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable45LoadResponse.Items);

			this.appDB.Insert(nonTable45InsertRequest);
		}

		public ICollectionLoadResponse Nontable46Select(Guid? EsigRowpointer, int? Counter, string ActionCode)
		{
			var nonTable46LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sAction"},
					{ "column_value", ActionCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable46LoadRequest);
		}
		public void Nontable46Insert(ICollectionLoadResponse nonTable46LoadResponse)
		{
			var nonTable46InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable46LoadResponse.Items);

			this.appDB.Insert(nonTable46InsertRequest);
		}

		public ICollectionLoadResponse Nontable47Select(Guid? EsigRowpointer, int? Counter, string EcniGroup)
		{
			var nonTable47LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sGroup"},
					{ "column_value", EcniGroup},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable47LoadRequest);
		}
		public void Nontable47Insert(ICollectionLoadResponse nonTable47LoadResponse)
		{
			var nonTable47InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable47LoadResponse.Items);

			this.appDB.Insert(nonTable47InsertRequest);
		}

		public ICollectionLoadResponse Nontable48Select(Guid? EsigRowpointer, int? Counter, string Item)
		{
			var nonTable48LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sItem"},
					{ "column_value", Item},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable48LoadRequest);
		}
		public void Nontable48Insert(ICollectionLoadResponse nonTable48LoadResponse)
		{
			var nonTable48InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable48LoadResponse.Items);

			this.appDB.Insert(nonTable48InsertRequest);
		}

		public ICollectionLoadResponse Nontable49Select(Guid? EsigRowpointer, int? Counter, string ItemDescription)
		{
			var nonTable49LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sItemDescription"},
					{ "column_value", ItemDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable49LoadRequest);
		}
		public void Nontable49Insert(ICollectionLoadResponse nonTable49LoadResponse)
		{
			var nonTable49InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable49LoadResponse.Items);

			this.appDB.Insert(nonTable49InsertRequest);
		}

		public ICollectionLoadResponse Nontable50Select(Guid? EsigRowpointer, int? Counter, string ItemStat)
		{
			var nonTable50LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sStatus"},
					{ "column_value", ItemStat},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable50LoadRequest);
		}
		public void Nontable50Insert(ICollectionLoadResponse nonTable50LoadResponse)
		{
			var nonTable50InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable50LoadResponse.Items);

			this.appDB.Insert(nonTable50InsertRequest);
		}

		public ICollectionLoadResponse Nontable51Select(Guid? EsigRowpointer, int? Counter, string Revision)
		{
			var nonTable51LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRevision"},
					{ "column_value", Revision},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable51LoadRequest);
		}
		public void Nontable51Insert(ICollectionLoadResponse nonTable51LoadResponse)
		{
			var nonTable51InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable51LoadResponse.Items);

			this.appDB.Insert(nonTable51InsertRequest);
		}

		public ICollectionLoadResponse Nontable52Select(Guid? EsigRowpointer, int? Counter, string OperNum)
		{
			var nonTable52LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOperation"},
					{ "column_value", OperNum},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable52LoadRequest);
		}
		public void Nontable52Insert(ICollectionLoadResponse nonTable52LoadResponse)
		{
			var nonTable52InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable52LoadResponse.Items);

			this.appDB.Insert(nonTable52InsertRequest);
		}

		public ICollectionLoadResponse Nontable53Select(Guid? EsigRowpointer, int? Counter, string WC)
		{
			var nonTable53LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sWC"},
					{ "column_value", WC},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable53LoadRequest);
		}
		public void Nontable53Insert(ICollectionLoadResponse nonTable53LoadResponse)
		{
			var nonTable53InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable53LoadResponse.Items);

			this.appDB.Insert(nonTable53InsertRequest);
		}

		public ICollectionLoadResponse Nontable54Select(Guid? EsigRowpointer, int? Counter, string WCDescription)
		{
			var nonTable54LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sWCDescription"},
					{ "column_value", WCDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable54LoadRequest);
		}
		public void Nontable54Insert(ICollectionLoadResponse nonTable54LoadResponse)
		{
			var nonTable54InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable54LoadResponse.Items);

			this.appDB.Insert(nonTable54InsertRequest);
		}

		public ICollectionLoadResponse Nontable55Select(Guid? EsigRowpointer, int? Counter, string EffectDate)
		{
			var nonTable55LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sEffective"},
					{ "column_value", EffectDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable55LoadRequest);
		}
		public void Nontable55Insert(ICollectionLoadResponse nonTable55LoadResponse)
		{
			var nonTable55InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable55LoadResponse.Items);

			this.appDB.Insert(nonTable55InsertRequest);
		}

		public ICollectionLoadResponse Nontable56Select(Guid? EsigRowpointer, int? Counter, string ObsDate)
		{
			var nonTable56LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sObsolete"},
					{ "column_value", ObsDate},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable56LoadRequest);
		}
		public void Nontable56Insert(ICollectionLoadResponse nonTable56LoadResponse)
		{
			var nonTable56InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable56LoadResponse.Items);

			this.appDB.Insert(nonTable56InsertRequest);
		}

		public ICollectionLoadResponse Nontable57Select(Guid? EsigRowpointer, int? Counter, string SpecificNoteDesc)
		{
			var nonTable57LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSubject"},
					{ "column_value", SpecificNoteDesc},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable57LoadRequest);
		}
		public void Nontable57Insert(ICollectionLoadResponse nonTable57LoadResponse)
		{
			var nonTable57InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable57LoadResponse.Items);

			this.appDB.Insert(nonTable57InsertRequest);
		}

		public ICollectionLoadResponse Nontable58Select(Guid? EsigRowpointer, int? Counter, string SpecificNoteContent)
		{
			var nonTable58LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sNotes"},
					{ "column_value", SpecificNoteContent},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable58LoadRequest);
		}
		public void Nontable58Insert(ICollectionLoadResponse nonTable58LoadResponse)
		{
			var nonTable58InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable58LoadResponse.Items);

			this.appDB.Insert(nonTable58InsertRequest);
		}

		public ICollectionLoadResponse Nontable59Select(Guid? EsigRowpointer, int? Counter, string MatlItem)
		{
			var nonTable59LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMaterial"},
					{ "column_value", MatlItem},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable59LoadRequest);
		}
		public void Nontable59Insert(ICollectionLoadResponse nonTable59LoadResponse)
		{
			var nonTable59InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable59LoadResponse.Items);

			this.appDB.Insert(nonTable59InsertRequest);
		}

		public ICollectionLoadResponse Nontable60Select(Guid? EsigRowpointer, int? Counter, string MatlDescription)
		{
			var nonTable60LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMaterialDescription"},
					{ "column_value", MatlDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable60LoadRequest);
		}
		public void Nontable60Insert(ICollectionLoadResponse nonTable60LoadResponse)
		{
			var nonTable60InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable60LoadResponse.Items);

			this.appDB.Insert(nonTable60InsertRequest);
		}

		public ICollectionLoadResponse Nontable61Select(Guid? EsigRowpointer, int? Counter, string AltGroup)
		{
			var nonTable61LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sAltGroup"},
					{ "column_value", AltGroup},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable61LoadRequest);
		}
		public void Nontable61Insert(ICollectionLoadResponse nonTable61LoadResponse)
		{
			var nonTable61InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable61LoadResponse.Items);

			this.appDB.Insert(nonTable61InsertRequest);
		}

		public ICollectionLoadResponse Nontable62Select(Guid? EsigRowpointer, int? Counter, string AltGroupRank)
		{
			var nonTable62LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sAltGroupRank"},
					{ "column_value", AltGroupRank},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable62LoadRequest);
		}
		public void Nontable62Insert(ICollectionLoadResponse nonTable62LoadResponse)
		{
			var nonTable62InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable62LoadResponse.Items);

			this.appDB.Insert(nonTable62InsertRequest);
		}

		public ICollectionLoadResponse Nontable63Select(Guid? EsigRowpointer, int? Counter, string Sequence)
		{
			var nonTable63LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSequence"},
					{ "column_value", Sequence},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable63LoadRequest);
		}
		public void Nontable63Insert(ICollectionLoadResponse nonTable63LoadResponse)
		{
			var nonTable63InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable63LoadResponse.Items);

			this.appDB.Insert(nonTable63InsertRequest);
		}

		public ICollectionLoadResponse Nontable64Select(Guid? EsigRowpointer, int? Counter, string MatlType)
		{
			var nonTable64LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMaterialType"},
					{ "column_value", MatlType},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable64LoadRequest);
		}
		public void Nontable64Insert(ICollectionLoadResponse nonTable64LoadResponse)
		{
			var nonTable64InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable64LoadResponse.Items);

			this.appDB.Insert(nonTable64InsertRequest);
		}

		public ICollectionLoadResponse Nontable65Select(Guid? EsigRowpointer, int? Counter, string MatlQtyConv)
		{
			var nonTable65LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sQuantity"},
					{ "column_value", MatlQtyConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable65LoadRequest);
		}
		public void Nontable65Insert(ICollectionLoadResponse nonTable65LoadResponse)
		{
			var nonTable65InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable65LoadResponse.Items);

			this.appDB.Insert(nonTable65InsertRequest);
		}

		public ICollectionLoadResponse Nontable66Select(Guid? EsigRowpointer, int? Counter, string Units)
		{
			var nonTable66LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sUnits"},
					{ "column_value", Units},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable66LoadRequest);
		}
		public void Nontable66Insert(ICollectionLoadResponse nonTable66LoadResponse)
		{
			var nonTable66InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable66LoadResponse.Items);

			this.appDB.Insert(nonTable66InsertRequest);
		}

		public ICollectionLoadResponse Nontable67Select(Guid? EsigRowpointer, int? Counter, string UM)
		{
			var nonTable67LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sU/M"},
					{ "column_value", UM},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable67LoadRequest);
		}
		public void Nontable67Insert(ICollectionLoadResponse nonTable67LoadResponse)
		{
			var nonTable67InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable67LoadResponse.Items);

			this.appDB.Insert(nonTable67InsertRequest);
		}

		public ICollectionLoadResponse Nontable68Select(Guid? EsigRowpointer, int? Counter, string BOMSeq)
		{
			var nonTable68LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sBOMSeq"},
					{ "column_value", BOMSeq},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable68LoadRequest);
		}
		public void Nontable68Insert(ICollectionLoadResponse nonTable68LoadResponse)
		{
			var nonTable68InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable68LoadResponse.Items);

			this.appDB.Insert(nonTable68InsertRequest);
		}

		public ICollectionLoadResponse Nontable69Select(Guid? EsigRowpointer, int? Counter, string Feature)
		{
			var nonTable69LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sFeature"},
					{ "column_value", Feature},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable69LoadRequest);
		}
		public void Nontable69Insert(ICollectionLoadResponse nonTable69LoadResponse)
		{
			var nonTable69InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable69LoadResponse.Items);

			this.appDB.Insert(nonTable69InsertRequest);
		}

		public ICollectionLoadResponse Nontable70Select(Guid? EsigRowpointer, int? Counter, string FeatureDescription)
		{
			var nonTable70LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sFeatureDescription"},
					{ "column_value", FeatureDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable70LoadRequest);
		}
		public void Nontable70Insert(ICollectionLoadResponse nonTable70LoadResponse)
		{
			var nonTable70InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable70LoadResponse.Items);

			this.appDB.Insert(nonTable70InsertRequest);
		}

		public ICollectionLoadResponse Nontable71Select(Guid? EsigRowpointer, int? Counter, string OptCode)
		{
			var nonTable71LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOptionCode"},
					{ "column_value", OptCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable71LoadRequest);
		}
		public void Nontable71Insert(ICollectionLoadResponse nonTable71LoadResponse)
		{
			var nonTable71InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable71LoadResponse.Items);

			this.appDB.Insert(nonTable71InsertRequest);
		}

		public ICollectionLoadResponse Nontable72Select(Guid? EsigRowpointer, int? Counter, string Probable)
		{
			var nonTable72LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sProbable"},
					{ "column_value", Probable},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable72LoadRequest);
		}
		public void Nontable72Insert(ICollectionLoadResponse nonTable72LoadResponse)
		{
			var nonTable72InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable72LoadResponse.Items);

			this.appDB.Insert(nonTable72InsertRequest);
		}

		public ICollectionLoadResponse Nontable73Select(Guid? EsigRowpointer, int? Counter, string IncPrice)
		{
			var nonTable73LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sIncrementalPrice"},
					{ "column_value", IncPrice},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable73LoadRequest);
		}
		public void Nontable73Insert(ICollectionLoadResponse nonTable73LoadResponse)
		{
			var nonTable73InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable73LoadResponse.Items);

			this.appDB.Insert(nonTable73InsertRequest);
		}

		public ICollectionLoadResponse Nontable74Select(Guid? EsigRowpointer, int? Counter, string MatlCostConv)
		{
			var nonTable74LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMaterialCost"},
					{ "column_value", MatlCostConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable74LoadRequest);
		}
		public void Nontable74Insert(ICollectionLoadResponse nonTable74LoadResponse)
		{
			var nonTable74InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable74LoadResponse.Items);

			this.appDB.Insert(nonTable74InsertRequest);
		}

		public ICollectionLoadResponse Nontable75Select(Guid? EsigRowpointer, int? Counter, string LbrCostConv)
		{
			var nonTable75LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sLaborCost"},
					{ "column_value", LbrCostConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable75LoadRequest);
		}
		public void Nontable75Insert(ICollectionLoadResponse nonTable75LoadResponse)
		{
			var nonTable75InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable75LoadResponse.Items);

			this.appDB.Insert(nonTable75InsertRequest);
		}

		public ICollectionLoadResponse Nontable76Select(Guid? EsigRowpointer, int? Counter, string FovhdCostConv)
		{
			var nonTable76LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sFixedOverheadCost"},
					{ "column_value", FovhdCostConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable76LoadRequest);
		}
		public void Nontable76Insert(ICollectionLoadResponse nonTable76LoadResponse)
		{
			var nonTable76InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable76LoadResponse.Items);

			this.appDB.Insert(nonTable76InsertRequest);
		}

		public ICollectionLoadResponse Nontable77Select(Guid? EsigRowpointer, int? Counter, string VovhdCostConv)
		{
			var nonTable77LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sVariableOverheadCost"},
					{ "column_value", VovhdCostConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable77LoadRequest);
		}
		public void Nontable77Insert(ICollectionLoadResponse nonTable77LoadResponse)
		{
			var nonTable77InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable77LoadResponse.Items);

			this.appDB.Insert(nonTable77InsertRequest);
		}

		public ICollectionLoadResponse Nontable78Select(Guid? EsigRowpointer, int? Counter, string OutCostConv)
		{
			var nonTable78LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOutsideCost"},
					{ "column_value", OutCostConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable78LoadRequest);
		}
		public void Nontable78Insert(ICollectionLoadResponse nonTable78LoadResponse)
		{
			var nonTable78InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable78LoadResponse.Items);

			this.appDB.Insert(nonTable78InsertRequest);
		}

		public ICollectionLoadResponse Nontable79Select(Guid? EsigRowpointer, int? Counter, string CostConv)
		{
			var nonTable79LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sTotalCost"},
					{ "column_value", CostConv},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable79LoadRequest);
		}
		public void Nontable79Insert(ICollectionLoadResponse nonTable79LoadResponse)
		{
			var nonTable79InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable79LoadResponse.Items);

			this.appDB.Insert(nonTable79InsertRequest);
		}

		public ICollectionLoadResponse Nontable80Select(Guid? EsigRowpointer, int? Counter, string EcnLine)
		{
			var nonTable80LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sLine"},
					{ "column_value", EcnLine},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable80LoadRequest);
		}
		public void Nontable80Insert(ICollectionLoadResponse nonTable80LoadResponse)
		{
			var nonTable80InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable80LoadResponse.Items);

			this.appDB.Insert(nonTable80InsertRequest);
		}

		public ICollectionLoadResponse Nontable81Select(Guid? EsigRowpointer, int? Counter, string Job)
		{
			var nonTable81LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sJob"},
					{ "column_value", Job},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable81LoadRequest);
		}
		public void Nontable81Insert(ICollectionLoadResponse nonTable81LoadResponse)
		{
			var nonTable81InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable81LoadResponse.Items);

			this.appDB.Insert(nonTable81InsertRequest);
		}

		public ICollectionLoadResponse Nontable82Select(Guid? EsigRowpointer, int? Counter, string Suffix)
		{
			var nonTable82LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSuffix"},
					{ "column_value", Suffix},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable82LoadRequest);
		}
		public void Nontable82Insert(ICollectionLoadResponse nonTable82LoadResponse)
		{
			var nonTable82InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable82LoadResponse.Items);

			this.appDB.Insert(nonTable82InsertRequest);
		}

		public ICollectionLoadResponse Nontable83Select(Guid? EsigRowpointer, int? Counter, string ECNItemType)
		{
			var nonTable83LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sType"},
					{ "column_value", ECNItemType},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable83LoadRequest);
		}
		public void Nontable83Insert(ICollectionLoadResponse nonTable83LoadResponse)
		{
			var nonTable83InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable83LoadResponse.Items);

			this.appDB.Insert(nonTable83InsertRequest);
		}

		public ICollectionLoadResponse Nontable84Select(Guid? EsigRowpointer, int? Counter, string ActionCode)
		{
			var nonTable84LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sAction"},
					{ "column_value", ActionCode},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable84LoadRequest);
		}
		public void Nontable84Insert(ICollectionLoadResponse nonTable84LoadResponse)
		{
			var nonTable84InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable84LoadResponse.Items);

			this.appDB.Insert(nonTable84InsertRequest);
		}

		public ICollectionLoadResponse Nontable85Select(Guid? EsigRowpointer, int? Counter, string EcniGroup)
		{
			var nonTable85LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sGroup"},
					{ "column_value", EcniGroup},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable85LoadRequest);
		}
		public void Nontable85Insert(ICollectionLoadResponse nonTable85LoadResponse)
		{
			var nonTable85InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable85LoadResponse.Items);

			this.appDB.Insert(nonTable85InsertRequest);
		}

		public ICollectionLoadResponse Nontable86Select(Guid? EsigRowpointer, int? Counter, string Item)
		{
			var nonTable86LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sItem"},
					{ "column_value", Item},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable86LoadRequest);
		}
		public void Nontable86Insert(ICollectionLoadResponse nonTable86LoadResponse)
		{
			var nonTable86InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable86LoadResponse.Items);

			this.appDB.Insert(nonTable86InsertRequest);
		}

		public ICollectionLoadResponse Nontable87Select(Guid? EsigRowpointer, int? Counter, string ItemDescription)
		{
			var nonTable87LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sItemDescription"},
					{ "column_value", ItemDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable87LoadRequest);
		}
		public void Nontable87Insert(ICollectionLoadResponse nonTable87LoadResponse)
		{
			var nonTable87InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable87LoadResponse.Items);

			this.appDB.Insert(nonTable87InsertRequest);
		}

		public ICollectionLoadResponse Nontable88Select(Guid? EsigRowpointer, int? Counter, string ItemStat)
		{
			var nonTable88LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sStatus"},
					{ "column_value", ItemStat},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable88LoadRequest);
		}
		public void Nontable88Insert(ICollectionLoadResponse nonTable88LoadResponse)
		{
			var nonTable88InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable88LoadResponse.Items);

			this.appDB.Insert(nonTable88InsertRequest);
		}

		public ICollectionLoadResponse Nontable89Select(Guid? EsigRowpointer, int? Counter, string Revision)
		{
			var nonTable89LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRevision"},
					{ "column_value", Revision},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable89LoadRequest);
		}
		public void Nontable89Insert(ICollectionLoadResponse nonTable89LoadResponse)
		{
			var nonTable89InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable89LoadResponse.Items);

			this.appDB.Insert(nonTable89InsertRequest);
		}

		public ICollectionLoadResponse Nontable90Select(Guid? EsigRowpointer, int? Counter, string OperNum)
		{
			var nonTable90LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sOperation"},
					{ "column_value", OperNum},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable90LoadRequest);
		}
		public void Nontable90Insert(ICollectionLoadResponse nonTable90LoadResponse)
		{
			var nonTable90InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable90LoadResponse.Items);

			this.appDB.Insert(nonTable90InsertRequest);
		}

		public ICollectionLoadResponse Nontable91Select(Guid? EsigRowpointer, int? Counter, string WC)
		{
			var nonTable91LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sWC"},
					{ "column_value", WC},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable91LoadRequest);
		}
		public void Nontable91Insert(ICollectionLoadResponse nonTable91LoadResponse)
		{
			var nonTable91InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable91LoadResponse.Items);

			this.appDB.Insert(nonTable91InsertRequest);
		}

		public ICollectionLoadResponse Nontable92Select(Guid? EsigRowpointer, int? Counter, string WCDescription)
		{
			var nonTable92LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sWCDescription"},
					{ "column_value", WCDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable92LoadRequest);
		}
		public void Nontable92Insert(ICollectionLoadResponse nonTable92LoadResponse)
		{
			var nonTable92InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable92LoadResponse.Items);

			this.appDB.Insert(nonTable92InsertRequest);
		}

		public ICollectionLoadResponse Nontable93Select(Guid? EsigRowpointer, int? Counter, string SpecificNoteDesc)
		{
			var nonTable93LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSubject"},
					{ "column_value", SpecificNoteDesc},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable93LoadRequest);
		}
		public void Nontable93Insert(ICollectionLoadResponse nonTable93LoadResponse)
		{
			var nonTable93InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable93LoadResponse.Items);

			this.appDB.Insert(nonTable93InsertRequest);
		}

		public ICollectionLoadResponse Nontable94Select(Guid? EsigRowpointer, int? Counter, string SpecificNoteContent)
		{
			var nonTable94LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sNotes"},
					{ "column_value", SpecificNoteContent},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable94LoadRequest);
		}
		public void Nontable94Insert(ICollectionLoadResponse nonTable94LoadResponse)
		{
			var nonTable94InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable94LoadResponse.Items);

			this.appDB.Insert(nonTable94InsertRequest);
		}

		public ICollectionLoadResponse Nontable95Select(Guid? EsigRowpointer, int? Counter, string MatlItem)
		{
			var nonTable95LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMaterial"},
					{ "column_value", MatlItem},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable95LoadRequest);
		}
		public void Nontable95Insert(ICollectionLoadResponse nonTable95LoadResponse)
		{
			var nonTable95InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable95LoadResponse.Items);

			this.appDB.Insert(nonTable95InsertRequest);
		}

		public ICollectionLoadResponse Nontable96Select(Guid? EsigRowpointer, int? Counter, string MatlDescription)
		{
			var nonTable96LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sMaterialDescription"},
					{ "column_value", MatlDescription},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable96LoadRequest);
		}
		public void Nontable96Insert(ICollectionLoadResponse nonTable96LoadResponse)
		{
			var nonTable96InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable96LoadResponse.Items);

			this.appDB.Insert(nonTable96InsertRequest);
		}

		public ICollectionLoadResponse Nontable97Select(Guid? EsigRowpointer, int? Counter, string Sequence)
		{
			var nonTable97LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sSequence"},
					{ "column_value", Sequence},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable97LoadRequest);
		}
		public void Nontable97Insert(ICollectionLoadResponse nonTable97LoadResponse)
		{
			var nonTable97InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable97LoadResponse.Items);

			this.appDB.Insert(nonTable97InsertRequest);
		}

		public ICollectionLoadResponse Nontable98Select(Guid? EsigRowpointer, int? Counter, string RefSeq)
		{
			var nonTable98LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRefSeq"},
					{ "column_value", RefSeq},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable98LoadRequest);
		}
		public void Nontable98Insert(ICollectionLoadResponse nonTable98LoadResponse)
		{
			var nonTable98InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable98LoadResponse.Items);

			this.appDB.Insert(nonTable98InsertRequest);
		}

		public ICollectionLoadResponse Nontable99Select(Guid? EsigRowpointer, int? Counter, string Bubble)
		{
			var nonTable99LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sBubble#"},
					{ "column_value", Bubble},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable99LoadRequest);
		}
		public void Nontable99Insert(ICollectionLoadResponse nonTable99LoadResponse)
		{
			var nonTable99InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable99LoadResponse.Items);

			this.appDB.Insert(nonTable99InsertRequest);
		}

		public ICollectionLoadResponse Nontable100Select(Guid? EsigRowpointer, int? Counter, string RefDes)
		{
			var nonTable100LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sRefDesignator"},
					{ "column_value", RefDes},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable100LoadRequest);
		}
		public void Nontable100Insert(ICollectionLoadResponse nonTable100LoadResponse)
		{
			var nonTable100InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable100LoadResponse.Items);

			this.appDB.Insert(nonTable100InsertRequest);
		}

		public ICollectionLoadResponse Nontable101Select(Guid? EsigRowpointer, int? Counter, string AssySeq)
		{
			var nonTable101LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "ElectronicSignatureRowPointer", EsigRowpointer},
					{ "seq", Counter},
					{ "column_caption", "sAssemblySeq"},
					{ "column_value", AssySeq},
					{ "key_sequence", null},
			});

			return this.appDB.Load(nonTable101LoadRequest);
		}
		public void Nontable101Insert(ICollectionLoadResponse nonTable101LoadResponse)
		{
			var nonTable101InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "electronic_signature_detail",
				items: nonTable101LoadResponse.Items);

			this.appDB.Insert(nonTable101InsertRequest);
		}

		public (int? ReturnCode,
			Guid? EsigRowpointer)
		AltExtGen_CreateEcnEsigSp(
			string AltExtGenSp,
			string UserName,
			string ReasonCode,
			string ECNNum,
			Guid? EsigRowpointer)
		{
			UsernameType _UserName = UserName;
			ReasonCodeType _ReasonCode = ReasonCode;
			ElectronicSignatureColumnValueType _ECNNum = ECNNum;
			RowPointerType _EsigRowpointer = EsigRowpointer;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNNum", _ECNNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigRowpointer", _EsigRowpointer, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				EsigRowpointer = _EsigRowpointer;

				return (Severity, EsigRowpointer);
			}
		}

	}
}
