using ConsumerApi.Models;

namespace ConsumerApi.Service
{
    public class CrudService
    {
       
            private readonly HttpClient _httpClient;

            public CrudService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<List<Product>> GetAllProductsAsync()
            {
                return await _httpClient.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");
            }

            public async Task<Product> GetProductByIdAsync(int id)
            {
                return await _httpClient.GetFromJsonAsync<Product>($"https://fakestoreapi.com/products/{id}");
            }

            public async Task<Product> CreateProductAsync(Product newProduct)
            {
                var response = await _httpClient.PostAsJsonAsync("https://fakestoreapi.com/products", newProduct);
                return await response.Content.ReadFromJsonAsync<Product>();
            }

            public async Task UpdateProductAsync(int id, Product updatedProduct)
            {
                await _httpClient.PutAsJsonAsync($"https://fakestoreapi.com/products/{id}", updatedProduct);
            }

            public async Task DeleteProductAsync(int id)
            {
                await _httpClient.DeleteAsync($"https://fakestoreapi.com/products/{id}");
            }
        }
    }


