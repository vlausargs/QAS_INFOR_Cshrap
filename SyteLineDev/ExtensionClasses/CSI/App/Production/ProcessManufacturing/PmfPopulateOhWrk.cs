//PROJECT NAME: Production
//CLASS NAME: PmfPopulateOhWrk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPopulateOhWrk
	{
		(int? ReturnCode, string InfoBar) PmfPopulateOhWrkSp(string InfoBar = null,
		                                                     int? RowLimit = 100,
		                                                     string Item = null,
		                                                     string Whse = null,
		                                                     string Function = null,
		                                                     int? ExpiredFlag = 0,
		                                                     int? LockedForPickFlag = 0,
		                                                     int? ExcludeOtherPnInv = 1,
		                                                     Guid? PnRp = null,
		                                                     Guid? JobRp = null,
		                                                     int? AddNegInv = 0,
		                                                     decimal? QtyReq = null,
		                                                     string QtyUm = null,
		                                                     string Ref = null,
		                                                     Guid? SessionId = null);
	}
	
	public class PmfPopulateOhWrk : IPmfPopulateOhWrk
	{
		readonly IApplicationDB appDB;
		
		public PmfPopulateOhWrk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPopulateOhWrkSp(string InfoBar = null,
		                                                            int? RowLimit = 100,
		                                                            string Item = null,
		                                                            string Whse = null,
		                                                            string Function = null,
		                                                            int? ExpiredFlag = 0,
		                                                            int? LockedForPickFlag = 0,
		                                                            int? ExcludeOtherPnInv = 1,
		                                                            Guid? PnRp = null,
		                                                            Guid? JobRp = null,
		                                                            int? AddNegInv = 0,
		                                                            decimal? QtyReq = null,
		                                                            string QtyUm = null,
		                                                            string Ref = null,
		                                                            Guid? SessionId = null)
		{
			InfobarType _InfoBar = InfoBar;
			IntType _RowLimit = RowLimit;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			StringType _Function = Function;
			IntType _ExpiredFlag = ExpiredFlag;
			IntType _LockedForPickFlag = LockedForPickFlag;
			IntType _ExcludeOtherPnInv = ExcludeOtherPnInv;
			RowPointerType _PnRp = PnRp;
			RowPointerType _JobRp = JobRp;
			IntType _AddNegInv = AddNegInv;
			ProcessMfgQuantityType _QtyReq = QtyReq;
			UMType _QtyUm = QtyUm;
			DescriptionType _Ref = Ref;
			GuidType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPopulateOhWrkSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowLimit", _RowLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Function", _Function, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpiredFlag", _ExpiredFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockedForPickFlag", _LockedForPickFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeOtherPnInv", _ExcludeOtherPnInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddNegInv", _AddNegInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyUm", _QtyUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref", _Ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
