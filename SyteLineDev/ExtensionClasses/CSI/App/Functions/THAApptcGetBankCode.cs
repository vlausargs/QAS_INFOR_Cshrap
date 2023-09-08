//PROJECT NAME: Data
//CLASS NAME: THAApptcGetBankCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApptcGetBankCode : ITHAApptcGetBankCode
	{
		readonly IApplicationDB appDB;
		
		public THAApptcGetBankCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PBankCode,
			string Infobar) THAApptcGetBankCodeSp(
			string PPayType,
			int? PCheckNum,
			string PVendNum,
			DateTime? PCheckDate,
			decimal? PAmtPaid,
			string PBankCode,
			string Infobar)
		{
			LongListType _PPayType = PPayType;
			ApCheckNumType _PCheckNum = PCheckNum;
			VendNumType _PVendNum = PVendNum;
			CurrentDateType _PCheckDate = PCheckDate;
			AmountType _PAmtPaid = PAmtPaid;
			BankCodeType _PBankCode = PBankCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAApptcGetBankCodeSp";
				
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmtPaid", _PAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PBankCode = _PBankCode;
				Infobar = _Infobar;
				
				return (Severity, PBankCode, Infobar);
			}
		}
	}
}
