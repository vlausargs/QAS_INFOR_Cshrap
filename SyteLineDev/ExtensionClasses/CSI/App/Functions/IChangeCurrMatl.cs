//PROJECT NAME: Data
//CLASS NAME: IChangeCurrMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeCurrMatl
	{
		(int? ReturnCode,
			string Description,
			string MatlType,
			string UM,
			int? Backflush,
			string RefType,
			string Infobar) ChangeCurrMatlSp(
			string Item,
			string PreqJob,
			string Description,
			string MatlType,
			string UM,
			int? Backflush,
			string RefType,
			string Infobar);
	}
}

