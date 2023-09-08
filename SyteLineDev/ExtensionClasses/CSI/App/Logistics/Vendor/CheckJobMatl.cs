//PROJECT NAME: CSIVendor
//CLASS NAME: CheckJobMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckJobMatl
	{
		int CheckJobMatlSp(string PoNum,
		                   short? PoLine,
		                   short? PoRelease,
		                   string Item,
		                   string RefNum,
		                   short? RefLineSuf,
		                   short? RefRelease,
		                   string PoitemUM,
		                   ref byte? PermitToUpdateJobMatl,
		                   ref string PromptMsg,
		                   ref string Infobar);
	}
	
	public class CheckJobMatl : ICheckJobMatl
	{
		readonly IApplicationDB appDB;
		
		public CheckJobMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckJobMatlSp(string PoNum,
		                          short? PoLine,
		                          short? PoRelease,
		                          string Item,
		                          string RefNum,
		                          short? RefLineSuf,
		                          short? RefRelease,
		                          string PoitemUM,
		                          ref byte? PermitToUpdateJobMatl,
		                          ref string PromptMsg,
		                          ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			ItemType _Item = Item;
			CoJobProjTrnNumType _RefNum = RefNum;
			CoLineSuffixProjTaskTrnLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			UMType _PoitemUM = PoitemUM;
			ListYesNoType _PermitToUpdateJobMatl = PermitToUpdateJobMatl;
			Infobar _PromptMsg = PromptMsg;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckJobMatlSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemUM", _PoitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PermitToUpdateJobMatl", _PermitToUpdateJobMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PermitToUpdateJobMatl = _PermitToUpdateJobMatl;
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
