﻿using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Chats.Queries
{
    public class GetChatQuery : IQuery<ChatViewModel>
    {
        public GetChatQuery(int Id ) 
        {
            ChatId = Id;
        }
        [Required]
        public int ChatId { get; set; }
    }
}
