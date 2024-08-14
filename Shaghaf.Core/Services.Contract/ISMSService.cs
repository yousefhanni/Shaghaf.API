using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace Shaghaf.Core.Services.Contract
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body); // Method to send SMS using Twilio.
    }
}
