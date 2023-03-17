using Microsoft.VisualBasic;
using System;

namespace PlayersList.Models.Response
{
    public class PlayerResponse
    {
        public long id { get; set; }
        public long user_game_category_id { get; set; }
        public int type_id { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        public string action { get; set; }
        public DateTime updated_at { get; set; }

    }

}
