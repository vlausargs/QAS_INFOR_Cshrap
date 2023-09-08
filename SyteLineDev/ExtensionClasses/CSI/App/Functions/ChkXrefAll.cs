//PROJECT NAME: Data
//CLASS NAME: ChkXrefAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChkXrefAll : IChkXrefAll
	{
		readonly IApplicationDB appDB;
		
		public ChkXrefAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChkXrefAllSp(
			string CoNum = null,
			int? CoLine = null,
			int? CoRelease = null,
			string OldRefType = null,
			string NewRefType = null,
			string NewRefNum = null,
			int? NewRefLineSuf = null,
			int? NewRefRel = null,
			string NewItem = null,
			string DestinationType = null,
			string ShipSite = null,
			string Infobar = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoLineType _CoRelease = CoRelease;
			UnknownRefTypeType _OldRefType = OldRefType;
			UnknownRefTypeType _NewRefType = NewRefType;
			AnyRefNumType _NewRefNum = NewRefNum;
			CoLineType _NewRefLineSuf = NewRefLineSuf;
			CoLineType _NewRefRel = NewRefRel;
			ItemType _NewItem = NewItem;
			DefaultCharType _DestinationType = DestinationType;
			SiteType _ShipSite = ShipSite;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkXrefAllSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldRefType", _OldRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefType", _NewRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefNum", _NewRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefLineSuf", _NewRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefRel", _NewRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DestinationType", _DestinationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
