//PROJECT NAME: CSICustomer
//CLASS NAME: CoGetOrderActivity2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoGetOrderActivity2
	{
		int CoGetOrderActivity2Sp(string CoNum,
		                          string CustNum,
		                          int? CustSeq,
		                          ref string PromptMsg,
		                          ref string PromptButtons);
	}
	
	public class CoGetOrderActivity2 : ICoGetOrderActivity2
	{
		readonly IApplicationDB appDB;
		
		public CoGetOrderActivity2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CoGetOrderActivity2Sp(string CoNum,
		                                 string CustNum,
		                                 int? CustSeq,
		                                 ref string PromptMsg,
		                                 ref string PromptButtons)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoGetOrderActivity2Sp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return Severity;
			}
		}
	}
}
