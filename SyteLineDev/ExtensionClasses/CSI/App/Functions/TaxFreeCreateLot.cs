//PROJECT NAME: Data
//CLASS NAME: TaxFreeCreateLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TaxFreeCreateLot : ITaxFreeCreateLot
	{
		readonly IApplicationDB appDB;
		
		public TaxFreeCreateLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TaxFreeCreateLotSp(
			string pItem,
			string pRevision = null,
			string Infobar = null)
		{
			ItemType _pItem = pItem;
			RevisionType _pRevision = pRevision;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxFreeCreateLotSp";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRevision", _pRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
