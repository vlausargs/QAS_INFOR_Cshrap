//PROJECT NAME: Production
//CLASS NAME: IGetIndentedJobStructure.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetIndentedJobStructure
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) GetIndentedJobStructureSp(string JobType,
		string Job,
		int? Suffix,
		string Infobar);
	}
}

