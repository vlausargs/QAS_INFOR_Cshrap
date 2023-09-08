//PROJECT NAME: Logistics
//CLASS NAME: GetArparmLinesPerDoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetArparmLinesPerDoc : IGetArparmLinesPerDoc
	{
		readonly IApplicationDB appDB;
		
		
		public GetArparmLinesPerDoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PArparmUsePrePrintedForms,
		int? PArparmLinesPerInv,
		int? PArparmLinesPerDM,
		int? PArparmLinesPerCM) GetArparmLinesPerDocSp(int? PArparmUsePrePrintedForms,
		int? PArparmLinesPerInv,
		int? PArparmLinesPerDM,
		int? PArparmLinesPerCM)
		{
			ListYesNoType _PArparmUsePrePrintedForms = PArparmUsePrePrintedForms;
			LinesPerDocType _PArparmLinesPerInv = PArparmLinesPerInv;
			LinesPerDocType _PArparmLinesPerDM = PArparmLinesPerDM;
			LinesPerDocType _PArparmLinesPerCM = PArparmLinesPerCM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetArparmLinesPerDocSp";
				
				appDB.AddCommandParameter(cmd, "PArparmUsePrePrintedForms", _PArparmUsePrePrintedForms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmLinesPerInv", _PArparmLinesPerInv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmLinesPerDM", _PArparmLinesPerDM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmLinesPerCM", _PArparmLinesPerCM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PArparmUsePrePrintedForms = _PArparmUsePrePrintedForms;
				PArparmLinesPerInv = _PArparmLinesPerInv;
				PArparmLinesPerDM = _PArparmLinesPerDM;
				PArparmLinesPerCM = _PArparmLinesPerCM;
				
				return (Severity, PArparmUsePrePrintedForms, PArparmLinesPerInv, PArparmLinesPerDM, PArparmLinesPerCM);
			}
		}
	}
}
