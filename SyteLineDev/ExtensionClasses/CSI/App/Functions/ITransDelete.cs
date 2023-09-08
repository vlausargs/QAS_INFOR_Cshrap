//PROJECT NAME: Data
//CLASS NAME: ITransDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransDelete
	{
		(int? ReturnCode,
			string Infobar) TransDeleteSp(
			string PTrnNum,
			string FromSite,
			string ToSite,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null);
	}
}

