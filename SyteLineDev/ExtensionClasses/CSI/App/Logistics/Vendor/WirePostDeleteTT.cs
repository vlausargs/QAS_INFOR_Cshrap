//PROJECT NAME: Logistics
//CLASS NAME: WirePostDeleteTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class WirePostDeleteTT : IWirePostDeleteTT
	{
		readonly IApplicationDB appDB;
		
		
		public WirePostDeleteTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WirePostDeleteTTSp(Guid? PSessionID,
		string AppmtPayType,
		int? bRemitAdvicePrint = 0)
		{
			RowPointer _PSessionID = PSessionID;
			AppmtPayTypeType _AppmtPayType = AppmtPayType;
			ListYesNoType _bRemitAdvicePrint = bRemitAdvicePrint;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WirePostDeleteTTSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtPayType", _AppmtPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bRemitAdvicePrint", _bRemitAdvicePrint, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
