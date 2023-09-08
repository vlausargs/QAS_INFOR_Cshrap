//PROJECT NAME: Production
//CLASS NAME: IProjPctComp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjPctComp
	{
		(int? ReturnCode,
			decimal? PctComplete) ProjPctCompSp(
			string RefNum,
			string ProjType,
			string ProjNum,
			int? TaskNum,
			decimal? PctComplete);
	}
}

