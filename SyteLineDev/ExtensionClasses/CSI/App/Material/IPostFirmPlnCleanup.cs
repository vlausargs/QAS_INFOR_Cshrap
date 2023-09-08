//PROJECT NAME: Material
//CLASS NAME: IPostFirmPlnCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPostFirmPlnCleanup
	{
		(int? ReturnCode, string Infobar) PostFirmPlnCleanupSp(string OldRefType,
		string OldRefNum,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? DeleteDepDemand = 0,
		string Infobar = null,
		int? OldRefLineSuf = null);
	}
}

