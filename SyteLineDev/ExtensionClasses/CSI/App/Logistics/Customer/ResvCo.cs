//PROJECT NAME: CSICustomer
//CLASS NAME: ResvCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IResvCo
	{
		int ResvCoSp(string CurCoNum,
		             ref string Infobar);
	}
	
	public class ResvCo : IResvCo
	{
		readonly IApplicationDB appDB;
		
		public ResvCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ResvCoSp(string CurCoNum,
		                    ref string Infobar)
		{
			CoNumType _CurCoNum = CurCoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ResvCoSp";
				
				appDB.AddCommandParameter(cmd, "CurCoNum", _CurCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
