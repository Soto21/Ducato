using System.Text.Json;
using Microsoft.JSInterop;

public class LocalStorageService
{
    private readonly IJSRuntime _js;

    public LocalStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SaveAsync<T>(string key, T value)
    {
        await _js.InvokeVoidAsync("localStorageHelper.saveState", key, value);
    }

    public async Task<T?> LoadAsync<T>(string key)
    {
        return await _js.InvokeAsync<T>("localStorageHelper.loadState", key);
    }
}
