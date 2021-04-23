using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.EmailModels
{
	public class EmailMessageModel
    {
        public EmailAddressModel SenderAddress { get; set; }
        public EmailAddressModel ReceiverAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
