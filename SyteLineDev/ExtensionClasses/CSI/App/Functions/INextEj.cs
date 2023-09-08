//PROJECT NAME: Data
//CLASS NAME: INextEj.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextEj
	{
		(int? ReturnCode,
			string PKey,
			string Infobar) NextEjSp(
			string PContext,
			string PPrefix,
			int? PKeyLength,
			string PKey,
			string Infobar);
	}
}

