//PROJECT NAME: Material
//CLASS NAME: IGetTransitItemLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetTransitItemLoc
	{
		(int? ReturnCode, string TrnLoc,
		string Infobar) GetTransitItemLocSp(string Item,
		string Whse,
		int? BlankOk,
		string TrnLoc,
		string Infobar,
		string Site = null);
	}
}

