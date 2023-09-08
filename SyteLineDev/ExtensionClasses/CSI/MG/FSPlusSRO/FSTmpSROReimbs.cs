//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSTmpSROReimbs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSTmpSROReimbs")]
	public class FSTmpSROReimbs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSTmpSROReimbCleanUpSp(Guid? SessionID)
		{
			var iSSSFSTmpSROReimbCleanUpExt = new SSSFSTmpSROReimbCleanUpFactory().Create(this, true);
			
			var result = iSSSFSTmpSROReimbCleanUpExt.SSSFSTmpSROReimbCleanUpSp(SessionID);
			
			
			return result??0;
		}

	}
}
