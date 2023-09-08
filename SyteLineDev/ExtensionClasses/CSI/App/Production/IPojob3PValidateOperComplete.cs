//PROJECT NAME: Production
//CLASS NAME: IPojob3PValidateOperComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPojob3PValidateOperComplete
	{
		(int? ReturnCode, string Infobar) Pojob3PValidateOperCompleteSp(string TJob,
		int? TSuffix,
		int? TOper,
		int? TOperComplete,
		string Infobar);
	}
}

