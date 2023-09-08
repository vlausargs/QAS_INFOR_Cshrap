//PROJECT NAME: Production
//CLASS NAME: ICopyNotesBulk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICopyNotesBulk
	{
		int? CopyNotesBulkSp(
			string FromObject,
			string ToObject);
	}
}

