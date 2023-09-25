﻿using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public int ConsumerId { get; set; }
        public ConsumerViewModel? Consumer { get; set; }
        public int AdminId { get; set; }
        public AdminViewModel? Admin { get; set; }
        public string MsgOrPath { get; set; } = string.Empty;
        public MessageType Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
