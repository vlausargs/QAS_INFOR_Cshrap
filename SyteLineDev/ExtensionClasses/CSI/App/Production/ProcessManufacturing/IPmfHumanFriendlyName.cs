//PROJECT NAME: Production
//CLASS NAME: IPmfHumanFriendlyName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfHumanFriendlyName
	{
		string PmfHumanFriendlyNameFn(
			string Identifier);
	}
}

