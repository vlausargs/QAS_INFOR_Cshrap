//PROJECT NAME: Data
//CLASS NAME: IFeatStrValidStd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFeatStrValidStd
	{
		(int? ReturnCode,
			string Infobar) FeatStrValidStdSp(
			string FeatStr,
			string Item,
			string Infobar,
			string Site);
	}
}

