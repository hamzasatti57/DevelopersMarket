using System;

namespace FypProject.App_Start
{
    internal class TwilioRestClient
    {
        private string v1;
        private string v2;

        public TwilioRestClient(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public object SendMessage(string v, object destination, object body)
        {
            throw new NotImplementedException();
        }
    }
}