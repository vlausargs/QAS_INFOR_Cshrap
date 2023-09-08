//PROJECT NAME: Logistics
//CLASS NAME: IEstimateLinesCanEnableUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesCanEnableUM
	{
		(int? ReturnCode, int? PEnableUM) EstimateLinesCanEnableUMSp(string PItem,
		int? PEnableUM);
	}
}

