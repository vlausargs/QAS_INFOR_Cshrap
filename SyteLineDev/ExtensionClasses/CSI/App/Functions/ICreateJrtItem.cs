//PROJECT NAME: Data
//CLASS NAME: ICreateJrtItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateJrtItem
	{
		(int? ReturnCode,
			string Infobar) CreateJrtItemSp(
			string PJob,
			int? PSuffix,
			string PItem,
			string Infobar);
	}
}

