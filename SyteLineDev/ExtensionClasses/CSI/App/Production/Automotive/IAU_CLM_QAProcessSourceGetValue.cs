//PROJECT NAME: Production
//CLASS NAME: IAU_CLM_QAProcessSourceGetValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Automotive
{
	public interface IAU_CLM_QAProcessSourceGetValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_CLM_QAProcessSourceGetValueSp(string RefType = null,
		string RefNum = null,
		int? RefLineSuf = null,
		int? SourceLevel = 1);
	}
}

