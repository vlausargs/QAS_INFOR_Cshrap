//PROJECT NAME: Production
//CLASS NAME: IPmfGetCollectionNameBase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetCollectionNameBase
	{
		string PmfGetCollectionNameBaseFn(
			string Tablename);
	}
}

