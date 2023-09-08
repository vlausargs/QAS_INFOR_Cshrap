//PROJECT NAME: Data
//CLASS NAME: ISvallocPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISvallocPost
	{
		(int? ReturnCode,
			string Infobar) SvallocPostSp(
			string Site,
			string Item,
			string Whse,
			string Loc,
			string Infobar);
	}
}

