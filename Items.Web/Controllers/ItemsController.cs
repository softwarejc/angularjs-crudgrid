using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Items.Business.DAL.Entities;
using Items.Business.Services;
using Items.Web.ViewModels;
using Utils.Web;

namespace Items.Web.Controllers
{
    public class ItemsController : ApiController, ICrudService<ItemViewModel>
    {
        private readonly IItemsService _itemsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsController"/> class.
        /// </summary>
        public ItemsController(IItemsService itemsService)
        {
            // Injected service
            _itemsService = itemsService;
        }

        // Create 
        [ValidateModel]
        public HttpResponseMessage Post(ItemViewModel itemVm)
        {
            Item item = itemVm.MapToEntity();
            var addedItem = _itemsService.Add(item);
            return Request.CreateResponse(HttpStatusCode.Created, addedItem);
        }

        // Read all 
        public HttpResponseMessage Get()
        {
            var allItems = _itemsService.GetAll().Select(ItemViewModel.MapFromEntity);
            return Request.CreateResponse(HttpStatusCode.OK, allItems);
        }

        // Read by id
        public HttpResponseMessage Get(int id)
        {
            var item = _itemsService.Get(id);
            if (item == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ItemViewModel.MapFromEntity(item));
        }

        // Update
        [ValidateModel]
        public HttpResponseMessage Put([FromBody]ItemViewModel updatedItemVm)
        {
            // Item must exists
            if (updatedItemVm.Id == 0 || !_itemsService.Any(updatedItemVm.Id))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ServerConstants.UpdateError);
            }

            Item item = updatedItemVm.MapToEntity();

            if (!_itemsService.Update(item))
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, ServerConstants.UpdateError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // Delete
        public HttpResponseMessage Delete(int id)
        {
            var item = _itemsService.Get(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ServerConstants.DeleteError);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _itemsService.Remove(id));
        }
    }
}
