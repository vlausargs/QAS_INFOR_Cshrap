//PROJECT NAME: Data
//CLASS NAME: IPrintW2Forms_UpdateTempTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrintW2Forms_UpdateTempTables
	{
		(int? ReturnCode,
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
			int? t_first_state);
	}
}

