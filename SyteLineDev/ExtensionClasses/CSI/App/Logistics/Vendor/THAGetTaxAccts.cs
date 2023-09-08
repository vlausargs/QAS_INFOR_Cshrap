//PROJECT NAME: Logistics
//CLASS NAME: THAGetTaxAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAGetTaxAccts : ITHAGetTaxAccts
	{
		readonly IApplicationDB appDB;
		
		
		public THAGetTaxAccts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rChartAcct,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar) THAGetTaxAcctsSp(string TaxCode,
		string pSite,
		string pType,
		string pVendNum,
		decimal? pDiscAmt,
		string rChartAcct,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar)
		{
			TaxCodeType _TaxCode = TaxCode;
			SiteType _pSite = pSite;
			AppmtdTypeType _pType = pType;
			VendNumType _pVendNum = pVendNum;
			AmountType _pDiscAmt = pDiscAmt;
			AcctType _rChartAcct = rChartAcct;
			UnitCode1Type _rAccessUnit1 = rAccessUnit1;
			UnitCode2Type _rAccessUnit2 = rAccessUnit2;
			UnitCode3Type _rAccessUnit3 = rAccessUnit3;
			UnitCode4Type _rAccessUnit4 = rAccessUnit4;
			DescriptionType _rDescription = rDescription;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAGetTaxAcctsSp";
				
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDiscAmt", _pDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rChartAcct", _rChartAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit1", _rAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit2", _rAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit3", _rAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit4", _rAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDescription", _rDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rChartAcct = _rChartAcct;
				rAccessUnit1 = _rAccessUnit1;
				rAccessUnit2 = _rAccessUnit2;
				rAccessUnit3 = _rAccessUnit3;
				rAccessUnit4 = _rAccessUnit4;
				rDescription = _rDescription;
				Infobar = _Infobar;
				
				return (Severity, rChartAcct, rAccessUnit1, rAccessUnit2, rAccessUnit3, rAccessUnit4, rDescription, Infobar);
			}
		}
	}
}
