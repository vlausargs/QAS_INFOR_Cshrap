//PROJECT NAME: Data
//CLASS NAME: PrintW2Forms_UpdateTempTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrintW2Forms_UpdateTempTables : IPrintW2Forms_UpdateTempTables
	{
		readonly IApplicationDB appDB;
		
		public PrintW2Forms_UpdateTempTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? t_first_city,
			int? t_first_state) PrintW2Forms_UpdateTempTablesSp(
			string to_state,
			string city_code,
			string de_code,
			decimal? de_amt,
			decimal? gross_pay,
			decimal? swt_g,
			decimal? cwt_g,
			int? t_first_city,
			int? t_first_state)
		{
			PrTaxCodeType _to_state = to_state;
			PrTaxCodeType _city_code = city_code;
			DeCodeType _de_code = de_code;
			PrYtdAmountType _de_amt = de_amt;
			PrYtdAmountType _gross_pay = gross_pay;
			PrYtdAmountType _swt_g = swt_g;
			PrYtdAmountType _cwt_g = cwt_g;
			ListYesNoType _t_first_city = t_first_city;
			ListYesNoType _t_first_state = t_first_state;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintW2Forms_UpdateTempTablesSp";
				
				appDB.AddCommandParameter(cmd, "to_state", _to_state, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "city_code", _city_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "de_code", _de_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "de_amt", _de_amt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "gross_pay", _gross_pay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "swt_g", _swt_g, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cwt_g", _cwt_g, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_first_city", _t_first_city, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_first_state", _t_first_state, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				t_first_city = _t_first_city;
				t_first_state = _t_first_state;
				
				return (Severity, t_first_city, t_first_state);
			}
		}
	}
}
