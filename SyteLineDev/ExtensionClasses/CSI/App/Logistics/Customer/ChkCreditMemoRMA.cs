//PROJECT NAME: CSICustomer
//CLASS NAME: ChkCreditMemoRMA.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IChkCreditMemoRMA
	{
		int ChkCreditMemoRMASp(string ParamRmaNum,
		                       short? ParamRmaLine,
		                       ref string Infobar);
	}
	
	public class ChkCreditMemoRMA : IChkCreditMemoRMA
	{
		readonly IApplicationDB appDB;
		
		public ChkCreditMemoRMA(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ChkCreditMemoRMASp(string ParamRmaNum,
		                              short? ParamRmaLine,
		                              ref string Infobar)
		{
			RmaNumType _ParamRmaNum = ParamRmaNum;
			RmaLineType _ParamRmaLine = ParamRmaLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkCreditMemoRMASp";
				
				appDB.AddCommandParameter(cmd, "ParamRmaNum", _ParamRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRmaLine", _ParamRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
