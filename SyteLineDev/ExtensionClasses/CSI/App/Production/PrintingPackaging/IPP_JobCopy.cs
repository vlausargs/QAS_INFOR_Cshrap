//PROJECT NAME: Production
//CLASS NAME: IPP_JobCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_JobCopy
	{
		(int? ReturnCode,
			string ToJob,
			int? ToSuffix,
			string Infobar) PP_JobCopySp(
			string FromType,
			string FromJob,
			int? FromSuffix,
			string ToType,
			string ToJob,
			int? ToSuffix,
			string Infobar);
	}
}

