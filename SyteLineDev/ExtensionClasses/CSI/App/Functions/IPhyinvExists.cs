//PROJECT NAME: Data
//CLASS NAME: IPhyinvExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPhyinvExists
	{
		int? PhyinvExistsFn(
			string Whse);
	}
}

