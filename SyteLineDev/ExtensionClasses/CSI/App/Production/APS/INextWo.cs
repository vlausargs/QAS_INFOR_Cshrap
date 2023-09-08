//PROJECT NAME: Production
//CLASS NAME: INextWo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface INextWo
	{
		(int? ReturnCode, string PKey,
		string Infobar) NextWoSp(string PContext,
		string PPrefix,
		int? PKeyLength,
		string PKey,
		string Infobar);
	}
}

