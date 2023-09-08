//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSDelOtherObjNoteRecord.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSDelOtherObjNoteRecord
	{
		int? EXTSSSFSDelOtherObjNoteRecordSp(
			string iTable,
			decimal? iSpecificToken,
			decimal? iUserToken,
			decimal? iSystemToken,
			Guid? RefRowPointer = null);
	}
}

