//PROJECT NAME: Logistics
//CLASS NAME: GetParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetParms : IGetParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice) GetParmsSp(decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice)
		{
			TolerancePercentType _POToleranceOver = POToleranceOver;
			TolerancePercentType _POToleranceUnder = POToleranceUnder;
			ListYesNoType _Vchrauthorize = Vchrauthorize;
			TolerancePercentType _VchrOverPoCostTolerance = VchrOverPoCostTolerance;
			TolerancePercentType _VchrUnderPoCostTolerance = VchrUnderPoCostTolerance;
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
				cmd.CommandText = "GetParmsSp";
				
				appDB.AddCommandParameter(cmd, "POToleranceOver", _POToleranceOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POToleranceUnder", _POToleranceUnder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Vchrauthorize", _Vchrauthorize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrOverPoCostTolerance", _VchrOverPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrUnderPoCostTolerance", _VchrUnderPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTBankCode", _PEFTBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTFormat", _PEFTFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTUserName", _PEFTUserName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTUserNumber", _PEFTUserNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintManualRemitAdvice", _PPrintManualRemitAdvice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintEFTRemitAdvice", _PPrintEFTRemitAdvice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintWireRemitAdvice", _PPrintWireRemitAdvice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPrintDraftRemitAdvice", _PPrintDraftRemitAdvice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POToleranceOver = _POToleranceOver;
				POToleranceUnder = _POToleranceUnder;
				Vchrauthorize = _Vchrauthorize;
				VchrOverPoCostTolerance = _VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = _VchrUnderPoCostTolerance;
				PEFTBankCode = _PEFTBankCode;
				PEFTFormat = _PEFTFormat;
				PEFTUserName = _PEFTUserName;
				PEFTUserNumber = _PEFTUserNumber;
				PPrintManualRemitAdvice = _PPrintManualRemitAdvice;
				PPrintEFTRemitAdvice = _PPrintEFTRemitAdvice;
				PPrintWireRemitAdvice = _PPrintWireRemitAdvice;
				PPrintDraftRemitAdvice = _PPrintDraftRemitAdvice;
				
				return (Severity, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, PEFTBankCode, PEFTFormat, PEFTUserName, PEFTUserNumber, PPrintManualRemitAdvice, PPrintEFTRemitAdvice, PPrintWireRemitAdvice, PPrintDraftRemitAdvice);
			}
		}
	}
}
