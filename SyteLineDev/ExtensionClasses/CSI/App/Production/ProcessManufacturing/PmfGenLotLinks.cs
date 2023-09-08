//PROJECT NAME: Production
//CLASS NAME: PmfGenLotLinks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGenLotLinks : IPmfGenLotLinks
	{
		readonly IApplicationDB appDB;
		
		public PmfGenLotLinks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? RowsAdded) PmfGenLotLinksSp(
			string Infobar = null,
			string Item = null,
			string Lot = null,
			int? UseLotFlag = 0,
			int? Level = 0,
			int? RowsAdded = 0,
			int? Cascade = 0,
			int? GenSession = 0)
		{
			InfobarType _Infobar = Infobar;
			ItemType _Item = Item;
			LotType _Lot = Lot;
			IntType _UseLotFlag = UseLotFlag;
			IntType _Level = Level;
			IntType _RowsAdded = RowsAdded;
			IntType _Cascade = Cascade;
			IntType _GenSession = GenSession;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGenLotLinksSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseLotFlag", _UseLotFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowsAdded", _RowsAdded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Cascade", _Cascade, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenSession", _GenSession, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				RowsAdded = _RowsAdded;
				
				return (Severity, Infobar, RowsAdded);
			}
		}
	}
}
