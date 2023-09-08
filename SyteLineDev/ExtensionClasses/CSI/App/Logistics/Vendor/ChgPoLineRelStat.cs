//PROJECT NAME: Logistics
//CLASS NAME: ChgPoLineRelStat.cs

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

namespace CSI.Logistics.Vendor
{
	public class ChgPoLineRelStat : IChgPoLineRelStat
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IDefineVariable iDefineVariable;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly IPOItemlog iPOItemlog;
		readonly IRaiseError raiseError;
		readonly IObsSlow iObsSlow;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IChgPoLineRelStatCRUD iChgPoLineRelStatCRUD;
		
		public ChgPoLineRelStat(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IApplyDateOffset iApplyDateOffset,
			IDefineVariable iDefineVariable,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			IPOItemlog iPOItemlog,
			IRaiseError raiseError,
			IObsSlow iObsSlow,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IChgPoLineRelStatCRUD iChgPoLineRelStatCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iDefineVariable = iDefineVariable;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.iPOItemlog = iPOItemlog;
			this.raiseError = raiseError;
			this.iObsSlow = iObsSlow;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iChgPoLineRelStatCRUD = iChgPoLineRelStatCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode,
			string Infobar)
		ChgPoLineRelStatSp (
			string ProcSel,
			string IPoStat,
			string IPoType,
			string SPoNum,
			string EPoNum,
			int? SPoLine,
			int? EPoLine,
			int? SPoRelease,
			int? EPoRelease,
			string SPoVendNum,
			string EPoVendNum,
			DateTime? SPoOrderDate,
			DateTime? EPoOrderDate,
			DateTime? SPoitemDueDate,
			DateTime? EPoitemDueDate,
			DateTime? SPoitemRelDate,
			DateTime? EPoitemRelDate,
			string Infobar,
			int? StartOrderDateOffset = null,
			int? EndOrderDateOffset = null,
			int? StartDueDateOffset = null,
			int? EndDueDateOffset = null,
			int? StartRelDateOffset = null,
			int? EndRelDateOffset = null)
		{
			
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				
				ICollectionLoadResponse Data = null;
				
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? Severity = null;
				int? TChange = null;
				int? TProcess = null;
				string TMsg = null;
				string TPrompt1 = null;
				string TPrompt2 = null;
				int? Counter = null;
				Guid? PoRowPointer = null;
				string PoStat = null;
				string PoType = null;
				string PoVendNum = null;
				string PoPoNum = null;
				DateTime? PoOrderDate = null;
				string TOldPoitemStat = null;
				string TNewPoitemStat = null;
				string PoitemPoNum = null;
				int? PoitemPoLine = null;
				int? PoitemPoRelease = null;
				int? PoParmsVendorReq = null;
				Guid? PoitemRowPointer = null;
				string PoitemItem = null;
				string PoitemStat = null;
				DateTime? PoitemRelDate = null;
				DateTime? PoitemDueDate = null;
				string PoitemWhse = null;
				decimal? PoitemQtyOrdered = null;
				string PoitemUM = null;
				decimal? PoitemItemCost = null;
				decimal? PoitemMaterialCost = null;
				decimal? PoitemFreightCost = null;
				decimal? PoitemDutyCost = null;
				decimal? PoitemBrokerageCost = null;
				decimal? PoitemLocalFreightCost = null;
				decimal? PoitemInsuranceCost = null;
				decimal? PoitemPlanCost = null;
				DateTime? PoitemPromiseDate = null;
				decimal? PoitemConvFactor = null;
				Guid? ItemRowPointer = null;
				string ItemItem = null;
				Guid? PoBlnRowPointer = null;
				string PoBlnStat = null;
				ICollectionLoadResponse PoSp1CrsLoadResponseForCursor = null;
				int PoSp1Crs_CursorFetch_Status = -1;
				int PoSp1Crs_CursorCounter = -1;
				ICollectionLoadResponse PoitemSp1CrsLoadResponseForCursor = null;
				int PoitemSp1Crs_CursorFetch_Status = -1;
				int PoitemSp1Crs_CursorCounter = -1;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				string KeyColumns = null;
				string FilterString = null;
				if (this.iChgPoLineRelStatCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iChgPoLineRelStatCRUD.Optional_Module1Select();
					foreach(var optional_module1Item in optional_module1LoadResponse.Items){
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ChgPoLineRelStatSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
					};
					
					var optional_module1RequiredColumns = new List<string>() {"SpName"};
					
					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
					
					this.iChgPoLineRelStatCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					
					while (this.iChgPoLineRelStatCRUD.Tv_ALTGENForExists())
					{
						ALTGEN_SpName = this.iChgPoLineRelStatCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iChgPoLineRelStatCRUD.AltExtGen_ChgPoLineRelStatSp (ALTGEN_SpName,
							ProcSel,
							IPoStat,
							IPoType,
							SPoNum,
							EPoNum,
							SPoLine,
							EPoLine,
							SPoRelease,
							EPoRelease,
							SPoVendNum,
							EPoVendNum,
							SPoOrderDate,
							EPoOrderDate,
							SPoitemDueDate,
							EPoitemDueDate,
							SPoitemRelDate,
							EPoitemRelDate,
							Infobar,
							StartOrderDateOffset,
							EndOrderDateOffset,
							StartDueDateOffset,
							EndDueDateOffset,
							StartRelDateOffset,
							EndRelDateOffset);
						ALTGEN_Severity = ALTGEN.ReturnCode;
						
						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity, Infobar);
							
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iChgPoLineRelStatCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iChgPoLineRelStatCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
						
					}
					
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ChgPoLineRelStatSp") != null)
				{
					var EXTGEN = this.iChgPoLineRelStatCRUD.AltExtGen_ChgPoLineRelStatSp("dbo.EXTGEN_ChgPoLineRelStatSp",
						ProcSel,
						IPoStat,
						IPoType,
						SPoNum,
						EPoNum,
						SPoLine,
						EPoLine,
						SPoRelease,
						EPoRelease,
						SPoVendNum,
						EPoVendNum,
						SPoOrderDate,
						EPoOrderDate,
						SPoitemDueDate,
						EPoitemDueDate,
						SPoitemRelDate,
						EPoitemRelDate,
						Infobar,
						StartOrderDateOffset,
						EndOrderDateOffset,
						StartDueDateOffset,
						EndDueDateOffset,
						StartRelDateOffset,
						EndRelDateOffset);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;
					
					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity, EXTGEN.Infobar);
					}
				}
				
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
				this.transactionFactory.BeginTransaction("");
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: SPoOrderDate,
					Offset: StartOrderDateOffset,
					IsEndDate: 0);
				SPoOrderDate = ApplyDateOffset.Date;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: EPoOrderDate,
					Offset: EndOrderDateOffset,
					IsEndDate: 1);
				EPoOrderDate = ApplyDateOffset1.Date;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset2 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: SPoitemDueDate,
					Offset: StartDueDateOffset,
					IsEndDate: 0);
				SPoitemDueDate = ApplyDateOffset2.Date;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset3 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: EPoitemDueDate,
					Offset: EndDueDateOffset,
					IsEndDate: 1);
				EPoitemDueDate = ApplyDateOffset3.Date;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset4 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: SPoitemRelDate,
					Offset: StartRelDateOffset,
					IsEndDate: 0);
				SPoitemRelDate = ApplyDateOffset4.Date;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset5 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: EPoitemRelDate,
					Offset: EndRelDateOffset,
					IsEndDate: 1);
				EPoitemRelDate = ApplyDateOffset5.Date;
				
				#endregion ExecuteMethodCall
				
				this.sQLExpressionExecutor.Execute(@"Declare
					@PoitemPoNum PoNumType
					,@PoitemPoLine PoLineType
					,@PoitemPoRelease PoReleaseType
					,@TOldPoitemStat PoitemStatType
					,@TNewPoitemStat PoitemStatType
					,@TMsg InfobarType
					SELECT @PoitemPoNum AS PoNum,
					       @PoitemPoLine AS PoLine,
					       @PoitemPoRelease AS PoRelease,
					       @TOldPoitemStat AS OldStat,
					       @TNewPoitemStat AS NewStat,
					       @TMsg AS TMsg
					INTO   #ChgStat
					WHERE  1 = 2");
				Severity = 0;
				Infobar = null;
				TProcess = 0;
				if (sQLUtil.SQLEqual(ProcSel, "C") == true)
				{
					TProcess = 1;
					
				}
				else
				{
					if (sQLUtil.SQLEqual(ProcSel, "P") == true)
					{
						TProcess = 0;
						
					}
					
				}
				PoParmsVendorReq = this.iChgPoLineRelStatCRUD.PoparmsLoad(PoParmsVendorReq);
				#region Cursor Statement
				PoSp1CrsLoadResponseForCursor = this.iChgPoLineRelStatCRUD.PoSelect(IPoStat, IPoType, SPoNum, EPoNum, SPoVendNum, EPoVendNum, SPoOrderDate, EPoOrderDate);
				#endregion Cursor Statement
				PoSp1Crs_CursorFetch_Status = PoSp1CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				PoSp1Crs_CursorCounter = -1;
				
				while (sQLUtil.SQLEqual(Severity, 0) == true)
				{
					PoSp1Crs_CursorCounter++;
					if(PoSp1CrsLoadResponseForCursor.Items.Count > PoSp1Crs_CursorCounter)
					{
						PoRowPointer = PoSp1CrsLoadResponseForCursor.Items[PoSp1Crs_CursorCounter].GetValue<Guid?>(0);
						PoPoNum = PoSp1CrsLoadResponseForCursor.Items[PoSp1Crs_CursorCounter].GetValue<string>(1);
						PoStat = PoSp1CrsLoadResponseForCursor.Items[PoSp1Crs_CursorCounter].GetValue<string>(2);
						PoType = PoSp1CrsLoadResponseForCursor.Items[PoSp1Crs_CursorCounter].GetValue<string>(3);
						PoVendNum = PoSp1CrsLoadResponseForCursor.Items[PoSp1Crs_CursorCounter].GetValue<string>(4);
						PoOrderDate = PoSp1CrsLoadResponseForCursor.Items[PoSp1Crs_CursorCounter].GetValue<DateTime?>(5);
					}
					PoSp1Crs_CursorFetch_Status = (PoSp1Crs_CursorCounter == PoSp1CrsLoadResponseForCursor.Items.Count ? -1 : 0);
					
					if (sQLUtil.SQLEqual(PoSp1Crs_CursorFetch_Status, -1) == true)
					{
						
						break;
						
					}
					if (sQLUtil.SQLEqual(PoStat, "P") == true && (sQLUtil.SQLEqual(PoVendNum, "") == true || PoVendNum== null) && sQLUtil.SQLEqual(PoParmsVendorReq, 1) == true)
					{
						
						continue;
						
					}
					#region Cursor Statement
					PoitemSp1CrsLoadResponseForCursor = this.iChgPoLineRelStatCRUD.PoitemSelect(SPoLine, EPoLine, SPoRelease, EPoRelease, SPoitemDueDate, EPoitemDueDate, SPoitemRelDate, EPoitemRelDate, PoType, PoPoNum);
					#endregion Cursor Statement
					PoitemSp1Crs_CursorFetch_Status = PoitemSp1CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
					PoitemSp1Crs_CursorCounter = -1;
					
					while (sQLUtil.SQLEqual(Severity, 0) == true)
					{
						PoitemSp1Crs_CursorCounter++;
						if(PoitemSp1CrsLoadResponseForCursor.Items.Count > PoitemSp1Crs_CursorCounter)
						{
							PoitemRowPointer = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<Guid?>(0);
							PoitemPoNum = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<string>(1);
							PoitemPoLine = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<int?>(2);
							PoitemPoRelease = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<int?>(3);
							PoitemStat = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<string>(4);
							PoitemRelDate = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<DateTime?>(5);
							PoitemDueDate = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<DateTime?>(6);
							PoitemItem = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<string>(7);
							PoitemWhse = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<string>(8);
							PoitemQtyOrdered = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(9);
							PoitemUM = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<string>(10);
							PoitemItemCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(11);
							PoitemMaterialCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(12);
							PoitemFreightCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(13);
							PoitemDutyCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(14);
							PoitemBrokerageCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(15);
							PoitemLocalFreightCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(16);
							PoitemInsuranceCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(17);
							PoitemPlanCost = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(18);
							PoitemPromiseDate = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<DateTime?>(19);
							PoitemConvFactor = PoitemSp1CrsLoadResponseForCursor.Items[PoitemSp1Crs_CursorCounter].GetValue<decimal?>(20);
						}
						PoitemSp1Crs_CursorFetch_Status = (PoitemSp1Crs_CursorCounter == PoitemSp1CrsLoadResponseForCursor.Items.Count ? -1 : 0);
						
						if (sQLUtil.SQLEqual(PoitemSp1Crs_CursorFetch_Status, -1) == true)
						{
							
							break;
							
						}
						TChange = TProcess;
						TMsg = null;
						TPrompt1 = null;
						TOldPoitemStat = PoitemStat;
						TNewPoitemStat = "O";
						ItemRowPointer = null;
						ItemItem = null;
						(ItemRowPointer, ItemItem) = this.iChgPoLineRelStatCRUD.ItemLoad(PoitemItem, ItemRowPointer, ItemItem);
						if (ItemRowPointer!= null && sQLUtil.SQLNotEqual(ItemItem, "") == true)
						{
							
							#region CRUD ExecuteMethodCall
							
							//Please Generate the bounce for this stored procedure: ObsSlowSp
							var ObsSlow = this.iObsSlow.ObsSlowSp(
								Item: ItemItem,
								WarnIfSlowMoving: 1,
								ErrorIfSlowMoving: 0,
								WarnIfObsolete: 0,
								ErrorIfObsolete: 1,
								Infobar: TMsg,
								Prompt: TPrompt1,
								PromptButtons: TPrompt2);
							TMsg = ObsSlow.Infobar;
							TPrompt1 = ObsSlow.Prompt;
							TPrompt2 = ObsSlow.PromptButtons;
							
							#endregion ExecuteMethodCall
							
							if (TMsg!= null || TPrompt1!= null)
							{
								if (TPrompt1!= null)
								{
									
									#region CRUD ExecuteMethodCall
									
									var MsgApp = this.iMsgApp.MsgAppSp(
										Infobar: TMsg,
										BaseMsg: "I=IsCompare0",
										Parm1: "@item.stat",
										Parm2: "@:ItemStatus:S",
										Parm3: "@item.item");
									TMsg = MsgApp.Infobar;
									
									#endregion ExecuteMethodCall
									
								}
								else
								{
									
									#region CRUD ExecuteMethodCall
									
									var MsgApp1 = this.iMsgApp.MsgAppSp(
										Infobar: TMsg,
										BaseMsg: "I=IsCompare0",
										Parm1: "@item.stat",
										Parm2: "@:ItemStatus:O",
										Parm3: "@item.item");
									TMsg = MsgApp1.Infobar;
									
									#endregion ExecuteMethodCall
									
									TChange = 0;
									TNewPoitemStat = PoitemStat;
									
								}
								
							}
							
						}
						if (sQLUtil.SQLEqual(TChange, 1) == true)
						{
							PoitemStat = this.iChgPoLineRelStatCRUD.Poitem1Load(PoitemRowPointer, PoitemStat);
							PoitemStat = "O";
							var poitem2LoadResponse = this.iChgPoLineRelStatCRUD.Poitem2Select(PoitemRowPointer);
							this.iChgPoLineRelStatCRUD.Poitem2Update(PoitemStat, poitem2LoadResponse);
							
							#region CRUD ExecuteMethodCall
							
							//Please Generate the bounce for this stored procedure: POItemlogSp
							var POItemlog = this.iPOItemlog.POItemlogSp(
								PAction: "A",
								PPoNum: PoitemPoNum,
								PPoLine: PoitemPoLine,
								PPoRelease: PoitemPoRelease,
								PNewItem: PoitemItem,
								POldItem: PoitemItem,
								PNewUM: PoitemUM,
								POldUM: PoitemUM,
								PNewStatus: "O",
								POldStatus: "P",
								PNewQty: PoitemQtyOrdered,
								POldQty: PoitemQtyOrdered,
								PNewItemCost: PoitemItemCost,
								POldItemCost: PoitemItemCost,
								PNewMaterialCost: PoitemMaterialCost,
								POldMaterialCost: PoitemMaterialCost,
								PNewFreightCost: PoitemFreightCost,
								POldFreightCost: PoitemFreightCost,
								PNewDutyCost: PoitemDutyCost,
								POldDutyCost: PoitemDutyCost,
								PNewBrokerageCost: PoitemBrokerageCost,
								POldBrokerageCost: PoitemBrokerageCost,
								PNewInsuranceCost: PoitemInsuranceCost,
								POldInsuranceCost: PoitemInsuranceCost,
								PNewLocalFreightCost: PoitemLocalFreightCost,
								POldLocalFreightCost: PoitemLocalFreightCost,
								PNewPlanCost: PoitemPlanCost,
								POldPlanCost: PoitemPlanCost,
								PNewDueDate: PoitemDueDate,
								POldDueDate: PoitemDueDate,
								PNewPromiseDate: PoitemPromiseDate,
								POldPromiseDate: PoitemPromiseDate,
								PNewConvFactor: PoitemConvFactor,
								POldConvFactor: PoitemConvFactor,
								Infobar: Infobar);
							Severity = POItemlog.ReturnCode;
							Infobar = POItemlog.Infobar;
							
							#endregion ExecuteMethodCall
							
							PoStat = this.iChgPoLineRelStatCRUD.Po1Load(Severity,
								 PoitemPoNum,
								 PoitemPoLine,
								 PoitemPoRelease,
								 PoitemItem,
								 PoitemUM,
								 PoitemQtyOrdered,
								 PoitemItemCost,
								 PoitemMaterialCost,
								 PoitemFreightCost,
								 PoitemDutyCost,
								 PoitemBrokerageCost,
								 PoitemInsuranceCost,
								 PoitemLocalFreightCost,
								 PoitemPlanCost,
								 PoitemDueDate,
								 PoitemPromiseDate,
								 PoitemConvFactor,
								 Infobar,
								 PoRowPointer,
								 PoStat);
							if (sQLUtil.SQLEqual(PoStat, "P") == true)
							{
								var po2LoadResponse = this.iChgPoLineRelStatCRUD.Po2Select(PoRowPointer);
								this.iChgPoLineRelStatCRUD.Po2Update(po2LoadResponse);
								
							}
							if (sQLUtil.SQLEqual(PoType, "B") == true)
							{
								PoBlnRowPointer = null;
								PoBlnStat = null;
								(PoBlnRowPointer, PoBlnStat) = this.iChgPoLineRelStatCRUD.Po_BlnLoad(PoitemPoNum, PoitemPoLine, PoBlnRowPointer, PoBlnStat);
								var poitem3LoadResponse = this.iChgPoLineRelStatCRUD.Poitem3Select(PoitemRowPointer);
								this.iChgPoLineRelStatCRUD.Poitem3Update(poitem3LoadResponse);
								if (PoBlnRowPointer!= null)
								{
									if (sQLUtil.SQLEqual(PoBlnStat, "P") == true)
									{
										var po_bln1LoadResponse = this.iChgPoLineRelStatCRUD.Po_Bln1Select(PoBlnRowPointer);
										this.iChgPoLineRelStatCRUD.Po_Bln1Update(po_bln1LoadResponse);
										
									}
									
								}
								
							}
							
						}
						var nonTableLoadResponse = this.iChgPoLineRelStatCRUD.NontableSelect(PoitemPoNum, PoitemPoLine, PoitemPoRelease, TOldPoitemStat, TNewPoitemStat, TMsg);
						Data = nonTableLoadResponse;
						this.iChgPoLineRelStatCRUD.NontableInsert(nonTableLoadResponse);
						
					}
					//Deallocate Cursor PoitemSp1Crs
					
				}
				//Deallocate Cursor PoSp1Crs
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				else
				{
					this.transactionFactory.CommitTransaction("");
					
				}
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					raiseError.RaiseErrorSp(
						Infobar,
						Severity,
						1);
					return (Data, Severity, Infobar);
				}
				SelectionClause = "";
				FromClause = "";
				WhereClause = "";
				AdditionalClause = "";
				KeyColumns = "";
				FilterString = "";
				SelectionClause = @"SELECT PoNum
					                              ,PoLine
					                              ,PoRelease
					                              ,OldStat
					                              ,NewStat
					                              ,TMsg";
				FromClause = "FROM #ChgStat";
				WhereClause = null;
				AdditionalClause = "ORDER BY PoNum";
				KeyColumns = "PoNum";
				FilterString = null;
				if (this.scalarFunction.Execute<int?>(
					"OBJECT_ID",
					"tempdb..#DynamicParameters")!= null)
				{
					this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");
					
				}
				
				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@KeyColumns VeryLongListType
					,@FilterString VeryLongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       @KeyColumns AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");
				var DynamicParametersLoadResponse = this.iChgPoLineRelStatCRUD.DynamicparametersSelect(SelectionClause, FromClause, WhereClause, AdditionalClause, KeyColumns, FilterString);
				
				this.iChgPoLineRelStatCRUD.DynamicparametersInsert(DynamicParametersLoadResponse);
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 1,
					Infobar: Infobar,
					ImpactedRowCount: Counter);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;
				Counter = ExecuteDynamicSQL.ImpactedRowCount;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp2 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "I=#Processed",
					Parm1: convertToUtil.ToString(Counter),
					Parm2: "@poitem");
				Infobar = MsgApp2.Infobar;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: DefineVariableSp
				var DefineVariable = this.iDefineVariable.DefineVariableSp(
					VariableName: "ChgPoLineRelStat.Infobar",
					VariableValue: Infobar,
					Infobar: Infobar);
				Infobar = DefineVariable.Infobar;
				
				#endregion ExecuteMethodCall
				
				return (Data, Severity = 0, Infobar);
				
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
		
	}
}
