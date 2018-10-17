﻿using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class UpdatePaymentInstrument
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = "7020000000000137654";

            var requestObj = new Body3();

            var cardObj = new PaymentinstrumentsCard();

            cardObj.ExpirationMonth = "09";
            cardObj.ExpirationYear = "2022";
            cardObj.Type = PaymentinstrumentsCard.TypeEnum.Visa;
            requestObj.Card = cardObj;

            var billToObj = new PaymentinstrumentsBillTo();

            billToObj.FirstName = "John";
            billToObj.LastName = "Smith";
            billToObj.Company = "CyberSource";
            billToObj.Address1 = "12 Main Street";
            billToObj.Address2 = "20 My Street";
            billToObj.Locality = "San Francisco";
            billToObj.AdministrativeArea = "CA";
            billToObj.PostalCode = "90200";
            billToObj.Country = "US";
            billToObj.Email = "john.smith@example.com";
            billToObj.PhoneNumber = "555123456";
            requestObj.BillTo = billToObj;

            var instrumentIdentifierObj = new PaymentinstrumentsInstrumentIdentifier();

            var cardObj2 = new InstrumentidentifiersCard();

            cardObj2.Number = "4111111111111111";
            instrumentIdentifierObj.Card = cardObj2;

            requestObj.InstrumentIdentifier = instrumentIdentifierObj;

            try
            {
                var apiInstance = new PaymentInstrumentApi();
                var result = apiInstance.PaymentinstrumentsTokenIdPatch(profileId, tokenId, requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
