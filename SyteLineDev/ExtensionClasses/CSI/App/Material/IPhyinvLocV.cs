//PROJECT NAME: Material
//CLASS NAME: IPhyinvLocV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvLocV
	{
		(int? ReturnCode, string Infobar) PhyinvLocVSp(string Whse,
		string Item,
		string Loc,
		string Infobar);
	}
}

