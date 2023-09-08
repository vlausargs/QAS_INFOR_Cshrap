//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCurrentRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemCurrentRouting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCurrentRoutingSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ABCCode = "ABC",
		int? OperationStarting = null,
		int? OperationEnding = null,
		string AlternateIDStarting = null,
		string AlternateIDEnding = null,
		byte? PageBetweenOperations = null,
		byte? PrintItemMaterials = null,
		byte? PrintAlternate = null,
		byte? DisplayReferenceFields = null,
		byte? CheckEffectivityDates = null,
		DateTime? EffectiveDate = null,
		string PrintTextFor = "OM",
		short? DateOffset = null,
		byte? ShowInternal = (byte)0,
		byte? ShowExternal = (byte)1,
		byte? DisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_ItemCurrentRouting : IRpt_ItemCurrentRouting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemCurrentRouting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCurrentRoutingSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ABCCode = "ABC",
		int? OperationStarting = null,
		int? OperationEnding = null,
		string AlternateIDStarting = null,
		string AlternateIDEnding = null,
		byte? PageBetweenOperations = null,
		byte? PrintItemMaterials = null,
		byte? PrintAlternate = null,
		byte? DisplayReferenceFields = null,
		byte? CheckEffectivityDates = null,
		DateTime? EffectiveDate = null,
		string PrintTextFor = "OM",
		short? DateOffset = null,
		byte? ShowInternal = (byte)0,
		byte? ShowExternal = (byte)1,
		byte? DisplayHeader = (byte)1,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			StringType _ABCCode = ABCCode;
			OperNumType _OperationStarting = OperationStarting;
			OperNumType _OperationEnding = OperationEnding;
			MO_BOMAlternateType _AlternateIDStarting = AlternateIDStarting;
			MO_BOMAlternateType _AlternateIDEnding = AlternateIDEnding;
			ListYesNoType _PageBetweenOperations = PageBetweenOperations;
			ListYesNoType _PrintItemMaterials = PrintItemMaterials;
			ListYesNoType _PrintAlternate = PrintAlternate;
			ListYesNoType _DisplayReferenceFields = DisplayReferenceFields;
			ListYesNoType _CheckEffectivityDates = CheckEffectivityDates;
			DateType _EffectiveDate = EffectiveDate;
			StringType _PrintTextFor = PrintTextFor;
			DateOffsetType _DateOffset = DateOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemCurrentRoutingSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationStarting", _OperationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationEnding", _OperationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateIDStarting", _AlternateIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateIDEnding", _AlternateIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenOperations", _PageBetweenOperations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemMaterials", _PrintItemMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintAlternate", _PrintAlternate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayReferenceFields", _DisplayReferenceFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckEffectivityDates", _CheckEffectivityDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTextFor", _PrintTextFor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
