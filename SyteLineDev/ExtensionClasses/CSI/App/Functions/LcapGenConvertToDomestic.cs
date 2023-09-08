//PROJECT NAME: Data
//CLASS NAME: LcapGenConvertToDomestic.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LcapGenConvertToDomestic : ILcapGenConvertToDomestic
	{
		readonly IApplicationDB appDB;
		
		public LcapGenConvertToDomestic(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? pAmount,
			string Infobar) LcapGenConvertToDomesticSp(
			string pForeignVendNum,
			string pDomesticVendNum,
			decimal? pRate,
			decimal? pAmount,
			string Infobar,
			string ParmsSite = null,
			string CurrparmsCurrCode = null)
		{
			VendNumType _pForeignVendNum = pForeignVendNum;
			VendNumType _pDomesticVendNum = pDomesticVendNum;
			ExchRateType _pRate = pRate;
			GenericDecimalType _pAmount = pAmount;
			InfobarType _Infobar = Infobar;
			SiteType _ParmsSite = ParmsSite;
			CurrCodeType _CurrparmsCurrCode = CurrparmsCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LcapGenConvertToDomesticSp";
				
				appDB.AddCommandParameter(cmd, "pForeignVendNum", _pForeignVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomesticVendNum", _pDomesticVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRate", _pRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrparmsCurrCode", _CurrparmsCurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pAmount = _pAmount;
				Infobar = _Infobar;
				
				return (Severity, pAmount, Infobar);
			}
		}
	}
}
