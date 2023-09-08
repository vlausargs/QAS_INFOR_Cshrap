//PROJECT NAME: Data
//CLASS NAME: IGetEFTDataViewRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEFTDataViewRecordDate
	{
		DateTime? GetEFTDataViewRecordDateFn(
			string ViewName);
	}
}

