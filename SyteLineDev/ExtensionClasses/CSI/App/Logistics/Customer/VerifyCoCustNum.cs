//PROJECT NAME: Logistics
//CLASS NAME: VerifyCoCustNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class VerifyCoCustNum : IVerifyCoCustNum
	{
		readonly IApplicationDB appDB;
		
		
		public VerifyCoCustNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustNum,
		string Infobar) VerifyCoCustNumSp(string CoNum,
		string CustNum,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyCoCustNumSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				Infobar = _Infobar;
				
				return (Severity, CustNum, Infobar);
			}
		}
	}
}
