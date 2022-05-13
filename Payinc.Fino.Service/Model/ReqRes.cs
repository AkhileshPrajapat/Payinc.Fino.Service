using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payinc.Fino.Service.Model
{
    public class ReqRes
    {
    }
    #region 2.2.1 AUTHENTICATION REQ/RES
    #region AUTHENTICATION REQ
    public class AuthenticationReq
    {
        public string AuthKey { get; set; }
        public string PartnerID { get; set; }
    }
    #endregion

    #region AUTHENTICATION RES
    public class AuthenticationRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public string DisplayMessage { get; set; }
        public object ResponseData { get; set; }
        public string ResponseDateTime { get; set; }//public DateTime ResponseDateTime { get; set; }
    }
    #endregion
    #endregion

    #region 2.3.1 OTP GENERATION REQ/RES

    #region OTP GENERATION REQ
    public class GetOtpRequest
    {
        //public string ClientUniqueID { get; set; }
        //public string ClientInitiatorId { get; set; }
        //public string RequestDateTime { get; set; }
        //public int Version { get; set; }
        public string ClientID { get; set; }
        //public int SERVICEID { get; set; }
        public GetOtpRequestData RequestData { get; set; }
    }
    public class GetOtpReq
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public string ClientID { get; set; }
        public int SERVICEID { get; set; }
        public GetOtpRequestData RequestData { get; set; }
    }
    public class GetOtpRequestData
    {
        public string OTPParam1 { get; set; }
        public string OTPParam2 { get; set; }
        public string OTPParam3 { get; set; }
        public string OTPParam4 { get; set; }
        public string OTPParam5 { get; set; }
        public string OTPParam6 { get; set; }
        public string OTPParam7 { get; set; }
        public string OTPParam8 { get; set; }
    }
    #endregion

    #region OTP GENERATION RES
    public class GetOtpResonse
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public string ClientUniqueID { get; set; }
        public string RequestID { get; set; }
        public string ReferenceID { get; set; }
        public string ResponseDateTime { get; set; }
        public string ClientID { get; set; }
        public object ResponseData { get; set; }
    }

    public class GetOtpRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public string ClientUniqueID { get; set; }
        public string RequestID { get; set; }
        public string ReferenceID { get; set; }
        public string ResponseDateTime { get; set; }
        public string ClientID { get; set; }
        public OTPResponseData ResponseData { get; set; }
    }

    public class OTPResponseData
    {
        public string RefernceID { get; set; }
        public string RFU1 { get; set; }
        public string RFU2 { get; set; }
        public string RFU3 { get; set; }
    }
    #endregion
    #endregion

    #region 2.3.2 GET CLIENT MASTER REQ/RES
    #region GET CLIENT MASTER REQ

    public class GetClientMasterRequest
    {
        //public string ClientUniqueID { get; set; }
        //public string ClientInitiatorId { get; set; }
        //public string RequestDateTime { get; set; }
        //public int Version { get; set; }
        //public int SERVICEID { get; set; }
        public int ClientID { get; set; }
        public GetClientMasterReqData RequestData { get; set; }
    }
    public class GetClientMasterReq
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public int ClientID { get; set; }
        public GetClientMasterReqData RequestData { get; set; }
    }
    public class GetClientMasterReqData
    {
        public string ClientID { get; set; }
    }
    #endregion

    #region GET CLIENT MASTER RES
    public class GetClientMasterRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public int ClientID { get; set; }
        public string ResponseDateTime { get; set; }
        public string RequestID { get; set; }
        public string ClientUniqueID { get; set; }
        public object ReferenceID { get; set; }
        public string ResponseData { get; set; }
        public List<GetClientMasterDataRes> getClientMasterDataRes { get; set; }
    }
    public class GetClientMasterDataRes
    {
        public int PartnerId { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int IsVerify { get; set; }
        public int CoolOff { get; set; }
        public int PerCustomerMinTxnLimit { get; set; }
        public int PerCustomerMaxTxnLimit { get; set; }
        public int TxnMinLimit { get; set; }
        public int TxnMaxLimit { get; set; }
        public int PartPayment { get; set; }
        public int OverPayment { get; set; }
        public int PanRequired { get; set; }
        public int PanThreshold { get; set; }
        public string Category { get; set; }
        public int APIThreshold { get; set; }
        public int MultiVerify { get; set; }
        public string SpclVerifyFields { get; set; }
        public int ReturnMulti { get; set; }
        public string OTPParam1 { get; set; }
        public string OTPParam2 { get; set; }
        public string OTPParam3 { get; set; }
        public string OTPParam4 { get; set; }
        public string OTPParam5 { get; set; }
        public string OTPParam6 { get; set; }
        public string OTPParam7 { get; set; }
        public string OTPParam8 { get; set; }
        public bool OTPAuthRequired { get; set; }
        public string CutOffTime { get; set; }
    }
    #endregion
    #endregion

    #region 2.3.3 GET CLIENT FIELD MASTER REQ/RES
    #region GET CLIENT FIELD MASTER REQ

    public class GetClientFieldMasterRequest
    {
        //public string ClientUniqueID { get; set; }
        //public string ClientInitiatorId { get; set; }
        //public string RequestDateTime { get; set; }
        //public int Version { get; set; }
        //public int SERVICEID { get; set; }
        public int ClientID { get; set; }
        public GetClientFieldMasterDataReq RequestData { get; set; }
    }
    public class GetClientFieldMasterReq
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public int ClientID { get; set; }
        public GetClientFieldMasterDataReq RequestData { get; set; }
    }
    public class GetClientFieldMasterDataReq
    {
        public string ClientID { get; set; }
    }
    #endregion

    #region GET CLIENT FIELD MASTER RES
    public class GetClientFieldMasterRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public int ClientID { get; set; }
        public string RequestID { get; set; }
        public string ResponseDateTime { get; set; }
        public string ClientUniqueID { get; set; }
        public object ReferenceID { get; set; }
        public string ResponseData { get; set; }
        public List<GetClientFieldMasterDataRes> getClientFieldMasterDataRes { get; set; }
    }
    public class GetClientFieldMasterDataRes
    {
        public int ClientID { get; set; }
        public string FieldName { get; set; }
        public string FieldIndex { get; set; }
        public string FieldType { get; set; }
        public int FieldVisibility { get; set; }
        public string Type { get; set; }
        public int Active { get; set; }
        public int FieldMinLength { get; set; }
        public int FieldMaxLength { get; set; }
        public string FieldFormat { get; set; }
        public int FieldOrder { get; set; }
        public int IsVerificationfield { get; set; }
        public int IsRequired { get; set; }
        public string FieldValue { get; set; }
        public string DisplayName { get; set; }
        public string DDLValues { get; set; }
        public string RFU1 { get; set; }
        public string RFU2 { get; set; }
        public string RFU3 { get; set; }
        public string APIFieldName { get; set; }
    }
    #endregion
    #endregion

    #region 2.3.4 CASH COLLECTION VERIFICATION REQ/RES
    #region CASH COLLECTION VERIFICATION REQ

    public class CashCollectionVerificationRequest
    {
        //public int Version { get; set; }
        //public int SERVICEID { get; set; }
        //public string ClientUniqueID { get; set; }
        //public string RequestDateTime { get; set; }
        //public string ClientInitiatorId { get; set; }
        public string ClientID { get; set; }
        public string RFU1 { get; set; }
        public string RFU2 { get; set; }
        public string RFU3 { get; set; }
        public CashCollectionVerificationDataReq RequestData { get; set; }
    }
    public class CashCollectionVerificationReq
    {
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public string ClientUniqueID { get; set; }
        public string RequestDateTime { get; set; }
        public string ClientInitiatorId { get; set; }
        public string ClientID { get; set; }
        public string RFU1 { get; set; }
        public string RFU2 { get; set; }
        public string RFU3 { get; set; }
        public CashCollectionVerificationDataReq RequestData { get; set; }
    }
    public class CashCollectionVerificationDataReq
    {
        //public string Field1 { get; set; }
        //public string Field2 { get; set; }
        //public string Field3 { get; set; }
        //public string Field4 { get; set; }
        //public string Field5 { get; set; }
        public string Field1 { get; set; }
        public string Field4 { get; set; }
        public string Field11 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field5 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field35 { get; set; }
        public string Field36 { get; set; }
    }
    #endregion

    #region CASH COLLECTION VERIFICATION RES
    public class CashCollectionVerificationRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public int ClientID { get; set; }
        public string ResponseDateTime { get; set; }
        public string RequestID { get; set; }
        public string ClientUniqueID { get; set; }
        public string ResponseData { get; set; }
        public CashColResponseDataRes cashColResponseData { get; set; }
        public string ReferenceID { get; set; }
    }
    public class CashColResponseDataRes
    {
        public CashColFieldDetailRes FieldDetail { get; set; }
        public List<CashColWLGridFieldDetailRes> WLGridFieldDetail { get; set; }
    }
    public class CashColFieldDetailRes
    {
        public string Field1 { get; set; }
        public string Field4 { get; set; }
        public string Field11 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field5 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field35 { get; set; }
        public string Field36 { get; set; }
    }
    public class CashColWLGridFieldDetailRes
    {
        public string Field1 { get; set; }
        public string Field4 { get; set; }
        public string Field11 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field5 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field35 { get; set; }
        public string Field36 { get; set; }
    }
    #endregion

    #endregion

    #region 2.3.5 CMS TRANSACTION REQ/RES

    #region FINAL CMS TRANSACTION REQ
    public class FinalCMSTransactionReq
    {
        public string CustomerNumber { get; set; }
        public long TransactionId { get; set; }
        public CMSTransactionRequest cmsTransactionRequest { get; set; }
    }
    #endregion

    #region  CMS TRANSACTION REQ
    public class CMSTransactionRequest
    {
        public string ClientID { get; set; }
        public CMSTxnRequestData RequestData { get; set; }
    }
    public class CMSTransactionReq
    {
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public string ClientUniqueID { get; set; }
        public string RequestDateTime { get; set; }
        public string ClientInitiatorId { get; set; }
        public string ClientID { get; set; }
        public CMSTxnRequestData RequestData { get; set; }
    }
    public class CMSTxnRequestData
    {
        public string ReferenceID { get; set; }
        public CMSTxnFieldDetails FieldDetails { get; set; }
        public CustomerAuthData CustomerAuth { get; set; }
        //public List<CMSTxnWLGridFieldDetail> WLGridFieldDetail { get; set; }
    }
    public class CMSTxnFieldDetails
    {
        public string Field1 { get; set; }
        public string Field4 { get; set; }
        public string Field11 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field5 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field35 { get; set; }
        public string Field36 { get; set; }
    }
    public class CMSTxnWLGridFieldDetail
    {
        public string Field11 { get; set; }
        public string Field25 { get; set; }
        public string Field6 { get; set; }
        public string Field27 { get; set; }
        public string Field8 { get; set; }
        public string Field12 { get; set; }
        public string Field28 { get; set; }
        public string Field18 { get; set; }
        public string Field13 { get; set; }
        public string Field35 { get; set; }
        public string Field29 { get; set; }
    }

    public class CustomerAuthData
    {
        public string ReferenceNo { get; set; }
        public string OTPPin { get; set; }
        public string CustomerMobileNo { get; set; }
    }
    #endregion

    #region  CMS TRANSACTION RES
    public class CMSTransactionRes
    {
        public string ResponseCode { get; set; }
        public string MessageString { get; set; }
        public int ClientID { get; set; }
        public string ResponseDateTime { get; set; }
        public string RequestID { get; set; }
        public string ClientUniqueID { get; set; }
        public string ReferenceID { get; set; }
        public string ResponseData { get; set; }
        public CMSTxnResponseDataRes cmsTxnResponseData { get; set; }
    }
    public class CMSTxnResponseDataRes
    {
        //public double Amount { get; set; }
        public string Amount { get; set; }
        public string FinoTransactionID { get; set; }
        public string TxnDate { get; set; }
        public string TxnTime { get; set; }
        //public int TxnStatus { get; set; }
        public string TxnStatus { get; set; }
    }
    #endregion
    #endregion

    #region 2.3.6 TRANSACTION ENQUIRY API REQ/RES
    #region TRANSACTION ENQUIRY REQ

    public class TxnEnquiryRequest
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        //public string RequestDateTime { get; set; }
        //public int Version { get; set; }
        //public int SERVICEID { get; set; }
        public int ClientID { get; set; }
    }
    public class TxnEnquiryReq
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public int ClientID { get; set; }
    }
    #endregion

    #region TRANSACTION ENQUIRY RES
    public class TxnEnquiryRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public int ClientID { get; set; }
        public string ResponseDateTime { get; set; }
        public string RequestID { get; set; }
        public string ClientUniqueID { get; set; }
        public string ResponseData { get; set; }
        public TxnEnquiryResponseDataRes txnEnquiryResponseData { get; set; }
        public object ReferenceID { get; set; }
    }
    public class TxnEnquiryResponseDataRes
    {
        public double Amount { get; set; }
        public string FinoTransactionID { get; set; }
        public string TxnDate { get; set; }
        public string TxnTime { get; set; }
        public int TxnStatus { get; set; }
    }
    #endregion
    #endregion

    #region 2.3.7 RESEND OTP REQ/RES
    #region RESEND OTP REQ

    public class ResendOTPRequest
    {
        //public string ClientUniqueID { get; set; }
        //public string ClientInitiatorId { get; set; }
        //public string RequestDateTime { get; set; }
        //public int Version { get; set; }
        public string ClientID { get; set; }
        //public int SERVICEID { get; set; }
        public ResendOTPReqDataReq RequestData { get; set; }
    }
    public class ResendOTPReq
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public string ClientID { get; set; }
        public int SERVICEID { get; set; }
        public ResendOTPReqDataReq RequestData { get; set; }
    }
    public class ResendOTPReqDataReq
    {
        public string OTPParam1 { get; set; }
        public string OTPParam2 { get; set; }
        public string OTPParam3 { get; set; }
        public string OTPParam4 { get; set; }
        public string OTPParam5 { get; set; }
        public string OTPParam6 { get; set; }
        public string OTPParam7 { get; set; }
        public string OTPParam8 { get; set; }
    }
    #endregion

    #region RESEND OTP RES
    public class ResendOTPRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public string ClientID { get; set; }
        public string ResponseDateTime { get; set; }
        public string RequestID { get; set; }
        public string ClientUniqueID { get; set; }
        public string ResponseData { get; set; }
        public ResendOTPResponseData resendOTPResponseData { get; set; }
        public string ReferenceID { get; set; }
    }
    public class ResendOTPResponseData
    {
        public string RefernceID { get; set; }
        public string RFU1 { get; set; }
        public string RFU2 { get; set; }
        public string RFU3 { get; set; }
    }

    #endregion
    #endregion

    #region 2.3.8 GET PRINT TEMPLATES REQ/RES
    #region GET PRINT TEMPLATE REQ

    public class GetPrintTemplateRequest
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public int ClientID { get; set; }
        public GetPrintRequestData RequestData { get; set; }
    }
    public class GetPrintTemplateReq
    {
        public string ClientUniqueID { get; set; }
        public string ClientInitiatorId { get; set; }
        public string RequestDateTime { get; set; }
        public int Version { get; set; }
        public int SERVICEID { get; set; }
        public int ClientID { get; set; }
        public GetPrintRequestData RequestData { get; set; }
    }
    public class GetPrintRequestData
    {
        public string ClientID { get; set; }
    }
    #endregion

    #region GET PRINT TEMPLATE RES
    public class GetPrintTemplateRes
    {
        public int ResponseCode { get; set; }
        public string MessageString { get; set; }
        public string RequestID { get; set; }
        public string ClientUniqueID { get; set; }
        public string ClientID { get; set; }
        public object ReferenceID { get; set; }
        public string ResponseData { get; set; }
        public List<GetPrintResponseDataRes> getPrintResponseData { get; set; }
    }
    public class GetPrintResponseDataRes
    {
        public int ClientID { get; set; }
        public string PrintTemplate { get; set; }
    }
    #endregion
    #endregion

    #region GET ALL FIELD SET DATA 
    public class GetAllFieldSetData
    {
        public string Field1 { get; set; }
        public string Field4 { get; set; }
        public string Field11 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field5 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field35 { get; set; }
        public string Field36 { get; set; }
    }
    #endregion

}
