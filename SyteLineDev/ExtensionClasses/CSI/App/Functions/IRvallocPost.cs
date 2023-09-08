//PROJECT NAME: Data
//CLASS NAME: IRvallocPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRvallocPost
	{
		(int? ReturnCode,
			string Infobar) RvallocPostSp(
			string Site,
			string Item,
			string Whse,
			string Loc,
			string Infobar);
	}
}

