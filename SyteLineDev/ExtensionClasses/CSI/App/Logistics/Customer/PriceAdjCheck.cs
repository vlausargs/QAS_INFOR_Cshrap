//PROJECT NAME: CSICustomer
//CLASS NAME: PriceAdjCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPriceAdjCheck
	{
		int PriceAdjCheckSp(string CONum,
		                    ref string Infobar);
	}
	
	public class PriceAdjCheck : IPriceAdjCheck
	{
		readonly IApplicationDB appDB;
		
		public PriceAdjCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PriceAdjCheckSp(string CONum,
		                           ref string Infobar)
		{
			CoNumType _CONum = CONum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PriceAdjCheckSp";
				
				appDB.AddCommandParameter(cmd, "CONum", _CONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
