//PROJECT NAME: CSIProjects
//CLASS NAME: ProjWIPRelief.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjWIPRelief
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProjWIPReliefSp(string Process,
		string FromProjNum,
		string ToProjNum,
		int? FromTaskNum,
		int? ToTaskNum,
		DateTime? WipStartDate,
		DateTime? PostDate,
		string PrintLevel,
		string PostLevel,
		byte? WipAdjFlag = (byte)0,
		decimal? WipAdjTotLabrAdj = 0,
		decimal? WipAdjTotMatlAdj = 0,
		decimal? WipAdjTotOtherAdj = 0,
		decimal? WipAdjTotOvrhdAdj = 0,
		decimal? WipAdjTotGaAdj = 0);
	}
	
	public class ProjWIPRelief : IProjWIPRelief
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProjWIPRelief(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProjWIPReliefSp(string Process,
		string FromProjNum,
		string ToProjNum,
		int? FromTaskNum,
		int? ToTaskNum,
		DateTime? WipStartDate,
		DateTime? PostDate,
		string PrintLevel,
		string PostLevel,
		byte? WipAdjFlag = (byte)0,
		decimal? WipAdjTotLabrAdj = 0,
		decimal? WipAdjTotMatlAdj = 0,
		decimal? WipAdjTotOtherAdj = 0,
		decimal? WipAdjTotOvrhdAdj = 0,
		decimal? WipAdjTotGaAdj = 0)
		{
			StringType _Process = Process;
			HighLowCharType _FromProjNum = FromProjNum;
			HighLowCharType _ToProjNum = ToProjNum;
			GenericIntType _FromTaskNum = FromTaskNum;
			GenericIntType _ToTaskNum = ToTaskNum;
			DateType _WipStartDate = WipStartDate;
			DateType _PostDate = PostDate;
			StringType _PrintLevel = PrintLevel;
			StringType _PostLevel = PostLevel;
			ListYesNoType _WipAdjFlag = WipAdjFlag;
			AmtTotType _WipAdjTotLabrAdj = WipAdjTotLabrAdj;
			AmtTotType _WipAdjTotMatlAdj = WipAdjTotMatlAdj;
			AmtTotType _WipAdjTotOtherAdj = WipAdjTotOtherAdj;
			AmtTotType _WipAdjTotOvrhdAdj = WipAdjTotOvrhdAdj;
			AmtTotType _WipAdjTotGaAdj = WipAdjTotGaAdj;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjWIPReliefSp";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTaskNum", _FromTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTaskNum", _ToTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipStartDate", _WipStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLevel", _PrintLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostLevel", _PostLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAdjFlag", _WipAdjFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAdjTotLabrAdj", _WipAdjTotLabrAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAdjTotMatlAdj", _WipAdjTotMatlAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAdjTotOtherAdj", _WipAdjTotOtherAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAdjTotOvrhdAdj", _WipAdjTotOvrhdAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAdjTotGaAdj", _WipAdjTotGaAdj, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
