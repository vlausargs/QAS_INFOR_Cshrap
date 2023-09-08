//PROJECT NAME: Production
//CLASS NAME: RSQC_SetUptmpser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetUptmpser : IRSQC_SetUptmpser
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SetUptmpser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SerialTracked,
		string Infobar) RSQC_SetUptmpserSp(string RefType,
		string RefNum,
		int? RefLine,
		int? RefRelease,
		int? OperNum,
		int? TestSeq,
		string MrrNum,
		int? RcvrNum,
		string Item,
		string Entity,
		int? SerialTracked,
		string Infobar)
		{
			QCRefType _RefType = RefType;
			QCRefNumType _RefNum = RefNum;
			QCRefLineType _RefLine = RefLine;
			QCRefReleaseType _RefRelease = RefRelease;
			OperNumType _OperNum = OperNum;
			QCTestSeqType _TestSeq = TestSeq;
			QCDocNumType _MrrNum = MrrNum;
			QCRcvrNumType _RcvrNum = RcvrNum;
			ItemType _Item = Item;
			QCDocNumType _Entity = Entity;
			ListYesNoType _SerialTracked = SerialTracked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SetUptmpserSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TestSeq", _TestSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrrNum", _MrrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Entity", _Entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerialTracked = _SerialTracked;
				Infobar = _Infobar;
				
				return (Severity, SerialTracked, Infobar);
			}
		}
	}
}
