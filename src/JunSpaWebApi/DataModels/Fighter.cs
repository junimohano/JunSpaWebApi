using System.Collections.Generic;
using Newtonsoft.Json;

namespace JunSpaWebApi.DataModels
{
    public class Fighter
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName = "wins")]
        public int? Wins { get; set; }

        [JsonProperty(PropertyName = "statid")]
        public int? Statid { get; set; }

        [JsonProperty(PropertyName = "losses")]
        public int? Losses { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "weight_class")]
        public string WeightClass { get; set; }

        [JsonProperty(PropertyName = "title_holder")]
        public bool TitleHolder { get; set; }

        [JsonProperty(PropertyName = "draws")]
        public int? Draws { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "fighter_status")]
        public string FighterStatus { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public string Rank { get; set; }

        [JsonProperty(PropertyName = "pound_for_pound_rank")]
        public string PoundForPoundRank { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty(PropertyName = "belt_thumbnail")]
        public string BeltThumbnail { get; set; }

        [JsonProperty(PropertyName = "left_full_body_image")]
        public string LeftFullBodyImage { get; set; }

        [JsonProperty(PropertyName = "right_full_body_image")]
        public string RightFullBodyImage { get; set; }

        [JsonProperty(PropertyName = "profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

    }
}
