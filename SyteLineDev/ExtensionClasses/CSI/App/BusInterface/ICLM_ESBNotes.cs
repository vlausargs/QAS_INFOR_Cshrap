//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBNotes
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBNotesSp(
			Guid? RowPointer);
	}
}

