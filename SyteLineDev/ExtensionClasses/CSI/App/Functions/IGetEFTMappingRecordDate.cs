//PROJECT NAME: Data
//CLASS NAME: IGetEFTMappingRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEFTMappingRecordDate
	{
		DateTime? GetEFTMappingRecordDateFn(
			string MapId);
	}
}

