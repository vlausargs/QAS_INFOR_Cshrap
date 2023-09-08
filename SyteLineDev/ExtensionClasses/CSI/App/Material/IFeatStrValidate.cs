//PROJECT NAME: Material
//CLASS NAME: IFeatStrValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IFeatStrValidate
	{
		(int? ReturnCode, string Infobar) FeatStrValidateSp(string FeatStr,
		string Item,
		string Infobar,
		string Site = null);
	}
}

