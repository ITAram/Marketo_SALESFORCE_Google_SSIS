using System;
using Mktows;
using System.Security.Cryptography;



/*
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
*/
public class MarketoClient {
	/**
		Change this endpoint if required, as per your WSDL
	*/
	public static String API_ENDPOINT = "https://843-ZUS-102.mktoapi.com/soap/mktows/2_3";

	// DATE format for calculating request timestamp
	//private static  String W3C_DATE_TIME_FORMAT =  "yyyy-MM-dd\'T\'HH:mm:ss-05:00";

	private String mktowsUserId, encKey;

	public MarketoClient(String userId, String encKey) {
		this.mktowsUserId = userId;
		this.encKey = encKey;
	}

	/**
		Use this port for making other web service calls.
		This port is ready and authenticated
	*/
    public MktowsPortClient prepareSoapPort()
    {

        Mktows.getLeadRequest LeadRequest = new Mktows.getLeadRequest();
        LeadRequest.AuthenticationHeader = createAuthenticationHeader();

        MktowsPortClient port = new MktowsPortClient(API_ENDPOINT);
        
         
		return port;
	}

	public AuthenticationHeaderInfo createAuthenticationHeader() {
		AuthenticationHeaderInfo authHeader = null;
		String requestTimestamp = calcRequestTimestamp();
		String requestSignature = calcRequestSignature(requestTimestamp, mktowsUserId, encKey);
		authHeader = new AuthenticationHeaderInfo();
 		authHeader.mktowsUserId = mktowsUserId;
		authHeader.requestSignature = requestSignature;
		authHeader.requestTimestamp = requestTimestamp;
		return authHeader;
	}

	String calcRequestTimestamp() {
		DateTime dt = System.DateTime.Now;
        var utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(dt);
        String w3cValue = dt.ToString("yyyy-MM-ddTHH:mm:ss");
        w3cValue += utcOffset == TimeSpan.Zero ? "Z" : 
            String.Format("{0}{1:00}:{2:00}", (utcOffset > TimeSpan.Zero ? "+" : "-")
        , utcOffset.Hours, utcOffset.Minutes);
		return w3cValue;
	}


	String calcRequestSignature(String requestTimestamp, String mktowsUserId, String encryptionKey){
		String encryptString = requestTimestamp + mktowsUserId;
		return calculateHMAC(encryptString, encryptionKey);
	}			

	String calculateHMAC(String message, String key) {
        if (key == null) return "";
        if (message == null) return "";


        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        byte[] keyByte = encoding.GetBytes(key);
        HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);

        byte[] messageBytes = encoding.GetBytes(message);
        byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
       
        string hmac = "";

        for (int i = 0; i < hashmessage.Length; i++)
        {
            hmac += hashmessage[i].ToString("X2"); // hex format
        }
        return hmac;		
	}	
}