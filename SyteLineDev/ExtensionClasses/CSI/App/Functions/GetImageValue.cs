//PROJECT NAME: Data
//CLASS NAME: GetImageValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetImageValue : IGetImageValue
	{
		readonly IApplicationDB appDB;
		
		public GetImageValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public byte[] GetImageValueFn(
			string ImageId,
			string keyvalue,
			string imagename)
		{
			ImageIdType _ImageId = ImageId;
			KeyValueType _keyvalue = keyvalue;
			ImageNameType _imagename = imagename;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetImageValue](@ImageId, @keyvalue, @imagename)";
				
				appDB.AddCommandParameter(cmd, "ImageId", _ImageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "keyvalue", _keyvalue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "imagename", _imagename, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<byte[]>(cmd);
				
				return Output;
			}
		}
	}
}
