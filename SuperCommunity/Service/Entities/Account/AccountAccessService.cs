using System;
using SuperCommunity.Service.IO;

namespace SuperCommunity.Service.Entities.Account
{
    public class AccountAccessService
    {
        private readonly ParamReader _paramReader = new ParamReader(AppDomain.CurrentDomain.BaseDirectory + "Service\\idFile.txt");

        public bool CheckId(string urlId)
        {
            if (urlId.Equals(_paramReader.ReadParam()))
            {
                return true;
            }
            return false;
        }
    }
}