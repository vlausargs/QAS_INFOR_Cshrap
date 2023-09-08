//PROJECT NAME: Data
//CLASS NAME: IMpwxrefdDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMpwxrefdDelete
	{
		(int? ReturnCode,
			string Infobar) MpwxrefdDeleteSp(
			string PReference,
			string PRefType,
			string PItem,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			int? PRefSeq,
			string Infobar);
	}
}

