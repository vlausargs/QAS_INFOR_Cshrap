//PROJECT NAME: Data
//CLASS NAME: StatBalI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class StatBalI : IStatBalI
	{
		readonly IApplicationDB appDB;
		
		public StatBalI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Balance,
			string Infobar) StatBalISp(
			string PType,
			DateTime? SDate,
			DateTime? EDate,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PHierarchy,
			decimal? Balance,
			string Infobar,
			string pSite = null,
			string PSort = null)
		{
			ChartTypeType _PType = PType;
			CurrentDateType _SDate = SDate;
			CurrentDateType _EDate = EDate;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			HierarchyType _PHierarchy = PHierarchy;
			GenericDecimalType _Balance = Balance;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			LongListType _PSort = PSort;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "StatBalISp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDate", _SDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDate", _EDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHierarchy", _PHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSort", _PSort, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				Infobar = _Infobar;
				
				return (Severity, Balance, Infobar);
			}
		}
	}
}
