using Newtonsoft.Json;

namespace JunSpaWebApi.DataModels
{
    public class OctagonGirlGallery
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "thumbnail_path")]
        public string ThumbnailPath { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "media_id")]
        public string MediaId { get; set; }

        [JsonProperty(PropertyName = "gallery_order")]
        public string GalleryOrder { get; set; }

    }
}
