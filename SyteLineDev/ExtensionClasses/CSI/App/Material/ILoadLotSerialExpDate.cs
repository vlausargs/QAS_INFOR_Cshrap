//PROJECT NAME: Material
//CLASS NAME: ILoadLotSerialExpDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ILoadLotSerialExpDate
	{
		(int? ReturnCode,
		DateTime? ExpirationDate) LoadLotSerialExpDateSp(
			string Item,
			DateTime? ManufacturedDate = null,
			DateTime? ExpirationDate = null);
	}
}

