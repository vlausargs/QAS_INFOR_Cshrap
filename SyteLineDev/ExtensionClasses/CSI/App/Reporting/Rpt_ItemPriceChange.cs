//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemPriceChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemPriceChange
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		DateTime? FromEffectDate,
		DateTime? ToEffectDate,
		string FromPriceCode,
		string ToPriceCode,
		string FromCurrCode,
		string ToCurrCode,
		DateTime? NewEffectDate,
		byte? UpdateCreate = (byte)1,
		byte? ItmPrc1 = (byte)0,
		byte? ItmPrc2 = (byte)0,
		byte? ItmPrc3 = (byte)0,
		byte? ItmPrc4 = (byte)0,
		byte? ItmPrc5 = (byte)0,
		byte? ItmPrc6 = (byte)0,
		byte? DisplayHeader = (byte)0,
		string PriWhole = null,
		string AmtType = "A",
		decimal? PriAmt = 0,
		short? StartingEffectDateOffset = null,
		short? EndingEffectDateOffset = null,
		string pSite = null);
	}
	
	public class Rpt_ItemPriceChange : IRpt_ItemPriceChange
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemPriceChange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		DateTime? FromEffectDate,
		DateTime? ToEffectDate,
		string FromPriceCode,
		string ToPriceCode,
		string FromCurrCode,
		string ToCurrCode,
		DateTime? NewEffectDate,
		byte? UpdateCreate = (byte)1,
		byte? ItmPrc1 = (byte)0,
		byte? ItmPrc2 = (byte)0,
		byte? ItmPrc3 = (byte)0,
		byte? ItmPrc4 = (byte)0,
		byte? ItmPrc5 = (byte)0,
		byte? ItmPrc6 = (byte)0,
		byte? DisplayHeader = (byte)0,
		string PriWhole = null,
		string AmtType = "A",
		decimal? PriAmt = 0,
		short? StartingEffectDateOffset = null,
		short? EndingEffectDateOffset = null,
		string pSite = null)
		{
			ProductCodeType _FromProductCode = FromProductCode;
			ProductCodeType _ToProductCode = ToProductCode;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			DateType _FromEffectDate = FromEffectDate;
			DateType _ToEffectDate = ToEffectDate;
			PriceCodeType _FromPriceCode = FromPriceCode;
			PriceCodeType _ToPriceCode = ToPriceCode;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			DateType _NewEffectDate = NewEffectDate;
			ListYesNoType _UpdateCreate = UpdateCreate;
			ListYesNoType _ItmPrc1 = ItmPrc1;
			ListYesNoType _ItmPrc2 = ItmPrc2;
			ListYesNoType _ItmPrc3 = ItmPrc3;
			ListYesNoType _ItmPrc4 = ItmPrc4;
			ListYesNoType _ItmPrc5 = ItmPrc5;
			ListYesNoType _ItmPrc6 = ItmPrc6;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _PriWhole = PriWhole;
			ListAmountPercentType _AmtType = AmtType;
			CostPrcType _PriAmt = PriAmt;
			DateOffsetType _StartingEffectDateOffset = StartingEffectDateOffset;
			DateOffsetType _EndingEffectDateOffset = EndingEffectDateOffset;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemPriceChangeSp";
				
				appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEffectDate", _FromEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEffectDate", _ToEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPriceCode", _FromPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPriceCode", _ToPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewEffectDate", _NewEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateCreate", _UpdateCreate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmPrc1", _ItmPrc1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmPrc2", _ItmPrc2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmPrc3", _ItmPrc3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmPrc4", _ItmPrc4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmPrc5", _ItmPrc5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmPrc6", _ItmPrc6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriWhole", _PriWhole, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtType", _AmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriAmt", _PriAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingEffectDateOffset", _StartingEffectDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEffectDateOffset", _EndingEffectDateOffset, ParameterDirection.Input);
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
