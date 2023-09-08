//PROJECT NAME: Data
//CLASS NAME: ICxtCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtCoitem
	{
		(int? ReturnCode,
			string Infobar) CxtCoitemSp(
			string CoNum,
			int? CoLine,
			string Infobar);
	}
}

