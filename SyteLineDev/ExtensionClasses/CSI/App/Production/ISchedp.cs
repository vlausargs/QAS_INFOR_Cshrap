//PROJECT NAME: Production
//CLASS NAME: ISchedp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISchedp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SchedpSp(string pType,
		string pStatus,
		string pUseCr,
		string pStartingJobNum,
		string pEndingJobNum,
		int? pStartingSuffixNum,
		int? pEndingSuffixNum);
	}
}

