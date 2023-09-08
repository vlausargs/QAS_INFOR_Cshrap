//PROJECT NAME: Data
//CLASS NAME: IDelFeatqty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDelFeatqty
	{
		(int? ReturnCode,
			string Infobar) DelFeatqtySp(
			string CoNum,
			int? CoLine,
			string Infobar);
	}
}

