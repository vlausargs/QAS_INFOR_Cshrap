//PROJECT NAME: Data
//CLASS NAME: IPSVal6.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPSVal6
	{
		(int? ReturnCode,
			string Infobar) PSVal6Sp(
			string PSNum,
			string PSItem,
			string Infobar);
	}
}

