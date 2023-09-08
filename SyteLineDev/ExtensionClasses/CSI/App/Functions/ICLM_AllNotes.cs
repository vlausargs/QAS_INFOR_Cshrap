//PROJECT NAME: Data
//CLASS NAME: ICLM_AllNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_AllNotes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_AllNotesSp(
			string TableName,
			string RowPointer);
	}
}

