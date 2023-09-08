//PROJECT NAME: Data
//CLASS NAME: Dunn1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Dunn1 : IDunn1
	{
		readonly IApplicationDB appDB;
		
		public Dunn1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PTaTotal,
			decimal? PGdTotal,
			string Infobar) Dunn1Sp(
			string PCustNum = null,
			DateTime? PSDate = null,
			DateTime? PEDate = null,
			decimal? PTaTotal = null,
			decimal? PGdTotal = null,
			string PSiteRef = null,
			string Infobar = null)
		{
			CustNumType _PCustNum = PCustNum;
			DateType _PSDate = PSDate;
			DateType _PEDate = PEDate;
			DecimalType _PTaTotal = PTaTotal;
			DecimalType _PGdTotal = PGdTotal;
			SiteType _PSiteRef = PSiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Dunn1Sp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSDate", _PSDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEDate", _PEDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaTotal", _PTaTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PGdTotal", _PGdTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSiteRef", _PSiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTaTotal = _PTaTotal;
				PGdTotal = _PGdTotal;
				Infobar = _Infobar;
				
				return (Severity, PTaTotal, PGdTotal, Infobar);
			}
		}
	}
}
