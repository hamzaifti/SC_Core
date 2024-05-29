namespace SC_Common.Dto
{
    public class PagedResponseDto<T>
    {
        public List<T> Data {  get; set; }   
        public int TotalRows { get; set; }
    }
}
