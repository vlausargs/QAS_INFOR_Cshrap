//PROJECT NAME: CSIVendor
//CLASS NAME: GRNAlloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGrnalloc
	{
		int GrnallocSp(string CurGrnNum,
		               string CurVendNum,
		               ref int? ProcessLevel,
		               ref string PromptMsg,
		               ref string Buttons,
		               ref string Infobar);
	}
	
	public class Grnalloc : IGrnalloc
	{
		readonly IApplicationDB appDB;
		
		public Grnalloc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GrnallocSp(string CurGrnNum,
		                      string CurVendNum,
		                      ref int? ProcessLevel,
		                      ref string PromptMsg,
		                      ref string Buttons,
		                      ref string Infobar)
		{
			GrnNumType _CurGrnNum = CurGrnNum;
			VendNumType _CurVendNum = CurVendNum;
			IntType _ProcessLevel = ProcessLevel;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Buttons = Buttons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GrnallocSp";
				
				appDB.AddCommandParameter(cmd, "CurGrnNum", _CurGrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurVendNum", _CurVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessLevel", _ProcessLevel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProcessLevel = _ProcessLevel;
				PromptMsg = _PromptMsg;
				Buttons = _Buttons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
