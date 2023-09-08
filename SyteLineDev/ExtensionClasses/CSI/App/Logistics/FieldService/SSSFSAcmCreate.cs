//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcmCreate : ISSSFSAcmCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAcmCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4,
			string Infobar) SSSFSAcmCreateSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRelease,
			string InvNum,
			int? InvLine,
			string CustNum,
			string Whse,
			string ProductCode,
			decimal? Amount,
			int? Periods,
			int? CreateLines,
			DateTime? StartDate,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4,
			string Infobar)
		{
			FSRefTypeCKOPSType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLine = RefLine;
			FSRefReleaseType _RefRelease = RefRelease;
			InvNumType _InvNum = InvNum;
			InvLineType _InvLine = InvLine;
			CustNumType _CustNum = CustNum;
			WhseType _Whse = Whse;
			ProductCodeType _ProductCode = ProductCode;
			AmountType _Amount = Amount;
			GenericIntType _Periods = Periods;
			ListYesNoType _CreateLines = CreateLines;
			DateType _StartDate = StartDate;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAcmCreateSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Periods", _Periods, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateLines", _CreateLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				AcctUnit1 = _AcctUnit1;
				AcctUnit2 = _AcctUnit2;
				AcctUnit3 = _AcctUnit3;
				AcctUnit4 = _AcctUnit4;
				Infobar = _Infobar;
				
				return (Severity, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, Infobar);
			}
		}
	}
}
