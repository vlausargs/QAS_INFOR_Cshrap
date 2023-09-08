//PROJECT NAME: Data
//CLASS NAME: ILibClrXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILibClrXref
	{
		int? LibClrXrefSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRel,
			string ParNum,
			int? ParLine,
			int? ParRel);
	}
}

