//PROJECT NAME: CSIVendor
//CLASS NAME: CheckProjMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckProjMatl
	{
		int CheckProjMatlSp(string PoNum,
		                    short? PoLine,
		                    string Item,
		                    string RefNum,
		                    short? RefLineSuf,
		                    ref byte? PermitToAddProjMatl,
		                    ref string PromptMsg,
		                    ref string Infobar);
	}
	
	public class CheckProjMatl : ICheckProjMatl
	{
		readonly IApplicationDB appDB;
		
		public CheckProjMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckProjMatlSp(string PoNum,
		                           short? PoLine,
		                           string Item,
		                           string RefNum,
		                           short? RefLineSuf,
		                           ref byte? PermitToAddProjMatl,
		                           ref string PromptMsg,
		                           ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			ItemType _Item = Item;
			CoJobProjTrnNumType _RefNum = RefNum;
			CoLineSuffixProjTaskTrnLineType _RefLineSuf = RefLineSuf;
			ListYesNoType _PermitToAddProjMatl = PermitToAddProjMatl;
			Infobar _PromptMsg = PromptMsg;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckProjMatlSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PermitToAddProjMatl", _PermitToAddProjMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PermitToAddProjMatl = _PermitToAddProjMatl;
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
