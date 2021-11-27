namespace Application.Core
{
    // T could be swapped with PostLabeling, Post, etc
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        
        public T Value { get; set; }
        
        public string Error { get; set; }
        
        // if value is null, return NotFound(). If value is not null, return PostLabeling
        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Error = error };
    }
}