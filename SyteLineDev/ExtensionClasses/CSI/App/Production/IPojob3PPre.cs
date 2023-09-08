//PROJECT NAME: Production
//CLASS NAME: IPojob3PPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPojob3PPre
	{
		(int? ReturnCode, int? TNextOper,
		int? TIsLastOper,
		int? ParmsLotGenExp,
		Guid? SessionID,
		string Infobar) Pojob3PPreSp(string TJob,
		int? TSuffix,
		int? TOper,
		int? TNextOper,
		int? TIsLastOper,
		int? ParmsLotGenExp,
		Guid? SessionID,
		string Infobar);
	}
}

