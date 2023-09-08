//PROJECT NAME: Data
//CLASS NAME: ICostingAtItemWarehouse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICostingAtItemWarehouse
	{
		(int? ReturnCode,
			string Infobar) CostingAtItemWarehouseSp(
			string Infobar);
	}
}

