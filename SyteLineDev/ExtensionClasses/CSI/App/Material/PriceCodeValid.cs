//PROJECT NAME: Material
//CLASS NAME: PriceCodeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPriceCodeValid
	{
		(int? ReturnCode, string PriceCodeDesc, string Infobar) PriceCodeValidSp(string PriceCode,
		                                                                         string PriceCodeDesc,
		                                                                         string Infobar);
	}
	
	public class PriceCodeValid : IPriceCodeValid
	{
		readonly IApplicationDB appDB;
		
		public PriceCodeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PriceCodeDesc, string Infobar) PriceCodeValidSp(string PriceCode,
		                                                                                string PriceCodeDesc,
		                                                                                string Infobar)
		{
			PriceCodeType _PriceCode = PriceCode;
			DescriptionType _PriceCodeDesc = PriceCodeDesc;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PriceCodeValidSp";
				
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCodeDesc", _PriceCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceCodeDesc = _PriceCodeDesc;
				Infobar = _Infobar;
				
				return (Severity, PriceCodeDesc, Infobar);
			}
		}
	}
}
