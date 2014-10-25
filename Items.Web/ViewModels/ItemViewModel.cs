using System.Runtime.Serialization;
using Items.Business.DAL.Entities;
using Utils.Web;

namespace Items.Web.ViewModels
{
    [DataContract]
    public class ItemViewModel : BaseValidatableViewModel<ItemViewModel, Item>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}