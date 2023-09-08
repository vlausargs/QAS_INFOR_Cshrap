//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetMaxSerialNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetMaxSerialNum
	{
		(int? ReturnCode, string SerNum) RSQC_GetMaxSerialNumSp(string SerNumPrefix,
		string Site = null,
		string SerNum = null);
	}
}

