//PROJECT NAME: Codes
//CLASS NAME: InvProceduralMarkingsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class InvProceduralMarkingsUpd : IInvProceduralMarkingsUpd
	{
		readonly IApplicationDB appDB;
		
		
		public InvProceduralMarkingsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvProceduralMarkingsUpdSp(int? IsSelected = 0,
		string InvNum = null,
		int? InvSeq = null,
		string VatProceduralMarking = null,
		string Infobar = null)
		{
			ListYesNoType _IsSelected = IsSelected;
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			VATProceduralMarkingIdType _VatProceduralMarking = VatProceduralMarking;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvProceduralMarkingsUpdSp";
				
				appDB.AddCommandParameter(cmd, "IsSelected", _IsSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VatProceduralMarking", _VatProceduralMarking, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
