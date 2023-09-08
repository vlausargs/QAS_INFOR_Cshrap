//PROJECT NAME: CSICustomer
//CLASS NAME: GetUseAltPriceParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetUseAltPriceParms
	{
		(int? ReturnCode, byte? PUseAltPriceCalc) GetUseAltPriceParmsSp(byte? PUseAltPriceCalc,
		string PSite = null);
	}
	
	public class GetUseAltPriceParms : IGetUseAltPriceParms
	{
		readonly IApplicationDB appDB;
		
		public GetUseAltPriceParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? PUseAltPriceCalc) GetUseAltPriceParmsSp(byte? PUseAltPriceCalc,
		string PSite = null)
		{
			ListYesNoType _PUseAltPriceCalc = PUseAltPriceCalc;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetUseAltPriceParmsSp";
				
				appDB.AddCommandParameter(cmd, "PUseAltPriceCalc", _PUseAltPriceCalc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUseAltPriceCalc = _PUseAltPriceCalc;
				
				return (Severity, PUseAltPriceCalc);
			}
		}
	}
}
