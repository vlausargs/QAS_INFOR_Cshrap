//PROJECT NAME: Data
//CLASS NAME: IFeatStrValidString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFeatStrValidString
	{
		(int? ReturnCode,
			string Infobar) FeatStrValidStringSp(
			string FeatStr,
			string Item,
			string Infobar,
			string Site);
	}
}

