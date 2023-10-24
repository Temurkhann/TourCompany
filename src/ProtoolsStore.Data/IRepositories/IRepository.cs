using System.Linq.Expressions;
using ProtoolsStore.Domain.Commons;

namespace ProtoolsStore.Data.IRepositories;

/// <summary>
/// IRepository is an interface for a generic repository pattern that provides basic CRUD operations for a given entity type.
/// It is designed to be flexible and extendable, allowing for the use of expressions, includes, and tracking options.
/// </summary>
/// <typeparam name="TSource">The entity type for which the repository is to be used.</typeparam>
public interface IRepository<TSource>
    where TSource : BaseEntity
{
    /// <summary>
    /// Retrieves all entities that match a given expression, with the option to include related entities and disable tracking.
    /// </summary>
    /// <param name="expression">A lambda expression to filter the entities.</param>
    /// <param name="includes">An array of strings representing the navigation properties to include in the query.</param>
    /// <param name="isTracking">A flag indicating whether to disable change tracking on the returned entities.</param>
    /// <returns>An IQueryable of the matching entities.</returns>
    IQueryable<TSource?> GetAll(Expression<Func<TSource, bool>>? expression = null!, string[]? includes = null!, bool isTracking = true);

    /// <summary>
    /// Asynchronously adds an entity to the repository and saves changes if specified.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="withSaveChanges">A flag indicating whether to save changes after the entity is added.</param>
    /// <param name="token">The cancellation token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous add operation. The result of the task is the added entity.</returns>
    ValueTask<TSource?> AddAsync(TSource? entity, bool withSaveChanges = false, CancellationToken token = default);

    /// <summary>
    /// Asynchronously retrieves the first entity that matches a given expression, with the option to include related entities.
    /// </summary>
    /// <param name="expression">A lambda expression to filter the entities.</param>
    /// <param name="includes">An array of strings representing the navigation properties to include in the query.</param>
    /// <param name="token">The cancellation token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous get operation. The result of the task is the first matching entity, or null if no match is found.</returns>
    ValueTask<TSource?> GetAsync(Expression<Func<TSource, bool>>? expression, string[]? includes = null!, CancellationToken token = default);

    /// <summary>
    /// Asynchronously updates an entity in the repository and saves changes if specified.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="withSaveChanges">A flag indicating whether to save changes after the entity is updated.</param>
    /// <param name="token">The cancellation token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous update operation. The result of the task is the updated entity.</returns>
    ValueTask<TSource?> UpdateAsync(TSource? entity, bool withSaveChanges = false, CancellationToken token = default);

    /// <summary>
    /// Asynchronously deletes an entity from the repository and saves changes if specified.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="withSaveChanges">A flag indicating whether to save changes after the entity is deleted.</param>
    /// <param name="token">The cancellation token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous delete operation. The result of the task is a boolean indicating whether the deletion was successful.</returns>
    ValueTask<bool> DeleteAsync(TSource? entity, bool withSaveChanges = false, CancellationToken token = default);

    /// <summary>
    /// Asynchronously saves any changes made to the repository to the underlying data source.
    /// </summary>
    /// <param name="token">The cancellation token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous save operation. The result of the task is the number of state entries written to the data source.</returns>
    ValueTask<int> SaveChangesAsync(CancellationToken token = default);
}