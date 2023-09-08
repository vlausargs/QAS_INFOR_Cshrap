//PROJECT NAME: CSICustomer
//CLASS NAME: EdiPostCoCustPoExistsWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IEdiPostCoCustPoExistsWarning
	{
		int EdiPostCoCustPoExistsWarningSp(byte? PostAll,
		                                   string PEdiCoNum,
		                                   string PEdiCustPo,
		                                   ref string PromptMsg,
		                                   ref string PromptButtons,
		                                   ref string Infobar);
	}
	
	public class EdiPostCoCustPoExistsWarning : IEdiPostCoCustPoExistsWarning
	{
		readonly IApplicationDB appDB;
		
		public EdiPostCoCustPoExistsWarning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EdiPostCoCustPoExistsWarningSp(byte? PostAll,
		                                          string PEdiCoNum,
		                                          string PEdiCustPo,
		                                          ref string PromptMsg,
		                                          ref string PromptButtons,
		                                          ref string Infobar)
		{
			FlagNyType _PostAll = PostAll;
			CoNumType _PEdiCoNum = PEdiCoNum;
			CustPoType _PEdiCustPo = PEdiCustPo;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiPostCoCustPoExistsWarningSp";
				
				appDB.AddCommandParameter(cmd, "PostAll", _PostAll, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEdiCoNum", _PEdiCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEdiCustPo", _PEdiCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
