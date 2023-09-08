//PROJECT NAME: Finance
//CLASS NAME: IARPayPostRemoteCopyNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARPayPostRemoteCopyNotes
	{
		(int? ReturnCode,
			string Infobar) ARPayPostRemoteCopyNotesSp(
			Guid? PArpmtRowPointer,
			string PToSite,
			string PToTable,
			Guid? PToRowPointer,
			string Infobar);
	}
}

