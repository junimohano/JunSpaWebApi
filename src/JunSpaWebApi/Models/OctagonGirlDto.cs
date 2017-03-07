using System.Collections.Generic;
using Newtonsoft.Json;

namespace JunSpaWebApi.Models
{
    public class OctagonGirlDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "twitter_feed_file_name")]
        public string TwitterFeedFileName { get; set; }

        [JsonProperty(PropertyName = "biography2")]
        public string Biography2 { get; set; }

        [JsonProperty(PropertyName = "biography1")]
        public string Biography1 { get; set; }

        [JsonProperty(PropertyName = "turn_ons")]
        public string TurnOns { get; set; }

        [JsonProperty(PropertyName = "height")]
        public string Height { get; set; }

        [JsonProperty(PropertyName = "country_residing")]
        public string CountryResiding { get; set; }

        [JsonProperty(PropertyName = "banner_background_image")]
        public string BannerBackgroundImage { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "favorite_foods")]
        public string FavoriteFoods { get; set; }

        [JsonProperty(PropertyName = "hobbies")]
        public string Hobbies { get; set; }

        [JsonProperty(PropertyName = "state_residing")]
        public string StateResiding { get; set; }

        [JsonProperty(PropertyName = "ways_to_pick_up")]
        public string WaysToPickUp { get; set; }

        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "large_profile_picture")]
        public string LargeProfilePicture { get; set; }

        [JsonProperty(PropertyName = "large_body_picture")]
        public string LargeBodyPicture { get; set; }

        [JsonProperty(PropertyName = "octagon_girl_media_id")]
        public string OctagonGirlMediaId { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public string Weight { get; set; }

        [JsonProperty(PropertyName = "city_residing")]
        public string CityResiding { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public string Quote { get; set; }

        [JsonProperty(PropertyName = "twitter_hashtag")]
        public string TwitterHashtag { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty(PropertyName = "biography_header")]
        public string BiographyHeader { get; set; }

        [JsonProperty(PropertyName = "websiteurl")]
        public string Websiteurl { get; set; }

        [JsonProperty(PropertyName = "medium_profile_picture")]
        public string MediumProfilePicture { get; set; }

        [JsonProperty(PropertyName = "career_goals")]
        public string CareerGoals { get; set; }

        [JsonProperty(PropertyName = "storeurl")]
        public string Storeurl { get; set; }

        [JsonProperty(PropertyName = "youtube_channelurl")]
        public string YoutubeChannelurl { get; set; }

        [JsonProperty(PropertyName = "favoritetvshows")]
        public string Favoritetvshows { get; set; }

        [JsonProperty(PropertyName = "gallery")]
        public IEnumerable<OctagonGirlGalleryDto> Gallery { get; set; }
    }
}
