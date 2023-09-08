//PROJECT NAME: CSIVendor
//CLASS NAME: PoLineGetInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPoLineGetInfo
	{
		(int? ReturnCode, string Stat, DateTime? OrderDate, string VendNum, string VendorName, string VendOrder, string CurrCode, decimal? PoExchRate, string Whse, byte? ControlledByExternalWms, string PoTaxCode1, string PoTaxCode2, string TransNat, string TransNat2, string Delterm, string ProcessInd, string EcCode, short? FirstLine, int? PoChgNum, DateTime? PoChgDate, string PoChgStat, string CurrAmtTotFormat, string CurrCstPrcFormat, string VendPriceBy, string Infobar, byte? CurrencyPlaces, string CurrAmtFormat) PoLineGetInfoSp(string PoNum,
		string PoType,
		string Stat,
		DateTime? OrderDate,
		string VendNum,
		string VendorName,
		string VendOrder,
		string CurrCode,
		decimal? PoExchRate,
		string Whse,
		byte? ControlledByExternalWms,
		string PoTaxCode1,
		string PoTaxCode2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string EcCode,
		short? FirstLine,
		int? PoChgNum,
		DateTime? PoChgDate,
		string PoChgStat,
		string CurrAmtTotFormat,
		string CurrCstPrcFormat,
		string VendPriceBy,
		string Infobar,
		byte? CurrencyPlaces = null,
		string CurrAmtFormat = null);
	}
	
	public class PoLineGetInfo : IPoLineGetInfo
	{
		readonly IApplicationDB appDB;
		
		public PoLineGetInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Stat, DateTime? OrderDate, string VendNum, string VendorName, string VendOrder, string CurrCode, decimal? PoExchRate, string Whse, byte? ControlledByExternalWms, string PoTaxCode1, string PoTaxCode2, string TransNat, string TransNat2, string Delterm, string ProcessInd, string EcCode, short? FirstLine, int? PoChgNum, DateTime? PoChgDate, string PoChgStat, string CurrAmtTotFormat, string CurrCstPrcFormat, string VendPriceBy, string Infobar, byte? CurrencyPlaces, string CurrAmtFormat) PoLineGetInfoSp(string PoNum,
		string PoType,
		string Stat,
		DateTime? OrderDate,
		string VendNum,
		string VendorName,
		string VendOrder,
		string CurrCode,
		decimal? PoExchRate,
		string Whse,
		byte? ControlledByExternalWms,
		string PoTaxCode1,
		string PoTaxCode2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string EcCode,
		short? FirstLine,
		int? PoChgNum,
		DateTime? PoChgDate,
		string PoChgStat,
		string CurrAmtTotFormat,
		string CurrCstPrcFormat,
		string VendPriceBy,
		string Infobar,
		byte? CurrencyPlaces = null,
		string CurrAmtFormat = null)
		{
			PoNumType _PoNum = PoNum;
			PoTypeType _PoType = PoType;
			PoStatType _Stat = Stat;
			DateType _OrderDate = OrderDate;
			VendNumType _VendNum = VendNum;
			NameType _VendorName = VendorName;
			VendOrderType _VendOrder = VendOrder;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _PoExchRate = PoExchRate;
			WhseType _Whse = Whse;
			ListYesNoType _ControlledByExternalWms = ControlledByExternalWms;
			TaxCodeType _PoTaxCode1 = PoTaxCode1;
			TaxCodeType _PoTaxCode2 = PoTaxCode2;
			TransNatType _TransNat = TransNat;
			TransNat2Type _TransNat2 = TransNat2;
			DeltermType _Delterm = Delterm;
			ProcessIndType _ProcessInd = ProcessInd;
			EcCodeType _EcCode = EcCode;
			PoLineType _FirstLine = FirstLine;
			ChgNumType _PoChgNum = PoChgNum;
			DateType _PoChgDate = PoChgDate;
			PoChangeStatusType _PoChgStat = PoChgStat;
			InputMaskType _CurrAmtTotFormat = CurrAmtTotFormat;
			InputMaskType _CurrCstPrcFormat = CurrCstPrcFormat;
			ListOrderDueType _VendPriceBy = VendPriceBy;
			InfobarType _Infobar = Infobar;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			InputMaskType _CurrAmtFormat = CurrAmtFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoLineGetInfoSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendorName", _VendorName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendOrder", _VendOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoExchRate", _PoExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlledByExternalWms", _ControlledByExternalWms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoTaxCode1", _PoTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoTaxCode2", _PoTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FirstLine", _FirstLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChgNum", _PoChgNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChgDate", _PoChgDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChgStat", _PoChgStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrAmtTotFormat", _CurrAmtTotFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", _CurrCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendPriceBy", _VendPriceBy, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrAmtFormat", _CurrAmtFormat, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Stat = _Stat;
				OrderDate = _OrderDate;
				VendNum = _VendNum;
				VendorName = _VendorName;
				VendOrder = _VendOrder;
				CurrCode = _CurrCode;
				PoExchRate = _PoExchRate;
				Whse = _Whse;
				ControlledByExternalWms = _ControlledByExternalWms;
				PoTaxCode1 = _PoTaxCode1;
				PoTaxCode2 = _PoTaxCode2;
				TransNat = _TransNat;
				TransNat2 = _TransNat2;
				Delterm = _Delterm;
				ProcessInd = _ProcessInd;
				EcCode = _EcCode;
				FirstLine = _FirstLine;
				PoChgNum = _PoChgNum;
				PoChgDate = _PoChgDate;
				PoChgStat = _PoChgStat;
				CurrAmtTotFormat = _CurrAmtTotFormat;
				CurrCstPrcFormat = _CurrCstPrcFormat;
				VendPriceBy = _VendPriceBy;
				Infobar = _Infobar;
				CurrencyPlaces = _CurrencyPlaces;
				CurrAmtFormat = _CurrAmtFormat;
				
				return (Severity, Stat, OrderDate, VendNum, VendorName, VendOrder, CurrCode, PoExchRate, Whse, ControlledByExternalWms, PoTaxCode1, PoTaxCode2, TransNat, TransNat2, Delterm, ProcessInd, EcCode, FirstLine, PoChgNum, PoChgDate, PoChgStat, CurrAmtTotFormat, CurrCstPrcFormat, VendPriceBy, Infobar, CurrencyPlaces, CurrAmtFormat);
			}
		}
	}
}
