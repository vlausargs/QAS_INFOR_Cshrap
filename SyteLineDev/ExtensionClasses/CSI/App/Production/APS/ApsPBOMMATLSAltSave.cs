//PROJECT NAME: Production
//CLASS NAME: ApsPBOMMATLSAltSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPBOMMATLSAltSave : IApsPBOMMATLSAltSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsPBOMMATLSAltSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPBOMMATLSAltSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		int? ALTID,
		int? SEQNO,
		string MATERIALID,
		int? NEWSEQNO)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsPbomType _BOMID = BOMID;
			ApsIntType _ALTID = ALTID;
			ApsIntType _SEQNO = SEQNO;
			ApsMaterialType _MATERIALID = MATERIALID;
			ApsIntType _NEWSEQNO = NEWSEQNO;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPBOMMATLSAltSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMID", _BOMID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTID", _ALTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SEQNO", _SEQNO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NEWSEQNO", _NEWSEQNO, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
