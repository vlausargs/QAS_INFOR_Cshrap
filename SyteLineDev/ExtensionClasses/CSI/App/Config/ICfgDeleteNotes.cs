//PROJECT NAME: Config
//CLASS NAME: ICfgDeleteNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgDeleteNotes
	{
		int? CfgDeleteNotesSp(
			Guid? RowPointer);
	}
}

