using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payinc.Fino.Service
{
    public class AppSettings
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public const string DefaultConnection = "DefaultConnection";
        public const string Service_Config = "Service_Config";
        public const string FINO_URL = "FINO_URL";
        public const string FINO_AUTHKEY_KEY = "FINO_AUTHKEY_KEY";
        public const string FINO_PARTNERID = "FINO_PARTNERID";
        public const string BODY_ENCRYPTION_KEY = "BODY_ENCRYPTION_KEY";
        public const string HEADER_ENCRYPTION_KEY = "HEADER_ENCRYPTION_KEY";
        public const string CLIENT_NAME = "CLIENT_NAME";
        public const string VERSION = "VERSION";
        //public const string SERVICEID = "SERVICEID";
        public const string GetClientMaster_SERVICEID = "GetClientMaster_SERVICEID";
        public const string GetClientFieldMaster_SERVICEID = "GetClientFieldMaster_SERVICEID";
        public const string CashCollectionVerification_SERVICEID = "CashCollectionVerification_SERVICEID";
        public const string CMSTransaction_SERVICEID = "CMSTransaction_SERVICEID";
        public const string GetOTP_SERVICEID = "GetOTP_SERVICEID";
        public const string TxnEnquiry_SERVICEID = "TxnEnquiry_SERVICEID";
        public const string ResendOTP_SERVICEID = "ResendOTP_SERVICEID";
        public const string GetPrintTemplate_SERVICEID = "GetPrintTemplate_SERVICEID";

        public const string IS_LOG = "IS_LOG";
    }
}
