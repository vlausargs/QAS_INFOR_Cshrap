//PROJECT NAME: CSICodes
//CLASS NAME: TaxCodeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ITaxCodeValid
	{
		int TaxCodeValidSp(byte? TaxSystem,
		                   string TaxCode,
		                   string TaxType,
		                   ref string Infobar);
	}
	
	public class TaxCodeValid : ITaxCodeValid
	{
		readonly IApplicationDB appDB;
		
		public TaxCodeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int TaxCodeValidSp(byte? TaxSystem,
		                          string TaxCode,
		                          string TaxType,
		                          ref string Infobar)
		{
			TaxSystemType _TaxSystem = TaxSystem;
			TaxCodeType _TaxCode = TaxCode;
			StringType _TaxType = TaxType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxCodeValidSp";
				
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxType", _TaxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
