//PROJECT NAME: Data
//CLASS NAME: ICopyJItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyJItem
	{
		(int? ReturnCode,
			string Infobar) CopyJItemSp(
			string FromJob,
			int? FromSuffix,
			string ToJob,
			int? ToSuffix,
			string Infobar);
	}
}

