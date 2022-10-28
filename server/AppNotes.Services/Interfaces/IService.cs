using AppNotes.Models.Entities;
using AppNotes.Models.Query;
using AppNotes.Models.Validation;

namespace AppNotes.Services;
public interface IService<T> where T : Entity
{
    Task<QueryResult<T>> Query(QueryParams queryParams);
    Task<T> GetById(int id);
    Task<T> GetByUrl(string url);
    Task<bool> ValidateName(T entity);
    Task<ValidationResult> Validate(T entity);
    Task<T> Save(T entity);
    Task<int> Remove(T entity);
}