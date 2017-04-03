

using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.Entities
{
    public class LikeChangeModel : IReadModel
    {
        public int Likes;

        public int PictureId;
    }
}