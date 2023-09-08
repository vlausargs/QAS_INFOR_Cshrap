//PROJECT NAME: CSICustomer
//CLASS NAME: CpSoPreprocess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICpSoPreprocess
	{
		(int? ReturnCode, string FromCurrCode, string ToCurrCode, string LcrWarningMsg, string LcrWarningButtons, string CurrCodeMatchWarningMsg, string CurrCodeMatchWarningButtons, string Infobar) CpSoPreprocessSp(string FromCoNum,
		string ToCoNum,
		string FromCurrCode,
		string ToCurrCode,
		string LcrWarningMsg,
		string LcrWarningButtons,
		string CurrCodeMatchWarningMsg,
		string CurrCodeMatchWarningButtons,
		string Infobar,
		string ToType = null);
	}
	
	public class CpSoPreprocess : ICpSoPreprocess
	{
		readonly IApplicationDB appDB;
		
		public CpSoPreprocess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string FromCurrCode, string ToCurrCode, string LcrWarningMsg, string LcrWarningButtons, string CurrCodeMatchWarningMsg, string CurrCodeMatchWarningButtons, string Infobar) CpSoPreprocessSp(string FromCoNum,
		string ToCoNum,
		string FromCurrCode,
		string ToCurrCode,
		string LcrWarningMsg,
		string LcrWarningButtons,
		string CurrCodeMatchWarningMsg,
		string CurrCodeMatchWarningButtons,
		string Infobar,
		string ToType = null)
		{
			CoNumType _FromCoNum = FromCoNum;
			CoNumType _ToCoNum = ToCoNum;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			Infobar _LcrWarningMsg = LcrWarningMsg;
			Infobar _LcrWarningButtons = LcrWarningButtons;
			Infobar _CurrCodeMatchWarningMsg = CurrCodeMatchWarningMsg;
			Infobar _CurrCodeMatchWarningButtons = CurrCodeMatchWarningButtons;
			Infobar _Infobar = Infobar;
			CoTypeType _ToType = ToType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoPreprocessSp";
				
				appDB.AddCommandParameter(cmd, "FromCoNum", _FromCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCoNum", _ToCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LcrWarningMsg", _LcrWarningMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LcrWarningButtons", _LcrWarningButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCodeMatchWarningMsg", _CurrCodeMatchWarningMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCodeMatchWarningButtons", _CurrCodeMatchWarningButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FromCurrCode = _FromCurrCode;
				ToCurrCode = _ToCurrCode;
				LcrWarningMsg = _LcrWarningMsg;
				LcrWarningButtons = _LcrWarningButtons;
				CurrCodeMatchWarningMsg = _CurrCodeMatchWarningMsg;
				CurrCodeMatchWarningButtons = _CurrCodeMatchWarningButtons;
				Infobar = _Infobar;
				
				return (Severity, FromCurrCode, ToCurrCode, LcrWarningMsg, LcrWarningButtons, CurrCodeMatchWarningMsg, CurrCodeMatchWarningButtons, Infobar);
			}
		}
	}
}
