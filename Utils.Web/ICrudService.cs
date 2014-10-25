using System.Net.Http;
using System.Web.Http;

namespace Utils.Web
{
    public interface ICrudService<in T>
    {
        // CREATE
        HttpResponseMessage Post(T item);
        // READ ALL
        HttpResponseMessage Get();
        // READ By ID
        HttpResponseMessage Get(int id);
        // UPDATE
        HttpResponseMessage Put([FromBody] T updatedItem);
        // DELETE
        HttpResponseMessage Delete(int id);
    }
}