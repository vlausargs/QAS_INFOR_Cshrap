//PROJECT NAME: Data
//CLASS NAME: GetCoitemTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCoitemTax : IGetCoitemTax
	{
		readonly IApplicationDB appDB;
		
		public GetCoitemTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GetCoitemTaxSp(
			int? ProrateTax,
			string Infobar)
		{
			ListYesNoType _ProrateTax = ProrateTax;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoitemTaxSp";
				
				appDB.AddCommandParameter(cmd, "ProrateTax", _ProrateTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
