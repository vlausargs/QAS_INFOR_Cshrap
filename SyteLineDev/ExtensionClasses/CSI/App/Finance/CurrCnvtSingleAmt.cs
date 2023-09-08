//PROJECT NAME: Finance
//CLASS NAME: CurrCnvtSingleAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Finance
{
	public class CurrCnvtSingleAmt : ICurrCnvtSingleAmt
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public CurrCnvtSingleAmt(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse CurrCnvtSingleAmtFn(
			string CurrCode,
			int? FromDomestic,
			int? UseBuyRate,
			int? RoundResult,
			DateTime? Date = null,
			int? RoundPlaces = null,
			int? UseCustomsAndExciseRates = 0,
			int? ForceRate = null,
			decimal? TRate = null,
			string Site = null,
			string DomCurrCode = null,
			int? TRateD = null,
			decimal? Amount1 = null)
		{
			CurrCodeType _CurrCode = CurrCode;
			Flag _FromDomestic = FromDomestic;
			Flag _UseBuyRate = UseBuyRate;
			Flag _RoundResult = RoundResult;
			GenericDate _Date = Date;
			DecimalPlacesType _RoundPlaces = RoundPlaces;
			Flag _UseCustomsAndExciseRates = UseCustomsAndExciseRates;
			Flag _ForceRate = ForceRate;
			AmountType _TRate = TRate;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;
			Flag _TRateD = TRateD;
			GenericDecimalType _Amount1 = Amount1;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[CurrCnvtSingleAmt](@CurrCode, @FromDomestic, @UseBuyRate, @RoundResult, @Date, @RoundPlaces, @UseCustomsAndExciseRates, @ForceRate, @TRate, @Site, @DomCurrCode, @TRateD, @Amount1)";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDomestic", _FromDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundPlaces", _RoundPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseCustomsAndExciseRates", _UseCustomsAndExciseRates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForceRate", _ForceRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate", _TRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRateD", _TRateD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount1", _Amount1, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_CurrCnvtSingleAmt";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
