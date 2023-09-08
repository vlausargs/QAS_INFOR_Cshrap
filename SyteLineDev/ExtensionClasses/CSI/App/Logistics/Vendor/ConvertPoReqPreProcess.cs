//PROJECT NAME: Logistics
//CLASS NAME: ConvertPoReqPreProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ConvertPoReqPreProcess : IConvertPoReqPreProcess
	{
		readonly IApplicationDB appDB;
		
		
		public ConvertPoReqPreProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PPoChangeFlag,
		string PromptMsg,
		string PromptButtons,
		string PoChgPromptMsg,
		string PoChgPromptButtons,
		string VendReqPromptMsg,
		string VendReqPromptButtons,
		string Infobar) ConvertPoReqPreProcessSp(string PPoNum,
		string PReqNum,
		int? PPreqFromLine,
		int? PPreqToLine,
		string PPoType,
		int? PPoChangeFlag,
		string PromptMsg = null,
		string PromptButtons = null,
		string PoChgPromptMsg = null,
		string PoChgPromptButtons = null,
		string VendReqPromptMsg = null,
		string VendReqPromptButtons = null,
		string Infobar = null)
		{
			PoNumType _PPoNum = PPoNum;
			ReqNumType _PReqNum = PReqNum;
			ReqLineType _PPreqFromLine = PPreqFromLine;
			ReqLineType _PPreqToLine = PPreqToLine;
			PoTypeType _PPoType = PPoType;
			ListYesNoType _PPoChangeFlag = PPoChangeFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _PoChgPromptMsg = PoChgPromptMsg;
			InfobarType _PoChgPromptButtons = PoChgPromptButtons;
			InfobarType _VendReqPromptMsg = VendReqPromptMsg;
			InfobarType _VendReqPromptButtons = VendReqPromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConvertPoReqPreProcessSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPreqFromLine", _PPreqFromLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPreqToLine", _PPreqToLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoType", _PPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoChangeFlag", _PPoChangeFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChgPromptMsg", _PoChgPromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChgPromptButtons", _PoChgPromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendReqPromptMsg", _VendReqPromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendReqPromptButtons", _VendReqPromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPoChangeFlag = _PPoChangeFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				PoChgPromptMsg = _PoChgPromptMsg;
				PoChgPromptButtons = _PoChgPromptButtons;
				VendReqPromptMsg = _VendReqPromptMsg;
				VendReqPromptButtons = _VendReqPromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PPoChangeFlag, PromptMsg, PromptButtons, PoChgPromptMsg, PoChgPromptButtons, VendReqPromptMsg, VendReqPromptButtons, Infobar);
			}
		}
	}
}
