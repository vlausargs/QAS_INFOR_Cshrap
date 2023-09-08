//PROJECT NAME: Production
//CLASS NAME: PP_UpdateOperTypeCodeMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_UpdateOperTypeCodeMaterial : IPP_UpdateOperTypeCodeMaterial
	{
		readonly IApplicationDB appDB;
		
		
		public PP_UpdateOperTypeCodeMaterial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PP_UpdateOperTypeCodeMaterialSp(string OperType,
		string OperTypeCode,
		string Item,
		decimal? StdConsumptionRate,
		int? NumberOfDimensions,
		int? DivideByUp,
		int? UseForMatchingCriteria)
		{
			PP_OperationType2Type _OperType = OperType;
			PP_OperationTypeCodeType _OperTypeCode = OperTypeCode;
			ItemType _Item = Item;
			PP_StdConsumptionRateType _StdConsumptionRate = StdConsumptionRate;
			PP_NumberOfDimensionsType _NumberOfDimensions = NumberOfDimensions;
			ListYesNoType _DivideByUp = DivideByUp;
			ListYesNoType _UseForMatchingCriteria = UseForMatchingCriteria;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_UpdateOperTypeCodeMaterialSp";
				
				appDB.AddCommandParameter(cmd, "OperType", _OperType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperTypeCode", _OperTypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StdConsumptionRate", _StdConsumptionRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumberOfDimensions", _NumberOfDimensions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DivideByUp", _DivideByUp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseForMatchingCriteria", _UseForMatchingCriteria, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
