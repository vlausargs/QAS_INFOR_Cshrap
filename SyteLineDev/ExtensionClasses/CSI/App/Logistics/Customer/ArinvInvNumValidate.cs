//PROJECT NAME: Logistics
//CLASS NAME: ArinvInvNumValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArinvInvNumValidate : IArinvInvNumValidate
	{
		readonly IApplicationDB appDB;
		
		
		public ArinvInvNumValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string Infobar,
		string CoNum,
		string PCurrCode,
		DateTime? PTaxDate) ArinvInvNumValidateSp(string CustNum,
		string ArinvType,
		string InvNum,
		DateTime? InvDate,
		string CalledFrom,
		string PromptMsg,
		string Infobar,
		int? IsApplyToInvNum = 0,
		string CoNum = null,
		string PCurrCode = null,
		DateTime? PTaxDate = null)
		{
			CustNumType _CustNum = CustNum;
			ArinvTypeType _ArinvType = ArinvType;
			InvNumType _InvNum = InvNum;
			DateType _InvDate = InvDate;
			StringType _CalledFrom = CalledFrom;
			Infobar _PromptMsg = PromptMsg;
			Infobar _Infobar = Infobar;
			ListYesNoType _IsApplyToInvNum = IsApplyToInvNum;
			CoNumType _CoNum = CoNum;
			CurrCodeType _PCurrCode = PCurrCode;
			DateType _PTaxDate = PTaxDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArinvInvNumValidateSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvType", _ArinvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsApplyToInvNum", _IsApplyToInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxDate", _PTaxDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				CoNum = _CoNum;
				PCurrCode = _PCurrCode;
				PTaxDate = _PTaxDate;
				
				return (Severity, PromptMsg, Infobar, CoNum, PCurrCode, PTaxDate);
			}
		}
	}
}
