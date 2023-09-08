//PROJECT NAME: Codes
//CLASS NAME: VchProceduralMarkingsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class VchProceduralMarkingsUpd : IVchProceduralMarkingsUpd
	{
		readonly IApplicationDB appDB;
		
		
		public VchProceduralMarkingsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VchProceduralMarkingsUpdSp(int? VchNum,
		int? VchSeq,
		int? Selected,
		string VATProceduralMarkingId,
		string Infobar)
		{
			VoucherType _VchNum = VchNum;
			VouchSeqType _VchSeq = VchSeq;
			ListYesNoType _Selected = Selected;
			VATProceduralMarkingIdType _VATProceduralMarkingId = VATProceduralMarkingId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VchProceduralMarkingsUpdSp";
				
				appDB.AddCommandParameter(cmd, "VchNum", _VchNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchSeq", _VchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VATProceduralMarkingId", _VATProceduralMarkingId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
