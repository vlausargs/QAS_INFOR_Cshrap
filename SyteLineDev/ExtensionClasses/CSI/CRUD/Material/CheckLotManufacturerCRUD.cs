//PROJECT NAME: Material
//CLASS NAME: CheckLotManufacturerCRUD.cs

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
	public class CheckLotManufacturerCRUD : ICheckLotManufacturerCRUD
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		
		public CheckLotManufacturerCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CheckLotManufacturerSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CheckLotManufacturerSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
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
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
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
				tableName:"#tv_ALTGEN",
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (string LotManufacturer, string LotManufacturerName, string LotManufacturerItem, string LotManItemDescription) LotasltLoad(string Item,
			string Lot,
			string LotManufacturer,
			string LotManufacturerName,
			string LotManufacturerItem,
			string LotManItemDescription)
		{
			ManufacturerIdType _LotManufacturer = DBNull.Value;
			NameType _LotManufacturerName = DBNull.Value;
			ManufacturerItemType _LotManufacturerItem = DBNull.Value;
			DescriptionType _LotManItemDescription = DBNull.Value;
			
			var lotASltLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_LotManufacturer,"lt.manufacturer_id"},
					{_LotManufacturerName,"man.name"},
					{_LotManufacturerItem,"lt.manufacturer_item"},
					{_LotManItemDescription,"manitem.description"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"lot AS lt",
				fromClause: collectionLoadRequestFactory.Clause(@" WITH (READUNCOMMITTED) LEFT OUTER JOIN manufacturer_item AS manitem ON manitem.manufacturer_id = lt.manufacturer_id
					AND manitem.manufacturer_item = lt.manufacturer_item LEFT OUTER JOIN manufacturer AS man ON man.manufacturer_id = lt.manufacturer_id"),
				whereClause: collectionLoadRequestFactory.Clause("lt.item = {0} AND lt.lot = {1}",Item,Lot),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var lotASltLoadResponse = this.appDB.Load(lotASltLoadRequest);
			if(lotASltLoadResponse.Items.Count > 0)
			{
				LotManufacturer = _LotManufacturer;
				LotManufacturerName = _LotManufacturerName;
				LotManufacturerItem = _LotManufacturerItem;
				LotManItemDescription = _LotManItemDescription;
			}
			
			return (LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription);
		}
		
		public (int? ReturnCode,
			string LotManufacturer,
			string LotManufacturerName,
			string LotManufacturerItem,
			string LotManItemDescription,
			string PromptMsg,
			string PromptButtons,
			int? DisplayMessage)
		AltExtGen_CheckLotManufacturerSp(
			string AltExtGenSp,
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
			RefTypeCGPVType _Type = Type;
			ManufacturerIdType _Manufacturer = Manufacturer;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			ManufacturerIdType _LotManufacturer = LotManufacturer;
			NameType _LotManufacturerName = LotManufacturerName;
			ManufacturerItemType _LotManufacturerItem = LotManufacturerItem;
			DescriptionType _LotManItemDescription = LotManItemDescription;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			ListYesNoType _DisplayMessage = DisplayMessage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Manufacturer", _Manufacturer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotManufacturer", _LotManufacturer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotManufacturerName", _LotManufacturerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotManufacturerItem", _LotManufacturerItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotManItemDescription", _LotManItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DisplayMessage", _DisplayMessage, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotManufacturer = _LotManufacturer;
				LotManufacturerName = _LotManufacturerName;
				LotManufacturerItem = _LotManufacturerItem;
				LotManItemDescription = _LotManItemDescription;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				DisplayMessage = _DisplayMessage;
				
				return (Severity, LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription, PromptMsg, PromptButtons, DisplayMessage);
			}
		}
		
	}
}
