//PROJECT NAME: Material
//CLASS NAME: IMrpWbXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbXref
	{
		(int? ReturnCode,
			string Infobar) MrpWbXrefSp(
			string OrdType,
			string OrdNum,
			int? OrdLineSuf,
			int? OrdRelease,
			int? OrdSeq,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar);
	}
}

