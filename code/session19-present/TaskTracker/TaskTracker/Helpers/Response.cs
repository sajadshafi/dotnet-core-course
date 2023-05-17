namespace TaskTracker.Helpers {
    public class Response<T> {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public int Count { get; set; } = 0;
        public T Data { get; set; }
    }
}
