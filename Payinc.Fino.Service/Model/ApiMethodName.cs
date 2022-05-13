using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payinc.Fino.Service.Model
{
    //https://www.mware.incrediwebs.in/mtmoney_vendor_fino_cms/swagger/index.html
    #region
    //Field1:UniqueID
    //Field11:UserName
    //Field6:MobileNo
    //Field25:Remarks1
    //Field27:Remarks3
    //Field13:EmsilId
    //Field26:Remarks2
    //Field23:Amount
    //Field36:R1R2MobileNo
    #endregion
    public class ApiMethodName
    {
    }

    #region FINO BANK PAYMENT API METHOD NAME
    public class FINO_Method_Name
    {
        public const string GET_OTP = "GetOTP";
        public const string GET_CLIENT_MASTER = "GetClientMaster";
        public const string GET_CLIENT_FIELD_MASTER = "GetClientFieldMaster";
        public const string CASH_COLLECTION_VERIFICATION = "CashCollectionVerification";
        public const string CMS_TRANSACTION = "CMSTransaction";
        public const string TXN_ENQUIRY = "TxnEnquiry";
        public const string RESEND_OTP = "ResendOTP";
        public const string GET_PRINT_TEMPLATE = "GetPrintTemplate";
    }
    #endregion
}
