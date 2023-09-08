//PROJECT NAME: Data
//CLASS NAME: IGetEFTMapTypeRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEFTMapTypeRecordDate
	{
		DateTime? GetEFTMapTypeRecordDateFn(
			string EFTType);
	}
}

