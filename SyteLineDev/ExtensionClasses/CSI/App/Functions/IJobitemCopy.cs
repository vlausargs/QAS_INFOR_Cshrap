//PROJECT NAME: Data
//CLASS NAME: IJobitemCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobitemCopy
	{
		(int? ReturnCode,
			string Infobar) JobitemCopySp(
			string FromJob,
			int? FromSuffix,
			string ToJob,
			int? ToSuffix,
			string Infobar);
	}
}

