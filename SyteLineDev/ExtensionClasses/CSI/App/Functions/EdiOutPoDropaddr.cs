//PROJECT NAME: Data
//CLASS NAME: EdiOutPoDropaddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutPoDropaddr : IEdiOutPoDropaddr
	{
		readonly IApplicationDB appDB;
		
		public EdiOutPoDropaddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EdiOutPoDropaddrSp(
			string PoDropShipNo,
			int? PoDropSeq,
			string PoShipAddr,
			string PoWhse,
			Guid? EdiPoRowPointer,
			string Infobar)
		{
			DropShipNoType _PoDropShipNo = PoDropShipNo;
			DropSeqType _PoDropSeq = PoDropSeq;
			DropShipTypeType _PoShipAddr = PoShipAddr;
			WhseType _PoWhse = PoWhse;
			RowPointerType _EdiPoRowPointer = EdiPoRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutPoDropaddrSp";
				
				appDB.AddCommandParameter(cmd, "PoDropShipNo", _PoDropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoDropSeq", _PoDropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoShipAddr", _PoShipAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoWhse", _PoWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EdiPoRowPointer", _EdiPoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
