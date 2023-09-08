//PROJECT NAME: Data
//CLASS NAME: ICoUpdateCommSlsman.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoUpdateCommSlsman
	{
		(int? ReturnCode,
			string Infobar) CoUpdateCommSlsmanSp(
			string CoNum,
			string Slsman,
			string Infobar);
	}
}

