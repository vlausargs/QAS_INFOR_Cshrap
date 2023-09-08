//PROJECT NAME: Production
//CLASS NAME: IPmfGetCollectionName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetCollectionName
	{
		string PmfGetCollectionNameFn(
			string Tablename);
	}
}

