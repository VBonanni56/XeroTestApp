using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Example.Applications.Partner;
using Xero.Api.Serialization;

namespace XeroTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new ApiUser { Name = "The users name" };
            var tokenStore = new SqliteTokenStore();

            //var api = new Core(tokenStore, user)
            //{
            //    UserAgent = "Itemize.com"
            //};

            var partner_app_api = new XeroCoreApi("https://api-partner.network.xero.com", new PartnerAuthenticator("https://api-partner.network.xero.com",
                  "https://api.xero.com", "oob", new MemoryTokenStore(),
                  @"C:\Development\TestProjects\Xero-Net-master\Licenses\win32gen_public_privatekey.pfx",
                  @"C:\Development\TestProjects\Xero-Net-master\Licenses\entrust-private-nopass.p12", 
                  "pwEntrustt",
                  "pwLocal"),
                   new Consumer("conkey", "seckey"), user,
                   new DefaultMapper(), new DefaultMapper());

            var partner_contacts = partner_app_api.Contacts.Find().ToList();
        }
    }
}
