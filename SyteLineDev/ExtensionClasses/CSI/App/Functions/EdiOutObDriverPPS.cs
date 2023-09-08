//PROJECT NAME: Data
//CLASS NAME: EdiOutObDriverPPS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutObDriverPPS : IEdiOutObDriverPPS
	{
		readonly IApplicationDB appDB;
		
		public EdiOutObDriverPPS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PFlag,
			string Infobar) EdiOutObDriverPPSSp(
			string PTranType,
			string PCustNum,
			int? PCustSeq,
			string PInvNum,
			string PCoNum,
			decimal? PBolNum,
			int? PFlag,
			string Infobar)
		{
			LongListType _PTranType = PTranType;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			InvNumType _PInvNum = PInvNum;
			CoNumType _PCoNum = PCoNum;
			ShipmentIDType _PBolNum = PBolNum;
			FlagNyType _PFlag = PFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutObDriverPPSSp";
				
				appDB.AddCommandParameter(cmd, "PTranType", _PTranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBolNum", _PBolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFlag", _PFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PFlag = _PFlag;
				Infobar = _Infobar;
				
				return (Severity, PFlag, Infobar);
			}
		}
	}
}
