//PROJECT NAME: CSICustomer
//CLASS NAME: CheckCustExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICheckCustExists
	{
		int CheckCustExistsSp(string CustNum,
		                      int? CustSeq,
		                      ref string Infobar);
	}
	
	public class CheckCustExists : ICheckCustExists
	{
		readonly IApplicationDB appDB;
		
		public CheckCustExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckCustExistsSp(string CustNum,
		                             int? CustSeq,
		                             ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckCustExistsSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
