namespace SlottyMedia.Backend.Services.Interfaces;

public interface ICookieService
{
    ValueTask SetCookie(string name, string value, int days);
    ValueTask<string> GetCookie(string name);
    ValueTask<string> RemoveCookie(string name);
}