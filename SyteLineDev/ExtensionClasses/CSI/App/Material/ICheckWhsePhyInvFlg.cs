//PROJECT NAME: Material
//CLASS NAME: ICheckWhsePhyInvFlg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckWhsePhyInvFlg
	{
		(int? ReturnCode, int? WhsePhyInvFlg,
		string Infobar) CheckWhsePhyInvFlgSp(string Whse,
		string Site,
		int? WhsePhyInvFlg = 0,
		string Infobar = null);
	}
}

