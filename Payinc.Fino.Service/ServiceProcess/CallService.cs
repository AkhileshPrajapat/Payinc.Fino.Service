using Payinc.Fino.Service.Model;
using Payinc.Fino.Service.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payinc.Fino.Service.ServiceProcess
{
    public class CallService
    {

        #region OTP GENERATION
        public async Task<GetOtpRes> otpGeneration(GetOtpReq getOtpReq)
        {
            var getOtpRes = new GetOtpRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.GET_OTP, JsonConvert.SerializeObject(getOtpReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {

                    var getOtpResonse = JsonConvert.DeserializeObject<GetOtpResonse>(Convert.ToString(response));

                    getOtpRes = new GetOtpRes()
                    {
                        ResponseCode = getOtpResonse.ResponseCode,
                        MessageString = getOtpResonse.MessageString,
                        ClientID = getOtpResonse.ClientID,
                        ResponseDateTime = getOtpResonse.ResponseDateTime,
                        RequestID = getOtpResonse.RequestID,
                        ClientUniqueID = getOtpResonse.ClientUniqueID,
                        ReferenceID = Convert.ToString(getOtpResonse.ReferenceID),
                    };

                    if (getOtpResonse.ResponseCode == 0)
                    {
                        var getParamter = new Util().OpenSSLDecrypt(Convert.ToString(getOtpResonse.ResponseData), Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var otpResponseData = JsonConvert.DeserializeObject<OTPResponseData>(Convert.ToString(getParamter));
                        getOtpRes.ResponseData = otpResponseData;
                    }
                }
            }
            catch (Exception ex)
            {
                getOtpRes = new GetOtpRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(getOtpRes);
        }
        #endregion

        #region GET CLIENT MASTER
        public async Task<GetClientMasterRes> getClientMaster(GetClientMasterReq getClientMasterReq)
        {
            var getClientMasterRes = new GetClientMasterRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.GET_CLIENT_MASTER, JsonConvert.SerializeObject(getClientMasterReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    getClientMasterRes = JsonConvert.DeserializeObject<GetClientMasterRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(getClientMasterRes.ResponseData) && Convert.ToString(getClientMasterRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(getClientMasterRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var getClientMasterDataResData = JsonConvert.DeserializeObject<List<GetClientMasterDataRes>>(Convert.ToString(getResponseData));
                        getClientMasterRes.getClientMasterDataRes = getClientMasterDataResData;
                        getClientMasterRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                getClientMasterRes = new GetClientMasterRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(getClientMasterRes);
        }
        #endregion

        #region GET CLIENT FIELD MASTER
        public async Task<GetClientFieldMasterRes> getClientFieldMaster(GetClientFieldMasterReq getClientFieldMasterReq)
        {
            var getClientFieldMasterRes = new GetClientFieldMasterRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.GET_CLIENT_FIELD_MASTER, JsonConvert.SerializeObject(getClientFieldMasterReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    getClientFieldMasterRes = JsonConvert.DeserializeObject<GetClientFieldMasterRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(getClientFieldMasterRes.ResponseData) && Convert.ToString(getClientFieldMasterRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(getClientFieldMasterRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var getClientFieldMasterDataRes = JsonConvert.DeserializeObject<List<GetClientFieldMasterDataRes>>(Convert.ToString(getResponseData));
                        getClientFieldMasterRes.getClientFieldMasterDataRes = getClientFieldMasterDataRes;
                        getClientFieldMasterRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                getClientFieldMasterRes = new GetClientFieldMasterRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(getClientFieldMasterRes);
        }
        #endregion

        #region CASH COLLECTION VERIFICATION
        public async Task<CashCollectionVerificationRes> cashCollectionVerification(CashCollectionVerificationReq cashCollectionVerificationReq)
        {
            var cashCollectionVerificationRes = new CashCollectionVerificationRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.CASH_COLLECTION_VERIFICATION, JsonConvert.SerializeObject(cashCollectionVerificationReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    cashCollectionVerificationRes = JsonConvert.DeserializeObject<CashCollectionVerificationRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(cashCollectionVerificationRes.ResponseData) && Convert.ToString(cashCollectionVerificationRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(cashCollectionVerificationRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var cashColResponseData = JsonConvert.DeserializeObject<CashColResponseDataRes>(Convert.ToString(getResponseData));
                        cashCollectionVerificationRes.cashColResponseData = cashColResponseData;
                        cashCollectionVerificationRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                cashCollectionVerificationRes = new CashCollectionVerificationRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(cashCollectionVerificationRes);
        }
        #endregion

        #region CMS TRANSACTION

        public CMSTransactionRes cmsTransaction(CMSTransactionReq cmsTransactionReq)
        {
            var cmsTransactionRes = new CMSTransactionRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.CMS_TRANSACTION, JsonConvert.SerializeObject(cmsTransactionReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    cmsTransactionRes = JsonConvert.DeserializeObject<CMSTransactionRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(cmsTransactionRes.ResponseData) && Convert.ToString(cmsTransactionRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(cmsTransactionRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var cmsTxnResponseDataRes = JsonConvert.DeserializeObject<CMSTxnResponseDataRes>(Convert.ToString(getResponseData));
                        cmsTransactionRes.cmsTxnResponseData = cmsTxnResponseDataRes;
                        cmsTransactionRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                cmsTransactionRes = new CMSTransactionRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return cmsTransactionRes;
        }
        public async Task<CMSTransactionRes> cmsTransaction_OLD(CMSTransactionReq cmsTransactionReq)
        {
            var cmsTransactionRes = new CMSTransactionRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.CMS_TRANSACTION, JsonConvert.SerializeObject(cmsTransactionReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    cmsTransactionRes = JsonConvert.DeserializeObject<CMSTransactionRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(cmsTransactionRes.ResponseData) && Convert.ToString(cmsTransactionRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(cmsTransactionRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var cmsTxnResponseDataRes = JsonConvert.DeserializeObject<CMSTxnResponseDataRes>(Convert.ToString(getResponseData));
                        cmsTransactionRes.cmsTxnResponseData = cmsTxnResponseDataRes;
                        cmsTransactionRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                cmsTransactionRes = new CMSTransactionRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(cmsTransactionRes);
        }
        #endregion

        #region TRANSACTION ENQUIRY
        public async Task<TxnEnquiryRes> txnEnquiry(TxnEnquiryReq txnEnquiryReq)
        {
            var txnEnquiryRes = new TxnEnquiryRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.TXN_ENQUIRY, JsonConvert.SerializeObject(txnEnquiryReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    txnEnquiryRes = JsonConvert.DeserializeObject<TxnEnquiryRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(txnEnquiryRes.ResponseData) && Convert.ToString(txnEnquiryRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(txnEnquiryRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var cmsTxnResponseDataRes = JsonConvert.DeserializeObject<TxnEnquiryResponseDataRes>(Convert.ToString(getResponseData));
                        txnEnquiryRes.txnEnquiryResponseData = cmsTxnResponseDataRes;
                        txnEnquiryRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                txnEnquiryRes = new TxnEnquiryRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(txnEnquiryRes);
        }
        #endregion

        #region RESEND OTP
        public async Task<ResendOTPRes> resendOTP(ResendOTPReq resendOTPReq)
        {
            var resendOTPRes = new ResendOTPRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.RESEND_OTP, JsonConvert.SerializeObject(resendOTPReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    #region
                    //resendOTPRes = JsonConvert.DeserializeObject<ResendOTPRes>(Convert.ToString(response));
                    //if (!string.IsNullOrEmpty(resendOTPRes.ResponseData) && Convert.ToString(resendOTPRes.ResponseData) != "")
                    //{
                    //    var getResponseData = new Utility.Util().OpenSSLDecrypt(resendOTPRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                    //    var resendOTPResponseData = JsonConvert.DeserializeObject<ResendOTPResponseData>(Convert.ToString(getResponseData));
                    //    resendOTPRes.resendOTPResponseData = resendOTPResponseData;
                    //    resendOTPRes.ResponseData = string.Empty;
                    //}
                    #endregion

                    var getOtpResonse = JsonConvert.DeserializeObject<GetOtpResonse>(Convert.ToString(response));

                    resendOTPRes = new ResendOTPRes()
                    {
                        ResponseCode = getOtpResonse.ResponseCode,
                        MessageString = getOtpResonse.MessageString,
                        ClientID = getOtpResonse.ClientID,
                        ResponseDateTime = getOtpResonse.ResponseDateTime,
                        RequestID = getOtpResonse.RequestID,
                        ClientUniqueID = getOtpResonse.ClientUniqueID,
                        ReferenceID = Convert.ToString(getOtpResonse.ReferenceID),
                    };
                    if (getOtpResonse.ResponseCode == 0)
                    {
                        var getParamter = new Util().OpenSSLDecrypt(Convert.ToString(getOtpResonse.ResponseData), Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var otpResponseData = JsonConvert.DeserializeObject<ResendOTPResponseData>(Convert.ToString(getParamter));
                        resendOTPRes.resendOTPResponseData = otpResponseData;
                    }
                }
            }
            catch (Exception ex)
            {
                resendOTPRes = new ResendOTPRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(resendOTPRes);
        }
        #endregion

        #region GET PRINT TEMPLATE
        public async Task<GetPrintTemplateRes> getPrintTemplate(GetPrintTemplateReq getPrintTemplateReq)
        {
            var getPrintTemplateRes = new GetPrintTemplateRes() { MessageString = ServiceMessage.Unable_to_data };
            string response = string.Empty;
            try
            {
                response = new Util().HttpPostWithPara(Startup.AppSetting[AppSettings.FINO_URL] + FINO_Method_Name.GET_PRINT_TEMPLATE, JsonConvert.SerializeObject(getPrintTemplateReq));
                if (!string.IsNullOrEmpty(response) || Convert.ToString(response) != "")
                {
                    getPrintTemplateRes = JsonConvert.DeserializeObject<GetPrintTemplateRes>(Convert.ToString(response));
                    if (!string.IsNullOrEmpty(getPrintTemplateRes.ResponseData) && Convert.ToString(getPrintTemplateRes.ResponseData) != "")
                    {
                        var getResponseData = new Utility.Util().OpenSSLDecrypt(getPrintTemplateRes.ResponseData, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                        var getPrintResponseData = JsonConvert.DeserializeObject<List<GetPrintResponseDataRes>>(Convert.ToString(getResponseData));
                        getPrintTemplateRes.getPrintResponseData = getPrintResponseData;
                        getPrintTemplateRes.ResponseData = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                getPrintTemplateRes = new GetPrintTemplateRes() { MessageString = ServiceMessage.Unable_to_data };
            }
            return await Task.FromResult(getPrintTemplateRes);
        }
        #endregion
    }
}
