//PROJECT NAME: Data
//CLASS NAME: EdiOutPoitemDropaddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutPoitemDropaddr : IEdiOutPoitemDropaddr
	{
		readonly IApplicationDB appDB;
		
		public EdiOutPoitemDropaddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EdiOutPoitemDropaddrSp(
			string PoitemDropShipNo,
			int? PoitemDropSeq,
			string PoitemShipAddr,
			string PoitemWhse,
			Guid? EdiPoitemRowPointer,
			string Infobar)
		{
			DropShipNoType _PoitemDropShipNo = PoitemDropShipNo;
			DropSeqType _PoitemDropSeq = PoitemDropSeq;
			DropShipTypeType _PoitemShipAddr = PoitemShipAddr;
			WhseType _PoitemWhse = PoitemWhse;
			RowPointerType _EdiPoitemRowPointer = EdiPoitemRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutPoitemDropaddrSp";
				
				appDB.AddCommandParameter(cmd, "PoitemDropShipNo", _PoitemDropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemDropSeq", _PoitemDropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemShipAddr", _PoitemShipAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemWhse", _PoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EdiPoitemRowPointer", _EdiPoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
