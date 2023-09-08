//PROJECT NAME: Material
//CLASS NAME: IGetIndentedCurrentJobStructure.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetIndentedCurrentJobStructure
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) GetIndentedCurrentJobStructureSp(string JobType,
		string Job,
		int? Suffix,
		string Infobar);
	}
}

