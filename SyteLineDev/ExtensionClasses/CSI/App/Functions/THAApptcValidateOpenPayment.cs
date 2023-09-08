//PROJECT NAME: Data
//CLASS NAME: THAApptcValidateOpenPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApptcValidateOpenPayment : ITHAApptcValidateOpenPayment
	{
		readonly IApplicationDB appDB;
		
		public THAApptcValidateOpenPayment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar) THAApptcValidateOpenPaymentSp(
			string PVendNum,
			int? PCheckNum,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			ApCheckNumType _PCheckNum = PCheckNum;
			FlagNyType _POpenPay = POpenPay;
			AmountType _PForCheckAmt = PForCheckAmt;
			AmountType _PDomCheckAmt = PDomCheckAmt;
			ExchRateType _PExchRate = PExchRate;
			DateType _PCheckDate = PCheckDate;
			ReferenceType _PRef = PRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAApptcValidateOpenPaymentSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenPay", _POpenPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POpenPay = _POpenPay;
				PForCheckAmt = _PForCheckAmt;
				PDomCheckAmt = _PDomCheckAmt;
				PExchRate = _PExchRate;
				PCheckDate = _PCheckDate;
				PRef = _PRef;
				Infobar = _Infobar;
				
				return (Severity, POpenPay, PForCheckAmt, PDomCheckAmt, PExchRate, PCheckDate, PRef, Infobar);
			}
		}
	}
}
