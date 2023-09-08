//PROJECT NAME: Production
//CLASS NAME: PmftPmfGenLotLinks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmftPmfGenLotLinks : IPmftPmfGenLotLinks
	{
		readonly IApplicationDB appDB;
		
		public PmftPmfGenLotLinks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PmftPmfGenLotLinksSp(
			int? SessionID,
			string item,
			string lot = null,
			string ser = null,
			int? forward = 1,
			int? back = 1,
			string Infobar = null)
		{
			IntType _SessionID = SessionID;
			ItemType _item = item;
			LotType _lot = lot;
			SerNumType _ser = ser;
			IntType _forward = forward;
			IntType _back = back;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmftPmfGenLotLinksSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lot", _lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ser", _ser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "forward", _forward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "back", _back, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
