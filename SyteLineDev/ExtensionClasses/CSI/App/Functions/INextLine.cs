//PROJECT NAME: Data
//CLASS NAME: INextLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextLine
	{
		(int? ReturnCode,
			int? CoLine,
			string Infobar) NextLineSp(
			string CoNum,
			int? CoRel,
			int? CoLine,
			string Infobar);
	}
}

