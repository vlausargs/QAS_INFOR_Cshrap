//PROJECT NAME: Data
//CLASS NAME: IShipCodeAllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IShipCodeAllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) ShipCodeAllValidSp(
			string SiteRef,
			string ShipCode,
			string Description,
			string Infobar);
	}
}

