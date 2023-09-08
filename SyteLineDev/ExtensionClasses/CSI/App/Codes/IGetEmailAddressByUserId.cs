//PROJECT NAME: Codes
//CLASS NAME: IGetEmailAddressByUserId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
    public interface IGetEmailAddressByUserId
    {
        (int? ReturnCode, string EmailAddress) GetEmailAddressByUserIdSp(
            decimal? UserId,
            string EmailAddress);
    }
}
