namespace LoginSystemApi.ViewModels
{
    public class ResultViewModel<T>
    {
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }
        public ResultViewModel(T data)
        {
            Data= data;
        }
        public ResultViewModel(List<string> errors)
        {
            Errors= errors;
        }
        public ResultViewModel(string error)
        {
            Errors.Add(error);
        }

    }
}
