//PROJECT NAME: Admin
//CLASS NAME: CreatePrivacyUtilityEsig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class CreatePrivacyUtilityEsig : ICreatePrivacyUtilityEsig
	{
		IApplicationDB appDB;
		
		
		public CreatePrivacyUtilityEsig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreatePrivacyUtilityEsigSp(Guid? TmpGDPRDataRowpointer,
		string ProcessType)
		{
			RowPointerType _TmpGDPRDataRowpointer = TmpGDPRDataRowpointer;
			ProcessIndType _ProcessType = ProcessType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePrivacyUtilityEsigSp";
				
				appDB.AddCommandParameter(cmd, "TmpGDPRDataRowpointer", _TmpGDPRDataRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessType", _ProcessType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
