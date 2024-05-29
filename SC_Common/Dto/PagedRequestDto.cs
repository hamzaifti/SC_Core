namespace SC_Common.Dto
{
    public class PagedRequestDto
    {
        public int LastId { get; set; }
        public int PageSize { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string? FilterText { get; set; }
    }
}
