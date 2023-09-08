//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToV
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToVSp(
			string pSite,
			string Infobar);
	}
}

