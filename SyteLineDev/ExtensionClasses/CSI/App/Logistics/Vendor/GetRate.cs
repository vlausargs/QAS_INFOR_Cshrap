//PROJECT NAME: CSIVendor
//CLASS NAME: GetRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.Vendor
{
	public interface IGetRate
	{
		(int? ReturnCode, decimal? ResultantRate, byte? ResultantRateDiv, decimal? DomToEuro, byte? DomToEuroDiv, decimal? ForToEuro, byte? ForToEuroDiv, byte? EuroBasis, string Infobar) GetRateSp(string ForCurrCode,
		byte? UseBuyRate,
		DateTime? TransDate = null,
		byte? SetResultantRateDiv = (byte)0,
		byte? UseCustomsAndExciseRates = (byte)0,
		string Site = null,
		string DomCurrCode = null,
		decimal? ResultantRate = null,
		byte? ResultantRateDiv = null,
		decimal? DomToEuro = null,
		byte? DomToEuroDiv = null,
		decimal? ForToEuro = null,
		byte? ForToEuroDiv = null,
		byte? EuroBasis = null,
		string Infobar = null);
		ICollectionLoadResponse GetRateFn(
			string ForCurrCode,
			int? UseBuyRate,
			DateTime? TransDate = null,
			int? SetResultantRateDiv = 0,
			int? UseCustomsAndExciseRates = 0,
			string Site = null,
			string DomCurrCode = null);

	}
	
	public class GetRate : IGetRate
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public GetRate(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public (int? ReturnCode, decimal? ResultantRate, byte? ResultantRateDiv, decimal? DomToEuro, byte? DomToEuroDiv, decimal? ForToEuro, byte? ForToEuroDiv, byte? EuroBasis, string Infobar) GetRateSp(string ForCurrCode,
		byte? UseBuyRate,
		DateTime? TransDate = null,
		byte? SetResultantRateDiv = (byte)0,
		byte? UseCustomsAndExciseRates = (byte)0,
		string Site = null,
		string DomCurrCode = null,
		decimal? ResultantRate = null,
		byte? ResultantRateDiv = null,
		decimal? DomToEuro = null,
		byte? DomToEuroDiv = null,
		decimal? ForToEuro = null,
		byte? ForToEuroDiv = null,
		byte? EuroBasis = null,
		string Infobar = null)
		{
			CurrCodeType _ForCurrCode = ForCurrCode;
			Flag _UseBuyRate = UseBuyRate;
			GenericDate _TransDate = TransDate;
			Flag _SetResultantRateDiv = SetResultantRateDiv;
			Flag _UseCustomsAndExciseRates = UseCustomsAndExciseRates;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;
			ExchRateType _ResultantRate = ResultantRate;
			Flag _ResultantRateDiv = ResultantRateDiv;
			ExchRateType _DomToEuro = DomToEuro;
			Flag _DomToEuroDiv = DomToEuroDiv;
			ExchRateType _ForToEuro = ForToEuro;
			Flag _ForToEuroDiv = ForToEuroDiv;
			Flag _EuroBasis = EuroBasis;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRateSp";
				
				appDB.AddCommandParameter(cmd, "ForCurrCode", _ForCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetResultantRateDiv", _SetResultantRateDiv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseCustomsAndExciseRates", _UseCustomsAndExciseRates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResultantRate", _ResultantRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ResultantRateDiv", _ResultantRateDiv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomToEuro", _DomToEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomToEuroDiv", _DomToEuroDiv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForToEuro", _ForToEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForToEuroDiv", _ForToEuroDiv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EuroBasis", _EuroBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ResultantRate = _ResultantRate;
				ResultantRateDiv = _ResultantRateDiv;
				DomToEuro = _DomToEuro;
				DomToEuroDiv = _DomToEuroDiv;
				ForToEuro = _ForToEuro;
				ForToEuroDiv = _ForToEuroDiv;
				EuroBasis = _EuroBasis;
				Infobar = _Infobar;
				
				return (Severity, ResultantRate, ResultantRateDiv, DomToEuro, DomToEuroDiv, ForToEuro, ForToEuroDiv, EuroBasis, Infobar);
			}
		}

		public ICollectionLoadResponse GetRateFn(
			string ForCurrCode,
			int? UseBuyRate,
			DateTime? TransDate = null,
			int? SetResultantRateDiv = 0,
			int? UseCustomsAndExciseRates = 0,
			string Site = null,
			string DomCurrCode = null)
		{
			CurrCodeType _ForCurrCode = ForCurrCode;
			Flag _UseBuyRate = UseBuyRate;
			GenericDate _TransDate = TransDate;
			Flag _SetResultantRateDiv = SetResultantRateDiv;
			Flag _UseCustomsAndExciseRates = UseCustomsAndExciseRates;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GetRate](@ForCurrCode, @UseBuyRate, @TransDate, @SetResultantRateDiv, @UseCustomsAndExciseRates, @Site, @DomCurrCode)";

				appDB.AddCommandParameter(cmd, "ForCurrCode", _ForCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetResultantRateDiv", _SetResultantRateDiv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseCustomsAndExciseRates", _UseCustomsAndExciseRates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);

				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetRate";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
