//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROTmpSers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSSROTmpSers")]
	public class FSSROTmpSers : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSerialGetReturnSerialSp(Guid? SessionId,
		string Item,
		string RefNum,
		[Optional, DefaultParameterValue((short)0)] short? RefLine,
		[Optional, DefaultParameterValue((short)0)] short? RefRelease,
		string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSerialGetReturnSerialExt = new SSSFSSerialGetReturnSerialFactory().Create(appDb);
				
				var result = iSSSFSSerialGetReturnSerialExt.SSSFSSerialGetReturnSerialSp(SessionId,
				Item,
				RefNum,
				RefLine,
				RefRelease,
				Site);
				
				
				return result.Value;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteTmpSerSp(Guid? TmpSerId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeleteTmpSerExt = new DeleteTmpSerFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeleteTmpSerExt.DeleteTmpSerSp(TmpSerId);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
