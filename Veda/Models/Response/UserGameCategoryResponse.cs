using System;
using System.Collections.Generic;

namespace PlayersList.Models.Response
{
    public class UserGameCategoryResponse
    {
        public long id { get; set; }

        public GameCategoryResponse gameCategory { get; set; }

        public DateTime updated_at { get; set; }
    }
}
