//PROJECT NAME: CSICustomer
//CLASS NAME: LcrValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ILcrValid
	{
		int LcrValidSp(string CoNum,
		               string CustNum,
		               string LcrNum,
		               string CoStat,
		               ref string Infobar);
	}
	
	public class LcrValid : ILcrValid
	{
		readonly IApplicationDB appDB;
		
		public LcrValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LcrValidSp(string CoNum,
		                      string CustNum,
		                      string LcrNum,
		                      string CoStat,
		                      ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			LcrNumType _LcrNum = LcrNum;
			CoStatusType _CoStat = CoStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LcrValidSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrNum", _LcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoStat", _CoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
