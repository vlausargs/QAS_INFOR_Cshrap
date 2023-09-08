//PROJECT NAME: Production
//CLASS NAME: PP_SavePrintingJobRouteData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_SavePrintingJobRouteData : IPP_SavePrintingJobRouteData
	{
		readonly IApplicationDB appDB;
		
		
		public PP_SavePrintingJobRouteData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PP_SavePrintingJobRouteDataSp(string Job,
		int? Suffix,
		int? OperNum,
		string JobType,
		string OperationType,
		string OperationTypeCode,
		decimal? CartonLength = 0,
		decimal? CartonWidth = 0,
		decimal? length = 0,
		int? NumOfHoles = 0,
		int? ColorsFront_C = 0,
		int? ColorsFront_M = 0,
		int? ColorsFront_Y = 0,
		int? ColorsFront_K = 0,
		int? ColorsBack_C = 0,
		int? ColorsBack_M = 0,
		int? ColorsBack_Y = 0,
		int? ColorsBack_K = 0,
		int? Out = 0,
		int? NumOfWords = 0,
		decimal? SheetCount = 0,
		int? Up = 0,
		int? NumOfSpclColors = 0,
		decimal? Width = 0,
		decimal? OperDifficultFactor = 0,
		int? NumOfManualHandleSteps = 0,
		int? NumOfSidesToPrint = 0,
		int? NumberOfAddlColors = 0,
		decimal? JobQtyPerSheet = 0,
		decimal? PaperConsumptionQty = 0,
		decimal? OperRating1 = 0,
		decimal? OperRating2 = 0,
		decimal? OperRating3 = 0,
		decimal? OperRating4 = 0,
		decimal? OperRating5 = 0,
		decimal? OperRating6 = 0,
		decimal? OperRating7 = 0,
		decimal? OperRating8 = 0,
		decimal? OperRating9 = 0,
		decimal? OperRating10 = 0,
		decimal? OperRating11 = 0,
		decimal? OperRating12 = 0,
		decimal? OperRating13 = 0,
		decimal? OperRating14 = 0,
		decimal? OperRating15 = 0,
		decimal? OperRating16 = 0,
		decimal? OperRating17 = 0,
		decimal? OperRating18 = 0,
		decimal? OperRating19 = 0,
		decimal? OperRating20 = 0,
		int? SetupRunFinishSelected1 = 0,
		int? SetupRunFinishSelected2 = 0,
		int? SetupRunFinishSelected3 = 0,
		int? SetupRunFinishSelected4 = 0,
		int? SetupRunFinishSelected5 = 0,
		int? SetupRunFinishSelected6 = 0,
		int? SetupRunFinishSelected7 = 0,
		int? SetupRunFinishSelected8 = 0,
		int? SetupRunFinishSelected9 = 0,
		int? SetupRunFinishSelected10 = 0,
		int? SetupRunFinishSelected11 = 0,
		int? SetupRunFinishSelected12 = 0,
		int? SetupRunFinishSelected13 = 0,
		int? SetupRunFinishSelected14 = 0,
		int? SetupRunFinishSelected15 = 0,
		int? SetupRunFinishSelected16 = 0,
		int? SetupRunFinishSelected17 = 0,
		int? SetupRunFinishSelected18 = 0,
		int? SetupRunFinishSelected19 = 0,
		int? SetupRunFinishSelected20 = 0,
		string Infobar = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobTypeType _JobType = JobType;
			PP_OperationType2Type _OperationType = OperationType;
			PP_OperationTypeCodeType _OperationTypeCode = OperationTypeCode;
			PP_CartonDimensionType _CartonLength = CartonLength;
			PP_CartonDimensionType _CartonWidth = CartonWidth;
			PP_CartonDimensionType _length = length;
			PP_NumberOfHolesType _NumOfHoles = NumOfHoles;
			ListYesNoType _ColorsFront_C = ColorsFront_C;
			ListYesNoType _ColorsFront_M = ColorsFront_M;
			ListYesNoType _ColorsFront_Y = ColorsFront_Y;
			ListYesNoType _ColorsFront_K = ColorsFront_K;
			ListYesNoType _ColorsBack_C = ColorsBack_C;
			ListYesNoType _ColorsBack_M = ColorsBack_M;
			ListYesNoType _ColorsBack_Y = ColorsBack_Y;
			ListYesNoType _ColorsBack_K = ColorsBack_K;
			PP_OutNumberType _Out = Out;
			PP_NumberOfWordsType _NumOfWords = NumOfWords;
			PP_SheetCountType _SheetCount = SheetCount;
			PP_UpNumberType _Up = Up;
			PP_NumberOfColorsType _NumOfSpclColors = NumOfSpclColors;
			PP_OperationDimensionType _Width = Width;
			PP_FactorType _OperDifficultFactor = OperDifficultFactor;
			PP_NumberOfManualHandlingStepsType _NumOfManualHandleSteps = NumOfManualHandleSteps;
			PP_NumberOfSidesToPrintType _NumOfSidesToPrint = NumOfSidesToPrint;
			PP_NumberOfColorsType _NumberOfAddlColors = NumberOfAddlColors;
			QtyUnitType _JobQtyPerSheet = JobQtyPerSheet;
			QtyUnitType _PaperConsumptionQty = PaperConsumptionQty;
			PP_FactorType _OperRating1 = OperRating1;
			PP_FactorType _OperRating2 = OperRating2;
			PP_FactorType _OperRating3 = OperRating3;
			PP_FactorType _OperRating4 = OperRating4;
			PP_FactorType _OperRating5 = OperRating5;
			PP_FactorType _OperRating6 = OperRating6;
			PP_FactorType _OperRating7 = OperRating7;
			PP_FactorType _OperRating8 = OperRating8;
			PP_FactorType _OperRating9 = OperRating9;
			PP_FactorType _OperRating10 = OperRating10;
			PP_FactorType _OperRating11 = OperRating11;
			PP_FactorType _OperRating12 = OperRating12;
			PP_FactorType _OperRating13 = OperRating13;
			PP_FactorType _OperRating14 = OperRating14;
			PP_FactorType _OperRating15 = OperRating15;
			PP_FactorType _OperRating16 = OperRating16;
			PP_FactorType _OperRating17 = OperRating17;
			PP_FactorType _OperRating18 = OperRating18;
			PP_FactorType _OperRating19 = OperRating19;
			PP_FactorType _OperRating20 = OperRating20;
			ListYesNoType _SetupRunFinishSelected1 = SetupRunFinishSelected1;
			ListYesNoType _SetupRunFinishSelected2 = SetupRunFinishSelected2;
			ListYesNoType _SetupRunFinishSelected3 = SetupRunFinishSelected3;
			ListYesNoType _SetupRunFinishSelected4 = SetupRunFinishSelected4;
			ListYesNoType _SetupRunFinishSelected5 = SetupRunFinishSelected5;
			ListYesNoType _SetupRunFinishSelected6 = SetupRunFinishSelected6;
			ListYesNoType _SetupRunFinishSelected7 = SetupRunFinishSelected7;
			ListYesNoType _SetupRunFinishSelected8 = SetupRunFinishSelected8;
			ListYesNoType _SetupRunFinishSelected9 = SetupRunFinishSelected9;
			ListYesNoType _SetupRunFinishSelected10 = SetupRunFinishSelected10;
			ListYesNoType _SetupRunFinishSelected11 = SetupRunFinishSelected11;
			ListYesNoType _SetupRunFinishSelected12 = SetupRunFinishSelected12;
			ListYesNoType _SetupRunFinishSelected13 = SetupRunFinishSelected13;
			ListYesNoType _SetupRunFinishSelected14 = SetupRunFinishSelected14;
			ListYesNoType _SetupRunFinishSelected15 = SetupRunFinishSelected15;
			ListYesNoType _SetupRunFinishSelected16 = SetupRunFinishSelected16;
			ListYesNoType _SetupRunFinishSelected17 = SetupRunFinishSelected17;
			ListYesNoType _SetupRunFinishSelected18 = SetupRunFinishSelected18;
			ListYesNoType _SetupRunFinishSelected19 = SetupRunFinishSelected19;
			ListYesNoType _SetupRunFinishSelected20 = SetupRunFinishSelected20;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_SavePrintingJobRouteDataSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationType", _OperationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationTypeCode", _OperationTypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CartonLength", _CartonLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CartonWidth", _CartonWidth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "length", _length, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumOfHoles", _NumOfHoles, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsFront_C", _ColorsFront_C, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsFront_M", _ColorsFront_M, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsFront_Y", _ColorsFront_Y, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsFront_K", _ColorsFront_K, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsBack_C", _ColorsBack_C, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsBack_M", _ColorsBack_M, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsBack_Y", _ColorsBack_Y, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorsBack_K", _ColorsBack_K, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Out", _Out, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumOfWords", _NumOfWords, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SheetCount", _SheetCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Up", _Up, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumOfSpclColors", _NumOfSpclColors, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Width", _Width, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperDifficultFactor", _OperDifficultFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumOfManualHandleSteps", _NumOfManualHandleSteps, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumOfSidesToPrint", _NumOfSidesToPrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumberOfAddlColors", _NumberOfAddlColors, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobQtyPerSheet", _JobQtyPerSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaperConsumptionQty", _PaperConsumptionQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating1", _OperRating1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating2", _OperRating2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating3", _OperRating3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating4", _OperRating4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating5", _OperRating5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating6", _OperRating6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating7", _OperRating7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating8", _OperRating8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating9", _OperRating9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating10", _OperRating10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating11", _OperRating11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating12", _OperRating12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating13", _OperRating13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating14", _OperRating14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating15", _OperRating15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating16", _OperRating16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating17", _OperRating17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating18", _OperRating18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating19", _OperRating19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperRating20", _OperRating20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected1", _SetupRunFinishSelected1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected2", _SetupRunFinishSelected2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected3", _SetupRunFinishSelected3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected4", _SetupRunFinishSelected4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected5", _SetupRunFinishSelected5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected6", _SetupRunFinishSelected6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected7", _SetupRunFinishSelected7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected8", _SetupRunFinishSelected8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected9", _SetupRunFinishSelected9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected10", _SetupRunFinishSelected10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected11", _SetupRunFinishSelected11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected12", _SetupRunFinishSelected12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected13", _SetupRunFinishSelected13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected14", _SetupRunFinishSelected14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected15", _SetupRunFinishSelected15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected16", _SetupRunFinishSelected16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected17", _SetupRunFinishSelected17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected18", _SetupRunFinishSelected18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected19", _SetupRunFinishSelected19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupRunFinishSelected20", _SetupRunFinishSelected20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
