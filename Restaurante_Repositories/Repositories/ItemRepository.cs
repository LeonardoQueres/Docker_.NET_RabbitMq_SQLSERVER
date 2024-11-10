#nullable disable warnings
using Microsoft.Extensions.Logging;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Entities;
using Restaurante_Borders.Repositories;
using Restaurante_Borders.Shared;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Restaurante_Repositories.Repositories
{
    public class ItemRepository(HttpClient httpClient, ILogger<ItemRepository> logger, ApplicationConfig applicationConfig) : IItemRepository
    {
        private readonly ILogger<ItemRepository> _logger = logger;
        private readonly HttpClient _httpClient = httpClient;
        public async Task<Item> Create(CreateItemRequest item)
        {
            var conteudoHttp = new StringContent
                (
                    JsonSerializer.Serialize(item),
                    Encoding.UTF8,
                    "application/json"
                );
            var result = await _httpClient.PostAsync(applicationConfig.ItemService.BaseUrl, conteudoHttp);
            return await result.Content.ReadFromJsonAsync<Item>();
        }

        public Task<Item> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Item item)
        {
            throw new NotImplementedException();
        }

        //public async Task<Item> GetById(Guid id)
        //=> await HttpClientExtensions.Get<Item>(httpClient, $"/GetById?id={string.Join("&id=", id)}", DefaultErrorMessage(nameof(GetById)))!;

        //public async Task Update(Item item)
        //=> await HttpClientExtensions.Put<Item>(httpClient, "", item, DefaultErrorMessage(nameof(Update)))!;
    }
}