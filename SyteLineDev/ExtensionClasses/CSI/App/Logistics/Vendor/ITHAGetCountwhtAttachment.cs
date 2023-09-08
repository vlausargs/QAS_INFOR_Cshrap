//PROJECT NAME: Logistics
//CLASS NAME: ITHAGetCountwhtAttachment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface ITHAGetCountwhtAttachment
    {
        (int? ReturnCode,
        int? whtattachment) THAGetCountwhtAttachmentSp(
            int? whtattachment);
    }
}

