//PROJECT NAME: Data
//CLASS NAME: ISSSHas.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSHas
	{
		(int? ReturnCode,
			int? Enabled,
			string Infobar) SSSHasSp(
			string FeatureType = null,
			int? Enabled = 0,
			string Infobar = null);
	}
}

