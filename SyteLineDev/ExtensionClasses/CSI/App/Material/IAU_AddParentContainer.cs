//PROJECT NAME: Material
//CLASS NAME: IAU_AddParentContainer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IAU_AddParentContainer
	{
		(int? ReturnCode, string Infobar) AU_AddParentContainerSp(string ContainerNum,
		string ParentContainerNum,
		string Infobar);
	}
}

