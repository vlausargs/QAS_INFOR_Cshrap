//PROJECT NAME: Data
//CLASS NAME: RestTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RestTax : IRestTax
	{
		readonly IApplicationDB appDB;
		
		public RestTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? RestockTax1,
			decimal? RestockTax2,
			string Infobar) RestTaxSp(
			decimal? RestockAmount,
			string RmaRmaNum,
			int? RmaitemRmaLine,
			string RmaTaxCode1,
			string RmaitemTaxCode1,
			string RmaTaxCode2,
			string RmaitemTaxCode2,
			string CustomerTermsCode,
			string CustaddrCurrCode,
			decimal? RmaExchRate,
			int? RmaUseExchRate,
			int? Places,
			Guid? AltProcessId,
			decimal? RestockTax1,
			decimal? RestockTax2,
			string Infobar)
		{
			AmountType _RestockAmount = RestockAmount;
			RmaNumType _RmaRmaNum = RmaRmaNum;
			RmaLineType _RmaitemRmaLine = RmaitemRmaLine;
			TaxCodeType _RmaTaxCode1 = RmaTaxCode1;
			TaxCodeType _RmaitemTaxCode1 = RmaitemTaxCode1;
			TaxCodeType _RmaTaxCode2 = RmaTaxCode2;
			TaxCodeType _RmaitemTaxCode2 = RmaitemTaxCode2;
			TermsCodeType _CustomerTermsCode = CustomerTermsCode;
			CurrCodeType _CustaddrCurrCode = CustaddrCurrCode;
			ExchRateType _RmaExchRate = RmaExchRate;
			ListYesNoType _RmaUseExchRate = RmaUseExchRate;
			DecimalPlacesType _Places = Places;
			RowPointerType _AltProcessId = AltProcessId;
			GenericDecimalType _RestockTax1 = RestockTax1;
			GenericDecimalType _RestockTax2 = RestockTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RestTaxSp";
				
				appDB.AddCommandParameter(cmd, "RestockAmount", _RestockAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaRmaNum", _RmaRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRmaLine", _RmaitemRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaTaxCode1", _RmaTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemTaxCode1", _RmaitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaTaxCode2", _RmaTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemTaxCode2", _RmaitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerTermsCode", _CustomerTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustaddrCurrCode", _CustaddrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaExchRate", _RmaExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaUseExchRate", _RmaUseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltProcessId", _AltProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RestockTax1", _RestockTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RestockTax2", _RestockTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RestockTax1 = _RestockTax1;
				RestockTax2 = _RestockTax2;
				Infobar = _Infobar;
				
				return (Severity, RestockTax1, RestockTax2, Infobar);
			}
		}
	}
}
