//PROJECT NAME: Material
//CLASS NAME: IMO_UpdateAlternateDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMO_UpdateAlternateDesc
	{
		int? MO_UpdateAlternateDescSp(string Job,
		int? JobSuffix,
		string AlternateDescription = null);
	}
}

