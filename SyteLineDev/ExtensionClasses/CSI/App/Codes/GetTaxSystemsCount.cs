//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxSystemsCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetTaxSystemsCount
	{
		int GetTaxSystemsCountSp(ref int? TaxSystemCount,
		                         ref string Infobar);
	}
	
	public class GetTaxSystemsCount : IGetTaxSystemsCount
	{
		readonly IApplicationDB appDB;
		
		public GetTaxSystemsCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetTaxSystemsCountSp(ref int? TaxSystemCount,
		                                ref string Infobar)
		{
			IntType _TaxSystemCount = TaxSystemCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTaxSystemsCountSp";
				
				appDB.AddCommandParameter(cmd, "TaxSystemCount", _TaxSystemCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxSystemCount = _TaxSystemCount;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
