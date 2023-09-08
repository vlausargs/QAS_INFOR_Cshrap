//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemBOMWhereUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemBOMWhereUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemBOMWhereUsedSp(string ItemStarting,
		string ItemEnding,
		string ProductCodeStarting,
		string ProductCodeEnding,
		string JobType,
		string MaterialType,
		string Source,
		string Stocked,
		string NonStocked,
		string ABCCode,
		DateTime? EffectiveDate,
		short? EffectiveDateOffset = null,
		string DisplayHistory = null,
		byte? IndentedLevelView = null,
		byte? PageBetweenItems = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ItemBOMWhereUsed : IRpt_ItemBOMWhereUsed
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemBOMWhereUsed(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemBOMWhereUsedSp(string ItemStarting,
		string ItemEnding,
		string ProductCodeStarting,
		string ProductCodeEnding,
		string JobType,
		string MaterialType,
		string Source,
		string Stocked,
		string NonStocked,
		string ABCCode,
		DateTime? EffectiveDate,
		short? EffectiveDateOffset = null,
		string DisplayHistory = null,
		byte? IndentedLevelView = null,
		byte? PageBetweenItems = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			HighLowCharType _ItemStarting = ItemStarting;
			HighLowCharType _ItemEnding = ItemEnding;
			HighLowCharType _ProductCodeStarting = ProductCodeStarting;
			HighLowCharType _ProductCodeEnding = ProductCodeEnding;
			LongListType _JobType = JobType;
			LongListType _MaterialType = MaterialType;
			LongListType _Source = Source;
			StringType _Stocked = Stocked;
			StringType _NonStocked = NonStocked;
			LongListType _ABCCode = ABCCode;
			GenericDateType _EffectiveDate = EffectiveDate;
			DateOffsetType _EffectiveDateOffset = EffectiveDateOffset;
			StringType _DisplayHistory = DisplayHistory;
			FlagNyType _IndentedLevelView = IndentedLevelView;
			FlagNyType _PageBetweenItems = PageBetweenItems;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemBOMWhereUsedSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonStocked", _NonStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDateOffset", _EffectiveDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHistory", _DisplayHistory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IndentedLevelView", _IndentedLevelView, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
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
