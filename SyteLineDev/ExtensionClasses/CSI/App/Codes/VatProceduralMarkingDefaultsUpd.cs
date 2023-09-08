//PROJECT NAME: Codes
//CLASS NAME: VatProceduralMarkingDefaultsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class VatProceduralMarkingDefaultsUpd : IVatProceduralMarkingDefaultsUpd
	{
		readonly IApplicationDB appDB;
		
		
		public VatProceduralMarkingDefaultsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VatProceduralMarkingDefaultsUpdSp(int? Select,
		string RefNum,
		string RefType,
		string ProcMarKingId,
		string Infobar = null)
		{
			ListYesNoType _Select = Select;
			VATProceduralMarkingRefNumType _RefNum = RefNum;
			VATProceduralMarkingRefTypeType _RefType = RefType;
			VATProceduralMarkingIdType _ProcMarKingId = ProcMarKingId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VatProceduralMarkingDefaultsUpdSp";
				
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcMarKingId", _ProcMarKingId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
