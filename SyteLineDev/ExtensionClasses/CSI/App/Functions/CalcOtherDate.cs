//PROJECT NAME: Data
//CLASS NAME: CalcOtherDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcOtherDate : ICalcOtherDate
	{
		readonly IApplicationDB appDB;
		
		public CalcOtherDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? NewOtherDate,
			string Infobar) CalcOtherDateSp(
			string PTrnNum,
			DateTime? PKnownDate,
			string PItem,
			int? CalcShipDate,
			DateTime? NewOtherDate,
			string Infobar)
		{
			TrnNumType _PTrnNum = PTrnNum;
			DateType _PKnownDate = PKnownDate;
			ItemType _PItem = PItem;
			FlagNyType _CalcShipDate = CalcShipDate;
			DateType _NewOtherDate = NewOtherDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcOtherDateSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKnownDate", _PKnownDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcShipDate", _CalcShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewOtherDate", _NewOtherDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewOtherDate = _NewOtherDate;
				Infobar = _Infobar;
				
				return (Severity, NewOtherDate, Infobar);
			}
		}
	}
}
