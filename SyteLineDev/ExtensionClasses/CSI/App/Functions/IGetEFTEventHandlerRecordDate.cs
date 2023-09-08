//PROJECT NAME: Data
//CLASS NAME: IGetEFTEventHandlerRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEFTEventHandlerRecordDate
	{
		DateTime? GetEFTEventHandlerRecordDateFn(
			string MapId);
	}
}

