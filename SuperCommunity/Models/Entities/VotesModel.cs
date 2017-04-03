

using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.Entities
{
    public class VotesModel : IEditModel
    {
        public int Likes;

        public int Dislikes;

        public bool IsOwner;
    }
}