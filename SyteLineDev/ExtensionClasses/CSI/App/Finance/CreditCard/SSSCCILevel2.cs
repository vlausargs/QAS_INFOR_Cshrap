//PROJECT NAME: Finance
//CLASS NAME: SSSCCILevel2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCILevel2 : ISSSCCILevel2
	{
		readonly IApplicationDB appDB;
		
		public SSSCCILevel2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustPo,
			decimal? TaxAmt,
			string ShipToName,
			string ShipToStreet,
			string ShipToCity,
			string ShipToState,
			string ShipToZip,
			string ShipToCountryCode,
			decimal? TaxRate) SSSCCILevel2Sp(
			string InvNum,
			string CustPo,
			decimal? TaxAmt,
			string ShipToName,
			string ShipToStreet,
			string ShipToCity,
			string ShipToState,
			string ShipToZip,
			string ShipToCountryCode,
			decimal? TaxRate = 0)
		{
			InvNumType _InvNum = InvNum;
			CustPoType _CustPo = CustPo;
			AmountType _TaxAmt = TaxAmt;
			NameType _ShipToName = ShipToName;
			AddressType _ShipToStreet = ShipToStreet;
			CityType _ShipToCity = ShipToCity;
			StateType _ShipToState = ShipToState;
			PostalCodeType _ShipToZip = ShipToZip;
			CountryCodeType _ShipToCountryCode = ShipToCountryCode;
			TaxRateType _TaxRate = TaxRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCILevel2Sp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToName", _ShipToName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToStreet", _ShipToStreet, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToCity", _ShipToCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToState", _ShipToState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToZip", _ShipToZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToCountryCode", _ShipToCountryCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxRate", _TaxRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustPo = _CustPo;
				TaxAmt = _TaxAmt;
				ShipToName = _ShipToName;
				ShipToStreet = _ShipToStreet;
				ShipToCity = _ShipToCity;
				ShipToState = _ShipToState;
				ShipToZip = _ShipToZip;
				ShipToCountryCode = _ShipToCountryCode;
				TaxRate = _TaxRate;
				
				return (Severity, CustPo, TaxAmt, ShipToName, ShipToStreet, ShipToCity, ShipToState, ShipToZip, ShipToCountryCode, TaxRate);
			}
		}
	}
}
