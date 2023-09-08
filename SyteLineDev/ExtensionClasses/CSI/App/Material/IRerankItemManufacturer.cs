//PROJECT NAME: Material
//CLASS NAME: IRerankItemManufacturer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRerankItemManufacturer
	{
		(int? ReturnCode, string Infobar) RerankItemManufacturerSp(string PItem,
		string Infobar);
	}
}

