

using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.Service.Factoryes.shared
{
    public class AlbumEditModelBuilder
    {
        public AlbumEditModel BuildModel(Album userAlbum, int pageNumber = 0)
        {
            return new AlbumEditModel
            {
                Pictures = new ImagePaginationBuilder().BuildPicturePaginationModel(userAlbum.AlbumId, pageNumber),
                AlbumName = userAlbum.AlbumName,
                AlbumId = userAlbum.AlbumId
            };
        }
    }
}