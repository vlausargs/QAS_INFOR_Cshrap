//PROJECT NAME: Production
//CLASS NAME: Pmfto2GenLotLinks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class Pmfto2GenLotLinks : IPmfto2GenLotLinks
	{
		readonly IApplicationDB appDB;
		
		public Pmfto2GenLotLinks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Pmfto2GenLotLinksSp(
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
				cmd.CommandText = "Pmfto2GenLotLinksSp";
				
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
