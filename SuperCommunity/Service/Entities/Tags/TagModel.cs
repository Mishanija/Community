

using SuperCommunity.Models.Interfaces;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.Service.Entities.Tags
{
    public class TagModel : IReadModel
    {
        public Tag Tag;

        public int PicturesCount;
    }
}