using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Payinc.Fino.Service.Model;
using Payinc.Fino.Service.ServiceProcess;
using System;
using System.Threading.Tasks;

namespace Payinc.Fino.Service.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class Fino : ControllerBase
    {
        #region OTP GENERATION
        [Route("api/otpGeneration")]
        [HttpPost]
        public async Task<IActionResult> otpGeneration(GetOtpRequest getOtpRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var getOtpReq = JsonConvert.DeserializeObject<GetOtpReq>(Convert.ToString(JsonConvert.SerializeObject(getOtpRequest)));
                getOtpReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getOtpReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getOtpReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                getOtpReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                getOtpReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.GetOTP_SERVICEID]);
                #endregion

                var serviceResponse = await callService.otpGeneration(getOtpReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion

        #region GET CLIENT MASTER
        [Route("api/getClientMaster")]
        [HttpPost]
        public async Task<IActionResult> getClientMaster(GetClientMasterRequest getClientMasterRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var getClientMasterReq = JsonConvert.DeserializeObject<GetClientMasterReq>(Convert.ToString(JsonConvert.SerializeObject(getClientMasterRequest)));
                getClientMasterReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getClientMasterReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getClientMasterReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                getClientMasterReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                getClientMasterReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.GetClientMaster_SERVICEID]);
                #endregion

                var serviceResponse = await callService.getClientMaster(getClientMasterReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion

        #region GET CLIENT FIELD MASTER
        [Route("api/getClientFieldMaster")]
        [HttpPost]
        public async Task<IActionResult> getClientFieldMaster(GetClientFieldMasterRequest getClientFieldMasterRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var getClientFieldMasterReq = JsonConvert.DeserializeObject<GetClientFieldMasterReq>(Convert.ToString(JsonConvert.SerializeObject(getClientFieldMasterRequest)));
                getClientFieldMasterReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getClientFieldMasterReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getClientFieldMasterReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                getClientFieldMasterReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                getClientFieldMasterReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.GetClientFieldMaster_SERVICEID]);
                #endregion

                var serviceResponse = await callService.getClientFieldMaster(getClientFieldMasterReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion

        #region CASH COLLECTION VERIFICATION
        [Route("api/cashCollectionVerification")]
        [HttpPost]
        public async Task<IActionResult> cashCollectionVerification(CashCollectionVerificationRequest cashCollectionVerificationRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var cashCollectionVerificationReq = JsonConvert.DeserializeObject<CashCollectionVerificationReq>(Convert.ToString(JsonConvert.SerializeObject(cashCollectionVerificationRequest)));
                cashCollectionVerificationReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                cashCollectionVerificationReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                cashCollectionVerificationReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                cashCollectionVerificationReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                cashCollectionVerificationReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.CashCollectionVerification_SERVICEID]);
                #endregion

                var serviceResponse = await callService.cashCollectionVerification(cashCollectionVerificationReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion

        #region CMS TRANSACTION
        [Route("api/cmsTransaction")]
        [HttpPost]
        public async Task<IActionResult> cmsTransaction(CMSTransactionRequest cmsTransactionRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var cmsTransactionReq = JsonConvert.DeserializeObject<CMSTransactionReq>(Convert.ToString(JsonConvert.SerializeObject(cmsTransactionRequest)));
                cmsTransactionReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                cmsTransactionReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                cmsTransactionReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                cmsTransactionReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                cmsTransactionReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.CMSTransaction_SERVICEID]);
                #endregion

                var serviceResponse = await callService.cmsTransaction_OLD(cmsTransactionReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }

        [Route("api/FinalCmsTransaction")]
        [HttpPost]
        public string FinalCmsTransaction(FinalCMSTransactionReq finalCMSTransactionReq)
        {
            var callService = new CallService();
            int processingStageId = 142;
            string TxnStatus = string.Empty, FinoTransactionID = string.Empty, filalResponse = string.Empty;
            // filalResponse = "Status~ResponseCode~TxnStatus~TransactionId~ClientUniqueID~RequestID~ReferenceID~Amount~TrxDateTime~FinoTransactionID~ClientMessage~Message";
            //0~VendorStatusCode~VendorStatus~VendorSubStatus~PayInc TxnId~VendorTxnId~Operator TxnId~Customer Number~Recharge Amount~Vendor Balance~Vendor Response~Transaction Successful";
            try
            {
                #region CREATE LOGGER
                //Logger.Debug("STEP-1 " +JsonConvert.SerializeObject(finalCMSTransactionReq));
                #endregion

                #region GET SET INPUT PARAMETER
                var cmsTransactionReq = JsonConvert.DeserializeObject<CMSTransactionReq>(Convert.ToString(JsonConvert.SerializeObject(finalCMSTransactionReq.cmsTransactionRequest)));
                //cmsTransactionReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                //cmsTransactionReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                cmsTransactionReq.ClientUniqueID =Convert.ToString(finalCMSTransactionReq.TransactionId);
                cmsTransactionReq.ClientInitiatorId = Convert.ToString(finalCMSTransactionReq.TransactionId);
                cmsTransactionReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                cmsTransactionReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                cmsTransactionReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.CMSTransaction_SERVICEID]);
                #endregion

                var serviceResponse = callService.cmsTransaction(cmsTransactionReq);

                #region UPDATE FINO CASH COLLECTION TRANSACTIONS
                filalResponse = "2~NA~NA~NA~" + finalCMSTransactionReq.TransactionId + "~NA~NA~"+ finalCMSTransactionReq.CustomerNumber+ "~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~NA~Transaction Pending~Transaction Pending";

                #region SERVICE RESPONSE IS NULL
                if (serviceResponse==null)
                {
                    return filalResponse;
                }
                #endregion

                #region SERVICE RESPONSE CODE IS NULL
                if (Convert.ToString(serviceResponse.ResponseCode) =="")
                {
                    return filalResponse;
                }
                #endregion

                switch (serviceResponse.ResponseCode)
                {
                    #region SUCCESSFUL
                    case "0"://SUCCESSFUL
                        processingStageId = 140;
                        TxnStatus = serviceResponse.cmsTxnResponseData.TxnStatus;
                        FinoTransactionID = serviceResponse.cmsTxnResponseData.FinoTransactionID;
                        //filalResponse = "0~" + serviceResponse.ResponseCode + "~" + TxnStatus +"~NA~" + finalCMSTransactionReq.TransactionId + "~" + serviceResponse.RequestID + "~" + FinoTransactionID + "~" + finalCMSTransactionReq.CustomerNumber + "~" + serviceResponse.cmsTxnResponseData.Amount + "~NA~" + serviceResponse.MessageString + "~Transaction Successful";
                        filalResponse = "0~" + serviceResponse.ResponseCode + "~" + TxnStatus +"~NA~" + finalCMSTransactionReq.TransactionId + "~" + serviceResponse.RequestID + "~" + FinoTransactionID + "~" + finalCMSTransactionReq.CustomerNumber + "~" + serviceResponse.cmsTxnResponseData.Amount + "~NA~Transaction Successful~Transaction Successful";
                        break;
                    #endregion

                    #region PENDING
                    case "2"://PENDING
                        processingStageId = 142;
                        filalResponse = "2~" + serviceResponse.ResponseCode + "~NA~NA~" + finalCMSTransactionReq.TransactionId + "~" + serviceResponse.RequestID + "~" + FinoTransactionID + "~" + finalCMSTransactionReq.CustomerNumber + "~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~NA~" + serviceResponse.MessageString + "~Transaction Pending";
                        break;
                    #endregion

                    #region FAILED
                    default:
                        processingStageId = 141;
                        filalResponse = "1~" + serviceResponse.ResponseCode + "~NA~NA~" + finalCMSTransactionReq.TransactionId + "~" + serviceResponse.RequestID + "~" + FinoTransactionID + "~" + finalCMSTransactionReq.CustomerNumber + "~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~NA~" + serviceResponse.MessageString + "~Transaction Failed";
                        break;
                        #endregion
                }

                #endregion

                return filalResponse;
            }
            catch (Exception ex)
            {
                //Logger.Debug("STEP-3 " + ex.Message);
                filalResponse = "2~NA~NA~" + finalCMSTransactionReq.TransactionId + "~NA~NA~NA~NA~NA~NA~" + ex.Message + "~Transaction Pending";

                return filalResponse;
            }
        }

        #region OLD CODE COMMENT
        //[Route("api/FinalCmsTransaction")]
        //[HttpPost]
        //public async Task<IActionResult> FinalCmsTransaction(FinalCMSTransactionReq finalCMSTransactionReq)
        //{
        //    var callService = new CallService();
        //    var dbCallData = new dbCall();
        //    int processingStageId = 142;
        //    string TxnStatus = string.Empty, FinoTransactionID = string.Empty, filalResponse = string.Empty;
        //    // filalResponse = "Status~ResponseCode~TxnStatus~TransactionId~ClientUniqueID~RequestID~ReferenceID~Amount~TrxDateTime~FinoTransactionID~ClientMessage~Message";
        //    try
        //    {
        //        #region CREATE LOGGER
        //        Logger.Debug("FinalCMSTransactionReq " + JsonConvert.SerializeObject(finalCMSTransactionReq));
        //        #endregion

        //        #region GET SET INPUT PARAMETER
        //        var cmsTransactionReq = JsonConvert.DeserializeObject<CMSTransactionReq>(Convert.ToString(JsonConvert.SerializeObject(finalCMSTransactionReq.cmsTransactionRequest)));
        //        //cmsTransactionReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
        //        //cmsTransactionReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
        //        cmsTransactionReq.ClientUniqueID = Convert.ToString(finalCMSTransactionReq.TransactionId);
        //        cmsTransactionReq.ClientInitiatorId = Convert.ToString(finalCMSTransactionReq.TransactionId);
        //        cmsTransactionReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
        //        cmsTransactionReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
        //        cmsTransactionReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.SERVICEID]);
        //        #endregion

        //        #region INSERT FINO CASH COLLECTION TRANSACTIONS
        //        long getId = dbCallData.InsertFinoCashCollectionTransactions(finalCMSTransactionReq, cmsTransactionReq);
        //        if (getId <= 0)
        //        {
        //            filalResponse = "1~NA~NA~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~NA~NA~NA~NA~NA~NA~Transaction Failed";
        //            //filalResponse = "1~" + string.Empty + "~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~" + string.Empty + "~" + string.Empty + "~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~" + DateTime.Now + "~" + string.Empty + "~" + string.Empty + "~Transaction Failed";
        //            return new OkObjectResult(filalResponse);
        //        }
        //        #endregion

        //        var serviceResponse = await callService.cmsTransaction(cmsTransactionReq);

        //        #region UPDATE FINO CASH COLLECTION TRANSACTIONS
        //        filalResponse = "2~NA~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~NA~NA~NA~NA~NA~NA~Transaction Pending";
        //        //filalResponse = "2~NA~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~NA~NA~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~" + DateTime.Now + "~NA~NA~Transaction Pending";
        //        switch (serviceResponse.ResponseCode)
        //        {
        //            #region SUCCESSFUL
        //            case 0://SUCCESSFUL
        //                processingStageId = 140;
        //                TxnStatus = serviceResponse.cmsTxnResponseData.TxnStatus;
        //                FinoTransactionID = serviceResponse.cmsTxnResponseData.FinoTransactionID;
        //                filalResponse = "0~" + serviceResponse.ResponseCode + "~" + TxnStatus + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~" + serviceResponse.RequestID + "~" + serviceResponse.ReferenceID + "~" + serviceResponse.cmsTxnResponseData.Amount + "~NA~" + serviceResponse.cmsTxnResponseData.FinoTransactionID + "~" + serviceResponse.MessageString + "~Transaction Successful";
        //                //filalResponse = "0~" + serviceResponse.ResponseCode + "~" + TxnStatus  + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~" + serviceResponse.RequestID + "~" + serviceResponse.ReferenceID + "~" + serviceResponse.cmsTxnResponseData.Amount + "~" + serviceResponse.ResponseDateTime + "~" + serviceResponse.cmsTxnResponseData.FinoTransactionID + "~" + serviceResponse.MessageString + "~Transaction Successful";
        //                break;
        //            #endregion

        //            #region PENDING
        //            case 2://PENDING
        //                processingStageId = 142;
        //                filalResponse = "2~NA~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~NA~NA~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~NA~NA~NA~Transaction Pending";
        //                //filalResponse = "2~NA~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~NA~NA~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~" + DateTime.Now + "~NA~NA~Transaction Pending";
        //                break;
        //            #endregion

        //            #region FAILED
        //            default:
        //                processingStageId = 141;
        //                filalResponse = "1~" + serviceResponse.ResponseCode + "~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~" + serviceResponse.RequestID + "~" + serviceResponse.ReferenceID + "~NA~NA~" + string.Empty + "~" + serviceResponse.MessageString + "~Transaction Failed";
        //                //filalResponse = "1~" + serviceResponse.ResponseCode+ "~"+ string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~" + cmsTransactionReq.ClientInitiatorId + "~" + serviceResponse.RequestID + "~" + serviceResponse.ReferenceID + "~" + cmsTransactionReq.RequestData.FieldDetails.Field23 + "~" + serviceResponse.ResponseDateTime + "~" + string.Empty + "~" + serviceResponse.MessageString + "~Transaction Failed";
        //                break;
        //                #endregion
        //        }
        //        #region UPDATE FINO CASH COLLECTION TRANSACTIONS
        //        dbCallData.UpdateFinoCashCollectionTransactions(finalCMSTransactionReq.TransactionId, processingStageId, serviceResponse.ResponseCode, TxnStatus, serviceResponse.RequestID, FinoTransactionID, serviceResponse.MessageString);
        //        #endregion

        //        #endregion

        //        //return new OkObjectResult(serviceResponse);
        //        return new OkObjectResult(filalResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        filalResponse = "2~NA~" + string.Empty + "~" + finalCMSTransactionReq.TransactionId + "~NA~NA~NA~NA~NA~NA~" + ex.Message + "~Transaction Pending";

        //        return new OkObjectResult(filalResponse);
        //    }
        //}
        #endregion

        #endregion

        #region  TRANSACTION ENQUIRY
        [Route("api/txnEnquiry")]
        [HttpPost]
        public async Task<IActionResult> txnEnquiry(TxnEnquiryRequest txnEnquiryRequest)
        {
            var callService = new CallService();
            try
            {

                #region GET SET INPUT PARAMETER
                var txnEnquiryReq = JsonConvert.DeserializeObject<TxnEnquiryReq>(Convert.ToString(JsonConvert.SerializeObject(txnEnquiryRequest)));
                //txnEnquiryReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                //txnEnquiryReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                txnEnquiryReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                txnEnquiryReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                txnEnquiryReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.TxnEnquiry_SERVICEID]);
                #endregion

                var serviceResponse = await callService.txnEnquiry(txnEnquiryReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion

        #region  RESEND OTP
        [Route("api/resendOTP")]
        [HttpPost]
        public async Task<IActionResult> resendOTP(ResendOTPRequest resendOTPRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var resendOTPReq = JsonConvert.DeserializeObject<ResendOTPReq>(Convert.ToString(JsonConvert.SerializeObject(resendOTPRequest)));
                resendOTPReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                resendOTPReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                resendOTPReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                resendOTPReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                resendOTPReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.ResendOTP_SERVICEID]);
                #endregion

                var serviceResponse = await callService.resendOTP(resendOTPReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion

        #region  GET PRINT TEMPLATE
        [Route("api/getPrintTemplate")]
        [HttpPost]
        public async Task<IActionResult> getPrintTemplate(GetPrintTemplateRequest getPrintTemplateRequest)
        {
            var callService = new CallService();
            try
            {
                #region GET SET INPUT PARAMETER
                var getPrintTemplateReq = JsonConvert.DeserializeObject<GetPrintTemplateReq>(Convert.ToString(JsonConvert.SerializeObject(getPrintTemplateRequest)));
                getPrintTemplateReq.ClientUniqueID = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getPrintTemplateReq.ClientInitiatorId = String.Format("{0:ddMMyyHHmmssfff}", DateTime.Now).ToString();
                getPrintTemplateReq.RequestDateTime = String.Format("{0:MM-dd-yyyy HH:mm:ss}", DateTime.Now).ToString();
                getPrintTemplateReq.Version = Convert.ToInt32(Startup.AppSetting[AppSettings.VERSION]);
                getPrintTemplateReq.SERVICEID = Convert.ToInt32(Startup.AppSetting[AppSettings.GetPrintTemplate_SERVICEID]);
                #endregion

                var serviceResponse = await callService.getPrintTemplate(getPrintTemplateReq);
                return new OkObjectResult(serviceResponse);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

        }
        #endregion
    }
}
