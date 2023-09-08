//PROJECT NAME: Logistics
//CLASS NAME: GetApparms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetApparms : IGetApparms
	{
		readonly IApplicationDB appDB;
		
		
		public GetApparms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice) GetApparmsSp(string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice)
		{
			BankCodeType _PEFTBankCode = PEFTBankCode;
			EFTFormatType _PEFTFormat = PEFTFormat;
			EFTUserNameType _PEFTUserName = PEFTUserName;
			EFTUserNumberType _PEFTUserNumber = PEFTUserNumber;
			ListYesNoType _PPrintManualRemitAdvice = PPrintManualRemitAdvice;
			ListYesNoType _PPrintEFTRemitAdvice = PPrintEFTRemitAdvice;
			ListYesNoType _PPrintWireRemitAdvice = PPrintWireRemitAdvice;
			ListYesNoType _PPrintDraftRemitAdvice = PPrintDraftRemitAdvice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApparmsSp";
				
				appDB.AddCommandParameter(cmd, "PEFTBankCode", _PEFTBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTFormat", _PEFTFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTUserName", _PEFTUserName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTUserNumber", _PEFTUserNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintManualRemitAdvice", _PPrintManualRemitAdvice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintEFTRemitAdvice", _PPrintEFTRemitAdvice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintWireRemitAdvice", _PPrintWireRemitAdvice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintDraftRemitAdvice", _PPrintDraftRemitAdvice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEFTBankCode = _PEFTBankCode;
				PEFTFormat = _PEFTFormat;
				PEFTUserName = _PEFTUserName;
				PEFTUserNumber = _PEFTUserNumber;
				PPrintManualRemitAdvice = _PPrintManualRemitAdvice;
				PPrintEFTRemitAdvice = _PPrintEFTRemitAdvice;
				PPrintWireRemitAdvice = _PPrintWireRemitAdvice;
				PPrintDraftRemitAdvice = _PPrintDraftRemitAdvice;
				
				return (Severity, PEFTBankCode, PEFTFormat, PEFTUserName, PEFTUserNumber, PPrintManualRemitAdvice, PPrintEFTRemitAdvice, PPrintWireRemitAdvice, PPrintDraftRemitAdvice);
			}
		}
	}
}
