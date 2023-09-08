//PROJECT NAME: Data
//CLASS NAME: IDepPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDepPost
	{
		int? DepPostSp(
			DateTime? pCreateDate,
			int? pCreateSeq,
			DateTime? pSTransDate,
			DateTime? pETransDate);
	}
}

