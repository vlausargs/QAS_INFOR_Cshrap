//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdCnvtAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdCnvtAmt : IArpmtdCnvtAmt
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdCnvtAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PResult1,
		string Infobar) ArpmtdCnvtAmtSp(string PArpmtdSite,
		DateTime? PArpmtRecptDate,
		string PDerCustCurrCode,
		decimal? PArpmtdExchRate,
		decimal? PAmount1,
		decimal? PResult1,
		string Infobar)
		{
			SiteType _PArpmtdSite = PArpmtdSite;
			DateType _PArpmtRecptDate = PArpmtRecptDate;
			CurrCodeType _PDerCustCurrCode = PDerCustCurrCode;
			ExchRateType _PArpmtdExchRate = PArpmtdExchRate;
			AmountType _PAmount1 = PAmount1;
			AmountType _PResult1 = PResult1;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdCnvtAmtSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtRecptDate", _PArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerCustCurrCode", _PDerCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdExchRate", _PArpmtdExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmount1", _PAmount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PResult1", _PResult1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PResult1 = _PResult1;
				Infobar = _Infobar;
				
				return (Severity, PResult1, Infobar);
			}
		}
	}
}
