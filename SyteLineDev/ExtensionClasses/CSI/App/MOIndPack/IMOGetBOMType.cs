//PROJECT NAME: MOIndPack
//CLASS NAME: IMOGetBOMType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMOGetBOMType
	{
		string MOGetBOMTypeFn(
			string CoNum);
	}
}

