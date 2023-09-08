//PROJECT NAME: Finance
//CLASS NAME: ExtFinCurrCnvt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinCurrCnvt : IExtFinCurrCnvt
	{
		readonly IApplicationDB appDB;
		
		public ExtFinCurrCnvt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TRate,
			string Infobar,
			decimal? Result1,
			decimal? Result2,
			decimal? Result3,
			decimal? Result4,
			decimal? Result5,
			decimal? Result6,
			decimal? Result7,
			decimal? Result8,
			decimal? Result9,
			decimal? Result10,
			decimal? Result11,
			decimal? Result12,
			decimal? Result13,
			decimal? Result14,
			decimal? Result15,
			int? TRateD) ExtFinCurrCnvtSp(
			string CurrCode,
			int? FromDomestic,
			int? UseBuyRate,
			int? RoundResult,
			DateTime? Date = null,
			int? RoundPlaces = null,
			int? UseCustomsAndExciseRates = 0,
			int? ForceRate = null,
			int? FindTTFixed = null,
			decimal? TRate = null,
			string Infobar = null,
			decimal? Amount1 = null,
			decimal? Result1 = null,
			decimal? Amount2 = null,
			decimal? Result2 = null,
			decimal? Amount3 = null,
			decimal? Result3 = null,
			decimal? Amount4 = null,
			decimal? Result4 = null,
			decimal? Amount5 = null,
			decimal? Result5 = null,
			decimal? Amount6 = null,
			decimal? Result6 = null,
			decimal? Amount7 = null,
			decimal? Result7 = null,
			decimal? Amount8 = null,
			decimal? Result8 = null,
			decimal? Amount9 = null,
			decimal? Result9 = null,
			decimal? Amount10 = null,
			decimal? Result10 = null,
			decimal? Amount11 = null,
			decimal? Result11 = null,
			decimal? Amount12 = null,
			decimal? Result12 = null,
			decimal? Amount13 = null,
			decimal? Result13 = null,
			decimal? Amount14 = null,
			decimal? Result14 = null,
			decimal? Amount15 = null,
			decimal? Result15 = null,
			string Site = null,
			string DomCurrCode = null,
			int? TRateD = null)
		{
			CurrCodeType _CurrCode = CurrCode;
			Flag _FromDomestic = FromDomestic;
			Flag _UseBuyRate = UseBuyRate;
			Flag _RoundResult = RoundResult;
			GenericDate _Date = Date;
			DecimalPlacesType _RoundPlaces = RoundPlaces;
			Flag _UseCustomsAndExciseRates = UseCustomsAndExciseRates;
			Flag _ForceRate = ForceRate;
			Flag _FindTTFixed = FindTTFixed;
			ExchRateType _TRate = TRate;
			Infobar _Infobar = Infobar;
			GenericDecimalType _Amount1 = Amount1;
			GenericDecimalType _Result1 = Result1;
			GenericDecimalType _Amount2 = Amount2;
			GenericDecimalType _Result2 = Result2;
			GenericDecimalType _Amount3 = Amount3;
			GenericDecimalType _Result3 = Result3;
			GenericDecimalType _Amount4 = Amount4;
			GenericDecimalType _Result4 = Result4;
			GenericDecimalType _Amount5 = Amount5;
			GenericDecimalType _Result5 = Result5;
			GenericDecimalType _Amount6 = Amount6;
			GenericDecimalType _Result6 = Result6;
			GenericDecimalType _Amount7 = Amount7;
			GenericDecimalType _Result7 = Result7;
			GenericDecimalType _Amount8 = Amount8;
			GenericDecimalType _Result8 = Result8;
			GenericDecimalType _Amount9 = Amount9;
			GenericDecimalType _Result9 = Result9;
			GenericDecimalType _Amount10 = Amount10;
			GenericDecimalType _Result10 = Result10;
			GenericDecimalType _Amount11 = Amount11;
			GenericDecimalType _Result11 = Result11;
			GenericDecimalType _Amount12 = Amount12;
			GenericDecimalType _Result12 = Result12;
			GenericDecimalType _Amount13 = Amount13;
			GenericDecimalType _Result13 = Result13;
			GenericDecimalType _Amount14 = Amount14;
			GenericDecimalType _Result14 = Result14;
			GenericDecimalType _Amount15 = Amount15;
			GenericDecimalType _Result15 = Result15;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;
			Flag _TRateD = TRateD;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinCurrCnvtSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDomestic", _FromDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundPlaces", _RoundPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseCustomsAndExciseRates", _UseCustomsAndExciseRates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForceRate", _ForceRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FindTTFixed", _FindTTFixed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate", _TRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount1", _Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result1", _Result1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount2", _Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result2", _Result2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount3", _Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result3", _Result3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount4", _Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result4", _Result4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount5", _Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result5", _Result5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount6", _Amount6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result6", _Result6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount7", _Amount7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result7", _Result7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount8", _Amount8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result8", _Result8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount9", _Amount9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result9", _Result9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount10", _Amount10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result10", _Result10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount11", _Amount11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result11", _Result11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount12", _Amount12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result12", _Result12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount13", _Amount13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result13", _Result13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount14", _Amount14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result14", _Result14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount15", _Amount15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result15", _Result15, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRateD", _TRateD, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TRate = _TRate;
				Infobar = _Infobar;
				Result1 = _Result1;
				Result2 = _Result2;
				Result3 = _Result3;
				Result4 = _Result4;
				Result5 = _Result5;
				Result6 = _Result6;
				Result7 = _Result7;
				Result8 = _Result8;
				Result9 = _Result9;
				Result10 = _Result10;
				Result11 = _Result11;
				Result12 = _Result12;
				Result13 = _Result13;
				Result14 = _Result14;
				Result15 = _Result15;
				TRateD = _TRateD;
				
				return (Severity, TRate, Infobar, Result1, Result2, Result3, Result4, Result5, Result6, Result7, Result8, Result9, Result10, Result11, Result12, Result13, Result14, Result15, TRateD);
			}
		}
	}
}
