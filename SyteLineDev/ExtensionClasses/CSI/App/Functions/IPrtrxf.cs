//PROJECT NAME: Data
//CLASS NAME: IPrtrxf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtrxf
	{
		(int? ReturnCode,
			string Infobar) PrtrxfSp(
			string Infobar);
	}
}

