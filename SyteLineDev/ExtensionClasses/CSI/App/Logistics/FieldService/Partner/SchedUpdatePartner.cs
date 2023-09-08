//PROJECT NAME: Logistics
//CLASS NAME: SchedUpdatePartner.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedUpdatePartner : ISchedUpdatePartner
	{
		readonly IApplicationDB appDB;
		
		
		public SchedUpdatePartner(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SchedUpdatePartnerSp(Guid? RowPointer,
		Guid? NewRowPointer,
		string PartnerId,
		DateTime? StartDate,
		int? View,
		string Infobar)
		{
			RowPointerType _RowPointer = RowPointer;
			RowPointerType _NewRowPointer = NewRowPointer;
			FSPartnerType _PartnerId = PartnerId;
			DateType _StartDate = StartDate;
			ShortType _View = View;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedUpdatePartnerSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRowPointer", _NewRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "View", _View, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
