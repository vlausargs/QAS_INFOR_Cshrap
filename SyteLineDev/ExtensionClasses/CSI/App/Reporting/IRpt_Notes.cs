//PROJECT NAME: Reporting
//CLASS NAME: IRpt_Notes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_Notes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_NotesSp(Guid? pRefRowPointer = null,
			int? pShowExternal = 1,
			int? pShowInternal = 1);
	}
}

