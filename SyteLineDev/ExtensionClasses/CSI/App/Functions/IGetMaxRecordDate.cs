//PROJECT NAME: Data
//CLASS NAME: IGetMaxRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetMaxRecordDate
	{
		DateTime? GetMaxRecordDateFn(
			DateTime? RecordDate1,
			DateTime? RecordDate2 = null,
			DateTime? RecordDate3 = null,
			DateTime? RecordDate4 = null,
			DateTime? RecordDate5 = null,
			DateTime? RecordDate6 = null,
			DateTime? RecordDate7 = null,
			DateTime? RecordDate8 = null,
			DateTime? RecordDate9 = null,
			DateTime? RecordDate10 = null);
	}
}

