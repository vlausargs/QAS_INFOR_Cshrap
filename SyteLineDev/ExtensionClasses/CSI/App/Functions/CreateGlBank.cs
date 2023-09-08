//PROJECT NAME: Data
//CLASS NAME: CreateGlBank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateGlBank : ICreateGlBank
	{
		readonly IApplicationDB appDB;
		
		public CreateGlBank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateGlBankSp(
			Guid? ProcessId,
			string BankCode,
			DateTime? CheckDate,
			int? CheckNumber,
			decimal? CheckAmt,
			string Type,
			string RefType,
			string RefNum,
			decimal? DomCheckAmt,
			string Infobar)
		{
			RowPointer _ProcessId = ProcessId;
			BankCodeType _BankCode = BankCode;
			DateType _CheckDate = CheckDate;
			ArCheckNumType _CheckNumber = CheckNumber;
			AmountType _CheckAmt = CheckAmt;
			ArpmtTypeType _Type = Type;
			ReferenceType _RefType = RefType;
			CustNumType _RefNum = RefNum;
			AmountType _DomCheckAmt = DomCheckAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateGlBankSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNumber", _CheckNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckAmt", _CheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCheckAmt", _DomCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
