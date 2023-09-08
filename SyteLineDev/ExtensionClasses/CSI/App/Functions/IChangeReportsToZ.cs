//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToZ.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToZ
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToZSp(
			string Infobar);
	}
}

