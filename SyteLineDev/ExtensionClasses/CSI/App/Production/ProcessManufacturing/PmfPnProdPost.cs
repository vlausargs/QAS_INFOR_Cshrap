//PROJECT NAME: Production
//CLASS NAME: PmfPnProdPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnProdPost
	{
		(int? ReturnCode, string InfoBar, string Lot, string Loc, decimal? Qty, string Um, string ContainerNum, int? TransNum) PmfPnProdPostSp(string InfoBar = null,
		                                                                                                                                       Guid? PnRp = null,
		                                                                                                                                       Guid? JobRp = null,
		                                                                                                                                       DateTime? TranDate = null,
		                                                                                                                                       string Lot = null,
		                                                                                                                                       string Loc = null,
		                                                                                                                                       decimal? Qty = null,
		                                                                                                                                       string Um = null,
		                                                                                                                                       string ContainerNum = null,
		                                                                                                                                       string DocNum = null,
		                                                                                                                                       string EmpNum = null,
		                                                                                                                                       int? OpComplete = null,
		                                                                                                                                       int? TransNum = null);
	}
	
	public class PmfPnProdPost : IPmfPnProdPost
	{
		readonly IApplicationDB appDB;
		
		public PmfPnProdPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, string Lot, string Loc, decimal? Qty, string Um, string ContainerNum, int? TransNum) PmfPnProdPostSp(string InfoBar = null,
		                                                                                                                                              Guid? PnRp = null,
		                                                                                                                                              Guid? JobRp = null,
		                                                                                                                                              DateTime? TranDate = null,
		                                                                                                                                              string Lot = null,
		                                                                                                                                              string Loc = null,
		                                                                                                                                              decimal? Qty = null,
		                                                                                                                                              string Um = null,
		                                                                                                                                              string ContainerNum = null,
		                                                                                                                                              string DocNum = null,
		                                                                                                                                              string EmpNum = null,
		                                                                                                                                              int? OpComplete = null,
		                                                                                                                                              int? TransNum = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			RowPointerType _JobRp = JobRp;
			DateTimeType _TranDate = TranDate;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			ProcessMfgQuantityType _Qty = Qty;
			UMType _Um = Um;
			ContainerType _ContainerNum = ContainerNum;
			DocumentNumType _DocNum = DocNum;
			EmpNumType _EmpNum = EmpNum;
			IntType _OpComplete = OpComplete;
			IntType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnProdPostSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranDate", _TranDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Um", _Um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocNum", _DocNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpComplete", _OpComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				Lot = _Lot;
				Loc = _Loc;
				Qty = _Qty;
				Um = _Um;
				ContainerNum = _ContainerNum;
				TransNum = _TransNum;
				
				return (Severity, InfoBar, Lot, Loc, Qty, Um, ContainerNum, TransNum);
			}
		}
	}
}
