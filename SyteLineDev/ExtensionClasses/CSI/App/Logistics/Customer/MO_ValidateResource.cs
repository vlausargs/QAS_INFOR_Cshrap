//PROJECT NAME: CSICustomer
//CLASS NAME: MO_ValidateResource.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IMO_ValidateResource
	{
		(int? ReturnCode, string BOMType, string CoProductMix, string LaborType, int? RESIDQTY) MO_ValidateResourceSp(string RESID = null,
		string BOMType = null,
		string CoProductMix = null,
		string LaborType = null,
		int? RESIDQTY = null);
	}
	
	public class MO_ValidateResource : IMO_ValidateResource
	{
		readonly IApplicationDB appDB;
		
		public MO_ValidateResource(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BOMType, string CoProductMix, string LaborType, int? RESIDQTY) MO_ValidateResourceSp(string RESID = null,
		string BOMType = null,
		string CoProductMix = null,
		string LaborType = null,
		int? RESIDQTY = null)
		{
			ApsResourceType _RESID = RESID;
			MO_JobConfigTypeType _BOMType = BOMType;
			ProdMixType _CoProductMix = CoProductMix;
			MO_LaborType _LaborType = LaborType;
			ApsIntType _RESIDQTY = RESIDQTY;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ValidateResourceSp";
				
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LaborType", _LaborType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RESIDQTY", _RESIDQTY, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BOMType = _BOMType;
				CoProductMix = _CoProductMix;
				LaborType = _LaborType;
				RESIDQTY = _RESIDQTY;
				
				return (Severity, BOMType, CoProductMix, LaborType, RESIDQTY);
			}
		}
	}
}
