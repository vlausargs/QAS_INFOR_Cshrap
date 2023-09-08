//PROJECT NAME: Codes
//CLASS NAME: IEuroPart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IEuroPart
	{
		(int? ReturnCode, int? PPartOfEuro) EuroPartSp(string PCurrCode,
		int? PPartOfEuro,
		string Site = null);
	}
}

