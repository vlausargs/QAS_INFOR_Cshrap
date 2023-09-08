//PROJECT NAME: Data
//CLASS NAME: IInsertTtPrRecord.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInsertTtPrRecord
	{
		(int? ReturnCode,
			string t_plans) InsertTtPrRecordSp(
			string emp_num,
			string de_code,
			decimal? amt_delta,
			string t_plans);
	}
}

