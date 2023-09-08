//PROJECT NAME: Data
//CLASS NAME: INextSsdTransNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextSsdTransNum
	{
		(int? ReturnCode,
			decimal? NextTransNum,
			string Infobar) NextSsdTransNumSp(
			decimal? NextTransNum,
			string Infobar);
	}
}

