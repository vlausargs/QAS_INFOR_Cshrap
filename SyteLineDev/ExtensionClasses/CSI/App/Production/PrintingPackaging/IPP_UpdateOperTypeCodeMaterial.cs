//PROJECT NAME: Production
//CLASS NAME: IPP_UpdateOperTypeCodeMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_UpdateOperTypeCodeMaterial
	{
		int? PP_UpdateOperTypeCodeMaterialSp(string OperType,
		string OperTypeCode,
		string Item,
		decimal? StdConsumptionRate,
		int? NumberOfDimensions,
		int? DivideByUp,
		int? UseForMatchingCriteria);
	}
}

