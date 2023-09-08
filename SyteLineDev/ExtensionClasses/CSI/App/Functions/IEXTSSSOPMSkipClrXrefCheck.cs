//PROJECT NAME: Data
//CLASS NAME: IEXTSSSOPMSkipClrXrefCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSOPMSkipClrXrefCheck
	{
		(int? ReturnCode,
			int? SkipClrXref,
			string Infobar) EXTSSSOPMSkipClrXrefCheckSp(
			int? SkipClrXref,
			string Infobar);
	}
}

