//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSIncNoteExactRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncNoteExactRecordDate
	{
		(int? ReturnCode, string ExactRecordDate) SSSFSIncNoteExactRecordDateSp(decimal? SpecificNoteToken,
		string ExactRecordDate);
	}
}

