//PROJECT NAME: Material
//CLASS NAME: IPhytagsCountMethod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhytagsCountMethod
	{
		(int? ReturnCode, string CountMethod,
		string Infobar) PhytagsCountMethodSp(string Whse,
		string CountMethod,
		string Infobar);
	}
}

