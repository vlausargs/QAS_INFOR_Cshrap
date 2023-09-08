//PROJECT NAME: Data
//CLASS NAME: ARDistribDomAmts2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARDistribDomAmts2 : IARDistribDomAmts2
	{
		readonly IApplicationDB appDB;
		
		public ARDistribDomAmts2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? pOpenBal,
			int? pFixedRate) ARDistribDomAmts2Sp(
			string pSite,
			Guid? pRowPointer,
			decimal? pOpenBal,
			int? pFixedRate)
		{
			SiteType _pSite = pSite;
			RowPointerType _pRowPointer = pRowPointer;
			GenericDecimalType _pOpenBal = pOpenBal;
			ListYesNoType _pFixedRate = pFixedRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARDistribDomAmts2Sp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRowPointer", _pRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOpenBal", _pOpenBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pFixedRate", _pFixedRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pOpenBal = _pOpenBal;
				pFixedRate = _pFixedRate;
				
				return (Severity, pOpenBal, pFixedRate);
			}
		}
	}
}
