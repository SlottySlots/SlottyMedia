using System.Linq.Expressions;
using Supabase.Postgrest;
using Supabase.Postgrest.Models;
using Client = Supabase.Client;

namespace SlottyMedia.Database;

/// <summary>
///     This class represents the Database Actions. It is used to interact with the database.
/// </summary>
public class DatabaseActions : IDatabaseActions
{
    private readonly Client _supabaseClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DatabaseActions" /> class.
    /// </summary>
    /// <param name="supabaseClient">The Supabase client used to interact with the database.</param>
    public DatabaseActions(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    /// <summary>
    ///     Inserts an item into the database.
    /// </summary>
    /// <typeparam name="T">The model class of the item.</typeparam>
    /// <param name="item">The item to insert into the database.</param>
    /// <returns>Returns the inserted item.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the item could not be inserted into the database.</exception>
    public virtual async Task<T> Insert<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var insertedItem = await _supabaseClient.From<T>().Insert(item);
            if (insertedItem.Model is null)
                throw new Exception("The Item could not be inserted into the database.");
            return insertedItem.Model;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    ///     Updates an item in the database.
    /// </summary>
    /// <typeparam name="T">The model class of the item.</typeparam>
    /// <param name="item">The item to update in the database.</param>
    /// <returns>Returns the updated item.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the item could not be updated in the database.</exception>
    public virtual async Task<T> Update<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var updatedItem = await _supabaseClient.From<T>().Update(item);
            if (updatedItem.Model is null)
                throw new Exception("The Item could not be updated in the database.");
            return updatedItem.Model;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    ///     Deletes an item from the database.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="item">The item to delete.</param>
    /// <returns>Returns true if the operation was successful.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the item could not be deleted from the database.</exception>
    public virtual async Task<bool> Delete<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Delete(item);
            if (result.ResponseMessage is not null)
                result.ResponseMessage.EnsureSuccessStatusCode();
            else
                throw new Exception("The Item could not be deleted from the database.");

            return true;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    ///     Returns an entity from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>Returns the entity from the database.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the entity could not be found in the database.</exception>
    public virtual async Task<T> GetEntityByField<T>(string field, string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value).Single();
            if (result is null)
                throw new Exception($"The Entity with the Value {value} in the Field {field} in the " +
                                    $"Table {typeof(T)} could not be found in the database.");
            return result;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    ///     Returns an entity with a selector from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="selector">The selector expression to use.</param>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>Returns the entity from the database.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the items could not be retrieved from the database.</exception>
    public async Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value)
                .Select(selector).Single();
            if (result is null)
                throw new Exception("The Items could not be retrieved from the database.");
            return result;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    ///     Returns a list of entities with a selector from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="selector">The selector expression to use.</param>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <param name="limit">The maximum number of items to retrieve.</param>
    /// <param name="orderByFields">The fields to order by.</param>
    /// <returns>Returns a list of entities from the database.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the items could not be retrieved from the database.</exception>
    public async Task<List<T?>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value,
        int max = -1,
        int min = -1,
        params (string field, Constants.Ordering ordering, Constants.NullPosition nullPosition)[] orderByFields)
        where T : BaseModel, new()
    {
        try
        {
            var query = _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value).Select(selector);
            if (max is not -1) query = query.Range(min, max);

            if (orderByFields.Length > 0)
                foreach (var (orderByField, ordering, nullPosition) in orderByFields)
                    query = query.Order(orderByField, ordering, nullPosition);

            var result = await query.Get();
            if (result is null)
                throw new Exception("The Items could not be retrieved from the database.");
            return result.Models;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    ///     Returns a list of entities with a selector from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="selector">The selector expression to use.</param>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <param name="max">The maximum number of items to retrieve.</param>
    /// <param name="min">The minimum of a number</param>
    /// <param name="orderByFields">The fields to order by.</param>
    /// <returns>Returns a list of entities from the database.</returns>
    /// <exception cref="DatabaseExceptions">Thrown when the items could not be retrieved from the database.</exception>
    public async Task<List<T?>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector,
        List<(string, Constants.Operator, string)> search,
        int max = -1,
        int min = -1,
        params (string field, Constants.Ordering ordering, Constants.NullPosition nullPosition)[] orderByFields)
        where T : BaseModel, new()
    {
        try
        {
            var query = _supabaseClient.From<T>().Select(selector);
            if (max is not -1) query = query.Range(min, max);

            if (orderByFields.Length > 0)
                foreach (var (orderByField, ordering, nullPosition) in orderByFields)
                    query = query.Order(orderByField, ordering, nullPosition);
            if (search.Count > 0)
                foreach (var searchVariable in search)
                    query.Filter(searchVariable.Item1, searchVariable.Item2, searchVariable.Item3);

            var result = await query.Get();
            if (result is null)
                throw new Exception("The Items could not be retrieved from the database.");
            return result.Models;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    public async Task<List<T>> GetEntities<T>() where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Get();
            if (result is null) throw new Exception("The Items could not be retrieved from the database.");

            return result.Models;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }
}