//PROJECT NAME: Data
//CLASS NAME: THAApptcValidCheckAPPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApptcValidCheckAPPayment : ITHAApptcValidCheckAPPayment
	{
		readonly IApplicationDB appDB;
		
		public THAApptcValidCheckAPPayment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PBankCode,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar) THAApptcValidCheckAPPaymentSp(
			int? PNewRecord,
			int? PCheckNum,
			string PPayType,
			int? PReapplication,
			string PVendNum,
			string PBankCode,
			int? POpenPay,
			decimal? PForCheckAmt,
			decimal? PDomCheckAmt,
			decimal? PExchRate,
			DateTime? PCheckDate,
			string PRef,
			string Infobar)
		{
			FlagNyType _PNewRecord = PNewRecord;
			ApCheckNumType _PCheckNum = PCheckNum;
			LongListType _PPayType = PPayType;
			FlagNyType _PReapplication = PReapplication;
			VendNumType _PVendNum = PVendNum;
			BankCodeType _PBankCode = PBankCode;
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
				cmd.CommandText = "THAApptcValidCheckAPPaymentSp";
				
				appDB.AddCommandParameter(cmd, "PNewRecord", _PNewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReapplication", _PReapplication, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenPay", _POpenPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PBankCode = _PBankCode;
				POpenPay = _POpenPay;
				PForCheckAmt = _PForCheckAmt;
				PDomCheckAmt = _PDomCheckAmt;
				PExchRate = _PExchRate;
				PCheckDate = _PCheckDate;
				PRef = _PRef;
				Infobar = _Infobar;
				
				return (Severity, PBankCode, POpenPay, PForCheckAmt, PDomCheckAmt, PExchRate, PCheckDate, PRef, Infobar);
			}
		}
	}
}
