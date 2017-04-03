using SuperCommunity.Models.PageModels;
using SuperCommunity.Service.Factoryes.shared;

namespace SuperCommunity.Service.Factoryes
{
    public class GalleryModelFactory : ModelFactory<GalleryModel>
    {
        private readonly int _pageNumber;

        private readonly int _tagId;

        private readonly string _userName;

        public GalleryModelFactory(int pageNumber, int tagId, string userName)
        {
            _pageNumber = pageNumber;

            _userName = userName;

            _tagId = tagId;
        }

        public override GalleryModel BuildModel()
        {
            var paginationModel = new ImagePaginationBuilder().BuildGalleryPaginationModel(_pageNumber, _userName, _tagId);

            var tagCloudModel = new TagCloudModelFactory().BuildModel();

            return new GalleryModel { PaginationModel = paginationModel, TagId = _tagId, TagCloud = tagCloudModel};
        }
    }
}