//PROJECT NAME: Data
//CLASS NAME: IGenerateVchHdrProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenerateVchHdrProceduralMarkings
	{
		(int? ReturnCode,
			string Infobar) GenerateVchHdrProceduralMarkingsSp(
			int? VchNum,
			int? VchSeq,
			string VendNum,
			string TaxCode,
			string Infobar = null);
	}
}

