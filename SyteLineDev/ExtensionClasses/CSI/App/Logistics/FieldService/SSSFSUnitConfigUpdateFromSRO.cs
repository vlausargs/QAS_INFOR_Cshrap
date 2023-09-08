//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigUpdateFromSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigUpdateFromSRO
	{
		(int? ReturnCode, decimal? MatlQtyCounter, int? CfgCounter, string SuccessMsg, string Infobar) SSSFSUnitConfigUpdateFromSROSp(Guid? SroTransRowPointer,
		                                                                                                                              int? InCompId,
		                                                                                                                              string RemoveReason,
		                                                                                                                              decimal? MatlQtyCounter,
		                                                                                                                              int? CfgCounter,
		                                                                                                                              string SuccessMsg,
		                                                                                                                              string Infobar);
	}
	
	public class SSSFSUnitConfigUpdateFromSRO : ISSSFSUnitConfigUpdateFromSRO
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitConfigUpdateFromSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? MatlQtyCounter, int? CfgCounter, string SuccessMsg, string Infobar) SSSFSUnitConfigUpdateFromSROSp(Guid? SroTransRowPointer,
		                                                                                                                                     int? InCompId,
		                                                                                                                                     string RemoveReason,
		                                                                                                                                     decimal? MatlQtyCounter,
		                                                                                                                                     int? CfgCounter,
		                                                                                                                                     string SuccessMsg,
		                                                                                                                                     string Infobar)
		{
			RowPointerType _SroTransRowPointer = SroTransRowPointer;
			FSCompIdType _InCompId = InCompId;
			FSReasonType _RemoveReason = RemoveReason;
			QtyUnitType _MatlQtyCounter = MatlQtyCounter;
			IntType _CfgCounter = CfgCounter;
			Infobar _SuccessMsg = SuccessMsg;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigUpdateFromSROSp";
				
				appDB.AddCommandParameter(cmd, "SroTransRowPointer", _SroTransRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCompId", _InCompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoveReason", _RemoveReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQtyCounter", _MatlQtyCounter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CfgCounter", _CfgCounter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuccessMsg", _SuccessMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlQtyCounter = _MatlQtyCounter;
				CfgCounter = _CfgCounter;
				SuccessMsg = _SuccessMsg;
				Infobar = _Infobar;
				
				return (Severity, MatlQtyCounter, CfgCounter, SuccessMsg, Infobar);
			}
		}
	}
}
