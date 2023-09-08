//PROJECT NAME: Material
//CLASS NAME: INextSjb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface INextSjb
	{
		(int? ReturnCode,
			string PKey,
			string Infobar) NextSjbSp(
			string PContext,
			string PPrefix,
			int? PKeyLength,
			string PKey,
			string Infobar);
	}
}

