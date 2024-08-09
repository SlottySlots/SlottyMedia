using SlottyMedia.Database;
using Supabase;

namespace SlottyMedia.Tests;

/// <summary>
///     Test class for the InitializeSupabaseClient class.
/// </summary>
public class InitializeSupabaseClientTest
{
    private Client _supabaseClient;

    /// <summary>
    ///     Setup method to initialize the Supabase client before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _supabaseClient = InitializeSupabaseClient.GetSupabaseClient();
    }

    /// <summary>
    ///     Test method to verify that the Supabase client is not null.
    /// </summary>
    [Test]
    public void TestGetSupabaseClient()
    {
        Assert.That(_supabaseClient, Is.Not.Null, "Supabase client should not be null");
    }
}