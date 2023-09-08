//PROJECT NAME: Data
//CLASS NAME: INextRelease.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextRelease
	{
		(int? ReturnCode,
			int? CoRel,
			string Infobar) NextReleaseSp(
			string CoNum,
			int? CoLine,
			int? CoRel,
			string Infobar);
	}
}

