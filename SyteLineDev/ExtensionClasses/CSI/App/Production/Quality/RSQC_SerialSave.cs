//PROJECT NAME: Production
//CLASS NAME: RSQC_SerialSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SerialSave : IRSQC_SerialSave
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SerialSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_SerialSaveSp(string SerNum,
		string NewStat,
		string Item,
		int? RcvrNum)
		{
			SerNumType _SerNum = SerNum;
			QCCodeType _NewStat = NewStat;
			ItemType _Item = Item;
			QCRcvrNumType _RcvrNum = RcvrNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SerialSaveSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStat", _NewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
