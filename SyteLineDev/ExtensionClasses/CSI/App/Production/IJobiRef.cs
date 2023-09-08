//PROJECT NAME: Production
//CLASS NAME: IJobiRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobiRef
	{
		(int? ReturnCode, int? FoundRef,
		string PMessage,
		string Infobar) JobiRefSp(string PJob,
		int? PSuffix,
		string PItem,
		int? FoundRef,
		string PMessage,
		string Infobar);
	}
}

