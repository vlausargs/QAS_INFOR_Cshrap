//PROJECT NAME: Material
//CLASS NAME: ICheckPhytagsExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckPhytagsExist
	{
		(int? ReturnCode, string Infobar) CheckPhytagsExistSp(string Whse,
		string Infobar);
	}
}

