//PROJECT NAME: Data
//CLASS NAME: ICopyRecchk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyRecchk
	{
		(int? ReturnCode,
			string Infobar) CopyRecchkSp(
			string FromItem,
			string ToItem,
			int? FromSuffix,
			string Infobar);
	}
}

