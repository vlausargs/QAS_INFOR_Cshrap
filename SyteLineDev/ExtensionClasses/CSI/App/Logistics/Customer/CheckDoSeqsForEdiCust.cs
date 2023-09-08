//PROJECT NAME: CSICustomer
//CLASS NAME: CheckDoSeqsForEdiCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICheckDoSeqsForEdiCust
	{
		int CheckDoSeqsForEdiCustSp(string CustNum,
		                            int? CustSeq,
		                            byte? GenInv,
		                            ref string Infobar);
	}
	
	public class CheckDoSeqsForEdiCust : ICheckDoSeqsForEdiCust
	{
		readonly IApplicationDB appDB;
		
		public CheckDoSeqsForEdiCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckDoSeqsForEdiCustSp(string CustNum,
		                                   int? CustSeq,
		                                   byte? GenInv,
		                                   ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ByteType _GenInv = GenInv;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckDoSeqsForEdiCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenInv", _GenInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
