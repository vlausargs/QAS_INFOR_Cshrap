//PROJECT NAME: Data
//CLASS NAME: IJobValMix0.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobValMix0
	{
		(int? ReturnCode,
			string Infobar) JobValMix0Sp(
			string PProdMix,
			string Infobar);
	}
}

