using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Response
{
    public class GameCategoryResponse
    {
        public int id { get; set; }
    
        public string name { get; set; }

        public string about { get; set; }

        public string information { get; set; }

        public string system_requirement { get; set; }

        public string url_picture { get; set; }

        public string url_video { get; set; }

    }
}
