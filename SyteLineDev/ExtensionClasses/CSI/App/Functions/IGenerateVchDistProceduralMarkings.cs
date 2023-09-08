//PROJECT NAME: Data
//CLASS NAME: IGenerateVchDistProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenerateVchDistProceduralMarkings
	{
		(int? ReturnCode,
			string Infobar) GenerateVchDistProceduralMarkingsSp(
			int? VchNum,
			int? VchSeq,
			string Infobar = null);
	}
}

