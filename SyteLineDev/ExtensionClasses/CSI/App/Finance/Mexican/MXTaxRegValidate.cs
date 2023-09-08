//PROJECT NAME: Finance
//CLASS NAME: MXTaxRegValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public interface IMXTaxRegValidate
	{
		(int? ReturnCode, string Infobar) MXTaxRegValidateSp(string TaxRegNum = null,
		string TaxRegForeing = null,
		string Infobar = null);
	}
	
	public class MXTaxRegValidate : IMXTaxRegValidate
	{
		readonly IApplicationDB appDB;
		
		public MXTaxRegValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MXTaxRegValidateSp(string TaxRegNum = null,
		string TaxRegForeing = null,
		string Infobar = null)
		{
			TaxRegNumType _TaxRegNum = TaxRegNum;
			StringType _TaxRegForeing = TaxRegForeing;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXTaxRegValidateSp";
				
				appDB.AddCommandParameter(cmd, "TaxRegNum", _TaxRegNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxRegForeing", _TaxRegForeing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
