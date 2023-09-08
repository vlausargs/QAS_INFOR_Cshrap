//PROJECT NAME: Logistics
//CLASS NAME: TmpConInvGenerationUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TmpConInvGenerationUpd : ITmpConInvGenerationUpd
	{
		readonly IApplicationDB appDB;
		
		
		public TmpConInvGenerationUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TmpConInvGenerationUpdSp(Guid? SessionId,
		int? Selected,
		string CoNum,
		int? CoLine,
		int? CoRel,
		string CustPo,
		int? Consolidate,
		string InvFreq,
		DateTime? ShipDate,
		Guid? CoitemRowPointer,
		decimal? ShipmentId,
		string CoCustNum)
		{
			RowPointerType _SessionId = SessionId;
			ListYesNoType _Selected = Selected;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRel = CoRel;
			CustPoType _CustPo = CustPo;
			ListYesNoType _Consolidate = Consolidate;
			InvFreqType _InvFreq = InvFreq;
			DateType _ShipDate = ShipDate;
			RowPointerType _CoitemRowPointer = CoitemRowPointer;
			ShipmentIDType _ShipmentId = ShipmentId;
			CustNumType _CoCustNum = CoCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TmpConInvGenerationUpdSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRel", _CoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Consolidate", _Consolidate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvFreq", _InvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDate", _ShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemRowPointer", _CoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
