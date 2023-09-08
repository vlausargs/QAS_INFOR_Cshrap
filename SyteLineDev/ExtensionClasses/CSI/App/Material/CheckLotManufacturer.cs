//PROJECT NAME: Material
//CLASS NAME: CheckLotManufacturer.cs

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
	public class CheckLotManufacturer : ICheckLotManufacturer
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgAsk iMsgAsk;
		readonly ICheckLotManufacturerCRUD iCheckLotManufacturerCRUD;
		
		public CheckLotManufacturer(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgAsk iMsgAsk,
			ICheckLotManufacturerCRUD iCheckLotManufacturerCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgAsk = iMsgAsk;
			this.iCheckLotManufacturerCRUD = iCheckLotManufacturerCRUD;
		}
		
		public (
			int? ReturnCode,
			string LotManufacturer,
			string LotManufacturerName,
			string LotManufacturerItem,
			string LotManItemDescription,
			string PromptMsg,
			string PromptButtons,
			int? DisplayMessage)
		CheckLotManufacturerSp (
			string Item,
			string Lot,
			string Type,
			string Manufacturer,
			string ManufacturerItem,
			string LotManufacturer,
			string LotManufacturerName,
			string LotManufacturerItem,
			string LotManItemDescription,
			string PromptMsg,
			string PromptButtons,
			int? DisplayMessage = 0)
		{
			
			ItemType _Item = Item;
			LotType _Lot = Lot;
			ManufacturerIdType _Manufacturer = Manufacturer;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			ManufacturerIdType _LotManufacturer = LotManufacturer;
			NameType _LotManufacturerName = LotManufacturerName;
			ManufacturerItemType _LotManufacturerItem = LotManufacturerItem;
			DescriptionType _LotManItemDescription = LotManItemDescription;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			if (this.iCheckLotManufacturerCRUD.Optional_ModuleForExists())
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckLotManufacturerCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CheckLotManufacturerSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCheckLotManufacturerCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iCheckLotManufacturerCRUD.Tv_ALTGENForExists())
				{
					//BEGIN
					ALTGEN_SpName = this.iCheckLotManufacturerCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCheckLotManufacturerCRUD.AltExtGen_CheckLotManufacturerSp (ALTGEN_SpName,
						Item,
						Lot,
						Type,
						Manufacturer,
						ManufacturerItem,
						LotManufacturer,
						LotManufacturerName,
						LotManufacturerItem,
						LotManItemDescription,
						PromptMsg,
						PromptButtons,
						DisplayMessage);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription, PromptMsg, PromptButtons, DisplayMessage);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckLotManufacturerCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCheckLotManufacturerCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END
					
				}
				//END
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckLotManufacturerSp") != null)
			{
				var EXTGEN = this.iCheckLotManufacturerCRUD.AltExtGen_CheckLotManufacturerSp("dbo.EXTGEN_CheckLotManufacturerSp",
					Item,
					Lot,
					Type,
					Manufacturer,
					ManufacturerItem,
					LotManufacturer,
					LotManufacturerName,
					LotManufacturerItem,
					LotManItemDescription,
					PromptMsg,
					PromptButtons,
					DisplayMessage);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.LotManufacturer, EXTGEN.LotManufacturerName, EXTGEN.LotManufacturerItem, EXTGEN.LotManItemDescription, EXTGEN.PromptMsg, EXTGEN.PromptButtons, EXTGEN.DisplayMessage);
				}
			}
			
			Severity = 0;
			PromptMsg = null;
			PromptButtons = null;
			if (Lot== null)
			{
				goto EXITS;
				
			}
			(LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription) = this.iCheckLotManufacturerCRUD.LotasltLoad(Item, Lot, LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription);
			if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLNot((sQLUtil.SQLAnd(sQLUtil.SQLEqual(stringUtil.IsNull(
									LotManufacturer,
									""), stringUtil.IsNull(
									Manufacturer,
									"")), sQLUtil.SQLEqual(stringUtil.IsNull(
									LotManufacturerItem,
									""), stringUtil.IsNull(
									ManufacturerItem,
									""))))), sQLUtil.SQLNotEqual(stringUtil.IsNull(
						DisplayMessage,
						0), 1))))
			{
				if (sQLUtil.SQLEqual(Type, "C") == true)
				{
					//BEGIN
					
					#region CRUD ExecuteMethodCall
					
					//Please Generate the bounce for this stored procedure: MsgAskSp
					var MsgAsk = this.iMsgAsk.MsgAskSp(
						Infobar: PromptMsg,
						Buttons: PromptButtons,
						BaseMsg: "Q=ChangeLotNoYes",
						Parm1: "@coitem",
						Parm2: "@manufacturer",
						Parm3: "@manufacturer_item",
						Parm4: Manufacturer,
						Parm5: ManufacturerItem,
						Parm6: "@lot",
						Parm7: LotManufacturer,
						Parm8: LotManufacturerItem);
					Severity = MsgAsk.ReturnCode;
					PromptMsg = MsgAsk.Infobar;
					PromptButtons = MsgAsk.Buttons;
					
					#endregion ExecuteMethodCall
					
					DisplayMessage = 1;
					//END
					
				}
				else
				{
					if (sQLUtil.SQLEqual(Type, "J") == true)
					{
						//BEGIN
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: MsgAskSp
						var MsgAsk1 = this.iMsgAsk.MsgAskSp(
							Infobar: PromptMsg,
							Buttons: PromptButtons,
							BaseMsg: "Q=ChangeLotNoYes",
							Parm1: "@jobmatl",
							Parm2: "@manufacturer",
							Parm3: "@manufacturer_item",
							Parm4: Manufacturer,
							Parm5: ManufacturerItem,
							Parm6: "@lot",
							Parm7: LotManufacturer,
							Parm8: LotManufacturerItem);
						Severity = MsgAsk1.ReturnCode;
						PromptMsg = MsgAsk1.Infobar;
						PromptButtons = MsgAsk1.Buttons;
						
						#endregion ExecuteMethodCall
						
						DisplayMessage = 1;
						//END
						
					}
					
				}
				
			}
			EXITS: ;
			return (Severity = 0 , LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription, PromptMsg, PromptButtons, DisplayMessage);
			
		}
		
	}
}
