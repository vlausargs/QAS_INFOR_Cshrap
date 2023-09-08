//PROJECT NAME: Data
//CLASS NAME: IFbomV2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFbomV2
	{
		(int? ReturnCode,
			string XFeatureList,
			string Config,
			string Infobar) FbomV2Sp(
			Guid? ItemRowPointer,
			string XFeatureList,
			string Config,
			string Infobar);
	}
}

