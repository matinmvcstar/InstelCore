using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace GmailCore
{
    class EmailModel
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public IFromFile Attachment { get; set; }

        public string FromEmail { get; set; }

        public string FromPassword { get; set; }
    }
}
