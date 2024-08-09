using Supabase;

namespace SlottyMedia.Database;

/// <summary>
///     This Class is used to Initialize the Supabase Client
/// </summary>
public static class InitializeSupabaseClient
{
    /// <summary>
    ///     This class uses the Environment Variables to Initialize the Supabase Client
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception">When the Supabase EnvironemtVaraibles are not set, an Exception will be thrown</exception>
    public static Client GetSupabaseClient()
    {
        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
        if (url is null || key is null) throw new Exception("Supabase settings not found");

        var client = new Client(url, key, new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        });


        return client;
    }
}