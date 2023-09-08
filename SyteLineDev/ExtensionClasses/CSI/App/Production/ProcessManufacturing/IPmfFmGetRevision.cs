//PROJECT NAME: Production
//CLASS NAME: IPmfFmGetRevision.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmGetRevision
	{
		(int? ReturnCode,
		string InfoBar,
		int? NextRevNo) PmfFmGetRevisionSp(
			string InfoBar = null,
			string Fm = null,
			string FmVer = null,
			int? NextRevNo = null);
	}
}

