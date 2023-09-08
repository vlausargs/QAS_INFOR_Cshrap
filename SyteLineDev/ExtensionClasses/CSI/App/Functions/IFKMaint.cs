//PROJECT NAME: Data
//CLASS NAME: IFKMaint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFKMaint
	{
		int? FKMaintSp(
			int? Drop = 1,
			int? Create = 1);
	}
}

