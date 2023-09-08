//PROJECT NAME: Material
//CLASS NAME: IRenamePlant.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRenamePlant
	{
		(int? ReturnCode, string Infobar) RenamePlantSp(string OldPlantName,
		string NewPlantName,
		string Infobar);
	}
}

