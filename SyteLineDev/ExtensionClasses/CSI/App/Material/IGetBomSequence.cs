//PROJECT NAME: Material
//CLASS NAME: IGetBomSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetBomSequence
	{
		(int? ReturnCode, int? BomSequence,
		int? Sequence,
		int? IsExistRef,
		int? AltGroupRank,
		string Infobar) GetBomSequenceSp(string Job,
		int? Suffix,
		int? OperNum,
		int? AltGroup,
		string Type,
		string ItmItem,
		int? BomSequence = null,
		int? Sequence = null,
		int? IsExistRef = null,
		int? AltGroupRank = null,
		string Infobar = null);
	}
}

