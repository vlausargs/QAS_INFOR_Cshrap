//PROJECT NAME: CSICustomer
//CLASS NAME: CoStatusChangeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoStatusChangeValid
	{
		int CoStatusChangeValidSp(string CurrCoStatus,
		                          string NewCoStatus,
		                          string CoNum,
		                          ref string Infobar);
	}
	
	public class CoStatusChangeValid : ICoStatusChangeValid
	{
		readonly IApplicationDB appDB;
		
		public CoStatusChangeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CoStatusChangeValidSp(string CurrCoStatus,
		                                 string NewCoStatus,
		                                 string CoNum,
		                                 ref string Infobar)
		{
			CoStatusType _CurrCoStatus = CurrCoStatus;
			CoStatusType _NewCoStatus = NewCoStatus;
			CoNumType _CoNum = CoNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoStatusChangeValidSp";
				
				appDB.AddCommandParameter(cmd, "CurrCoStatus", _CurrCoStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCoStatus", _NewCoStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
