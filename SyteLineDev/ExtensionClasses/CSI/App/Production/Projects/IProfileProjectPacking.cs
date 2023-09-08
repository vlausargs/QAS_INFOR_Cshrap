//PROJECT NAME: Production
//CLASS NAME: IProfileProjectPacking.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProfileProjectPacking
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileProjectPackingSp(string CustNum,
		int? CustSeq);
	}
}

