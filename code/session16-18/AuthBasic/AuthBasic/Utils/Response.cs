namespace AuthBasic.Utils {
    public class Response<T> {
        public bool Success { get; set; } = true;
        public string Message = string.Empty;
        public T Data { get; set; }
        public int Count { get; set; } = 0;
    }
}
