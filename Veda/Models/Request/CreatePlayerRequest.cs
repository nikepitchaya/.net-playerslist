﻿using MyTask.Models.Request;
using System.Collections.Generic;
using System;

namespace PlayersList.Models.Request
{
    public class CreatePlayerRequest
    {
        public long user_game_category_id { get; set; }
        public int type_id { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        public string action { get; set; }
    }
}
