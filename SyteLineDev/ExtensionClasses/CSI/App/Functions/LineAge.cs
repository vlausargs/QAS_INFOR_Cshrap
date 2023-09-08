//PROJECT NAME: Data
//CLASS NAME: LineAge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LineAge : ILineAge
	{
		readonly IApplicationDB appDB;
		
		public LineAge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar) LineAgeSp(
			Guid? TRecid,
			DateTime? AgeByDate,
			string AgeBasis,
			int? DomCurr,
			int? UseHistRate,
			string PParmsCurrCode,
			int? PPlaces,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar = null)
		{
			RowPointerType _TRecid = TRecid;
			CurrentDateType _AgeByDate = AgeByDate;
			LongListType _AgeBasis = AgeBasis;
			FlagNyType _DomCurr = DomCurr;
			FlagNyType _UseHistRate = UseHistRate;
			CurrCodeType _PParmsCurrCode = PParmsCurrCode;
			DecimalPlacesType _PPlaces = PPlaces;
			AmountType _NetDue = NetDue;
			AmountType _DiscAllowed = DiscAllowed;
			AmountType _DiscTaken = DiscTaken;
			AmountType _InvAmt = InvAmt;
			AmountType _AmtPaid = AmtPaid;
			AmountType _DiscRem = DiscRem;
			GenericNoType _Age = Age;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LineAgeSp";
				
				appDB.AddCommandParameter(cmd, "TRecid", _TRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeByDate", _AgeByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeBasis", _AgeBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurr", _DomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsCurrCode", _PParmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlaces", _PPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NetDue", _NetDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscAllowed", _DiscAllowed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscTaken", _DiscTaken, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAmt", _InvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtPaid", _AmtPaid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscRem", _DiscRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Age", _Age, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NetDue = _NetDue;
				DiscAllowed = _DiscAllowed;
				DiscTaken = _DiscTaken;
				InvAmt = _InvAmt;
				AmtPaid = _AmtPaid;
				DiscRem = _DiscRem;
				Age = _Age;
				Infobar = _Infobar;
				
				return (Severity, NetDue, DiscAllowed, DiscTaken, InvAmt, AmtPaid, DiscRem, Age, Infobar);
			}
		}
	}
}
