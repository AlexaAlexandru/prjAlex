using System;
namespace SchedulePlatform.Service.Models
{
    public class ApiGenericsResult<TEntity> where TEntity : class
    {
        public bool Succeded { get; set; }
        public TEntity Result { get; }
        public IEnumerable<string> Errors { get; }

        private ApiGenericsResult(bool succeeded, TEntity result, IEnumerable<string> errors)
        {
            Succeded = succeeded;
            Result = result;
            Errors = errors;
        }

        public static ApiGenericsResult<TEntity> Success(TEntity result)
        {
            return new ApiGenericsResult<TEntity>(true, result, new List<string>());
        }
        public static ApiGenericsResult<TEntity> Failure(IEnumerable<string> errors)
        {
            return new ApiGenericsResult<TEntity>(false, default, errors);
        }
    }
}

