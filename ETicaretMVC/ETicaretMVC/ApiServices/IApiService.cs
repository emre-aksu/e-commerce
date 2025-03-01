using ETicaretMVC.Areas.AdminPanel.APITypes;

namespace ETicaretMVC.ApiServices
{
    //Bunu uygulayacak olan sınıflar belirtilen wep api ile haberleşmeyi sağlayacak
    public interface IApiService
    {
        Task<ResponseFromAPI<T>> GetData<T>(string endPoint, string token = null);
        Task<bool> PostData(string endPoint, string jsonData, string token = null);
        Task<bool> PutData(string endPoint, string jsonData, string token = null);
        Task<bool> DeleteData(string endPoint, string token = null);
    }
}
