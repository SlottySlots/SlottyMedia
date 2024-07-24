using Blazored.LocalStorage;

namespace SlottyMedia.Backend.Services;

public class LocalStorageService : Interfaces.ILocalStorageService
{
    private ILocalStorageService StorageService { get; }
    
    public LocalStorageService(ILocalStorageService storageService)
    {
        StorageService = storageService;
    }

    public async Task<string> GetItem(string key)
    {
        return await StorageService.GetItemAsync<string>(key);
    }

    public async Task SetItem(string key, string value)
    {
        await StorageService.SetItemAsync(key, value);
    }

    public async Task RemoveItem(string key)
    {
        if (await StorageService.ContainKeyAsync(key))
        {
            await  StorageService.RemoveItemAsync(key);
        }
    }

    public async Task Clear()
    {
        await StorageService.ClearAsync();
    } 
}