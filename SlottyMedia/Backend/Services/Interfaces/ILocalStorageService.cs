namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
/// This interface is used to abstract the Blazored.LocalStorage.
/// </summary>
public interface ILocalStorageService
{
    /// <summary>
    /// This method is used to get an item from the local storage.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Task<string> GetItem(string key);
    /// <summary>
    /// THis method is used to save an item in the local storage.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public Task SetItem(string key, string value);
    /// <summary>
    /// This method is used to remove an item from the local storage.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Task RemoveItem(string key);
    /// <summary>
    /// This method is used to clear the local storage.
    /// </summary>
    /// <returns></returns>
    public Task Clear();
    
}