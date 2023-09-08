//PROJECT NAME: Logistics
//CLASS NAME: CheckJobCostRollUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckJobCostRollUp : ICheckJobCostRollUp
	{
		readonly IApplicationDB appDB;
		
		
		public CheckJobCostRollUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string Infobar) CheckJobCostRollUpSp(string Item,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string PromptMsg,
		string Infobar)
		{
			ItemType _Item = Item;
			CoJobProjTrnNumType _RefNum = RefNum;
			CoLineSuffixProjTaskTrnLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			Infobar _PromptMsg = PromptMsg;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckJobCostRollUpSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, Infobar);
			}
		}
	}
}
