
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.Entities
{
    public class AlbumEditModel : IEditModel
    {
        public int AlbumId;

        public string AlbumName;

        public PaginationModel<ImageReadModel> Pictures;
    }
}