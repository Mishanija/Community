

using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.PageModels
{

    public class GalleryModel : IPageModel
    {
        public PaginationModel<ImageLikesModel> PaginationModel;

        public int TagId;

        public TagCloudModel TagCloud;
    }
}