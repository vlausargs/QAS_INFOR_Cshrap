//PROJECT NAME: Codes
//CLASS NAME: SaveInvProceduralMarkingsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class SaveInvProceduralMarkingsUpd : ISaveInvProceduralMarkingsUpd
	{
		readonly IApplicationDB appDB;
		
		
		public SaveInvProceduralMarkingsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SaveInvProceduralMarkingsUpdSp(string SiteRef,
		string InvNum,
		int? InvSeq,
		int? Selected,
		string VATProceduralMarkingId,
		string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			ListYesNoType _Selected = Selected;
			VATProceduralMarkingIdType _VATProceduralMarkingId = VATProceduralMarkingId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveInvProceduralMarkingsUpdSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
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
