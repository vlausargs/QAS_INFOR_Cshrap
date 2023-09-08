//PROJECT NAME: Data
//CLASS NAME: IDelTermAllUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDelTermAllUsed
	{
		(int? ReturnCode,
			string Infobar) DelTermAllUsedSp(
			string SiteRef,
			string Delterm,
			string Infobar);
	}
}

