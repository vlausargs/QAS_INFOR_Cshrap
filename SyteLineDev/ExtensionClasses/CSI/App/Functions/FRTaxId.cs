//PROJECT NAME: Data
//CLASS NAME: FRTaxId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FRTaxId : IFRTaxId
	{
		readonly IApplicationDB appDB;
		
		public FRTaxId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rTaxRegNum,
			string rCustRegNum,
			string rVendRegNum,
			string Infobar,
			string CustShipToRegNum) FRTaxIdSp(
			int? pTaxSystem,
			string pTaxCode,
			int? pBranchDefined,
			string pCustAddrCountry = null,
			string Custnum = null,
			string rTaxRegNum = null,
			string rCustRegNum = null,
			string rVendRegNum = null,
			string Infobar = null,
			int? CustSeq = 0,
			string CustShipToRegNum = null)
		{
			TaxSystemType _pTaxSystem = pTaxSystem;
			TaxCodeType _pTaxCode = pTaxCode;
			ListYesNoType _pBranchDefined = pBranchDefined;
			CountryType _pCustAddrCountry = pCustAddrCountry;
			CustNumType _Custnum = Custnum;
			TaxRegNumType _rTaxRegNum = rTaxRegNum;
			TaxRegNumType _rCustRegNum = rCustRegNum;
			TaxRegNumType _rVendRegNum = rVendRegNum;
			InfobarType _Infobar = Infobar;
			CustSeqType _CustSeq = CustSeq;
			TaxRegNumType _CustShipToRegNum = CustShipToRegNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FRTaxIdSp";
				
				appDB.AddCommandParameter(cmd, "pTaxSystem", _pTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTaxCode", _pTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBranchDefined", _pBranchDefined, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustAddrCountry", _pCustAddrCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Custnum", _Custnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rTaxRegNum", _rTaxRegNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rCustRegNum", _rCustRegNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rVendRegNum", _rVendRegNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustShipToRegNum", _CustShipToRegNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rTaxRegNum = _rTaxRegNum;
				rCustRegNum = _rCustRegNum;
				rVendRegNum = _rVendRegNum;
				Infobar = _Infobar;
				CustShipToRegNum = _CustShipToRegNum;
				
				return (Severity, rTaxRegNum, rCustRegNum, rVendRegNum, Infobar, CustShipToRegNum);
			}
		}
	}
}
