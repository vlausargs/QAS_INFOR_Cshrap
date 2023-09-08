//PROJECT NAME: Production
//CLASS NAME: IRSQC_SerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SerialSave
	{
		int? RSQC_SerialSaveSp(string SerNum,
		string NewStat,
		string Item,
		int? RcvrNum);
	}
}

