//PROJECT NAME: Data
//CLASS NAME: IWordNumI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWordNumI
	{
		(int? ReturnCode,
			string Result,
			string Infobar) WordNumISp(
			string WordNum,
			string PCurrCode,
			int? Offset,
			string Result,
			string Infobar);
	}
}

